//-----------------------------------------------------------------------
// <copyright file="S3Permission.cs" company="Tasty Codes">
//     Copyright (c) 2010 Chad Burggraf.
// </copyright>
//-----------------------------------------------------------------------

namespace Zencoder
{
    using System;
    using System.ComponentModel;
    using Newtonsoft.Json;

    /// <summary>
    /// Defines the possible Amazon S3 permissions.
    /// </summary>
    [JsonConverter(typeof(EnumDescriptionConverter))]
    public enum S3Permission
    {
        /// <summary>
        /// Identifies the grantee has read permission for the resource.
        /// </summary>
        [Description("READ")]
        Read,

        /// <summary>
        /// Identifies the grantee has write permission for the resource.
        /// </summary>
        [Description("WRITE")]
        Write,

        /// <summary>
        /// Identifies the grantee has full-controll permission for the resource.
        /// </summary>
        [Description("FULL_CONTROL")]
        FullControl
    }
}
