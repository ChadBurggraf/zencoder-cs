//-----------------------------------------------------------------------
// <copyright file="AccountIntegrationModeRequest.cs" company="Tasty Codes">
//     Copyright (c) 2010 Chad Burggraf.
// </copyright>
//-----------------------------------------------------------------------

namespace Zencoder
{
    using System;
    using System.IO;
    using Newtonsoft.Json;

    /// <summary>
    /// Implements the account integration mode request.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class AccountIntegrationModeRequest : Request<AccountIntegrationModeRequest, AccountIntegrationModeResponse>
    {
        /// <summary>
        /// Initializes a new instance of the AccountIntegrationModeRequest class.
        /// </summary>
        /// <param name="zencoder">The <see cref="Zencoder"/> service to create the request with.</param>
        public AccountIntegrationModeRequest(Zencoder zencoder)
            : base(zencoder)
        {
        }

        /// <summary>
        /// Initializes a new instance of the AccountIntegrationModeRequest class.
        /// </summary>
        /// <param name="apiKey">The API key to use when connecting to the service.</param>
        /// <param name="baseUrl">The service base URL.</param>
        public AccountIntegrationModeRequest(string apiKey, Uri baseUrl)
            : base(apiKey, baseUrl)
        {
        }

        /// <summary>
        /// Gets or sets a value indicating whether to enable integration mode for the account.
        /// </summary>
        public bool Enable { get; set; }

        /// <summary>
        /// Gets the concrete URL this request will call.
        /// </summary>
        public override Uri Url
        {
            get
            {
                return (this.Enable ?
                    BaseUrl.AppendPath("account/integration") :
                    BaseUrl.AppendPath("account/live")).WithApiKey(ApiKey);
            }
        }

        /// <summary>
        /// Gets the HTTP verb to use when making the request.
        /// </summary>
        public override string Verb
        {
            get { return "GET"; }
        }

        /// <summary>
        /// Reads any data from the response stream into a new <see cref="Response"/> instance.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <returns>The created response.</returns>
        protected override AccountIntegrationModeResponse ReadResponse(Stream stream)
        {
            return new AccountIntegrationModeResponse();
        }
    }
}
