//-----------------------------------------------------------------------
// <copyright file="Request.cs" company="Tasty Codes">
//     Copyright (c) 2010 Chad Burggraf.
// </copyright>
//-----------------------------------------------------------------------

namespace Zencoder
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// Base class for API requests.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public abstract class Request
    {
        /// <summary>
        /// Initializes a new instance of the Request class.
        /// </summary>
        /// <param name="zencoder">The <see cref="Zencoder"/> service to create the request with.</param>
        protected Request(Zencoder zencoder)
            : this(zencoder.ApiKey, zencoder.BaseUrl)
        {
        }

        /// <summary>
        /// Initializes a new instance of the Request class.
        /// </summary>
        /// <param name="apiKey">The API key to use when connecting to the service.</param>
        /// <param name="baseUrl">The service base URL.</param>
        protected Request(string apiKey, Uri baseUrl)
        {
            if (string.IsNullOrEmpty(apiKey))
            {
                throw new ArgumentNullException("apiKey", "apiKey must contain a value.");
            }

            if (baseUrl == null)
            {
                throw new ArgumentNullException("baseUrl", "baseUrl must contain a value.");
            }

            this.ApiKey = apiKey;
            this.BaseUrl = baseUrl;
        }

        /// <summary>
        /// Gets or sets the API key to use when connecting to the service.
        /// </summary>
        [JsonProperty("api_key")]
        public virtual string ApiKey { get; protected set; }

        /// <summary>
        /// Gets or sets the service base URL.
        /// </summary>
        public Uri BaseUrl { get; protected set; }

        /// <summary>
        /// Gets the concrete URL this request will call.
        /// </summary>
        public abstract Uri Url { get; }

        /// <summary>
        /// Gets the HTTP verb to use when making the request.
        /// </summary>
        public abstract string Verb { get; }
    }
}
