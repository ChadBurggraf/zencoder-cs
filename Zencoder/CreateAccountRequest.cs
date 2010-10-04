
namespace Zencoder
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Implements the create account request.
    /// </summary>
    [DataContract(Name = Request.ContractName)]
    public class CreateAccountRequest : Request<CreateAccountRequest, CreateAccountResponse>
    {
        /// <summary>
        /// Initializes a new instance of the CreateAccountRequest class.
        /// </summary>
        /// <param name="zencoder">The <see cref="Zencoder"/> service to create the request with.</param>
        public CreateAccountRequest(Zencoder zencoder)
            : base(Guid.NewGuid().ToString(), zencoder.BaseUrl)
        {
        }

        /// <summary>
        /// Initializes a new instance of the CreateAccountRequest class.
        /// </summary>
        /// <param name="baseUrl">The service base URL.</param>
        public CreateAccountRequest(Uri baseUrl)
            : base(Guid.NewGuid().ToString(), baseUrl)
        {
        }

        /// <summary>
        /// Gets or sets the affiliate code to create the account with, if applicable.
        /// </summary>
        [DataMember(Name = "affiliate_code")]
        public string AffiliateCode { get; set; }

        /// <summary>
        /// Gets or sets the email to create the account with.
        /// </summary>
        [DataMember(Name = "email")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to subscribe the email address to the newsletter.
        /// User 1 for true, 0 for false.
        /// </summary>
        [DataMember(Name = "newsletter")]
        public string Newsletter { get; set; }

        /// <summary>
        /// Gets or sets the password to create the account with.
        /// </summary>
        [DataMember(Name = "password")]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the terms of service are agreed to.
        /// Use 1 for true, 0 for false.
        /// </summary>
        [DataMember(Name = "terms_of_service")]
        public string TermsOfService { get; set; }

        /// <summary>
        /// Gets the concrete URL this request will call.
        /// </summary>
        public override Uri Url
        {
            get { return BaseUrl.AppendPath("account"); }
        }

        /// <summary>
        /// Gets the HTTP verb to use when making the request.
        /// </summary>
        public override string Verb
        {
            get { return "POST"; }
        }
    }
}
