
namespace Zencoder
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// Implements the create encoding job response.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class CreateJobResponse : Response<CreateJobRequest, CreateJobResponse>
    {
    }
}