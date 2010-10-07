//-----------------------------------------------------------------------
// <copyright file="NotificationHandler.cs" company="Tasty Codes">
//     Copyright (c) 2010 Chad Burggraf.
// </copyright>
//-----------------------------------------------------------------------

namespace Zencoder
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;
    using System.Web;
    using System.Web.SessionState;
    using Newtonsoft.Json;

    /// <summary>
    /// Implements <see cref="IHttpHandler"/> for receiving Zencoder notifications.
    /// </summary>
    public class NotificationHandler : IHttpHandler, IRequiresSessionState
    {
        private static readonly object locker = new object();
        private static IList<INotificationReceiver> receivers;

        /// <summary>
        /// Delegate for calling an <see cref="INotificationReceiver"/>'s 
        /// <see cref="INotificationReceiver.OnReceive(HttpPostNotification)"/> method.
        /// </summary>
        /// <param name="notification">The notification object to send.</param>
        private delegate void AsyncNotify(HttpPostNotification notification);

        /// <summary>
        /// Gets a list of current notification receivers.
        /// This list is intialized on first access from the configuration.
        /// </summary>
        public static IList<INotificationReceiver> Receivers
        {
            get
            {
                lock (locker)
                {
                    if (receivers == null)
                    {
                        receivers = new List<INotificationReceiver>();

                        foreach (string name in ZencoderSettings.Section.Notifications.AllKeys)
                        {
                            receivers.Add(CreateReceiver(ZencoderSettings.Section.Notifications[name].Value));    
                        }
                    }

                    return receivers;
                }
            }
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="IHttpHandler"/> is reusable.
        /// </summary>
        public bool IsReusable
        {
            get { return false; }
        }

        /// <summary>
        /// Creates a <see cref="INotificationReceiver"/> from the given type name.
        /// </summary>
        /// <param name="typeName">The name of the type to create the receiver from.</param>
        /// <returns>The created receiver.</returns>
        public static INotificationReceiver CreateReceiver(string typeName)
        {
            return (INotificationReceiver)Activator.CreateInstance(Type.GetType(typeName));
        }

        /// <summary>
        /// Processes the request for the given context.
        /// </summary>
        /// <param name="context">The request context to process.</param>
        public static void ProcessRequest(HttpContextBase context)
        {
            if ("POST".Equals(context.Request.HttpMethod, StringComparison.OrdinalIgnoreCase) &&
                "application/json".Equals(context.Request.ContentType, StringComparison.OrdinalIgnoreCase) &&
                context.Request.InputStream != null &&
                context.Request.InputStream.Length > 0)
            {
                HttpPostNotification notification;

                using (StreamReader sr = new StreamReader(context.Request.InputStream))
                {
                    using (JsonReader jr = new JsonTextReader(sr))
                    {
                        notification = new JsonSerializer().Deserialize<HttpPostNotification>(jr);
                    }
                }

                // We don't want changes to this collection while we're notifying.
                lock (Receivers)
                {
                    foreach (INotificationReceiver receiver in Receivers)
                    {
                        // Send the notifications out of band.
                        new AsyncNotify(receiver.OnReceive).BeginInvoke(notification, null, null);
                    }
                }
            }
        }

        /// <summary>
        /// Processes the request for the given context.
        /// </summary>
        /// <param name="context">The request context to process.</param>
        public void ProcessRequest(HttpContext context)
        {
            ProcessRequest(new HttpContextWrapper(context));
        }
    }
}
