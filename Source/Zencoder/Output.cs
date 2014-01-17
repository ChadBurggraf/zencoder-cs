//-----------------------------------------------------------------------
// <copyright file="Output.cs" company="Tasty Codes">
//     Copyright (c) 2010 Chad Burggraf.
// </copyright>
//-----------------------------------------------------------------------

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
        [JsonProperty("headers", NullValueHandling = NullValueHandling.Ignore)]
        private IDictionary<string, string> headers;

        /// <summary>
        /// Gets or sets the collection of custom S3 access grants to apply to the output
        /// if its destination is S3.
        /// </summary>
        [JsonProperty("access_control", NullValueHandling = NullValueHandling.Ignore)]
        public S3Access[] AccessControl { get; set; }

        /// <summary>
        /// Gets or sets the aspect mode to use if the input aspect ratio does not
        /// match the input aspect ratio.
        /// </summary>
        [JsonProperty("aspect_mode", NullValueHandling = NullValueHandling.Ignore)]
        public AspectMode? AspectMode { get; set; }

        /// <summary>
        /// Gets or sets the audio bitrate to use in Kbps. Should be a multiple of 16,
        /// and lower than 160Kbps per channel (i.e., 320Kbps stereo).
        /// Identifies that total bitrate, not per channel.
        /// </summary>
        [JsonProperty("audio_bitrate", NullValueHandling = NullValueHandling.Ignore)]
        public int? AudioBitrate { get; set; }

        /// <summary>
        /// Gets or sets the number of audio channels to use (1 or 2). Defaults to keep the number of
        /// input channels, or reduce to 2.
        /// </summary>
        [JsonProperty("audio_channels", NullValueHandling = NullValueHandling.Ignore)]
        public int? AudioChannels { get; set; }

        /// <summary>
        /// Gets or sets the audio codec to use. If encoding video and not set,
        /// the output video codec will determine this value automatically unless specifically set.
        /// </summary>
        [JsonProperty("audio_codec", NullValueHandling = NullValueHandling.Ignore)]
        public AudioCodec? AudioCodec { get; set; }

        /// <summary>
        /// Normalize the audio before applying expansion or compression effects.
        /// </summary>
        [JsonProperty("audio_pre_normalize", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(BooleanConverter))]
        public bool? AudioPreNormalize { get; set; }

        /// <summary>
        /// Normalize the audio after applying expansion or compression effects.
        /// </summary>
        [JsonProperty("audio_post_normalize", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(BooleanConverter))]
        public bool? AudioPostNormalize { get; set; }

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
        /// Gets or sets a value indicating whether to apply an auto-level filter to the output video.
        /// </summary>
        [JsonProperty("auto_level", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(BooleanConverter))]
        public bool? AutoLevel { get; set; }

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
        /// Gets or sets the buffer size. Used in conjuction with <see cref="BitrateCap"/>, this should be determined by
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
        /// Gets or sets a value indicating whether to use constant bitrate (CBR) encoding.
        /// Requires setting <see cref="VideoBitrate"/>. Cannot be used in conjuction with <see cref="Quality"/>.
        /// </summary>
        [JsonProperty("constant_bitrate", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(BooleanConverter))]
        public bool? ConstantBitrate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to apply a deblocking filter to the output video.
        /// </summary>
        [JsonProperty("deblock", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(BooleanConverter))]
        public bool? Deblock { get; set; }

        /// <summary>
        /// Gets or sets a value that acts as a divisor for the input frame rate.
        /// Given an input frame rate of 20 and a decimate value of 2, the output frame rate will be 10.
        /// </summary>
        [JsonProperty("decimate", NullValueHandling = NullValueHandling.Ignore)]
        public int? Decimate { get; set; }

        /// <summary>
        /// Gets or sets the deinterlace mode to use.
        /// </summary>
        [JsonProperty("deinterlace", NullValueHandling = NullValueHandling.Ignore)]
        public Deinterlace? Deinterlace { get; set; }

        /// <summary>
        /// Gets or sets the denoise filter to apply to the output video, if applicable.
        /// </summary>
        [JsonProperty("denoise", NullValueHandling = NullValueHandling.Ignore)]
        public DenoiseFilter? Denoise { get; set; }

        /// <summary>
        /// Gets or sets a shortcut device profile to use for the output.
        /// See https://app.zencoder.com/docs/api/encoding/general-output-settings/device-profile
        /// for more details on device profiles.
        /// </summary>
        [JsonProperty("device_profile", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(EnumDescriptionConverter))]
        public DeviceProfile? DeviceProfile { get; set; }

        /// <summary>
        /// Gets or sets the file name of the finished file. If supplied and <see cref="BaseUrl"/>
        /// is empty, Zencoder will store a file with this name in an S3 bucket for download.
        /// </summary>
        [JsonProperty("filename", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string FileName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to enable or disable variability in keyframe
        /// generation when using <see cref="KeyframeInterval"/>. When not set, defaults to false,
        /// allowing variability.
        /// </summary>
        [JsonProperty("fixed_keyframe_interval", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(BooleanConverter))]
        public bool? FixedKeyframeInterval { get; set; }

        /// <summary>
        /// Gets or sets the format of the output container to use. Only set this value if not inferring
        /// the format from the output file name.
        /// </summary>
        [JsonProperty("format", NullValueHandling = NullValueHandling.Ignore)]
        public MediaFileFormat? Format { get; set; }

        /// <summary>
        /// Gets or sets the output frame rate to use. Not recommended.
        /// </summary>
        [JsonProperty("frame_rate", NullValueHandling = NullValueHandling.Ignore)]
        public float? FrameRate { get; set; }

        /// <summary>
        /// Gets or sets the level to use when performing H264 encoding.
        /// </summary>
        [JsonProperty("h264_level", NullValueHandling = NullValueHandling.Ignore)]
        public H264Level? H264Level { get; set; }

        /// <summary>
        /// Gets or sets the profile to use when performing H264 encoding.
        /// </summary>
        [JsonProperty("h264_profile", NullValueHandling = NullValueHandling.Ignore)]
        public H264Profile? H264Profile { get; set; }

        /// <summary>
        /// Gets or sets the number of reference frames to use when performing H264 encoding.
        /// </summary>
        [JsonProperty("h264_reference_frames", NullValueHandling = NullValueHandling.Ignore)]
        public int? H264ReferenceFrames { get; set; }

        /// <summary>
        /// Gets the custom header dictionary to send to Amazon S3, if applicable. Zencoder supports
        /// the following subset of headers: Cache-Control, Content-Disposition, Content-Encoding,
        /// Content-Type, Expires, x-amz-acl, x-amz-storage-class and x-amz-meta-*.
        /// </summary>
        public IDictionary<string, string> Headers
        {
            get { return this.headers ?? (this.headers = new Dictionary<string, string>()); }
        }

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
        /// Gets or sets the number of keyframes per second. A value of 0.5 would result
        /// in one keyframe every two seconds, a value of 3 would result in three keyframes
        /// per second. Use this instead of <see cref="KeyframeInterval"/> if desired, althouth
        /// <see cref="KeyframeInterval"/> takes precedence if both are set.
        /// </summary>
        [JsonProperty("keyframe_rate", NullValueHandling = NullValueHandling.Ignore)]
        public float? KeyframeRate { get; set; }

        /// <summary>
        /// Gets or sets a nickname to use for the output, if applicable.
        /// </summary>
        [JsonProperty("label", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string Label { get; set; }

        /// <summary>
        /// Gets or sets a value indicating the maximum audio sample rate to use, rather than
        /// forcing a specific sample rate. Value should be in Hz (e.g., 44100 for CD quality).
        /// </summary>
        [JsonProperty("max_audio_sample_rate", NullValueHandling = NullValueHandling.Ignore)]
        public int? MaxAudioSampleRate { get; set; }

        /// <summary>
        /// Gets or sets the maximum frame rate (and therefore bitrate) to use,
        /// rather than forcing a specific frame rate.
        /// </summary>
        [JsonProperty("max_frame_rate", NullValueHandling = NullValueHandling.Ignore)]
        public float? MaxFrameRate { get; set; }

        /// <summary>
        /// Gets or sets the maximum average bitrate to use. Overiddes both <see cref="Quality"/>
        /// and <see cref="VideoBitrate"/>.
        /// </summary>
        [JsonProperty("max_video_bitrate", NullValueHandling = NullValueHandling.Ignore)]
        public int? MaxVideoBitrate { get; set; }

        /// <summary>
        /// Gets or sets the collection of notifications to define for the output.
        /// </summary>
        [JsonProperty("notifications", NullValueHandling = NullValueHandling.Ignore)]
        public Notification[] Notifications { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to force onepass encoding when
        /// <see cref="VideoBitrate"/> is set.
        /// </summary>
        [JsonProperty("onepass", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(BooleanConverter))]
        public bool? Onepass { get; set; }

        /// <summary>
        /// Gets or sets the output type to use.
        /// </summary>
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public OutputType? OutputType { get; set; }

        /// <summary>
        /// Gets or sets a value indicating a shortcut S3 ACL granding READ permission to the AllUsers group,
        /// if the output is being placed in S3.
        /// </summary>
        [JsonProperty("public", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(BooleanConverter))]
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
        public Rotate? Rotate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to pass the necessary headers to S3
        /// if the destination S3 bucket is using Reduced Redundancy Storage. Only
        /// application when storing outputs on S3.
        /// </summary>
        [JsonProperty("rrs", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(BooleanConverter))]
        public bool? Rrs { get; set; }

        /// <summary>
        /// Gets or sets the maximum duration to use for each segment in segmented outputs.
        /// </summary>
        [JsonProperty("segment_seconds", NullValueHandling = NullValueHandling.Ignore)]
        public int? SegmentSeconds { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to apply a sharpen filter to the output video.
        /// </summary>
        [JsonProperty("sharpet", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(BooleanConverter))]
        public bool? Sharpen { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to skip the input audio track, if one is present.
        /// </summary>
        [JsonProperty("skip_audio", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(BooleanConverter))]
        public bool? SkipAudio { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to skip the input video track, if one is present.
        /// </summary>
        [JsonProperty("skip_video", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(BooleanConverter))]
        public bool? SkipVideo { get; set; }

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
        /// Gets or sets a collection of streams to be re-formatted as a playlist.
        /// </summary>
        [JsonProperty("streams", NullValueHandling = NullValueHandling.Ignore)]
        public PlaylistStream[] Streams { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to enable "strict" mode. Will cause jobs to fail with invalid encoding settings,
        /// rather than having the service move bad parameters into valid ranges.
        /// </summary>
        [JsonProperty("strict", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(BooleanConverter))]
        public bool? Strict { get; set; }

        /// <summary>
        /// Gets or sets a collection of thumbnails settings to use for the output.
        /// </summary>
        [JsonProperty("thumbnails", NullValueHandling = NullValueHandling.Ignore)]
        public Thumbnails[] Thumbnails { get; set; }

        /// <summary>
        /// Gets or sets the tuning value to use when performing H264 encoding.
        /// </summary>
        [JsonProperty("tuning", NullValueHandling = NullValueHandling.Ignore)]
        public Tuning? Tuning { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to scale the input
        /// up to the output resolution if necessary.
        /// </summary>
        [JsonProperty("upscale", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(BooleanConverter))]
        public bool? Upscale { get; set; }

        /// <summary>
        /// Gets or sets the destination for the output file. If an S3 bucket,
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
        [JsonProperty("video_codec", NullValueHandling = NullValueHandling.Ignore)]
        public VideoCodec? VideoCodec { get; set; }

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
        /// Appends the given S3 access control to this instance's <see cref="AccessControl"/> collection.
        /// </summary>
        /// <param name="accessControl">The access controls to append.</param>
        /// <returns>The instance.</returns>
        public Output WithAccessControl(S3Access accessControl)
        {
            return this.WithAccessControls(new S3Access[] { accessControl });
        }

        /// <summary>
        /// Appends the given collection S3 access controls to this instance's <see cref="AccessControl"/> collection.
        /// </summary>
        /// <param name="accessControls">The access controls to append.</param>
        /// <returns>The instance.</returns>
        public Output WithAccessControls(IEnumerable<S3Access> accessControls)
        {
            if (accessControls != null)
            {
                this.AccessControl = (this.AccessControl ?? new S3Access[0]).Concat(accessControls).ToArray();
            }

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
        /// Sets this instance's <see cref="Thumbnails"/> property.
        /// </summary>
        /// <param name="thumbnails">The thumbnails to set.</param>
        /// <returns>This instance.</returns>
        public Output WithThumbnails(Thumbnails thumbnails)
        {
            return this.WithThumbnails(thumbnails != null ? new Thumbnails[1] { thumbnails } : null);
        }

        /// <summary>
        /// Sets this instance's <see cref="Thumbnails"/> property.
        /// </summary>
        /// <param name="thumbnails">The thumbnails collection to set.</param>
        /// <returns>This instance.</returns>
        public Output WithThumbnails(IEnumerable<Thumbnails> thumbnails)
        {
            Thumbnails[] t = thumbnails != null ? thumbnails.ToArray() : new Thumbnails[0];
            this.Thumbnails = t.Length > 0 ? t : null;
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
        /// Appends a <see cref="Notification"/> to this instance's <see cref="Notification"/> collection.
        /// </summary>
        /// <param name="notification">The notification to append.</param>
        /// <returns>This instance.</returns>
        public Output WithNotification(Notification notification)
        {
            if (notification != null)
            {
                return this.WithNotifications(new Notification[] { notification });
            }

            return this;
        }

        /// <summary>
        /// Appends a collection of <see cref="Notification"/>s to this instance's <see cref="Notification"/> collection.
        /// </summary>
        /// <param name="notifications">The notifications to append.</param>
        /// <returns>This instance.</returns>
        public Output WithNotifications(IEnumerable<Notification> notifications)
        {
            if (notifications != null)
            {
                this.Notifications = (this.Notifications ?? new Notification[0]).Concat(notifications).ToArray();
            }

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
