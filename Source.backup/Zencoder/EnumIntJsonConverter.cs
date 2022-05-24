//-----------------------------------------------------------------------
// <copyright file="EnumIntJsonConverter.cs" company="Tasty Codes">
//     Copyright (c) 2010 Chad Burggraf.
// </copyright>
//-----------------------------------------------------------------------

namespace Zencoder
{
    using System;
    using System.Globalization;
    using System.Text.RegularExpressions;
    using Newtonsoft.Json;

    /// <summary>
    /// Provides custom JSON serialization for enums to/from integers.
    /// </summary>
    public class EnumIntJsonConverter : JsonConverter
    {
        /// <summary>
        /// Determines whether this instance can convert the specified object type. 
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns>True if this instance can convert the specified object type, otherwise false.</returns>
        public override bool CanConvert(Type objectType)
        {
            return objectType.IsEnum || objectType.IsNullableEnum();
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
            string str = (reader.Value ?? string.Empty).ToString();
            object result = existingValue;

            if (!string.IsNullOrEmpty(str))
            {
                try
                {
                    if (Regex.IsMatch(str, @"\d+"))
                    {
                        result = Enum.ToObject(objectType, Convert.ToInt32(str, CultureInfo.InvariantCulture));
                    }
                    else
                    {
                        result = Enum.Parse(objectType, str, true);
                    }
                }
                catch (ArgumentException)
                {
                }
            }

            return result;
        }

        /// <summary>
        /// Writes the JSON representation of the object. 
        /// </summary>
        /// <param name="writer">The JsonWriter to write to.</param>
        /// <param name="value">The value.</param>
        /// <param name="serializer">The calling serializer.</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value != null)
            {
                serializer.Serialize(writer, (int)value);
            }
            else
            {
                serializer.Serialize(writer, null);
            }
        }
    }
}