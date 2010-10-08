//-----------------------------------------------------------------------
// <copyright file="Strings.cs" company="Tasty Codes">
//     Copyright (c) 2010 Chad Burggraf.
// </copyright>
//-----------------------------------------------------------------------

namespace Zencoder
{
    using System;
    using System.Text;

    /// <summary>
    /// Provides <see cref="String"/> extensions and helpers.
    /// </summary>
    public static class Strings
    {
        /// <summary>
        /// Converts the lower_case_underscore string into a PascalCase or camelCalse string.
        /// </summary>
        /// <param name="value">The string to convert.</param>
        /// <returns>The converted string.</returns>
        public static string FromLowercaseUnderscore(this string value)
        {
            return FromLowercaseUnderscore(value, false);
        }

        /// <summary>
        /// Converts the lower_case_underscore string into a PascalCase or camelCalse string.
        /// </summary>
        /// <param name="value">The string to convert.</param>
        /// <param name="camel">A value indicating whether to convert to camelCalse. If false, will convert to PascalCase.</param>
        /// <returns>The converted string.</returns>
        public static string FromLowercaseUnderscore(this string value, bool camel)
        {
            value = (value ?? String.Empty).ToLowerInvariant().Trim();

            if (String.IsNullOrEmpty(value))
            {
                return value;
            }

            StringBuilder sb = new StringBuilder();
            int i = 0;
            int wordLetterNumber = 0;

            while (i < value.Length)
            {
                if (Char.IsLetterOrDigit(value, i))
                {
                    wordLetterNumber++;
                }
                else
                {
                    wordLetterNumber = 0;
                }

                if (wordLetterNumber == 1)
                {
                    if (camel && i == 0)
                    {
                        sb.Append(value[i]);
                    }
                    else
                    {
                        sb.Append(value[i].ToString().ToUpperInvariant());
                    }
                }
                else if (value[i] != '_')
                {
                    sb.Append(value[i]);
                }

                i++;
            }

            return sb.ToString();
        }

        /// <summary>
        /// Converts the camelCase or PascalCase string to a lower_case_underscore string.
        /// </summary>
        /// <param name="value">The string to convert.</param>
        /// <returns>The converted string.</returns>
        public static string ToLowercaseUnderscore(this string value)
        {
            value = (value ?? String.Empty).Trim();

            if (String.IsNullOrEmpty(value))
            {
                return value;
            }

            StringBuilder sb = new StringBuilder();
            int i = 0;
            int wordLetterNumber = 0;

            while (i < value.Length)
            {
                if (Char.IsLetterOrDigit(value, i))
                {
                    wordLetterNumber++;
                }
                else
                {
                    wordLetterNumber = 0;
                }

                if (Char.IsUpper(value, i))
                {
                    if (wordLetterNumber > 1)
                    {
                        sb.Append("_");
                    }

                    sb.Append(Char.ToLowerInvariant(value[i]));
                }
                else
                {
                    sb.Append(value[i]);
                }

                i++;
            }

            return sb.ToString();
        }
    }
}
