
namespace Zencoder
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Implements the account details request.
    /// </summary>
    [DataContract(Name = Request.ContractName)]
    public class AccountDetailsRequest : Request<AccountDetailsRequest, AccountDetailsResponse>
    {
        /// <summary>
        /// Initializes a new instance of the AccountDetailsRequest class.
        /// </summary>
        /// <param name="zencoder">The <see cref="Zencoder"/> service to create the request with.</param>
        public AccountDetailsRequest(Zencoder zencoder)
            : base(zencoder)
        {
        }

        /// <summary>
        /// Initializes a new instance of the AccountDetailsRequest class.
        /// </summary>
        /// <param name="apiKey">The API key to use when connecting to the service.</param>
        /// <param name="baseUrl">The service base URL.</param>
        public AccountDetailsRequest(string apiKey, Uri baseUrl)
            : base(apiKey, baseUrl)
        {
        }

        /// <summary>
        /// Gets the concrete URL this request will call.
        /// </summary>
        public override Uri Url
        {
            get { return BaseUrl.AppendPath("account").WithApiKey(ApiKey); }
        }

        /// <summary>
        /// Gets the HTTP verb to use when making the request.
        /// </summary>
        public override string Verb
        {
            get { return "GET"; }
        }
    }
}
