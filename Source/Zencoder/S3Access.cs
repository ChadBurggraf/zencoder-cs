//-----------------------------------------------------------------------
// <copyright file="S3Access.cs" company="Tasty Codes">
//     Copyright (c) 2010 Chad Burggraf.
// </copyright>
//-----------------------------------------------------------------------

namespace Zencoder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Newtonsoft.Json;

    /// <summary>
    /// Represents an AWS S3 permission grant.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class S3Access
    {
        /// <summary>
        /// Gets or sets the grantee to grant permissions for.
        /// Can be an AWS ID, an email address linked to an AWS account,
        /// or a URL defining an AWS ACL group.
        /// </summary>
        [JsonProperty("grantee")]
        public string Grantee { get; set; }

        /// <summary>
        /// Gets or sets the collection of permissions to grant this instance's grantee.
        /// </summary>
        [JsonProperty("permissions")]
        public S3Permission[] Permissions { get; set; }

        /// <summary>
        /// Appends the given <see cref="S3Permission"/> to this instance's <see cref="Permissions"/> collection.
        /// </summary>
        /// <param name="permission">The permission to append.</param>
        /// <returns>This instance.</returns>
        public S3Access WithPermission(S3Permission permission)
        {
            return this.WithPermissions(new S3Permission[] { permission });
        }

        /// <summary>
        /// Appends the given collection of <see cref="S3Permission"/>s to this instance's <see cref="Permissions"/> collection.
        /// </summary>
        /// <param name="permissions">The permissions to append.</param>
        /// <returns>This instance.</returns>
        public S3Access WithPermissions(IEnumerable<S3Permission> permissions)
        {
            if (permissions != null)
            {
                this.Permissions = (this.Permissions ?? new S3Permission[0]).Concat(permissions).ToArray();
            }

            return this;
        }
    }
}
