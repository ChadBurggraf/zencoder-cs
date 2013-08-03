//-----------------------------------------------------------------------
// <copyright file="HttpPostNotificationOutput.cs" company="Tasty Codes">
//     Copyright (c) 2010 Chad Burggraf.
// </copyright>
//-----------------------------------------------------------------------

namespace Zencoder
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// Represents a job output in an <see cref="HttpPostNotification"/>.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class HttpPostNotificationOutput
    {
        /// <summary>
        /// Gets or sets the output's ID.
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the output's label, if applicable.
        /// </summary>
        [JsonProperty("label")]
        public string Label { get; set; }

        /// <summary>
        /// Gets or sets the output's state.
        /// </summary>
        [JsonProperty("state")]
        public OutputState State { get; set; }

        /// <summary>
        /// Gets or sets the output's URL.
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
