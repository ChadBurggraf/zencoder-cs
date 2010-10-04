

namespace Zencoder
{
    using System;
    using System.Globalization;
    using System.Runtime.Serialization;

    /// <summary>
    /// Represents job output settings.
    /// </summary>
    [DataContract]
    public class Output
    {
        private int? audioChannels, audioQuality, quality, speed;

        /// <summary>
        /// Gets or sets the audio bitrate to use in Kbps. Should be a multiple of 16,
        /// and lower than 160Kbps per channel (i.e., 320Kbps stereo).
        /// Identifies that total bitrate, not per channel.
        /// </summary>
        [DataMember(Name = "audio_bitrate", EmitDefaultValue = false)]
        public int? AudioBitrate { get; set; }

        /// <summary>
        /// The number of audio channels to use (1 or 2). Defaults to keep the number of
        /// input channels, or reduce to 2.
        /// </summary>
        [DataMember(Name = "audio_channels", EmitDefaultValue = false)]
        public int? AudioChannels
        {
            get
            {
                return this.audioChannels;
            }

            set
            {
                if (value != null && value < 1)
                {
                    this.audioChannels = 1;
                }
                else if (value != null && value > 2)
                {
                    this.audioChannels = 2;
                }
                else
                {
                    this.audioChannels = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the audio codec to use. If encoding video and not set,
        /// the output video codec will determine this value automatically unless specifically set.
        /// </summary>
        [DataMember(Name = "audio_codec", EmitDefaultValue = false)]
        public string AudioCodec { get; set; }

        /// <summary>
        /// Gets or sets a target audio quality, from 1 to 5. 5 is the best
        /// quality, but results in the largest files.
        /// </summary>
        [DataMember(Name = "audio_quality", EmitDefaultValue = false)]
        public int? AudioQuality
        {
            get
            {
                return this.audioQuality;
            }

            set
            {
                if (value != null && value < 1)
                {
                    this.audioQuality = 1;
                }
                else if (value != null && value > 5)
                {
                    this.audioQuality = 5;
                }
                else
                {
                    this.audioQuality = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the audio sample rate in Hz. Not recommended.
        /// By default, the input sample rate will be used. Rates higher than 48,000 Hz
        /// will be resampled to 48KHz.
        /// </summary>
        [DataMember(Name = "audio_sample_rate", EmitDefaultValue = false)]
        public int? AudioSampleRate { get; set; }

        /// <summary>
        /// Gets or sets a directory to place the output file in, but not the file name.
        /// If no <see cref="FileName"/> is specified, a random one will be generated with the appropriate extension.
        /// </summary>
        [DataMember(Name = "base_url", EmitDefaultValue = false)]
        public string BaseUrl { get; set; }

        /// <summary>
        /// Gets or sets the desired peak bitrate for the output video, without
        /// forcing lower bitrates to be raised.
        /// </summary>
        [DataMember(Name = "bitrate_cap", EmitDefaultValue = false)]
        public int? BitrateCap { get; set; }

        /// <summary>
        /// Used in conjuction with <see cref="MaxBitrate"/>, this should be determined by
        /// your streaming server settings. For example, use 10,000 for iPhone.
        /// </summary>
        [DataMember(Name = "buffer_size", EmitDefaultValue = false)]
        public int? BufferSize { get; set; }

        /// <summary>
        /// Gets or sets the duration of the movie subclip to create.
        /// </summary>
        [DataMember(Name = "clip_length", EmitDefaultValue = false)]
        public string ClipLength { get; set; }

        /// <summary>
        /// Gets or sets a value that acts as a divisor for the input frame rate.
        /// Given an input frame rate of 20 and a decimate value of 2, the output frame rate will be 10.
        /// </summary>
        [DataMember(Name = "decimate", EmitDefaultValue = false)]
        public int? Decimate { get; set; }

        /// <summary>
        /// Gets or sets the deinterlace mode to use.
        /// </summary>
        [DataMember(Name = "deinterlace", EmitDefaultValue = false)]
        public string Deinterlace { get; set; }

        /// <summary>
        /// Gets or sets the file name of the finished file. If supplied and <see cref="BaseUrl"/>
        /// is empty, Zencoder will store a file with this name in an S3 bucket for download.
        /// </summary>
        [DataMember(Name = "filename", EmitDefaultValue = false)]
        public string FileName { get; set; }

        /// <summary>
        /// Gets or sets the output frame rate to use. Not recommended.
        /// </summary>
        [DataMember(Name = "frame_rate", EmitDefaultValue = false)]
        public float? FrameRate { get; set; }

        /// <summary>
        /// Gets or sets the height of the output video, if applicable.
        /// </summary>
        [DataMember(Name = "height", EmitDefaultValue = false)]
        public int? Height { get; set; }

        /// <summary>
        /// Gets or sets the maximum number of frames between each keyframe.
        /// Defaults to 250.
        /// </summary>
        [DataMember(Name = "keyframe_interval", EmitDefaultValue = false)]
        public int? KeyframeInterval { get; set; }

        /// <summary>
        /// Gets or sets a nickname to use for the output, if applicable.
        /// </summary>
        [DataMember(Name = "label", EmitDefaultValue = false)]
        public string Label { get; set; }

        /// <summary>
        /// Gets or sets the maximum frame rate (and therefore bitrate) to use,
        /// rather than forcing a specific frame rate.
        /// </summary>
        [DataMember(Name = "max_frame_rate", EmitDefaultValue = false)]
        public int? MaxFrameRate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to force onepass encoding when
        /// <see cref="VideoBitrate"/> is set.
        /// </summary>
        [DataMember(Name = "onepass", EmitDefaultValue = false)]
        public bool? Onepass { get; set; }

        /// <summary>
        /// Gets or sets the desired video output quality, from 1 to 5.
        /// 5 is almost lossless, but results in the largest files.
        /// Defaults to 3.
        /// </summary>
        [DataMember(Name = "quality", EmitDefaultValue = false)]
        public int? Quality
        {
            get
            {
                return this.quality;
            }

            set
            {
                if (value != null && value < 1)
                {
                    this.quality = 1;
                }
                else if (value != null && value > 5)
                {
                    this.quality = 5;
                }
                else
                {
                    this.quality = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the degrees by which to explicitly rotate the video.
        /// Setting to non-null will prevent auto rotation.
        /// </summary>
        [DataMember(Name = "rotate", EmitDefaultValue = false)]
        public int? Rotate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to skip the input audio track, if one is present.
        /// Use 1 for true, 0 for false.
        /// </summary>
        [DataMember(Name = "skip_audio", EmitDefaultValue = false)]
        public int? SkipAudio { get; set; }

        /// <summary>
        /// Gets or sets the target transcoding speed, from 1 to 5.
        /// 1 is the slowest, resulting in the smallest file.
        /// Defaults to 2.
        /// </summary>
        [DataMember(Name = "speed")]
        public int Speed
        {
            get 
            { 
                return (int)(this.speed ?? (this.speed = 2)); 
            }

            set
            {
                if (value < 1)
                {
                    this.speed = 1;
                }
                else if (value > 5)
                {
                    this.speed = 5;
                }
                else
                {
                    this.speed = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the time to start creating a subclip of the movie at.
        /// </summary>
        [DataMember(Name = "start_clip", EmitDefaultValue = false)]
        public string StartClip { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to scale the input
        /// up to the output resolution if necessary.
        /// </summary>
        [DataMember(Name = "upscale", EmitDefaultValue = false)]
        public bool? Upscale { get; set; }

        /// <summary>
        /// The destination for the output file. If an S3 bucket,
        /// the bucket must have write permission enabled for aws@zencoder.com.
        /// Can also be an FTP/SFTP server.
        /// </summary>
        [DataMember(Name = "url")]
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the desired output bitrate for the video, in Kbps.
        /// </summary>
        [DataMember(Name = "video_bitrate", EmitDefaultValue = false)]
        public int? VideoBitrate { get; set; }

        /// <summary>
        /// Gets or sets the video codec to use for the output, if applicable.
        /// </summary>
        [DataMember(Name = "video_codec", EmitDefaultValue = false)]
        public string VideoCodec { get; set; }

        /// <summary>
        /// Gets or sets the width of the output video, if applicable.
        /// </summary>
        [DataMember(Name = "width", EmitDefaultValue = false)]
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
    }
}
