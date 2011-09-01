//-----------------------------------------------------------------------
// <copyright file="BooleanConverter.cs" company="Tasty Codes">
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
    /// Provides custom JSON serialization to allow any combination of "true", "false", "1" or "0" to be used for booleans.
    /// </summary>
    public class BooleanConverter : JsonConverter
    {
        private static readonly Regex allDigitsExp = new Regex(@"^[-+]?[0-9]*\.?[0-9]+$", RegexOptions.Compiled);

        /// <summary>
        /// Determines whether this instance can convert the specified object type. 
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns>True if this instance can convert the specified object type, otherwise false.</returns>
        public override bool CanConvert(Type objectType)
        {
            return typeof(bool?).IsAssignableFrom(objectType);
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
            string str = (reader.Value ?? string.Empty).ToString().Trim();
            object result = existingValue;

            if (!string.IsNullOrEmpty(str))
            {
                try
                {
                    if (allDigitsExp.IsMatch(str))
                    {
                        int number = (int)Convert.ToSingle(str, CultureInfo.InvariantCulture);
                        result = number == 0 ? false : true;
                    }
                    else
                    {
                        result = Convert.ToBoolean(str, CultureInfo.InvariantCulture);
                    }
                }
                catch (FormatException)
                {
                }
                catch (OverflowException)
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
            bool? b = (bool?)value;
            serializer.Serialize(writer, !b.HasValue || !b.Value ? "0" : "1");
        }
    }
}
