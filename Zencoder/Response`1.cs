

namespace Zencoder
{
    using System;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Json;
    using System.Text;

    /// <summary>
    /// Base generic implementation of <see cref="Response"/>.
    /// </summary>
    /// <typeparam name="TRequest">The concrete <see cref="Request"/> implementor.</typeparam>
    /// <typeparam name="TResponse">The corresponding <see cref="Response"/> implementor.</typeparam>
    [DataContract(Name = Response.ContractName)]
    public abstract class Response<TRequest, TResponse> : Response 
        where TRequest : Request
        where TResponse : Response, new()
    {
        /// <summary>
        /// Creates a new <see cref="Response"/> instance from the given JSON string.
        /// </summary>
        /// <param name="json">A string of JSON representing the response.</param>
        /// <returns>A <see cref="Response"/>.</returns>
        public static TResponse FromJson(string json)
        {
            using (Stream stream = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {
                return FromJson(stream);
            }
        }

        /// <summary>
        /// Creates a new <see cref="Response"/> instance from the JSON data in the given stream.
        /// </summary>
        /// <param name="stream">The stream to create the response from.</param>
        /// <returns>A <see cref="Response"/>.</returns>
        public static TResponse FromJson(Stream stream)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(TResponse));
            return (TResponse)serializer.ReadObject(stream);
        }
    }
}
