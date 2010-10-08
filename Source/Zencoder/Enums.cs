//-----------------------------------------------------------------------
// <copyright file="Enums.cs" company="Tasty Codes">
//     Copyright (c) 2010 Chad Burggraf.
// </copyright>
//-----------------------------------------------------------------------

namespace Zencoder
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Globalization;
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// Provides extensions and helpers for enumerations.
    /// </summary>
    public static class Enums
    {
        /// <summary>
        /// Parses an enum from the given description or member name.
        /// </summary>
        /// <typeparam name="T">The type of the enum to parse.</typeparam>
        /// <param name="value">The enum member name or description value to parse.</param>
        /// <returns>The parsed enum.</returns>
        public static T EnumFromDescription<T>(this string value)
        {
            return (T)EnumFromDescription(value, typeof(T));
        }

        /// <summary>
        /// Parses an enum from the given description or member name.
        /// </summary>
        /// <param name="value">The enum member name or description value to parse.</param>
        /// <param name="enumType">The type of the enum to parse.</param>
        /// <returns>The parsed enum.</returns>
        public static object EnumFromDescription(this string value, Type enumType)
        {
            bool isNullable = false;

            if (!enumType.IsEnum)
            {
                enumType = Nullable.GetUnderlyingType(enumType);
                isNullable = true;

                if (!enumType.IsEnum)
                {
                    throw new ArgumentException(String.Format(CultureInfo.InvariantCulture, @"Type ""{0}"" is not a valid enumeration.", enumType), "enumType");
                }
            }

            MemberInfo[] members = enumType.GetMembers();

            if (!String.IsNullOrEmpty(value))
            {
                foreach (MemberInfo member in members)
                {
                    if (value.Equals(member.Name, StringComparison.OrdinalIgnoreCase))
                    {
                        return Enum.Parse(enumType, value, true);
                    }

                    DescriptionAttribute attr = (DescriptionAttribute)member.GetCustomAttributes(typeof(DescriptionAttribute), false).FirstOrDefault();

                    if (attr != null && value.Equals(attr.Description, StringComparison.OrdinalIgnoreCase))
                    {
                        return Enum.Parse(enumType, member.Name, true);
                    }
                }

                throw new ArgumentException(String.Format(@"Value ""{0}"" could not be found in the members or descriptions of ""{1}"".", value, enumType), "value");
            }

            if (!isNullable)
            {
                throw new ArgumentException("Cannot parse null or empty into a non-nullable enumeration.", "value");
            }

            return null;
        }

        /// <summary>
        /// Gets the string representation of the enum value, substituting its
        /// description attribute value if set.
        /// </summary>
        /// <param name="value">The enum to get the description of.</param>
        /// <returns>An enum description.</returns>
        public static string ToDescription(this Enum value)
        {
            string text = value.ToString();
            Type type = value.GetType();

            if (type.GetCustomAttributes(typeof(FlagsAttribute), false).Count() > 0)
            {
                List<string> descriptions = new List<string>();
                int valueInt = Convert.ToInt32(value, CultureInfo.InvariantCulture);

                foreach (string name in Enum.GetNames(type))
                {
                    int val = (int)Enum.Parse(type, name);

                    if ((val & valueInt) == val)
                    {
                        MemberInfo info = type.GetMember(name).FirstOrDefault();

                        if (info != null)
                        {
                            DescriptionAttribute attr = (DescriptionAttribute)info.GetCustomAttributes(typeof(DescriptionAttribute), false).FirstOrDefault();

                            if (attr != null)
                            {
                                descriptions.Add(attr.Description);
                            }
                            else
                            {
                                descriptions.Add(name);
                            }
                        }
                        else
                        {
                            descriptions.Add(name);
                        }
                    }
                }

                text = String.Join(", ", descriptions.ToArray());
            }
            else
            {
                MemberInfo info = type.GetMember(text).FirstOrDefault();

                if (info != null)
                {
                    DescriptionAttribute attr = (DescriptionAttribute)info.GetCustomAttributes(typeof(DescriptionAttribute), false).FirstOrDefault();

                    if (attr != null)
                    {
                        text = attr.Description;
                    }
                }
            }

            return text;
        }
    }
}
