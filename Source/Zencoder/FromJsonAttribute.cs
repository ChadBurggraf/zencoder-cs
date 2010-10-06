//-----------------------------------------------------------------------
// <copyright file="FromJsonAttribute.cs" company="Tasty Codes">
//     Copyright (c) 2010 Chad Burggraf.
// </copyright>
//-----------------------------------------------------------------------

namespace Zencoder
{
    using System;

    /// <summary>
    /// Defines a custom method to use when converting a <see cref="Response"/> from JSON.
    /// </summary>
    public abstract class FromJsonAttribute : Attribute
    {
        /// <summary>
        /// Gets or sets the name of the static method to use when converting the response from JSON.
        /// </summary>
        public string Method { get; set; }

        /// <summary>
        /// Gets or sets the type to use when converting the response from JSON.
        /// </summary>
        public Type Type { get; set; }
    }
}
