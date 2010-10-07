//-----------------------------------------------------------------------
// <copyright file="NotificationTests.cs" company="Tasty Codes">
//     Copyright (c) 2010 Chad Burggraf.
// </copyright>
//-----------------------------------------------------------------------

namespace Zencoder.Test
{
    using System;
    using System.IO;
    using System.Text;
    using System.Threading;
    using System.Web;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Newtonsoft.Json;

    /// <summary>
    /// Notification tests.
    /// </summary>
    [TestClass]
    public class NotificationTests
    {
        private const string NotificationJson = @"{""job"":{""state"":""processing"",""id"":1234},""output"":{""label"":""web"",""url"":""http://example.com/file.mp4"",""state"":""processing"",""id"":12345}}";
        private static AutoResetEvent receiverHandle = new AutoResetEvent(false);

        /// <summary>
        /// Initializes the class for testing.
        /// </summary>
        /// <param name="context">The current test context.</param>
        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            NotificationHandler.Receivers.Add(new TestNotificationReceiver());
        }

        /// <summary>
        /// Notification handler process request tests.
        /// </summary>
        [TestMethod]
        public void NotificationHandlerProcessRequest()
        {
            using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(NotificationJson)))
            {
                var mockContext = new Mock<HttpContextBase>()
                {
                    DefaultValue = DefaultValue.Mock
                };

                var mockRequest = new Mock<HttpRequestBase>()
                {
                    DefaultValue = DefaultValue.Mock
                };

                mockRequest.Setup(r => r.ContentType).Returns("application/json");
                mockRequest.Setup(r => r.HttpMethod).Returns("POST");
                mockRequest.Setup(r => r.InputStream).Returns(stream);

                mockContext.Setup(c => c.Request).Returns(mockRequest.Object);

                NotificationHandler.ProcessRequest(mockContext.Object);

                WaitHandle.WaitAll(new WaitHandle[] { receiverHandle });
            }
        }

        /// <summary>
        /// HTTP POST notification from JSON tests.
        /// </summary>
        [TestMethod]
        public void NotificationHttpPostNotificationFromJson()
        {
            HttpPostNotification notification = JsonConvert.DeserializeObject<HttpPostNotification>(NotificationJson);
            Assert.AreEqual(JobState.Processing, notification.Job.State);
            Assert.AreEqual("http://example.com/file.mp4", notification.Output.Url);
        }

        #region TestNotificationReceiver Class

        /// <summary>
        /// Test <see cref="INotificationReceiver"/> implementation.
        /// </summary>
        private class TestNotificationReceiver : INotificationReceiver
        {
            /// <summary>
            /// Called when a notification is received.
            /// </summary>
            /// <param name="notification">The notification that was received.</param>
            public void OnReceive(HttpPostNotification notification)
            {
                Assert.IsNotNull(notification);
                Assert.AreEqual(1234, notification.Job.Id);
                Assert.AreEqual("web", notification.Output.Label);
                receiverHandle.Set();
            }
        }

        #endregion
    }
}
