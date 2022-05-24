
namespace Zencoder
{
    using System;
    using Newtonsoft.Json;
    /// <summary>
    /// Implements the notification thumbnail type
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class HttpPostNotificationThumbnail
    {
        /// <summary>
        /// Gets or sets the thumbnail label.
        /// </summary>
        [JsonProperty("label")]
        public string Label { get; set; }

        /// <summary>
        /// Gets or sets the thumbnail images.
        /// </summary>
        [JsonProperty("images")]
        public HttpPostNotificationImage[] Images { get; set; }
    }
}
