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
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Newtonsoft.Json;

    /// <summary>
    /// Middleware for receiving Zencoder notifications.
    /// </summary>
    public partial class NotificationHandlerMiddleware
    {
        private static readonly object locker = new();
        private static IList<INotificationReceiver> receivers;

        public NotificationHandlerMiddleware(RequestDelegate next)
        {
            // This is an HTTP Handler, so no need to store next
        }


        /// <summary>
        /// Processes the request for the given context.
        /// </summary>
        /// <param name="context">The request context to process.</param>
        public static async Task Invoke(HttpContext context)
        {
            if ("POST".Equals(context.Request.Method, StringComparison.OrdinalIgnoreCase) &&
                "application/json".Equals(context.Request.Headers.ContentType, StringComparison.OrdinalIgnoreCase) &&
                context.Request.Body != null &&
                context.Request.Body.Length > 0)
            {
                HttpPostOutputNotification notification;

                using (StreamReader sr = new(context.Request.Body))
                {
                    using JsonReader jr = new JsonTextReader(sr);
                    notification = new JsonSerializer().Deserialize<HttpPostOutputNotification>(jr);
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
        /// Delegate for calling an <see cref="INotificationReceiver"/>'s 
        /// <see cref="INotificationReceiver.OnReceive(HttpPostOutputNotification)"/> method.
        /// </summary>
        /// <param name="notification">The notification object to send.</param>
        private delegate void AsyncNotify(HttpPostOutputNotification notification);

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
        /// Creates a <see cref="INotificationReceiver"/> from the given type name.
        /// </summary>
        /// <param name="typeName">The name of the type to create the receiver from.</param>
        /// <returns>The created receiver.</returns>
        public static INotificationReceiver CreateReceiver(string typeName)
        {
            return (INotificationReceiver)Activator.CreateInstance(Type.GetType(typeName));
        }
    }
}
