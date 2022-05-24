using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zencoder
{
    using System;
    using Newtonsoft.Json;
    /// <summary>
    /// Implements the image notification type
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class HttpPostNotificationImage
    {
        /// <summary>
        /// Gets or sets the image url.
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the image format.
        /// </summary>
        [JsonProperty("format")]
        public string Format { get; set; }

        /// <summary>
        /// Gets or sets the image file size.
        /// </summary>
        [JsonProperty("file_size_bytes")]
        public long? FileSizeBytes { get; set; }

        /// <summary>
        /// Gets or sets the image dimensions.
        /// </summary>
        [JsonProperty("dimensions")]
        public string Dimensions { get; set; }

        /// <summary>
        /// Get the Width of the Image
        /// </summary>
        /// <returns>The image width</returns>
        public string Width()
        {
            if(Dimensions != null)
            {
                return Dimensions.Split('x')[0];
            }

            return "";
        }

        /// <summary>
        /// Get the Height of the Image
        /// </summary>
        /// <returns>The image height</returns>
        public string Height()
        {
            if (Dimensions != null)
            {
                return Dimensions.Split('x')[1];
            }

            return "";
        }
    }
}
