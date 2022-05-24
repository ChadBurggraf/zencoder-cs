//-----------------------------------------------------------------------
// <copyright file="AccountDetailsResponse.cs" company="Tasty Codes">
//     Copyright (c) 2010 Chad Burggraf.
// </copyright>
//-----------------------------------------------------------------------

namespace Zencoder
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// Implements the account details response.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class AccountDetailsResponse : Response<AccountDetailsRequest, AccountDetailsResponse>
    {
        /// <summary>
        /// Gets or sets the account's current state.
        /// Sorry about the string, kids. Could't find an exhaustive list of states.
        /// </summary>
        [JsonProperty("account_state")]
        public string AccountState { get; set; }

        /// <summary>
        /// Gets or sets the account's current billing state.
        /// Sorry about the string, kids. Could't find an exhaustive list of states.
        /// </summary>
        [JsonProperty("billing_state")]
        public string BillingState { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the account is in integration mode.
        /// </summary>
        [JsonProperty("integration_mode")]
        [JsonConverter(typeof(BooleanConverter))]
        public bool IntegrationMode { get; set; }

        /// <summary>
        /// Gets or sets the number of minutes included in the account's plan.
        /// </summary>
        [JsonProperty("minutes_included")]
        public int MinutesIncluded { get; set; }

        /// <summary>
        /// Gets or sets the number of minutes used by the account.
        /// </summary>
        [JsonProperty("minutes_used")]
        public int MinutesUsed { get; set; }

        /// <summary>
        /// Gets or sets the account's plan.
        /// </summary>
        [JsonProperty("plan")]
        public string Plan { get; set; }
    }
}
