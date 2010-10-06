//-----------------------------------------------------------------------
// <copyright file="AccountIntegrationModeResponse.cs" company="Tasty Codes">
//     Copyright (c) 2010 Chad Burggraf.
// </copyright>
//-----------------------------------------------------------------------

namespace Zencoder
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// Implements the account integration mode response.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class AccountIntegrationModeResponse : Response<AccountDetailsRequest, AccountIntegrationModeResponse>
    {
    }
}
