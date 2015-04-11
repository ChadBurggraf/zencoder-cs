//-----------------------------------------------------------------------
// <copyright file="HttpPostNotificationIutput.cs" company="Tasty Codes">
//     Copyright (c) 2013 Chad Burggraf, Adam Rogas
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
    public class HttpPostNotificationInput
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
        /// Gets or sets the input's height, if applicable.
        /// </summary>
        [JsonProperty("height")]
        public int Height { get; set; }

        /// <summary>
        /// Gets or sets the input's width, if applicable.
        /// </summary>
        [JsonProperty("width")]
        public int Width { get; set; }

        /// <summary>
        /// Gets or sets the input's file size, if applicable.
        /// </summary>
        [JsonProperty("file_size_in_bytes")]
        public long FileSize { get; set; }

        /// <summary>
        /// Gets or sets the input's duration, if applicable.
        /// </summary>
        [JsonProperty("duration_in_ms")]
        public long Duration { get; set; }

        /// <summary>
        /// Gets or sets the output's state.
        /// </summary>
        [JsonProperty("state")]
        public InputState State { get; set; }

        /// <summary>
        /// Gets or sets the output's URL.
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
