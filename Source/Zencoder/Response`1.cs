

namespace Zencoder
{
    using System;
    using System.IO;
    using System.Text;
    using Newtonsoft.Json;

    /// <summary>
    /// Base generic implementation of <see cref="Response"/>.
    /// </summary>
    /// <typeparam name="TRequest">The concrete <see cref="Request"/> implementor.</typeparam>
    /// <typeparam name="TResponse">The corresponding <see cref="Response"/> implementor.</typeparam>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
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
            return JsonConvert.DeserializeObject<TResponse>(json);
        }

        /// <summary>
        /// Creates a new <see cref="Response"/> instance from the JSON data in the given stream.
        /// </summary>
        /// <param name="stream">The stream to create the response from.</param>
        /// <returns>A <see cref="Response"/>.</returns>
        public static TResponse FromJson(Stream stream)
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
}
