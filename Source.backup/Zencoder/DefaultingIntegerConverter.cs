//-----------------------------------------------------------------------
// <copyright file="DefaultingIntegerConverter.cs" company="Tasty Codes">
//     Copyright (c) 2010 Chad Burggraf.
// </copyright>
//-----------------------------------------------------------------------

namespace Zencoder
{
    using System;
    using System.Globalization;
    using Newtonsoft.Json;

    /// <summary>
    /// Serializes integer values, using 0 as the default value during de-serialization
    /// when a null is encountered.
    /// </summary>
    public class DefaultingIntegerConverter : JsonConverter
    {
        /// <summary>
        /// Determines whether this instance can convert the specified object type. 
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns>True if this instance can convert the specified object type, otherwise false.</returns>
        public override bool CanConvert(Type objectType)
        {
            switch (Type.GetTypeCode(objectType))
            {
                case TypeCode.Byte:
                case TypeCode.Char:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.SByte:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                    return true;
                default:
                    return false;
            }
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
            TypeCode typeCode = Type.GetTypeCode(objectType);
            object result = this.GetDefaultValue(typeCode);
            string str = (reader.Value ?? string.Empty).ToString().Trim();

            if (!string.IsNullOrEmpty(str))
            {
                try
                {
                    result = this.ReadValue(typeCode, str);
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
            serializer.Serialize(writer, value);
        }

        /// <summary>
        /// Gets the default integral value for the given type.
        /// </summary>
        /// <param name="typeCode">The integral type to get the default value for.</param>
        /// <returns>A default value.</returns>
        private object GetDefaultValue(TypeCode typeCode)
        {
            switch (typeCode)
            {
                case TypeCode.Byte:
                    return (byte)0;
                case TypeCode.Char:
                    return (char)0;
                case TypeCode.Int16:
                    return (short)0;
                case TypeCode.Int32:
                    return 0;
                case TypeCode.Int64:
                    return 0L;
                case TypeCode.SByte:
                    return (sbyte)0;
                case TypeCode.UInt16:
                    return (ushort)0;
                case TypeCode.UInt32:
                    return 0U;
                case TypeCode.UInt64:
                    return 0UL;
                default:
                    throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Reads the value for the given integral type from the given string.
        /// </summary>
        /// <param name="typeCode">The type code of the integral type to read.</param>
        /// <param name="value">The string to read the value from.</param>
        /// <returns>The integral value.</returns>
        private object ReadValue(TypeCode typeCode, string value)
        {
            switch (typeCode)
            {
                case TypeCode.Byte:
                    return Convert.ToByte(value, CultureInfo.InvariantCulture);
                case TypeCode.Char:
                    return Convert.ToChar(value, CultureInfo.InvariantCulture);
                case TypeCode.Int16:
                    return Convert.ToInt16(value, CultureInfo.InvariantCulture);
                case TypeCode.Int32:
                    return Convert.ToInt32(value, CultureInfo.InvariantCulture);
                case TypeCode.Int64:
                    return Convert.ToInt64(value, CultureInfo.InvariantCulture);
                case TypeCode.SByte:
                    return Convert.ToSByte(value, CultureInfo.InvariantCulture);
                case TypeCode.UInt16:
                    return Convert.ToUInt16(value, CultureInfo.InvariantCulture);
                case TypeCode.UInt32:
                    return Convert.ToUInt32(value, CultureInfo.InvariantCulture);
                case TypeCode.UInt64:
                    return Convert.ToUInt64(value, CultureInfo.InvariantCulture);
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
