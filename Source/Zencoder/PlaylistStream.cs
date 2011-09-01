//-----------------------------------------------------------------------
// <copyright file="PlaylistStream.cs" company="Tasty Codes">
//     Copyright (c) 2011 Chad Burggraf.
// </copyright>
//-----------------------------------------------------------------------

namespace Zencoder
{
    using System;
    using System.Globalization;
    using Newtonsoft.Json;

    /// <summary>
    /// Represents a playlist stream definition, to be used when generating a playlist output.
    /// </summary>
    public class PlaylistStream
    {
        /// <summary>
        /// Gets or sets the bandwidth of the playlist stream, in Kbps.
        /// </summary>
        [JsonProperty("bandwidth")]
        public int? Bandwidth { get; set; }

        /// <summary>
        /// Gets or sets a comma-separated string of the codecs used in the stream in HTML5 format,
        /// such as: "mp4a.40.2, avc1.42E01E".
        /// </summary>
        [JsonProperty("codecs", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string Codecs { get; set; }

        /// <summary>
        /// Gets or sets the absolute or relative path to the stream's manifest file.
        /// </summary>
        [JsonProperty("path")]
        public string Path { get; set; }

        /// <summary>
        /// Gets or sets the resolution, such as 800x600, of a playlist stream.
        /// </summary>
        [JsonProperty("resolution", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string Resolution { get; set; }

        /// <summary>
        /// Sets the <see cref="Resolution"/> property.
        /// </summary>
        /// <param name="width">The width, in pixels.</param>
        /// <param name="height">The height, in pixels.</param>
        /// <returns>This instance.</returns>
        public PlaylistStream WithResolution(int width, int height)
        {
            if (width < 1)
            {
                throw new ArgumentException("width must be a positive number", "width");
            }

            if (height < 1)
            {
                throw new ArgumentException("height must be a positive number", "height");
            }

            this.Resolution = string.Format(CultureInfo.InvariantCulture, "{0}x{1}", width, height);
            return this;
        }
    }
}
