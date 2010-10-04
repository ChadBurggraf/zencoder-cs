

namespace Zencoder.Test
{
    using System;
    using System.Configuration;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Base class for tests.
    /// </summary>
    [TestClass]
    public abstract class TestBase
    {
        /// <summary>
        /// Gets the currently configured API key.
        /// </summary>
        public static readonly string ApiKey = ConfigurationManager.AppSettings["ZencoderApiKey"];

        /// <summary>
        /// Gets the default test <see cref="Zencoder"/> instance.
        /// </summary>
        public static readonly Zencoder Zencoder = new Zencoder(ApiKey);
    }
}
