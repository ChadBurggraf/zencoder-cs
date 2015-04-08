//-----------------------------------------------------------------------
// <copyright file="MediaFile.cs" company="Tasty Codes">
//     Copyright (c) 2010 Chad Burggraf.
// </copyright>
//-----------------------------------------------------------------------

namespace Zencoder
{
    using System;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Represents a single input or output media file in a <see cref="Job"/>.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public abstract class MediaFile
    {
        /// <summary>
        /// Gets or sets the file's audio bitrate (in Kbps).
        /// </summary>
        [JsonProperty("audio_bitrate_in_kbps")]
        public int? AudioBitrateInKbps { get; set; }

        /// <summary>
        /// Gets or sets the file's audio sample rate.
        /// </summary>
        [JsonProperty("audio_sample_rate")]
        public int? AudioSampleRate { get; set; }

        /// <summary>
        /// Gets or sets the number of audio channels in the file.
        /// </summary>
        [JsonProperty("channels")]
        public int? Channels { get; set; }

        /// <summary>
        /// Gets or sets the date the file was created.
        /// </summary>
        [JsonProperty("created_at")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the file's duration (in ms).
        /// </summary>
        [JsonProperty("duration_in_ms")]
        public long? DurationInMiliseconds { get; set; }

        /// <summary>
        /// Gets or sets the file's error class.
        /// </summary>
        [JsonProperty("error_class")]
        public string ErrorClass { get; set; }

        /// <summary>
        /// Gets or sets the file's error message.
        /// </summary>
        [JsonProperty("error_message")]
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Gets or sets the file's size in bytes.
        /// </summary>
        [JsonProperty("file_size_bytes")]
        public long? FileSizeBytes { get; set; }

        /// <summary>
        /// Gets or sets the date the file was finished.
        /// </summary>
        [JsonProperty("finished_at")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime? FinishedAt { get; set; }

        /// <summary>
        /// Gets or sets the file's frame rate.
        /// </summary>
        [JsonProperty("frame_rate")]
        public float? FrameRate { get; set; }

        /// <summary>
        /// Gets or sets the file's height.
        /// </summary>
        [JsonProperty("height")]
        public int? Height { get; set; }

        /// <summary>
        /// Gets or sets the file's ID.
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the file's total bitrate (in Kbps).
        /// </summary>
        [JsonProperty("total_bitrate_in_kbps")]
        public int? TotalBitrateInKbps { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the file is in test mode.
        /// </summary>
        [JsonProperty("test")]
        [JsonConverter(typeof(BooleanConverter))]
        public bool Test { get; set; }

        /// <summary>
        /// Gets or sets the file's URL.
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the date the file was last updated.
        /// </summary>
        [JsonProperty("updated_at")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// Gets or sets the file's video bitrate (in Kbps).
        /// </summary>
        [JsonProperty("video_bitrate_in_kbps")]
        public int? VideoBitrateInKbps { get; set; }

        /// <summary>
        /// Gets or sets the file's width.
        /// </summary>
        [JsonProperty("width")]
        public int? Width { get; set; }
    }
}
