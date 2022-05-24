//-----------------------------------------------------------------------
// <copyright file="OutputMediaFile.cs" company="Tasty Codes">
//     Copyright (c) 2010 Chad Burggraf.
// </copyright>
//-----------------------------------------------------------------------

namespace Zencoder
{
    using System;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Represents a single output media file in a <see cref="Job"/>.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class OutputMediaFile : MediaFile
    {
        /// <summary>
        /// Gets or sets the file's audio codec.
        /// </summary>
        [JsonProperty("audio_codec")]
        public AudioCodec? AudioCodec { get; set; }

        /// <summary>
        /// Gets or sets the file's format.
        /// </summary>
        [JsonProperty("format")]
        public MediaFileFormat Format { get; set; }

        /// <summary>
        /// Gets or sets the file's state with respect to its parent job.
        /// </summary>
        [JsonProperty("state")]
        public OutputState State { get; set; }

        /// <summary>
        /// Gets or sets the file's video codec.
        /// </summary>
        [JsonProperty("video_codec")]
        public OutputVideoCodec? VideoCodec { get; set; }
    }
}
