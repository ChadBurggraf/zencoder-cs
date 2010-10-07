//-----------------------------------------------------------------------
// <copyright file="INotificationReceiver.cs" company="Tasty Codes">
//     Copyright (c) 2010 Chad Burggraf.
// </copyright>
//-----------------------------------------------------------------------

namespace Zencoder
{
    using System;

    /// <summary>
    /// Interface definitions for notification receivers that are invoked by the <see cref="NotificationHandler"/>.
    /// </summary>
    public interface INotificationReceiver
    {
        /// <summary>
        /// Called when a notification is received.
        /// </summary>
        /// <param name="notification">The notification that was received.</param>
        void OnReceive(HttpPostNotification notification);
    }
}
