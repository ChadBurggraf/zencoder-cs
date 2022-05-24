//-----------------------------------------------------------------------
// <copyright file="Thumbnails.cs" company="Tasty Codes">
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
    /// Represents thumbnail generation properties for an <see cref="Output"/>.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class Thumbnails
    {
        [JsonProperty("headers", NullValueHandling = NullValueHandling.Ignore)]
        private IDictionary<string, string> headers;

        /// <summary>
        /// Gets or sets the collection of custom S3 access grants to apply to the thumbnails
        /// if their destination is S3.
        /// </summary>
        [JsonProperty("access_control", NullValueHandling = NullValueHandling.Ignore)]
        public S3Access[] AccessControl { get; set; }

        /// <summary>
        /// Gets or sets the aspect mode to use when creating thumbnails.
        /// </summary>
        [JsonProperty("aspect_mode", NullValueHandling = NullValueHandling.Ignore)]
        public AspectMode? AspectMode { get; set; }

        /// <summary>
        /// Gets or sets an output destination for thumbnails. If blank, will use the corresponding <see cref="Output"/>'s
        /// destination. If that is blank, they will be placed in the Zencoder S3 bucket.
        /// </summary>
        [JsonProperty("base_url", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string BaseUrl { get; set; }

        /// <summary>
        /// Gets or sets the interpolated filename to use for thumbnails. The attributes available for interpolation include
        /// number, padded-number, width, height and size. No file extension is necessary. Each attribute should be surrounded
        /// by double curly-braces, e.g., {{number}}_{{width}}x{{height}}-thumbnail.
        /// </summary>
        [JsonProperty("filename", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string FileName { get; set; }

        /// <summary>
        /// Gets or sets the format to use for thumbnail images.
        /// </summary>
        [JsonProperty("format", NullValueHandling = NullValueHandling.Ignore)]
        public ThumbnailFormat? Format { get; set; }

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
        /// Gets or sets the height of the thumbnails, if applicable.
        /// </summary>
        [JsonProperty("height", NullValueHandling = NullValueHandling.Ignore)]
        public int? Height { get; set; }

        /// <summary>
        /// Gets or sets a thumbnail interval in seconds. A thumbnail will be generated
        /// for every N seconds of the file. Should be exclusive of <see cref="Number"/>,
        /// <see cref="Times"/> and <see cref="IntervalInFrames"/>.
        /// </summary>
        [JsonProperty("interval", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int? Interval { get; set; }

        /// <summary>
        /// Gets or sets the thumbnail interval in frames. A thumbnail will be generated for every N
        /// frames of the file. Should be exclusive of <see cref="Number"/>, <see cref="Times"/>
        /// and <see cref="Interval"/>.
        /// </summary>
        [JsonProperty("interval_in_frames", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int? IntervalInFrames { get; set; }

        /// <summary>
        /// Gets or sets the name for the thumbnail set. Required when creating multiple thumbnail sets from an output.
        /// </summary>
        [JsonProperty("label")]
        public string Label { get; set; }

        /// <summary>
        /// Gets or sets the number of thumbnails to generate. The thumbnails will
        /// be grabbed evenly across the duration of the file. Should be exclusive of
        /// <see cref="Interval"/>, <see cref="Times"/> and <see cref="IntervalInFrames"/>.
        /// </summary>
        [JsonProperty("number", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int? Number { get; set; }

        /// <summary>
        /// Gets or sets the output file name prefix. The default is "frame", resulting in thumbnails named
        /// "frame_0000.png", "frame_0001.png", etc. 
        /// </summary>
        [JsonProperty("prefix", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string Prefix { get; set; }

        /// <summary>
        /// Gets or sets a value indicating a shortcut S3 ACL granding READ permission to the AllUsers group,
        /// if the thumbnails are being placed in S3.
        /// </summary>
        [JsonProperty("public", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(BooleanConverter))]
        public bool? Public { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to pass the necessary headers to S3
        /// if the destination S3 bucket is using Reduced Redundancy Storage. Only
        /// application when storing thumbnails on S3.
        /// </summary>
        [JsonProperty("rrs", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(BooleanConverter))]
        public bool? Rrs { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to begin taking thumbnails at the first frame
        /// when using the <see cref="Number"/> option.
        /// </summary>
        [JsonProperty("start_at_first_frame", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(BooleanConverter))]
        public bool? StartAtFirstFrame { get; set; }

        /// <summary>
        /// Gets or sets a collection of times, in fractional seconds, to generate
        /// thumbnails for. Should be exclusive of
        /// <see cref="Interval"/>, <see cref="Times"/> and <see cref="IntervalInFrames"/>.
        /// </summary>
        [JsonProperty("times", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public float[] Times { get; set; }

        /// <summary>
        /// Gets or sets the width of the thumbnails, if applicable.
        /// </summary>
        [JsonProperty("width", NullValueHandling = NullValueHandling.Ignore)]
        public int? Width { get; set; }

        /// <summary>
        /// Appends the given S3 access control to this instance's <see cref="AccessControl"/> collection.
        /// </summary>
        /// <param name="accessControl">The access controls to append.</param>
        /// <returns>The instance.</returns>
        public Thumbnails WithAccessControl(S3Access accessControl)
        {
            return this.WithAccessControls(new S3Access[] { accessControl });
        }

        /// <summary>
        /// Appends the given collection S3 access controls to this instance's <see cref="AccessControl"/> collection.
        /// </summary>
        /// <param name="accessControls">The access controls to append.</param>
        /// <returns>The instance.</returns>
        public Thumbnails WithAccessControls(IEnumerable<S3Access> accessControls)
        {
            if (accessControls != null)
            {
                this.AccessControl = (this.AccessControl ?? new S3Access[0]).Concat(accessControls).ToArray();
            }

            return this;
        }

        /// <summary>
        /// Sets the <see cref="Interval"/> property, resetting <see cref="Number"/>, <see cref="Times"/>
        /// and <see cref="IntervalInFrames"/>.
        /// </summary>
        /// <param name="seconds">The thumbnail interval in seconds.</param>
        /// <returns>This instance.</returns>
        public Thumbnails WithInterval(int seconds)
        {
            if (seconds < 1)
            {
                throw new ArgumentException("seconds should be greater than or equal to 1.", "seconds");
            }

            this.Number = null;
            this.Interval = seconds;
            this.IntervalInFrames = null;
            this.Times = null;

            return this;
        }

        /// <summary>
        /// Sets the <see cref="IntervalInFrames"/> property, resetting <see cref="Number"/>, <see cref="Times"/>
        /// and <see cref="Interval"/>.
        /// </summary>
        /// <param name="frames">The thumbnail interval in frames.</param>
        /// <returns>This instance.</returns>
        public Thumbnails WithIntervalInFrames(int frames)
        {
            if (frames < 1)
            {
                throw new ArgumentException("frames should be greater than or equal to 1.", "frames");
            }

            this.Interval = null;
            this.IntervalInFrames = frames;
            this.Number = null;
            this.Times = null;

            return this;
        }

        /// <summary>
        /// Sets the <see cref="Number"/> property, reseting <see cref="Interval"/>, <see cref="Times"/>
        /// and <see cref="IntervalInFrames"/>.
        /// </summary>
        /// <param name="number">The number of thumbnails to generate.</param>
        /// <returns>This instance.</returns>
        public Thumbnails WithNumber(int number)
        {
            if (number < 1)
            {
                throw new ArgumentException("number should be greater than or equal to 1.", "number");
            }

            this.Number = number;
            this.Interval = null;
            this.IntervalInFrames = null;
            this.Times = null;

            return this;
        }

        /// <summary>
        /// Sets the <see cref="Width"/> and <see cref="Height"/> properties.
        /// </summary>
        /// <param name="width">The width, in pixels.</param>
        /// <param name="height">The height, in pixels.</param>
        /// <returns>This instance.</returns>
        public Thumbnails WithSize(int width, int height)
        {
            if (width < 1)
            {
                throw new ArgumentException("width must be a positive number", "width");
            }

            if (height < 1)
            {
                throw new ArgumentException("height must be a positive number", "height");
            }

            this.Width = width;
            this.Height = height;
            return this;
        }

        /// <summary>
        /// Sets the <see cref="Times"/> property, resetting <see cref="Number"/>, <see cref="Interval"/>
        /// and <see cref="IntervalInFrames"/>.
        /// </summary>
        /// <param name="times">A collection of thumbnail times, in fractional seconds.</param>
        /// <returns>This instance.</returns>
        public Thumbnails WithTimes(IEnumerable<float> times)
        {
            if (times == null)
            {
                throw new ArgumentNullException("times", "times cannot be null.");
            }

            if (times.Any(t => t <= 0))
            {
                throw new ArgumentException("times must be a collection of positive values.", "times");
            }

            this.Number = null;
            this.Interval = null;
            this.IntervalInFrames = null;
            this.Times = times.ToArray();

            return this;
        }
    }
}
