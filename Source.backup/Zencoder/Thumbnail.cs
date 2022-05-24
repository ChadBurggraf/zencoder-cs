//-----------------------------------------------------------------------
// <copyright file="Thumbnail.cs" company="Tasty Codes">
//     Copyright (c) 2011 Thomas Petersen.
// </copyright>
//-----------------------------------------------------------------------

namespace Zencoder
{
    using System;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Represents a thumbnail in a <see cref="Job"/>.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class Thumbnail
    {
        /// <summary>
        /// Gets or sets date and time the thumbnail was created
        /// </summary>
        [JsonProperty("created_at")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets size of the thumbnail
        /// </summary>
        [JsonProperty("file_size_bytes")]
        public long? FileSize { get; set; }

        /// <summary>
        /// Gets or sets format of the thumbnail
        /// </summary>
        [JsonProperty("format")]
        public ThumbnailFormat? Format { get; set; }

        /// <summary>
        /// Gets or sets Group Label (Important if you have several thumbnail groups)
        /// </summary>
        [JsonProperty("group_label")]
        public string GroupLabel { get; set; }

        /// <summary>
        /// Gets or sets height of the thumbnail
        /// </summary>
        [JsonProperty("height")]
        public int? Height { get; set; }

        /// <summary>
        /// Gets or sets ID of the thumbnail
        /// </summary>
        [JsonProperty("id")]
        public long? Id { get; set; }

        /// <summary>
        /// Gets or sets date and time the thumbnail was updated
        /// </summary>
        [JsonProperty("updated_at")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// Gets or sets url to retrieve the generated thumbnail
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets width of the thumbnail
        /// </summary>
        [JsonProperty("width")]
        public int? Width { get; set; }
    }
}