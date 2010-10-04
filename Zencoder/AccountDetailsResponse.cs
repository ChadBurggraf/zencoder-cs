
namespace Zencoder
{
    using System;
    using System.Net;
    using System.Runtime.Serialization;

    /// <summary>
    /// Implements the account details response.
    /// </summary>
    [DataContract(Name = Response.ContractName)]
    public class AccountDetailsResponse : Response<AccountDetailsRequest, AccountDetailsResponse>
    {
        /// <summary>
        /// Gets or sets the account's current state.
        /// Sorry about the string, kids. Could't find an exhaustive list of states.
        /// </summary>
        [DataMember(Name = "account_state")]
        public string AccountState { get; set; }

        /// <summary>
        /// Gets or sets the account's current billing state.
        /// Sorry about the string, kids. Could't find an exhaustive list of states.
        /// </summary>
        [DataMember(Name = "billing_state")]
        public string BillingState { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the account is in integration mode.
        /// </summary>
        [DataMember(Name = "integration_mode")]
        public bool IntegrationMode { get; set; }

        /// <summary>
        /// Gets or sets the number of minutes included in the account's plan.
        /// </summary>
        [DataMember(Name = "minutes_included")]
        public int MinutesIncluded { get; set; }

        /// <summary>
        /// Gets or sets the number of minutes used by the account.
        /// </summary>
        [DataMember(Name = "minutes_used")]
        public int MinutesUsed { get; set; }

        /// <summary>
        /// Gets or sets the account's plan.
        /// </summary>
        [DataMember(Name = "plan")]
        public string Plan { get; set; }
    }
}
