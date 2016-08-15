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
    /// Represents a job output in an <see cref="HttpPostOutputNotification"/>.
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

        /// <summary>
        /// Gets or sets the output's height.
        /// </summary>
        [JsonProperty("height")]
        public int? Height { get; set; }

        /// <summary>
        /// Gets or sets the output's audio sample rate.
        /// </summary>
        [JsonProperty("audio_sample_rate")]
        public int? AudioSampleRate { get; set; }

        /// <summary>
        /// Gets or sets the output's frame rate.
        /// </summary>
        [JsonProperty("frame_rate")]
        public float? FrameRate { get; set; }

        /// <summary>
        /// Gets or sets the output's channels.
        /// </summary>
        [JsonProperty("channels")]
        public string Channels { get; set; }

        /// <summary>
        /// Gets or sets the output's duration.
        /// </summary>
        [JsonProperty("duration_in_ms")]
        public long? DurationInMs { get; set; }

        /// <summary>
        /// Gets or sets the output's bit rate.
        /// </summary>
        [JsonProperty("video_bitrate_in_kbps")]
        public int? VideoBitrateInKbps { get; set; }

        /// <summary>
        /// Gets or sets the output's video codec
        /// </summary>
        [JsonProperty("video_codec")]
        public string VideoCodec { get; set; }

        /// <summary>
        /// Gets or sets the output's format
        /// </summary>
        [JsonProperty("format")]
        public string Format { get; set; }

        /// <summary>
        /// Gets or sets the output's audio codec
        /// </summary>
        [JsonProperty("audio_codec")]
        public string AudioCodec { get; set; }

        /// <summary>
        /// Gets or sets the output's file size in bytes
        /// </summary>
        [JsonProperty("file_size_in_bytes")]
        public string FileSizeInBytes { get; set; }

        /// <summary>
        /// Gets or sets the output's width
        /// </summary>
        [JsonProperty("width")]
        public int? Width { get; set; }

        /// <summary>
        /// Gets or sets the output's audio bitrate
        /// </summary>
        [JsonProperty("audio_bitrate_in_kbps")]
        public int? AudioBitrateInKbps { get; set; }

        /// <summary>
        /// Gets or sets the output's total bitrate
        /// </summary>
        [JsonProperty("total_bitrate_in_kbps")]
        public int? TotalBitrateInKbps { get; set; }

        /// <summary>
        /// Gets or sets the output's md5 checksum
        /// </summary>
        [JsonProperty("md5_checksum")]
        public string Md5Checksum { get; set; }

        /// <summary>
        /// Gets or sets the output's md5 checksum
        /// </summary>
        [JsonProperty("thumbnails")]
        public HttpPostNotificationThumbnail[] Thumbnails { get; set; }

        /// <summary>
        /// Gets or sets the output's type
        /// </summary>
        [JsonProperty("type")]
        public OutputType? OutputType { get; set; }
    }
}
