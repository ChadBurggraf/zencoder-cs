//-----------------------------------------------------------------------
// <copyright file="ZencoderSettings.cs" company="Tasty Codes">
//     Copyright (c) 2010 Chad Burggraf.
// </copyright>
//-----------------------------------------------------------------------

namespace Zencoder
{
    using System;
    using System.Configuration;

    /// <summary>
    /// Implements <see cref="ConfigurationSection"/> for the Zencoder configuration settings.
    /// </summary>
    public class ZencoderSettings : ConfigurationSection
    {
        private static ZencoderSettings settings = (ZencoderSettings)(ConfigurationManager.GetSection("zencoder") ?? new ZencoderSettings());

        /// <summary>
        /// Gets the configuration section from the current configuration.
        /// </summary>
        public static ZencoderSettings Section
        {
            get { return settings; }
        }

        /// <summary>
        /// Gets or sets the default API to use.
        /// </summary>
        [ConfigurationProperty("apiKey", IsRequired = false)]
        public string ApiKey
        {
            get { return (string)this["apiKey"]; }
            set { this["apiKey"] = value; }
        }

        /// <summary>
        /// Gets a collection of named types that implement <see cref="INotificationReceiver"/> that should be 
        /// notifiied when a notification is received.
        /// </summary>
        [ConfigurationProperty("notifications")]
        public NameValueConfigurationCollection Notifications
        {
            get { return (NameValueConfigurationCollection)(this["notifications"] ?? (this["notifications"] = new NameValueConfigurationCollection())); }
        }

        /// <summary>
        /// Gets a value indicating whether this ConfigurationSection is read only.
        /// </summary>
        /// <returns>True if the section is read only, false otherwise.</returns>
        public override bool IsReadOnly()
        {
            return false;
        }
    }
}
