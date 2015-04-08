//-----------------------------------------------------------------------
// <copyright file="CreateAccountRequest.cs" company="Tasty Codes">
//     Copyright (c) 2010 Chad Burggraf.
// </copyright>
//-----------------------------------------------------------------------

namespace Zencoder
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// Implements the create account request.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
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
        [JsonProperty("affiliate_code", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string AffiliateCode { get; set; }

        /// <summary>
        /// Gets or sets the API key to use when connecting to the service.
        /// </summary>
        [JsonIgnore]
        public override string ApiKey
        {
            get
            {
                return base.ApiKey;
            }

            protected set
            {
                base.ApiKey = value;
            }
        }

        /// <summary>
        /// Gets or sets the email to create the account with.
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to subscribe the email address to the newsletter.
        /// </summary>
        [JsonProperty("newsletter", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(BooleanConverter))]
        public bool? Newsletter { get; set; }

        /// <summary>
        /// Gets or sets the password to create the account with.
        /// </summary>
        [JsonProperty("password", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the password confirmation to create the account with.
        /// </summary>
        [JsonProperty("password_confirmation", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string PasswordConfirmation { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the terms of service are agreed to.
        /// Use 1 for true, 0 for false.
        /// </summary>
        [JsonProperty("terms_of_service", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(BooleanConverter))]
        public bool? TermsOfService { get; set; }

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
