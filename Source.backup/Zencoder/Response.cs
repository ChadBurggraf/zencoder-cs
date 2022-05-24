//-----------------------------------------------------------------------
// <copyright file="Response.cs" company="Tasty Codes">
//     Copyright (c) 2010 Chad Burggraf.
// </copyright>
//-----------------------------------------------------------------------

namespace Zencoder
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Reflection;
    using Newtonsoft.Json;

    /// <summary>
    /// Base class for API responses.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public abstract class Response
    {
        private string[] errors;

        /// <summary>
        /// Gets or sets the error collection that was returned in the response.
        /// </summary>
        [JsonProperty("errors")]
        public string[] Errors
        {
            get { return this.errors ?? (this.errors = new string[0]); }
            set { this.errors = value; }
        }

        /// <summary>
        /// Gets the exception that occurred while making the request, if applicable.
        /// </summary>
        public WebException RequestException { get; internal set; }

        /// <summary>
        /// Gets the HTTP status code that was returned in the response.
        /// </summary>
        public HttpStatusCode StatusCode { get; internal set; }

        /// <summary>
        /// Gets a value indicating whether the request was successful.
        /// </summary>
        public virtual bool Success
        {
            get { return this.RequestException == null && this.StatusCode == HttpStatusCode.OK; }
        }

        /// <summary>
        /// Creates a new <see cref="Response"/> instance from the given JSON string.
        /// </summary>
        /// <typeparam name="TRequest">The concrete <see cref="Request"/> implementor.</typeparam>
        /// <typeparam name="TResponse">The corresponding <see cref="Response"/> implementor.</typeparam>
        /// <param name="json">A string of JSON representing the response.</param>
        /// <returns>A <see cref="Response"/>.</returns>
        public static TResponse FromJson<TRequest, TResponse>(string json)
            where TRequest : Request
            where TResponse : Response, new()
        {
            MethodInfo method = GetMethod<TResponse, FromJsonStringAttribute>(typeof(string));

            if (method != null)
            {
                return (TResponse)method.Invoke(null, new object[] { json });
            }
            else
            {
                return JsonConvert.DeserializeObject<TResponse>(json);
            }
        }

        /// <summary>
        /// Creates a new <see cref="Response"/> instance from the JSON data in the given stream.
        /// </summary>
        /// <typeparam name="TRequest">The concrete <see cref="Request"/> implementor.</typeparam>
        /// <typeparam name="TResponse">The corresponding <see cref="Response"/> implementor.</typeparam>
        /// <param name="stream">The stream to create the response from.</param>
        /// <returns>A <see cref="Response"/>.</returns>
        public static TResponse FromJson<TRequest, TResponse>(Stream stream)
            where TRequest : Request
            where TResponse : Response, new()
        {
            MethodInfo method = GetMethod<TResponse, FromJsonStreamAttribute>(typeof(Stream));

            if (method != null)
            {
                return (TResponse)method.Invoke(null, new object[] { stream });
            }
            else
            {
                JsonSerializer serializer = new JsonSerializer();

                using (StreamReader sr = new StreamReader(stream))
                {
                    using (JsonReader jr = new JsonTextReader(sr))
                    {
                        return serializer.Deserialize<TResponse>(jr);
                    }
                }
            }
        }

        /// <summary>
        /// Gets a custom method to use when creating a <see cref="Response"/> from JSON.
        /// </summary>
        /// <typeparam name="TResponse">The concrete <see cref="Response"/> implementor.</typeparam>
        /// <typeparam name="TAttr">The concrete <see cref="FromJsonAttribute"/> to use when searching for a method.</typeparam>
        /// <param name="argumentType">The artument type to use when searching for a method.</param>
        /// <returns>A custom <see cref="Response"/> creation method, or null if none was found.</returns>
        private static MethodInfo GetMethod<TResponse, TAttr>(Type argumentType)
            where TAttr : FromJsonAttribute
        {
            MethodInfo method = null;
            Type type = typeof(TResponse);
            TAttr attr = type.GetCustomAttributes(typeof(TAttr), true).Cast<TAttr>().FirstOrDefault();

            if (attr != null && !string.IsNullOrEmpty(attr.Method) && attr.Type != null)
            {
                method = attr.Type.GetMethod(attr.Method, new Type[] { argumentType });

                if (method != null && !method.IsStatic)
                {
                    method = null;
                }
            }

            return method;
        }
    }
}