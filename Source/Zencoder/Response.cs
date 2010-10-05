

namespace Zencoder
{
    using System;
    using System.Net;
    using Newtonsoft.Json;

    /// <summary>
    /// Base class for API responses.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public abstract class Response
    {
        private string[] errors;

        /// <summary>
        /// Gets or sets the error collection that was returned in the response.
        /// </summary>
        [JsonProperty("errors")]
        public string[] Errors
        {
            get { return this.errors ?? (this.errors = new string[0]); }
            set { this.errors = value; }
        }

        /// <summary>
        /// Gets the HTTP status code that was returned in the response.
        /// </summary>
        public HttpStatusCode StatusCode { get; internal set; }

        /// <summary>
        /// Gets a value indicating whether the request was successful.
        /// </summary>
        public virtual bool Success
        {
            get { return this.StatusCode == HttpStatusCode.OK; }
        }
    }
}