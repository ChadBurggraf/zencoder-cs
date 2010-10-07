//-----------------------------------------------------------------------
// <copyright file="Notification.cs" company="Tasty Codes">
//     Copyright (c) 2010 Chad Burggraf.
// </copyright>
//-----------------------------------------------------------------------

namespace Zencoder
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// Base class for <see cref="Output"/> notifications.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public abstract class Notification
    {
        /// <summary>
        /// Creates a new email <see cref="Notification"/> for the specified email address.
        /// </summary>
        /// <param name="email">The email address to notify.</param>
        /// <returns>The created <see cref="Notification"/>.</returns>
        public static Notification ForEmail(string email)
        {
            return new EmailNotification() { Email = email };
        }

        /// <summary>
        /// Creates a new HTTP <see cref="Notification"/> for posting to the given URL.
        /// </summary>
        /// <param name="url">The URL to post to.</param>
        /// <returns>The created <see cref="Notification"/>.</returns>
        public static Notification ForHttp(string url)
        {
            return new HttpNotification() { Url = url };
        }

        /// <summary>
        /// Creates a new HTTP <see cref="Notification"/> for posting to the given URL.
        /// </summary>
        /// <param name="url">The URL to post to.</param>
        /// <returns>The created <see cref="Notification"/>.</returns>
        public static Notification ForHttp(Uri url)
        {
            return new HttpNotification().WithUrl(url);
        }
    }
}
