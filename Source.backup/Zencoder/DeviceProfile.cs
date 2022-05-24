//-----------------------------------------------------------------------
// <copyright file="DeviceProfile.cs" company="Tasty Codes">
//     Copyright (c) 2011 Chad Burggraf.
// </copyright>
//-----------------------------------------------------------------------

namespace Zencoder
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// Defines the possible output device profile shortcuts.
    /// </summary>
    public enum DeviceProfile
    {
        /// <summary>
        /// Identifies the mobile/advanced profile.
        /// </summary>
        [Description("mobile/advanced")]
        MobileAdvanced,

        /// <summary>
        /// Identifies the mobile/baseline profile.
        /// </summary>
        [Description("mobile/baseline")]
        MobileBaseline,

        /// <summary>
        /// Identifies the mobile/legacy profile.
        /// </summary>
        [Description("mobile/legacy")]
        MobileLegacy,

        /// <summary>
        /// Identifies the v1/mobile/advanced profile.
        /// </summary>
        [Description("v1/mobile/advanced")]
        V1MobileAdvanced,

        /// <summary>
        /// Identifies the v1/mobile/baseline profile.
        /// </summary>
        [Description("v1/mobile/baseline")]
        V1MobileBaseline,

        /// <summary>
        /// Identifies the v1/mobile/legacy profile.
        /// </summary>
        [Description("v1/mobile/legacy")]
        V1MobileLegacy,

        /// <summary>
        /// Identifies the v2/mobile/legacy profile.
        /// </summary>
        [Description("v2/mobile/legacy")]
        V2MobileLegacy
    }
}
