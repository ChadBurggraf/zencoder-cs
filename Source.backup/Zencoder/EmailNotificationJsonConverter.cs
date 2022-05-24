//-----------------------------------------------------------------------
// <copyright file="EmailNotificationJsonConverter.cs" company="Tasty Codes">
//     Copyright (c) 2010 Chad Burggraf.
// </copyright>
//-----------------------------------------------------------------------

namespace Zencoder
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// Provides custom JSON serialization for <see cref="EmailNotification"/>s
    /// </summary>
    public class EmailNotificationJsonConverter : JsonConverter
    {
        /// <summary>
        /// Gets a value indicating whether this <see cref="JsonConverter"/> can read JSON.
        /// </summary>
        public override bool CanRead 
        { 
            get { return false; } 
        }

        /// <summary>
        /// Determines whether this instance can convert the specified object type. 
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns>True if this instance can convert the specified object type, otherwise false.</returns>
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(EmailNotification);
        }

        /// <summary>
        /// Reads the JSON representation of the object. 
        /// </summary>
        /// <param name="reader">The JsonReader to read from.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="existingValue">The existing value of the object being read.</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <returns>The object value.</returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Writes the JSON representation of the object. 
        /// </summary>
        /// <param name="writer">The JsonWriter to write to.</param>
        /// <param name="value">The value.</param>
        /// <param name="serializer">The calling serializer.</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            EmailNotification notification = value as EmailNotification;

            if (notification != null && !string.IsNullOrEmpty(notification.Email))
            {
                serializer.Serialize(writer, notification.Email);
            }
            else
            {
                serializer.Serialize(writer, null);
            }
        }
    }
}
