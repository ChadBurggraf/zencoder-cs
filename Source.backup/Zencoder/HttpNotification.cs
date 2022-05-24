//-----------------------------------------------------------------------
// <copyright file="HttpNotification.cs" company="Tasty Codes">
//     Copyright (c) 2010 Chad Burggraf.
// </copyright>
//-----------------------------------------------------------------------

namespace Zencoder
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// Represents an HTTP notification specification for an <see cref="Output"/>.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class HttpNotification : Notification
    {
        /// <summary>
        /// Gets the format to post notifications in.
        /// Always returns JSON.
        /// </summary>
        [JsonProperty("format")]
        public string Format 
        { 
            get { return "json"; } 
        }

        /// <summary>
        /// Gets or sets the URL to post notifications to for the output.
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }

        /// <summary>
        /// Sets this instance's <see cref="Url"/> property.
        /// </summary>
        /// <param name="url">The URL to set.</param>
        /// <returns>This instance.</returns>
        public HttpNotification WithUrl(Uri url)
        {
            this.Url = url.ToString();
            return this;
        }
    }
}
