//-----------------------------------------------------------------------
// <copyright file="FromJsonStringAttribute.cs" company="Tasty Codes">
//     Copyright (c) 2010 Chad Burggraf.
// </copyright>
//-----------------------------------------------------------------------

namespace Zencoder
{
    using System;

    /// <summary>
    /// Defines a custom method to use when converting a <see cref="Response"/> from JSON.
    /// The method must be static, return the type's concrete <see cref="Response"/> and
    /// must accept a <see cref="String"/>.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public sealed class FromJsonStringAttribute : FromJsonAttribute
    {
    }
}
