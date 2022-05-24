
namespace Zencoder
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// Represents an HTTP-posted job output notification.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class HttpPostJobNotification
    {
        /// <summary>
        /// Gets or sets the job the notification relates to.
        /// </summary>
        [JsonProperty("job")]
        public HttpPostNotificationJob Job { get; set; }

        /// <summary>
        /// Gets or sets the job's output the notification relates to.
        /// </summary>
        [JsonProperty("outputs")]
        public HttpPostNotificationOutput[] Outputs { get; set; }

        /// <summary>
        /// Gets or sets the job's input the notification relates to.
        /// </summary>
        [JsonProperty("input")]
        public HttpPostNotificationInput Input { get; set; }
    }
}
