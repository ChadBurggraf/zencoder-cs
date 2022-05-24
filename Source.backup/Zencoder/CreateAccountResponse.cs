//-----------------------------------------------------------------------
// <copyright file="CreateAccountResponse.cs" company="Tasty Codes">
//     Copyright (c) 2010 Chad Burggraf.
// </copyright>
//-----------------------------------------------------------------------

namespace Zencoder
{
    using System;
    using System.Net;
    using Newtonsoft.Json;

    /// <summary>
    /// Implements the create account response.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class CreateAccountResponse : Response<CreateAccountRequest, CreateAccountResponse>
    {
        /// <summary>
        /// Gets or sets the account's new API key.
        /// </summary>
        [JsonProperty("api_key")]
        public string ApiKey { get; set; }

        /// <summary>
        /// Gets or sets the account's password.
        /// </summary>
        [JsonProperty("password")]
        public string Password { get; set; }

        /// <summary>
        /// Gets a value indicating whether the request was successful.
        /// </summary>
        public override bool Success
        {
            get { return RequestException == null && StatusCode == HttpStatusCode.Created; }
        }
    }
}
