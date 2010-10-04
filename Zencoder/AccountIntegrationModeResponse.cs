
namespace Zencoder
{
    using System;
    using System.Net;
    using System.Runtime.Serialization;

    /// <summary>
    /// Implements the account integration mode response.
    /// </summary>
    [DataContract(Name = Response.ContractName)]
    public class AccountIntegrationModeResponse : Response<AccountDetailsRequest, AccountIntegrationModeResponse>
    {
    }
}
