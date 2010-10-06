//-----------------------------------------------------------------------
// <copyright file="DeleteJobResponse.cs" company="Tasty Codes">
//     Copyright (c) 2010 Chad Burggraf.
// </copyright>
//-----------------------------------------------------------------------

namespace Zencoder
{
    using System;
    using System.Net;
    using Newtonsoft.Json;

    /// <summary>
    /// Implements the delete job response.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class DeleteJobResponse : Response<DeleteJobRequest, DeleteJobResponse>
    {
        /// <summary>
        /// Gets a value indicating whether the service indicated that the delete request
        /// was invalid because the job was in the "finished" state.
        /// </summary>
        public bool InConflict
        {
            get { return StatusCode == HttpStatusCode.Conflict; }
        }
    }
}
