//-----------------------------------------------------------------------
// <copyright file="InputMediaFile.cs" company="Tasty Codes">
//     Copyright (c) 2010 Chad Burggraf.
// </copyright>
//-----------------------------------------------------------------------

namespace Zencoder
{
    using System;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Represents a single input media file in a <see cref="Job"/>.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class InputMediaFile : MediaFile
    {
        /// <summary>
        /// Gets or sets the file's audio codec.
        /// </summary>
        [JsonProperty("audio_codec")]
        public string AudioCodec { get; set; }

        /// <summary>
        /// Gets or sets the file's format.
        /// </summary>
        [JsonProperty("format")]
        public string Format { get; set; }

        /// <summary>
        /// Gets or sets the file's video codec.
        /// </summary>
        [JsonProperty("video_codec")]
        public string VideoCodec { get; set; }

        /// <summary>
        /// Gets or sets the file's state with respect to its parent job.
        /// </summary>
        [JsonProperty("state")]
        public InputState State { get; set; }
    }
}
