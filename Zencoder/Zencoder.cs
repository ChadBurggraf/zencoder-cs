

namespace Zencoder
{
    using System;
    using System.Globalization;

    /// <summary>
    /// Provides API-wide Zencoder services.
    /// </summary>
    public class Zencoder
    {
        /// <summary>
        /// Gets the query string key used to identify the API key.
        /// </summary>
        public const string ApiKeyQueryKey = "api_key";

        /// <summary>
        /// Gets the default API base URL.
        /// </summary>
        public static readonly Uri ServiceUrl = new Uri("https://app.zencoder.com/api");

        /// <summary>
        /// Initializes a new instance of the Zencoder class.
        /// </summary>
        /// <param name="apiKey">The API key to use when connecting to the service.</param>
        public Zencoder(string apiKey)
            : this(apiKey, ServiceUrl)
        {
        }

        /// <summary>
        /// Initializes a new instance of the Zencoder class.
        /// </summary>
        /// <param name="apiKey">The API key to use when connecting to the service.</param>
        /// <param name="baseUrl">The service base URL.</param>
        public Zencoder(string apiKey, Uri baseUrl)
        {
            if (String.IsNullOrEmpty(apiKey))
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
        /// Gets the API key to use when connecting to the service.
        /// </summary>
        public string ApiKey { get; private set; }

        /// <summary>
        /// Gets the service base URL.
        /// </summary>
        public Uri BaseUrl { get; private set; }

        /// <summary>
        /// A blocking create account request/response cycle.
        /// </summary>
        /// <param name="email">The email address to create the account with.</param>
        /// <param name="password">The password to create the account with.</param>
        /// <param name="affiliateCode">The affiliate code to create the account with, if applicable.</param>
        /// <param name="termsOfService">A value indicating whether the terms of service are agreed to.</param>
        /// <param name="newsletter">A value indicating whether to subscribe the email address to the newsletter.</param>
        /// <returns>The call response.</returns>
        public static CreateAccountResponse CreateAccount(string email, string password, string affiliateCode, bool termsOfService, bool newsletter)
        {
            return CreateAccount(email, password, affiliateCode, termsOfService, newsletter, ServiceUrl);
        }

        /// <summary>
        /// A blocking create account request/response cycle.
        /// </summary>
        /// <param name="email">The email address to create the account with.</param>
        /// <param name="password">The password to create the account with.</param>
        /// <param name="affiliateCode">The affiliate code to create the account with, if applicable.</param>
        /// <param name="termsOfService">A value indicating whether the terms of service are agreed to.</param>
        /// <param name="newsletter">A value indicating whether to subscribe the email address to the newsletter.</param>
        /// <param name="baseUrl">The service base URL.</param>
        /// <returns>The call response.</returns>
        public static CreateAccountResponse CreateAccount(string email, string password, string affiliateCode, bool termsOfService, bool newsletter, Uri baseUrl)
        {
            return new CreateAccountRequest(baseUrl)
            {
                AffiliateCode = affiliateCode,
                Email = email,
                Newsletter = (newsletter ? 1 : 0).ToString(CultureInfo.InvariantCulture),
                Password = password,
                TermsOfService = (termsOfService ? 1 : 0).ToString(CultureInfo.InvariantCulture)
            }.GetResponse();
        }

        /// <summary>
        /// A non blocking create account request/response cycle.
        /// </summary>
        /// <param name="email">The email address to create the account with.</param>
        /// <param name="password">The password to create the account with.</param>
        /// <param name="affiliateCode">The affiliate code to create the account with, if applicable.</param>
        /// <param name="termsOfService">A value indicating whether the terms of service are agreed to.</param>
        /// <param name="newsletter">A value indicating whether to subscribe the email address to the newsletter.</param>
        /// <param name="callback">The call response.</param>
        public static void CreateAccount(string email, string password, string affiliateCode, bool termsOfService, bool newsletter, Action<CreateAccountResponse> callback)
        {
            CreateAccount(email, password, affiliateCode, termsOfService, newsletter, ServiceUrl, callback);
        }

        /// <summary>
        /// A non blocking create account request/response cycle.
        /// </summary>
        /// <param name="email">The email address to create the account with.</param>
        /// <param name="password">The password to create the account with.</param>
        /// <param name="affiliateCode">The affiliate code to create the account with, if applicable.</param>
        /// <param name="termsOfService">A value indicating whether the terms of service are agreed to.</param>
        /// <param name="newsletter">A value indicating whether to subscribe the email address to the newsletter.</param>
        /// <param name="baseUrl">The service base URL.</param>
        /// <param name="callback">The call response.</param>
        public static void CreateAccount(string email, string password, string affiliateCode, bool termsOfService, bool newsletter, Uri baseUrl, Action<CreateAccountResponse> callback)
        {
            new CreateAccountRequest(baseUrl)
            {
                AffiliateCode = affiliateCode,
                Email = email,
                Newsletter = (newsletter ? 1 : 0).ToString(CultureInfo.InvariantCulture),
                Password = password,
                TermsOfService = (termsOfService ? 1 : 0).ToString(CultureInfo.InvariantCulture)
            }.GetResponseAsync(callback);
        }

        /// <summary>
        /// A blocking account details request/response cycle.
        /// </summary>
        /// <returns>The call response.</returns>
        public AccountDetailsResponse AccountDetails()
        {
            return new AccountDetailsRequest(this).GetResponse();
        }

        /// <summary>
        /// A non blocking account details request/response cycle.
        /// </summary>
        /// <param name="callback">The call response.</param>
        public void AccountDetails(Action<AccountDetailsResponse> callback)
        {
            new AccountDetailsRequest(this).GetResponseAsync(callback);
        }

        /// <summary>
        /// A blocking account integration mode request/response cycle.
        /// </summary>
        /// <param name="enable">A value indicating whether to enable integration mode for the account.</param>
        /// <returns>The call response.</returns>
        public AccountIntegrationModeResponse AccountIntegrationMode(bool enable)
        {
            return new AccountIntegrationModeRequest(this)
            {
                Enable = enable
            }.GetResponse();
        }

        /// <summary>
        /// A non blocking account integration mode request/response cycle.
        /// </summary>
        /// <param name="enable">A value indicating whether to enable integration mode for the account.</param>
        /// <param name="callback">The call response.</param>
        public void AccountIntegrationMode(bool enable, Action<AccountIntegrationModeResponse> callback)
        {
            new AccountIntegrationModeRequest(this)
            {
                Enable = enable
            }.GetResponseAsync(callback);
        }
    }
}
