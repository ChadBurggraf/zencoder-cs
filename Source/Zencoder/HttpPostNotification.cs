//-----------------------------------------------------------------------
// <copyright file="HttpPostNotification.cs" company="Tasty Codes">
//     Copyright (c) 2010 Chad Burggraf.
// </copyright>
//-----------------------------------------------------------------------

namespace Zencoder
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// Represents an HTTP-posted job output notification.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class HttpPostNotification
    {
        /// <summary>
        /// Gets or sets the job the notification relates to.
        /// </summary>
        [JsonProperty("job")]
        public HttpPostNotificationJob Job { get; set; }

        /// <summary>
        /// Gets or sets the job's output the notification relates to.
        /// </summary>
        [JsonProperty("output")]
        public HttpPostNotificationOutput Output { get; set; }
    }
}
