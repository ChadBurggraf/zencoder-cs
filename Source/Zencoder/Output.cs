

namespace Zencoder
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using Newtonsoft.Json;

    /// <summary>
    /// Represents job output settings.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class Output
    {
        /// <summary>
        /// Gets or sets the audio bitrate to use in Kbps. Should be a multiple of 16,
        /// and lower than 160Kbps per channel (i.e., 320Kbps stereo).
        /// Identifies that total bitrate, not per channel.
        /// </summary>
        [JsonProperty("audio_bitrate", NullValueHandling = NullValueHandling.Ignore)]
        public int? AudioBitrate { get; set; }

        /// <summary>
        /// The number of audio channels to use (1 or 2). Defaults to keep the number of
        /// input channels, or reduce to 2.
        /// </summary>
        [JsonProperty("audio_channels", NullValueHandling = NullValueHandling.Ignore)]
        public int? AudioChannels { get; set; }

        /// <summary>
        /// Gets or sets the audio codec to use. If encoding video and not set,
        /// the output video codec will determine this value automatically unless specifically set.
        /// </summary>
        [JsonProperty("audio_codec", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string AudioCodec { get; set; }

        /// <summary>
        /// Gets or sets a target audio quality, from 1 to 5. 5 is the best
        /// quality, but results in the largest files.
        /// </summary>
        [JsonProperty("audio_quality", NullValueHandling = NullValueHandling.Ignore)]
        public int? AudioQuality { get; set; }

        /// <summary>
        /// Gets or sets the audio sample rate in Hz. Not recommended.
        /// By default, the input sample rate will be used. Rates higher than 48,000 Hz
        /// will be resampled to 48KHz.
        /// </summary>
        [JsonProperty("audio_sample_rate", NullValueHandling = NullValueHandling.Ignore)]
        public int? AudioSampleRate { get; set; }

        /// <summary>
        /// Gets or sets a directory to place the output file in, but not the file name.
        /// If no <see cref="FileName"/> is specified, a random one will be generated with the appropriate extension.
        /// </summary>
        [JsonProperty("base_url", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string BaseUrl { get; set; }

        /// <summary>
        /// Gets or sets the desired peak bitrate for the output video, without
        /// forcing lower bitrates to be raised.
        /// </summary>
        [JsonProperty("bitrate_cap", NullValueHandling = NullValueHandling.Ignore)]
        public int? BitrateCap { get; set; }

        /// <summary>
        /// Used in conjuction with <see cref="MaxBitrate"/>, this should be determined by
        /// your streaming server settings. For example, use 10,000 for iPhone.
        /// </summary>
        [JsonProperty("buffer_size", NullValueHandling = NullValueHandling.Ignore)]
        public int? BufferSize { get; set; }

        /// <summary>
        /// Gets or sets the duration of the movie subclip to create.
        /// </summary>
        [JsonProperty("clip_length", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string ClipLength { get; set; }

        /// <summary>
        /// Gets or sets a value that acts as a divisor for the input frame rate.
        /// Given an input frame rate of 20 and a decimate value of 2, the output frame rate will be 10.
        /// </summary>
        [JsonProperty("decimate", NullValueHandling = NullValueHandling.Ignore)]
        public int? Decimate { get; set; }

        /// <summary>
        /// Gets or sets the deinterlace mode to use.
        /// </summary>
        [JsonProperty("deinterlace", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string Deinterlace { get; set; }

        /// <summary>
        /// Gets or sets the file name of the finished file. If supplied and <see cref="BaseUrl"/>
        /// is empty, Zencoder will store a file with this name in an S3 bucket for download.
        /// </summary>
        [JsonProperty("filename", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string FileName { get; set; }

        /// <summary>
        /// Gets or sets the output frame rate to use. Not recommended.
        /// </summary>
        [JsonProperty("frame_rate", NullValueHandling = NullValueHandling.Ignore)]
        public float? FrameRate { get; set; }

        /// <summary>
        /// Gets or sets the height of the output video, if applicable.
        /// </summary>
        [JsonProperty("height", NullValueHandling = NullValueHandling.Ignore)]
        public int? Height { get; set; }

        /// <summary>
        /// Gets or sets the maximum number of frames between each keyframe.
        /// Defaults to 250.
        /// </summary>
        [JsonProperty("keyframe_interval", NullValueHandling = NullValueHandling.Ignore)]
        public int? KeyframeInterval { get; set; }

        /// <summary>
        /// Gets or sets a nickname to use for the output, if applicable.
        /// </summary>
        [JsonProperty("label", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string Label { get; set; }

        /// <summary>
        /// Gets or sets the maximum frame rate (and therefore bitrate) to use,
        /// rather than forcing a specific frame rate.
        /// </summary>
        [JsonProperty("max_frame_rate", NullValueHandling = NullValueHandling.Ignore)]
        public int? MaxFrameRate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to force onepass encoding when
        /// <see cref="VideoBitrate"/> is set.
        /// </summary>
        [JsonProperty("onepass", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Onepass { get; set; }

        /// <summary>
        /// Gets or sets a value indicating a shortcut S3 ACL granding READ permission to the AllUsers group,
        /// if the output is being placed in S3.
        /// </summary>
        [JsonProperty("public", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Public { get; set; }

        /// <summary>
        /// Gets or sets the desired video output quality, from 1 to 5.
        /// 5 is almost lossless, but results in the largest files.
        /// Defaults to 3.
        /// </summary>
        [JsonProperty("quality", NullValueHandling = NullValueHandling.Ignore)]
        public int? Quality { get; set; }

        /// <summary>
        /// Gets or sets the degrees by which to explicitly rotate the video.
        /// Setting to non-null will prevent auto rotation.
        /// </summary>
        [JsonProperty("rotate", NullValueHandling = NullValueHandling.Ignore)]
        public int? Rotate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to skip the input audio track, if one is present.
        /// </summary>
        [JsonProperty("skip_audio", NullValueHandling = NullValueHandling.Ignore)]
        public bool? SkipAudio { get; set; }

        /// <summary>
        /// Gets or sets the target transcoding speed, from 1 to 5.
        /// 1 is the slowest, resulting in the smallest file.
        /// </summary>
        [JsonProperty("speed", NullValueHandling = NullValueHandling.Ignore)]
        public int? Speed { get; set; }

        /// <summary>
        /// Gets or sets the time to start creating a subclip of the movie at.
        /// </summary>
        [JsonProperty("start_clip", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string StartClip { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to scale the input
        /// up to the output resolution if necessary.
        /// </summary>
        [JsonProperty("upscale", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Upscale { get; set; }

        /// <summary>
        /// The destination for the output file. If an S3 bucket,
        /// the bucket must have write permission enabled for aws@zencoder.com.
        /// Can also be an FTP/SFTP server.
        /// </summary>
        [JsonProperty("url", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the desired output bitrate for the video, in Kbps, if applicable.
        /// </summary>
        [JsonProperty("video_bitrate", NullValueHandling = NullValueHandling.Ignore)]
        public int? VideoBitrate { get; set; }

        /// <summary>
        /// Gets or sets the video codec to use for the output, if applicable.
        /// </summary>
        [JsonProperty("video_codec", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string VideoCodec { get; set; }

        /// <summary>
        /// Gets or sets the collection of watermarks to apply to the output video, if applicable.
        /// </summary>
        [JsonProperty("watermarks", NullValueHandling = NullValueHandling.Ignore)]
        public Watermark[] Watermarks { get; set; }

        /// <summary>
        /// Gets or sets the width of the output video, if applicable.
        /// </summary>
        [JsonProperty("width", NullValueHandling = NullValueHandling.Ignore)]
        public int? Width { get; set; }

        /// <summary>
        /// Sets this instance's <see cref="AudioCodec"/> property.
        /// </summary>
        /// <param name="codec">The audio codec to set.</param>
        /// <returns>This instance.</returns>
        public Output WithAudioCodec(AudioCodec codec)
        {
            this.AudioCodec = codec.ToString().ToLowerInvariant();
            return this;
        }

        /// <summary>
        /// Sets this instance's clipping (<see cref="StartClip"/> and <see cref="ClipLength"/>) properties.
        /// </summary>
        /// <param name="startClip">The start clip to set.</param>
        /// <param name="clipLength">The clip length to set.</param>
        /// <returns>This instance.</returns>
        public Output WithClip(TimeSpan? startClip, TimeSpan? clipLength)
        {
            this.StartClip = null;
            this.ClipLength = null;

            if (startClip != null)
            {
                this.StartClip = startClip.Value.TotalSeconds.ToString("N1", CultureInfo.InvariantCulture);
            }

            if (clipLength != null)
            {
                this.ClipLength = clipLength.Value.TotalSeconds.ToString("N1", CultureInfo.InvariantCulture);
            }

            return this;
        }

        /// <summary>
        /// Sets this instance's <see cref="Deinterlace"/> property.
        /// </summary>
        /// <param name="deinterlace">The deinterlace mode to set.</param>
        /// <returns>This instance.</returns>
        public Output WithDeinterlace(Deinterlace deinterlace)
        {
            this.Deinterlace = deinterlace.ToString().ToLowerInvariant();
            return this;
        }

        /// <summary>
        /// Sets this instance's <see cref="Rotate"/> property.
        /// </summary>
        /// <param name="rotate">The rotation to set.</param>
        /// <returns>This instance.</returns>
        public Output WithRotate(Rotate rotate)
        {
            this.Rotate = (int)rotate;
            return this;
        }

        /// <summary>
        /// Sets the instance's <see cref="Url"/> property.
        /// </summary>
        /// <param name="url">The URL to set.</param>
        /// <returns>This instance.</returns>
        public Output WithUrl(Uri url)
        {
            this.Url = url.ToString();
            return this;
        }

        /// <summary>
        /// Sets this instance's <see cref="VideoCodec"/> property.
        /// </summary>
        /// <param name="codec">The video codec to set.</param>
        /// <returns>This instance.</returns>
        public Output WithVideoCodec(VideoCodec codec)
        {
            this.VideoCodec = codec.ToString().ToLowerInvariant();
            return this;
        }

        /// <summary>
        /// Appends a <see cref="Watermark"/> to this instance's <see cref="Watermark"/> collection.
        /// </summary>
        /// <param name="watermark">The watermark to append.</param>
        /// <returns>This instance.</returns>
        public Output WithWatermark(Watermark watermark)
        {
            if (watermark != null)
            {
                return this.WithWatermarks(new Watermark[] { watermark });
            }

            return this;
        }

        /// <summary>
        /// Appends a collection of <see cref="Watermark"/>s to this instance's <see cref="Watermark"/> collection.
        /// </summary>
        /// <param name="watermarks">The watermarks to append.</param>
        /// <returns>This instance.</returns>
        public Output WithWatermarks(IEnumerable<Watermark> watermarks)
        {
            if (watermarks != null)
            {
                this.Watermarks = (this.Watermarks ?? new Watermark[0]).Concat(watermarks).ToArray();
            }

            return this;
        }
    }
}
