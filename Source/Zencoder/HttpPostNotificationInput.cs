using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zencoder
{
    using System;
    using Newtonsoft.Json;
    /// <summary>
    /// Implements the notification input type
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class HttpPostNotificationInput
    {
        /// <summary>
        /// Gets or sets the input height.
        /// </summary>
        [JsonProperty("height")]
        public int? Height { get; set; }

        /// <summary>
        /// Gets or sets the input audio sample rate.
        /// </summary>
        [JsonProperty("audio_sample_rate")]
        public int? AudioSampleRate { get; set; }

        /// <summary>
        /// Gets or sets the input frame rate.
        /// </summary>
        [JsonProperty("frame_rate")]
        public float? FrameRate { get; set; }

        /// <summary>
        /// Gets or sets the input channels.
        /// </summary>
        [JsonProperty("channels")]
        public string Channels { get; set; }

        /// <summary>
        /// Gets or sets the input duration.
        /// </summary>
        [JsonProperty("duration_in_ms")]
        public long? DurationInMs { get; set; }

        /// <summary>
        /// Gets or sets the input video bitrate.
        /// </summary>
        [JsonProperty("video_bitrate_in_kbps")]
        public int? VideoBitrateInKbps { get; set; }

        /// <summary>
        /// Gets or sets the input video codec.
        /// </summary>
        [JsonProperty("video_codec")]
        public string VideoCodec { get; set; }

        /// <summary>
        /// Gets or sets the input format.
        /// </summary>
        [JsonProperty("format")]
        public string Format { get; set; }

        /// <summary>
        /// Gets or sets the input audio codec.
        /// </summary>
        [JsonProperty("audio_codec")]
        public string AudioCodec { get; set; }

        /// <summary>
        /// Gets or sets the input file size.
        /// </summary>
        [JsonProperty("file_size_in_bytes")]
        public long FileSizeInBytes { get; set; }

        /// <summary>
        /// Gets or sets the input width.
        /// </summary>
        [JsonProperty("width")]
        public int? Width { get; set; }

        /// <summary>
        /// Gets or sets the input audio bitrate.
        /// </summary>
        [JsonProperty("audio_bitrate_in_kbps")]
        public string AudioBitrateInKbps { get; set; }

        /// <summary>
        /// Gets or sets the input total bitrate.
        /// </summary>
        [JsonProperty("total_bitrate_in_kbps")]
        public int? TotalBitrateInKbps { get; set; }

        /// <summary>
        /// Gets or sets the input checksum.
        /// </summary>
        [JsonProperty("md5_checksum")]
        public string Md5Checksum { get; set; }
    }
}
