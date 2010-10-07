//-----------------------------------------------------------------------
// <copyright file="HttpPostNotificationJob.cs" company="Tasty Codes">
//     Copyright (c) 2010 Chad Burggraf.
// </copyright>
//-----------------------------------------------------------------------

namespace Zencoder
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// Represents a job in an <see cref="HttpPostNotification"/>.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class HttpPostNotificationJob
    {
        /// <summary>
        /// Gets or sets the job ID.
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the job state.
        /// </summary>
        [JsonProperty("state")]
        public JobState State { get; set; }
    }
}
