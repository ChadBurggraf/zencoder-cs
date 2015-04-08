//-----------------------------------------------------------------------
// <copyright file="Zencoder.cs" company="Tasty Codes">
//     Copyright (c) 2010 Chad Burggraf.
// </copyright>
//-----------------------------------------------------------------------

namespace Zencoder
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    /// <summary>
    /// Provides API-wide Zencoder services.
    /// </summary>
    public class Zencoder
    {
        /// <summary>
        /// Gets the query string key used to identify the API key.
        /// </summary>
        public const string ApiKeyQueryKey = "api_key";

        /// <summary>
        /// Gets the default API base URL.
        /// </summary>
        public static readonly Uri ServiceUrl = new Uri("https://app.zencoder.com/api/v1");

        /// <summary>
        /// Initializes a new instance of the Zencoder class.
        /// </summary>
        public Zencoder()
            : this(ZencoderSettings.Section.ApiKey, ServiceUrl)
        {
        }

        /// <summary>
        /// Initializes a new instance of the Zencoder class.
        /// </summary>
        /// <param name="apiKey">The API key to use when connecting to the service.</param>
        public Zencoder(string apiKey)
            : this(apiKey, ServiceUrl)
        {
        }

        /// <summary>
        /// Initializes a new instance of the Zencoder class.
        /// </summary>
        /// <param name="apiKey">The API key to use when connecting to the service.</param>
        /// <param name="baseUrl">The service base URL.</param>
        public Zencoder(string apiKey, Uri baseUrl)
        {
            if (string.IsNullOrEmpty(apiKey))
            {
                throw new ArgumentNullException("apiKey", "apiKey must contain a value.");
            }

            if (baseUrl == null)
            {
                throw new ArgumentNullException("baseUrl", "baseUrl must contain a value.");
            }

            this.ApiKey = apiKey;
            this.BaseUrl = baseUrl;
        }

        /// <summary>
        /// Gets the API key to use when connecting to the service.
        /// </summary>
        public string ApiKey { get; private set; }

        /// <summary>
        /// Gets the service base URL.
        /// </summary>
        public Uri BaseUrl { get; private set; }

        /// <summary>
        /// A blocking create account request/response cycle.
        /// </summary>
        /// <param name="email">The email address to create the account with.</param>
        /// <param name="password">The password to create the account with.</param>
        /// <param name="affiliateCode">The affiliate code to create the account with, if applicable.</param>
        /// <param name="termsOfService">A value indicating whether the terms of service are agreed to.</param>
        /// <param name="newsletter">A value indicating whether to subscribe the email address to the newsletter.</param>
        /// <returns>The call response.</returns>
        public static CreateAccountResponse CreateAccount(string email, string password, string affiliateCode, bool? termsOfService, bool? newsletter)
        {
            return CreateAccount(email, password, affiliateCode, termsOfService, newsletter, ServiceUrl);
        }

        /// <summary>
        /// A blocking create account request/response cycle.
        /// </summary>
        /// <param name="email">The email address to create the account with.</param>
        /// <param name="password">The password to create the account with.</param>
        /// <param name="affiliateCode">The affiliate code to create the account with, if applicable.</param>
        /// <param name="termsOfService">A value indicating whether the terms of service are agreed to.</param>
        /// <param name="newsletter">A value indicating whether to subscribe the email address to the newsletter.</param>
        /// <param name="baseUrl">The service base URL.</param>
        /// <returns>The call response.</returns>
        public static CreateAccountResponse CreateAccount(string email, string password, string affiliateCode, bool? termsOfService, bool? newsletter, Uri baseUrl)
        {
            CreateAccountRequest request = new CreateAccountRequest(baseUrl)
            {
                AffiliateCode = affiliateCode,
                Email = email,
                Newsletter = newsletter,
                Password = password,
                PasswordConfirmation = password,
                TermsOfService = termsOfService
            };

            return request.GetResponse();
        }

        /// <summary>
        /// A non blocking create account request/response cycle.
        /// </summary>
        /// <param name="email">The email address to create the account with.</param>
        /// <param name="password">The password to create the account with.</param>
        /// <param name="affiliateCode">The affiliate code to create the account with, if applicable.</param>
        /// <param name="termsOfService">A value indicating whether the terms of service are agreed to.</param>
        /// <param name="newsletter">A value indicating whether to subscribe the email address to the newsletter.</param>
        /// <param name="callback">The call response.</param>
        public static void CreateAccount(string email, string password, string affiliateCode, bool? termsOfService, bool? newsletter, Action<CreateAccountResponse> callback)
        {
            CreateAccount(email, password, affiliateCode, termsOfService, newsletter, ServiceUrl, callback);
        }

        /// <summary>
        /// A non blocking create account request/response cycle.
        /// </summary>
        /// <param name="email">The email address to create the account with.</param>
        /// <param name="password">The password to create the account with.</param>
        /// <param name="affiliateCode">The affiliate code to create the account with, if applicable.</param>
        /// <param name="termsOfService">A value indicating whether the terms of service are agreed to.</param>
        /// <param name="newsletter">A value indicating whether to subscribe the email address to the newsletter.</param>
        /// <param name="baseUrl">The service base URL.</param>
        /// <param name="callback">The call response.</param>
        public static void CreateAccount(string email, string password, string affiliateCode, bool? termsOfService, bool? newsletter, Uri baseUrl, Action<CreateAccountResponse> callback)
        {
            CreateAccountRequest request = new CreateAccountRequest(baseUrl)
            {
                AffiliateCode = affiliateCode,
                Email = email,
                Newsletter = newsletter,
                Password = password,
                PasswordConfirmation = password,
                TermsOfService = termsOfService,
            };

            request.GetResponseAsync(callback);
        }

        /// <summary>
        /// A blocking account details request/response cycle.
        /// </summary>
        /// <returns>The call response.</returns>
        public AccountDetailsResponse AccountDetails()
        {
            return new AccountDetailsRequest(this).GetResponse();
        }

        /// <summary>
        /// A non blocking account details request/response cycle.
        /// </summary>
        /// <param name="callback">The call response.</param>
        public void AccountDetails(Action<AccountDetailsResponse> callback)
        {
            new AccountDetailsRequest(this).GetResponseAsync(callback);
        }

        /// <summary>
        /// A blocking account integration mode request/response cycle.
        /// </summary>
        /// <param name="enable">A value indicating whether to enable integration mode for the account.</param>
        /// <returns>The call response.</returns>
        public AccountIntegrationModeResponse AccountIntegrationMode(bool enable)
        {
            AccountIntegrationModeRequest request = new AccountIntegrationModeRequest(this)
            {
                Enable = enable
            };

            return request.GetResponse();
        }

        /// <summary>
        /// A non blocking account integration mode request/response cycle.
        /// </summary>
        /// <param name="enable">A value indicating whether to enable integration mode for the account.</param>
        /// <param name="callback">The call response.</param>
        public void AccountIntegrationMode(bool enable, Action<AccountIntegrationModeResponse> callback)
        {
            AccountIntegrationModeRequest request = new AccountIntegrationModeRequest(this)
            {
                Enable = enable
            };

            request.GetResponseAsync(callback);
        }

        /// <summary>
        /// A blocking cancel job request/response cycle.
        /// </summary>
        /// <param name="jobId">The ID of the job to cancel.</param>
        /// <returns>The call response.</returns>
        public CancelJobResponse CancelJob(int jobId)
        {
            CancelJobRequest request = new CancelJobRequest(this)
            {
                JobId = jobId
            };

            return request.GetResponse();
        }

        /// <summary>
        /// A blocking cancel request/response cycle.
        /// </summary>
        /// <param name="jobId">The ID of the job to cancel.</param>
        /// <param name="callback">The call response.</param>
        public void CancelJob(int jobId, Action<CancelJobResponse> callback)
        {
            CancelJobRequest request = new CancelJobRequest(this)
            {
                JobId = jobId
            };

            request.GetResponseAsync(callback);
        }

        /// <summary>
        /// A blocking create job request/response cycle.
        /// </summary>
        /// <param name="input">The URL of the input file.</param>
        /// <param name="outputs">The output definition collection.</param>
        /// <returns>The call response.</returns>
        public CreateJobResponse CreateJob(string input, IEnumerable<Output> outputs)
        {
            return this.CreateJob(input, outputs, null, null, null, null);
        }

        /// <summary>
        /// A non blocking create job request/response cycle.
        /// </summary>
        /// <param name="input">The URL of the input file.</param>
        /// <param name="outputs">The output definition collection.</param>
        /// <param name="callback">The call response.</param>
        public void CreateJob(string input, IEnumerable<Output> outputs, Action<CreateJobResponse> callback)
        {
            this.CreateJob(input, outputs, null, null, null, null, callback);
        }

        /// <summary>
        /// A blocking create job request/response cycle.
        /// </summary>
        /// <param name="input">The URL of the input file.</param>
        /// <param name="outputs">The output definition collection.</param>
        /// <param name="downloadConnections">The number of download connections to use when fetching the input file.</param>
        /// <param name="region">The region to perform the job in.</param>
        /// <param name="test">A value indicating whether to use test mode.</param>
        /// <param name="mock">A value indicating whether to mock the response rather than actually creating a job.</param>
        /// <returns>The call response.</returns>
        public CreateJobResponse CreateJob(string input, IEnumerable<Output> outputs, int? downloadConnections, string region, bool? test, bool? mock)
        {
            CreateJobRequest request = new CreateJobRequest(this)
            {
                DownloadConnections = downloadConnections,
                Input = input,
                Mock = mock,
                Region = region,
                Test = test
            };

            return request.WithOutputs(outputs).GetResponse();
        }

        /// <summary>
        /// A blocking create job request/response cycle.
        /// </summary>
        /// <param name="input">The URL of the input file.</param>
        /// <param name="outputs">The output definition collection.</param>
        /// <param name="downloadConnections">The number of download connections to use when fetching the input file.</param>
        /// <param name="region">The region to perform the job in.</param>
        /// <param name="test">A value indicating whether to use test mode.</param>
        /// <param name="mock">A value indicating whether to mock the response rather than actually creating a job.</param>
        /// <param name="callback">The call response.</param>
        public void CreateJob(string input, IEnumerable<Output> outputs, int? downloadConnections, string region, bool? test, bool? mock, Action<CreateJobResponse> callback)
        {
            CreateJobRequest request = new CreateJobRequest(this)
            {
                DownloadConnections = downloadConnections,
                Input = input,
                Mock = mock,
                Region = region,
                Test = test
            };

            request.WithOutputs(outputs).GetResponseAsync(callback);
        }

        /// <summary>
        /// A blocking delete job request/response cycle.
        /// </summary>
        /// <param name="jobId">The ID of the job to delete.</param>
        /// <returns>The call response.</returns>
        public DeleteJobResponse DeleteJob(int jobId)
        {
            DeleteJobRequest request = new DeleteJobRequest(this)
            {
                JobId = jobId
            };

            return request.GetResponse();
        }

        /// <summary>
        /// A blocking delete request/response cycle.
        /// </summary>
        /// <param name="jobId">The ID of the job to delete.</param>
        /// <param name="callback">The call response.</param>
        public void DeleteJob(int jobId, Action<DeleteJobResponse> callback)
        {
            DeleteJobRequest request = new DeleteJobRequest(this)
            {
                JobId = jobId
            };

            request.GetResponseAsync(callback);
        }

        /// <summary>
        /// A blocking job details request/response cycle.
        /// </summary>
        /// <param name="jobId">The ID of the job to get details for.</param>
        /// <returns>The call response.</returns>
        public JobDetailsResponse JobDetails(int jobId)
        {
            JobDetailsRequest request = new JobDetailsRequest(this)
            {
                JobId = jobId
            };

            return request.GetResponse();
        }

        /// <summary>
        /// A blocking job details request/response cycle.
        /// </summary>
        /// <param name="jobId">The ID of the job to get details for.</param>
        /// <param name="callback">The call response.</param>
        public void JobDetails(int jobId, Action<JobDetailsResponse> callback)
        {
            JobDetailsRequest request = new JobDetailsRequest(this)
            {
                JobId = jobId
            };

            request.GetResponseAsync(callback);
        }

        /// <summary>
        /// A blocking job progress request/response cycle.
        /// </summary>
        /// <param name="outputId">The ID of the output (NOT the job ID) to get progress for.</param>
        /// <returns>The call response.</returns>
        public JobProgressResponse JobProgress(int outputId)
        {
            JobProgressRequest request = new JobProgressRequest(this)
            {
                OutputId = outputId
            };

            return request.GetResponse();
        }

        /// <summary>
        /// A non blocking job progress request/response cycle.
        /// </summary>
        /// <param name="outputId">The ID of the output (NOT the job ID) to get progress for.</param>
        /// <param name="callback">The call response.</param>
        public void JobProgress(int outputId, Action<JobProgressResponse> callback)
        {
            JobProgressRequest request = new JobProgressRequest(this)
            {
                OutputId = outputId
            };

            request.GetResponseAsync(callback);
        }

        /// <summary>
        /// A blocking list jobs request/response cycle.
        /// </summary>
        /// <returns>The call response.</returns>
        public ListJobsResponse ListJobs()
        {
            return this.ListJobs(null, null);
        }

        /// <summary>
        /// A non blocking list jobs request/response cycle.
        /// </summary>
        /// <param name="callback">The call response.</param>
        public void ListJobs(Action<ListJobsResponse> callback)
        {
            this.ListJobs(null, null, callback);
        }

        /// <summary>
        /// A blocking list jobs request/response cycle.
        /// </summary>
        /// <param name="pageNumber">The page number of jobs to list, if applicable.</param>
        /// <param name="pageSize">The page size of jobs to list, if applicable.</param>
        /// <returns>The call response.</returns>
        public ListJobsResponse ListJobs(int? pageNumber, int? pageSize)
        {
            ListJobsRequest request = new ListJobsRequest(this).ForPage(pageNumber, pageSize);
            return request.GetResponse();
        }

        /// <summary>
        /// A non blocking list jobs request/response cycle.
        /// </summary>
        /// <param name="pageNumber">The page number of jobs to list, if applicable.</param>
        /// <param name="pageSize">The page size of jobs to list, if applicable.</param>
        /// <param name="callback">The call response.</param>
        public void ListJobs(int? pageNumber, int? pageSize, Action<ListJobsResponse> callback)
        {
            ListJobsRequest request = new ListJobsRequest(this).ForPage(pageNumber, pageSize);
            request.GetResponseAsync(callback);
        }

        /// <summary>
        /// A blocking resubmit job request/response cycle.
        /// </summary>
        /// <param name="jobId">The ID of the job to resubmit.</param>
        /// <returns>The call response.</returns>
        public ResubmitJobResponse ResubmitJob(int jobId)
        {
            ResubmitJobRequest request = new ResubmitJobRequest(this)
            {
                JobId = jobId
            };

            return request.GetResponse();
        }

        /// <summary>
        /// A blocking resubmit job request/response cycle.
        /// </summary>
        /// <param name="jobId">The ID of the job to resubmit.</param>
        /// <param name="callback">The call response.</param>
        public void ResubmitJob(int jobId, Action<ResubmitJobResponse> callback)
        {
            ResubmitJobRequest request = new ResubmitJobRequest(this)
            {
                JobId = jobId
            };

            request.GetResponseAsync(callback);
        }
    }
}
