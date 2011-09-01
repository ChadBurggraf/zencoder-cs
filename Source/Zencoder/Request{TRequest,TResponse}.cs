//-----------------------------------------------------------------------
// <copyright file="Request{TRequest,TResponse}.cs" company="Tasty Codes">
//     Copyright (c) 2010 Chad Burggraf.
// </copyright>
//-----------------------------------------------------------------------

namespace Zencoder
{
    using System;
    using System.IO;
    using System.Net;
    using System.Reflection;
    using System.Text;
    using Newtonsoft.Json;

    /// <summary>
    /// Base generic implementation of <see cref="Request"/>.
    /// </summary>
    /// <typeparam name="TRequest">The concrete <see cref="Request"/> implementor.</typeparam>
    /// <typeparam name="TResponse">The corresponding <see cref="Response"/> implementor.</typeparam>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public abstract class Request<TRequest, TResponse> : Request 
        where TRequest : Request
        where TResponse : Response, new()
    {
        private TResponse response;

        /// <summary>
        /// Initializes a new instance of the Request class.
        /// </summary>
        /// <param name="zencoder">The <see cref="Zencoder"/> service to create the request with.</param>
        protected Request(Zencoder zencoder)
            : base(zencoder)
        {
        }

        /// <summary>
        /// Initializes a new instance of the Request class.
        /// </summary>
        /// <param name="apiKey">The API key to use when connecting to the service.</param>
        /// <param name="baseUrl">The service base URL.</param>
        protected Request(string apiKey, Uri baseUrl)
            : base(apiKey, baseUrl)
        {
        }

        /// <summary>
        /// Gets the response to this request.
        /// </summary>
        /// <returns>The response to this request.</returns>
        public virtual TResponse GetResponse()
        {
            if (this.response == null)
            {
                HttpWebResponse response;
                WebException requestException = null;

                try
                {
                    HttpWebRequest request = this.CreateRequest();

                    if ("POST".Equals(this.Verb, StringComparison.OrdinalIgnoreCase))
                    {
                        using (Stream stream = request.GetRequestStream())
                        {
                            this.WriteRequestStream(stream);
                        }
                    }

                    response = (HttpWebResponse)request.GetResponse();
                }
                catch (WebException ex)
                {
                    requestException = ex;
                    response = (HttpWebResponse)ex.Response;
                }

                this.response = this.CreateResponse(response, requestException);
            }

            return this.response;
        }

        /// <summary>
        /// Gets the response to this request asynchronously.
        /// </summary>
        /// <param name="callback">The callback to invoke when the response has been received.</param>
        public virtual void GetResponseAsync(Action<TResponse> callback)
        {
            if (this.response == null)
            {
                HttpWebRequest request = this.CreateRequest();

                if ("POST".Equals(this.Verb, StringComparison.OrdinalIgnoreCase))
                {
                    request.BeginGetRequestStream(
                        new AsyncCallback(
                            delegate(IAsyncResult requestResult)
                            {
                                using (Stream stream = request.EndGetRequestStream(requestResult))
                                {
                                    this.WriteRequestStream(stream);
                                }

                                this.GetResponseAsync(
                                    r =>
                                    {
                                        this.response = r;
                                        callback(this.response);
                                    }, 
                                    request);
                            }), 
                            null);
                }
                else
                {
                    this.GetResponseAsync(
                        r => 
                        { 
                            this.response = r;
                            callback(this.response);
                        }, 
                        request);
                }
            }
            else
            {
                callback(this.response);
            }
        }

        /// <summary>
        /// Serializes this instance to a JSON string.
        /// </summary>
        /// <returns>A JSON string.</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        /// <summary>
        /// Serializes this instance to JSON and writes it to the given stream.
        /// </summary>
        /// <param name="stream">The stream to write JSON data to.</param>
        public virtual void ToJson(Stream stream)
        {
            JsonSerializer serializer = new JsonSerializer();

            using (StreamWriter writer = new StreamWriter(stream))
            {
                serializer.Serialize(writer, this);
            }
        }

        /// <summary>
        /// Creates an HTTP request from this instance's state.
        /// </summary>
        /// <returns>The created request.</returns>
        protected virtual HttpWebRequest CreateRequest()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(this.Url);
            request.Accept = "application/json";
            request.ContentType = "application/json";
            request.Method = this.Verb;

            return request as HttpWebRequest;
        }

        /// <summary>
        /// Creates a <see cref="Response"/> from the given web response and possible exception.
        /// </summary>
        /// <param name="response">The response to create the <see cref="Response"/> from.</param>
        /// <param name="ex">The exception that occurred, if applicable.</param>
        /// <returns>The created response.</returns>
        protected virtual TResponse CreateResponse(HttpWebResponse response, WebException ex)
        {
            TResponse resultResponse = null;

            if (response != null)
            {
                using (Stream stream = response.GetResponseStream())
                {
                    resultResponse = this.ReadResponse(stream);
                }
            }

            if (resultResponse == null)
            {
                resultResponse = new TResponse();
            }

            if (response != null)
            {
                resultResponse.StatusCode = response.StatusCode;
            }

            resultResponse.RequestException = ex;
            return resultResponse;
        }

        /// <summary>
        /// Reads any data from the response stream into a new <see cref="Response"/> instance.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <returns>The created response.</returns>
        protected virtual TResponse ReadResponse(Stream stream)
        {
            return Response.FromJson<TRequest, TResponse>(stream);
        }

        /// <summary>
        /// Writes any data to the request stream for this instance.
        /// </summary>
        /// <param name="stream">The request stream to write to.</param>
        protected virtual void WriteRequestStream(Stream stream)
        {
            this.ToJson(stream);
        }

        /// <summary>
        /// Gets the response to this request asynchronously.
        /// </summary>
        /// <param name="callback">The callback to invoke when the response has been received.</param>
        /// <param name="request">The web request to get the response for.</param>
        private void GetResponseAsync(Action<TResponse> callback, HttpWebRequest request)
        {
            request.BeginGetResponse(
                new AsyncCallback(
                    delegate(IAsyncResult responseResult)
                    {
                        HttpWebResponse response;
                        WebException requestException = null;

                        try
                        {
                            response = (HttpWebResponse)request.EndGetResponse(responseResult);
                        }
                        catch (WebException ex)
                        {
                            requestException = ex;
                            response = (HttpWebResponse)ex.Response;
                        }

                        callback(this.CreateResponse(response, requestException));
                    }), 
                    null);
        }
    }
}
