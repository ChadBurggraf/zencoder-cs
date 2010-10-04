
namespace Zencoder
{
    using System;
    using System.Net;
    using System.Runtime.Serialization;

    /// <summary>
    /// Implements the create encoding job response.
    /// </summary>
    [DataContract(Name = Response.ContractName)]
    public class CreateJobResponse : Response<CreateJobRequest, CreateJobResponse>
    {
    }
}