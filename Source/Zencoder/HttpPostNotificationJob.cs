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
    /// Represents a job in an <see cref="HttpPostOutputNotification"/>.
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

        /// <summary>
        /// Gets or sets the time created.
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the pass through value.
        /// </summary>
        [JsonProperty("pass_through")]
        public string PassThrough { get; set; }

        /// <summary>
        /// Gets or sets the time updated.
        /// </summary>
        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }
    }
}
