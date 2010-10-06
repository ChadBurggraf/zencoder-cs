//-----------------------------------------------------------------------
// <copyright file="ResubmitJobResponse.cs" company="Tasty Codes">
//     Copyright (c) 2010 Chad Burggraf.
// </copyright>
//-----------------------------------------------------------------------

namespace Zencoder
{
    using System;
    using System.Net;
    using Newtonsoft.Json;

    /// <summary>
    /// Implements the resubmit job response.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class ResubmitJobResponse : Response<ResubmitJobRequest, ResubmitJobResponse>
    {
        /// <summary>
        /// Gets a value indicating whether the service indicated that the resubmit request
        /// was invalid because the job was not in the "finished" state.
        /// </summary>
        public bool InConflict
        {
            get { return StatusCode == HttpStatusCode.Conflict; }
        }
    }
}
