//-----------------------------------------------------------------------
// <copyright file="CancelJobResponse.cs" company="Tasty Codes">
//     Copyright (c) 2010 Chad Burggraf.
// </copyright>
//-----------------------------------------------------------------------

namespace Zencoder
{
    using System;
    using System.Net;
    using Newtonsoft.Json;

    /// <summary>
    /// Implements the cancel job response.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class CancelJobResponse : Response<CancelJobRequest, CancelJobResponse>
    {
        /// <summary>
        /// Gets a value indicating whether the service indicated that the cancel request
        /// was invalid because the job was not in the "waiting" or "processing" state.
        /// </summary>
        public bool InConflict
        {
            get { return StatusCode == HttpStatusCode.Conflict; }
        }
    }
}
