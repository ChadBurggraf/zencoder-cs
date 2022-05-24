//-----------------------------------------------------------------------
// <copyright file="EmailNotification.cs" company="Tasty Codes">
//     Copyright (c) 2010 Chad Burggraf.
// </copyright>
//-----------------------------------------------------------------------

namespace Zencoder
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// Represents an email notification specification for an <see cref="Output"/>.
    /// </summary>
    [JsonConverter(typeof(EmailNotificationJsonConverter))]
    public class EmailNotification : Notification
    {
        /// <summary>
        /// Gets or sets the email address to send output notifications to.
        /// </summary>
        public string Email { get; set; }
    }
}
