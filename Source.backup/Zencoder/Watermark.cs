//-----------------------------------------------------------------------
// <copyright file="Watermark.cs" company="Tasty Codes">
//     Copyright (c) 2010 Chad Burggraf.
// </copyright>
//-----------------------------------------------------------------------

namespace Zencoder
{
    using System;
    using System.Globalization;
    using Newtonsoft.Json;

    /// <summary>
    /// Represents a watermark that will be placed on a video output.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class Watermark
    {
        /// <summary>
        /// Gets or sets the height of the watermark. Can be in pixels (e.g., 48)
        /// or a percent of the video height (e.g., 10%). If set but no width is set,
        /// the watermark will be scaled proportionally.
        /// Defaults to scale to width, or original image height.
        /// </summary>
        [JsonProperty("height", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string Height { get; set; }

        /// <summary>
        /// Gets or sets the origin type to use for watermark generation.
        /// </summary>
        [JsonProperty("origin", NullValueHandling = NullValueHandling.Ignore)]
        public WatermarkOrigin? Origin { get; set; }

        /// <summary>
        /// Gets or sets the URL of the remote file to use as a watermark.
        /// </summary>
        [JsonProperty("url", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the width of the watermark. Can be in pixels(e.g., 64)
        /// or a percent of the video width (e.g., 10%). If set but no height is set,
        /// the watermark will be scaled proportionally.
        /// Defaults to scale to height, or original width.
        /// </summary>
        [JsonProperty("width", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string Width { get; set; }

        /// <summary>
        /// Gets or sets a value indicating where to place the watermark in the video along the X axis.
        /// Can be a number of pixels (e.g., 100 or -20) or a percent of the video width (e.g., 25% or -5%).
        /// Use positive values to place relative to the left side of the video, negative to place relative
        /// to the right side of the video. Use -0 to lock to the right side.
        /// Defaults to -10.
        /// </summary>
        [JsonProperty("x", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string X { get; set; }

        /// <summary>
        /// Gets or sets a value indicating where to place the watermark in the video along the Y axis.
        /// Can be a number of pixels (e.g., 100 or -20) or a percent of the video width (e.g., 25% or -5%).
        /// Use positive values to place relative to the top of the video, negative to place relative to the
        /// bottom of the video. Use -0 to lock to the bottom.
        /// Defaults to -10.
        /// </summary>
        [JsonProperty("y", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string Y { get; set; }

        /// <summary>
        /// Sets this instance's position properties as percentage values.
        /// </summary>
        /// <param name="x">The x-axis percentage value to set.</param>
        /// <param name="y">The y-axis percentage value to set.</param>
        /// <returns>This instance.</returns>
        public Watermark WithPositionInPercent(int? x, int? y)
        {
            this.X = this.Y = string.Empty;

            if (x != null)
            {
                this.X = x.Value.ToString("{0}%", CultureInfo.InvariantCulture);
            }

            if (y != null)
            {
                this.Y = y.Value.ToString("{0}%", CultureInfo.InvariantCulture);
            }

            return this;
        }

        /// <summary>
        /// Sets this instance's position properties as pixel values.
        /// </summary>
        /// <param name="x">The x-axis pixel value to set.</param>
        /// <param name="y">The y-axis pixel value to set.</param>
        /// <returns>This instance.</returns>
        public Watermark WithPositionInPixels(int? x, int? y)
        {
            this.X = this.Y = string.Empty;

            if (x != null)
            {
                this.X = x.Value.ToString(CultureInfo.InvariantCulture);
            }

            if (y != null)
            {
                this.Y = y.Value.ToString(CultureInfo.InvariantCulture);
            }

            return this;
        }

        /// <summary>
        /// Sets this instance's size properties as percentage values.
        /// </summary>
        /// <param name="width">The width percentage value to set.</param>
        /// <param name="height">The height percentage value to set.</param>
        /// <returns>This instance.</returns>
        public Watermark WithSizeInPercent(int? width, int? height)
        {
            this.Width = this.Height = string.Empty;

            if (width != null)
            {
                this.Width = width.Value.ToString("{0}%", CultureInfo.InvariantCulture);
            }

            if (height != null)
            {
                this.Height = height.Value.ToString("{0}%", CultureInfo.InvariantCulture);
            }

            return this;
        }

        /// <summary>
        /// Sets this instance's size properties as pixel values.
        /// </summary>
        /// <param name="width">The width pixel value to set.</param>
        /// <param name="height">The height pixel value to set.</param>
        /// <returns>This instance.</returns>
        public Watermark WithSizeInPixels(int? width, int? height)
        {
            this.Width = this.Height = string.Empty;

            if (width != null)
            {
                this.Width = width.Value.ToString(CultureInfo.InvariantCulture);
            }

            if (height != null)
            {
                this.Height = height.Value.ToString(CultureInfo.InvariantCulture);
            }

            return this;
        }

        /// <summary>
        /// Sets this instance's <see cref="Url"/> property.
        /// </summary>
        /// <param name="url">The URL to set.</param>
        /// <returns>This instance.</returns>
        public Watermark WithUrl(Uri url)
        {
            this.Url = url.ToString();
            return this;
        }
    }
}
