

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
                    response = (HttpWebResponse)ex.Response;
                }

                using (Stream stream = response.GetResponseStream())
                {
                    this.response = this.ReadResponse(stream);
                    this.response.StatusCode = response.StatusCode;
                }
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
                    request.BeginGetRequestStream(new AsyncCallback(delegate(IAsyncResult requestResult)
                    {
                        using (Stream stream = request.EndGetRequestStream(requestResult))
                        {
                            this.WriteRequestStream(stream);
                        }

                        this.GetResponseAsync(r =>
                        {
                            this.response = r;
                            callback(this.response);
                        }, request);
                    }), null);
                }
                else
                {
                    this.GetResponseAsync(r => 
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
        /// Reads any data from the response stream into a new <see cref="TResponse"/> instance.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <returns>The created response.</returns>
        protected virtual TResponse ReadResponse(Stream stream)
        {
            TResponse response;

            // Static polymorphism. Kinda. Who said it wasn't a good idea?
            MethodInfo fromJson = typeof(TResponse).GetMethod("FromJson", new Type[] { typeof(Stream) });

            if (fromJson != null)
            {
                response = (TResponse)fromJson.Invoke(null, new object[] { stream });
            }
            else
            {
                response = Response<TRequest, TResponse>.FromJson(stream);
            }

            return response;
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
            request.BeginGetResponse(new AsyncCallback(delegate(IAsyncResult responseResult)
            {
                HttpWebResponse response;

                try
                {
                    response = (HttpWebResponse)request.EndGetResponse(responseResult);
                }
                catch (WebException ex)
                {
                    response = (HttpWebResponse)ex.Response;
                }

                using (Stream stream = response.GetResponseStream())
                {
                    TResponse resultResponse = this.ReadResponse(stream);
                    resultResponse.StatusCode = response.StatusCode;

                    callback(resultResponse);
                }
            }), null);
        }
    }
}
