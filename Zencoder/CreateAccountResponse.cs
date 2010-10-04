
namespace Zencoder
{
    using System;
    using System.Net;
    using System.Runtime.Serialization;

    /// <summary>
    /// Implements the create account response.
    /// </summary>
    [DataContract(Name = Response.ContractName)]
    public class CreateAccountResponse : Response<CreateAccountRequest, CreateAccountResponse>
    {
        /// <summary>
        /// Gets or sets the account's new API key.
        /// </summary>
        [DataMember(Name = "api_key")]
        public string ApiKey { get; set; }

        /// <summary>
        /// Gets or sets the account's password.
        /// </summary>
        [DataMember(Name = "password")]
        public string Password { get; set; }

        /// <summary>
        /// Gets a value indicating whether the request was successful.
        /// </summary>
        public override bool Success
        {
            get { return StatusCode == HttpStatusCode.Created; }
        }
    }
}
