//-----------------------------------------------------------------------
// <copyright file="AccountTests.cs" company="Tasty Codes">
//     Copyright (c) 2010 Chad Burggraf.
// </copyright>
//-----------------------------------------------------------------------

namespace Zencoder.Test
{
    using System;
    using System.Threading;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Account tests.
    /// </summary>
    [TestClass]
    public class AccountTests : TestBase
    {
        /// <summary>
        /// Account details request tests.
        /// </summary>
        [TestMethod]
        public void AccountAccountDetailsRequest()
        {
            AccountDetailsResponse response = Zencoder.AccountDetails();
            Assert.IsTrue(response.Success);

            AutoResetEvent[] handles = new AutoResetEvent[] { new AutoResetEvent(false) };

            Zencoder.AccountDetails(r =>
            {
                Assert.IsTrue(r.Success);
                handles[0].Set();
            });

            WaitHandle.WaitAll(handles);
        }

        /// <summary>
        /// Account details response tests.
        /// </summary>
        [TestMethod]
        public void AccountAccountDetailsResponseFromJson()
        {
            AccountDetailsResponse response = AccountDetailsResponse.FromJson(@"{""account_state"":""active"",""plan"":""Growth"",""minutes_used"":12549,""minutes_included"":25000,""billing_state"":""active"",""integration_mode"":true}");
            Assert.AreEqual("active", response.AccountState);
            Assert.AreEqual(true, response.IntegrationMode);
            Assert.AreEqual(12549, response.MinutesUsed);
        }

        /// <summary>
        /// Account integration mode request tests.
        /// </summary>
        [TestMethod]
        public void AccountAccountIntegrationModeRequest()
        {
            AccountIntegrationModeResponse response = Zencoder.AccountIntegrationMode(true);
            Assert.IsTrue(response.Success);

            AutoResetEvent[] handles = new AutoResetEvent[] { new AutoResetEvent(false) };

            Zencoder.AccountIntegrationMode(
                true, 
                r =>
                {
                    Assert.IsTrue(r.Success);
                    handles[0].Set();
                });

            WaitHandle.WaitAll(handles);
        }

        /// <summary>
        /// Create account request tests.
        /// </summary>
        [TestMethod]
        public void AccountCreateAccountRequest()
        {
            CreateAccountResponse response = Zencoder.CreateAccount(Guid.NewGuid().ToString() + "@tastycodes.com", Guid.NewGuid().ToString(), null, true, false);
            Assert.IsTrue(response.Success);

            AutoResetEvent[] handles = new AutoResetEvent[] { new AutoResetEvent(false) };

            Zencoder.CreateAccount(
                Guid.NewGuid().ToString() + "@tastycodes.com", 
                Guid.NewGuid().ToString(), 
                null, 
                true, 
                false, 
                r =>
                {
                    Assert.IsTrue(r.Success);
                    handles[0].Set();
                });

            WaitHandle.WaitAll(handles);
        }

        /// <summary>
        /// Create account request to JSON tests.
        /// </summary>
        [TestMethod]
        public void AccountCreateAccountRequestToJson()
        {
            CreateAccountRequest request = new CreateAccountRequest(Zencoder.BaseUrl)
            {
                AffiliateCode = "asdf1234",
                Email = "test@tastycodes.com",
                Newsletter = true,
                Password = "1234",
                TermsOfService = true
            };

            Assert.AreEqual(
                @"{""affiliate_code"":""asdf1234"",""email"":""test@tastycodes.com"",""newsletter"":""1"",""password"":""1234"",""terms_of_service"":""1""}", 
                request.ToJson());
        }

        /// <summary>
        /// Create account response from JSON tests.
        /// </summary>
        [TestMethod]
        public void AccountCreateAccountResponseFromJson()
        {
            CreateAccountResponse response = CreateAccountResponse.FromJson(@"{""api_key"":""a123afdaf23fa231245fadcbbb"",""password"":""1234""}");
            Assert.AreEqual("a123afdaf23fa231245fadcbbb", response.ApiKey);
            Assert.AreEqual("1234", response.Password);
        }
    }
}
