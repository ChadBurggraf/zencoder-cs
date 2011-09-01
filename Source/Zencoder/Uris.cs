//-----------------------------------------------------------------------
// <copyright file="Uris.cs" company="Tasty Codes">
//     Copyright (c) 2010 Chad Burggraf.
// </copyright>
//-----------------------------------------------------------------------

namespace Zencoder
{
    using System;
    using System.Web;

    /// <summary>
    /// Provides exteions to <see cref="Uri"/> objects.
    /// </summary>
    public static class Uris
    {
        /// <summary>
        /// Appends the given path to the URI.
        /// </summary>
        /// <param name="uri">The URI to append the path to.</param>
        /// <param name="path">The path to append.</param>
        /// <returns>The result URI.</returns>
        public static Uri AppendPath(this Uri uri, string path)
        {
            UriBuilder builder = new UriBuilder(uri);
            builder.Path = Combine(builder.Path, path);

            return builder.Uri;
        }

        /// <summary>
        /// Combines the two URL parts with a URL path separator.
        /// </summary>
        /// <param name="first">The first part to combine.</param>
        /// <param name="second">The second part to combine.</param>
        /// <returns>The combined URL.</returns>
        public static string Combine(string first, string second)
        {
            first = (first ?? string.Empty).Trim();
            second = (second ?? string.Empty).Trim();

            if (first.EndsWith("/", StringComparison.Ordinal))
            {
                first = first.Substring(0, first.Length - 1);
            }

            if (second.StartsWith("/", StringComparison.Ordinal))
            {
                second = second.Substring(1);
            }

            if (!string.IsNullOrEmpty(first) && !string.IsNullOrEmpty(second))
            {
                return string.Concat(first, "/", second);
            }
            else if (!string.IsNullOrEmpty(first))
            {
                return first;
            }
            else
            {
                return second;
            }
        }

        /// <summary>
        /// Sets the entire query string of the URI to the given API key.
        /// </summary>
        /// <param name="uri">The URI to set the query string of.</param>
        /// <param name="apiKey">The API key value to set.</param>
        /// <returns>The result URI.</returns>
        public static Uri WithApiKey(this Uri uri, string apiKey)
        {
            return uri.WithQuery(Zencoder.ApiKeyQueryKey, apiKey);
        }

        /// <summary>
        /// Sets the path portion of the URI.
        /// </summary>
        /// <param name="uri">The URI to set the path portion of.</param>
        /// <param name="path">The path to set.</param>
        /// <returns>The result URI.</returns>
        public static Uri WithPath(this Uri uri, string path)
        {
            path = path ?? string.Empty;

            if (path.StartsWith("/", StringComparison.Ordinal))
            {
                path = path.Substring(1);
            }

            UriBuilder builder = new UriBuilder(uri);
            builder.Path = path;

            return builder.Uri;
        }

        /// <summary>
        /// Sets the entire query string of the URI to the given key/value pair.
        /// </summary>
        /// <param name="uri">The URI to set the query string of.</param>
        /// <param name="key">The key to set.</param>
        /// <param name="value">The value to set.</param>
        /// <returns>The result URI.</returns>
        public static Uri WithQuery(this Uri uri, string key, string value)
        {
            UriBuilder builder = new UriBuilder(uri);

            builder.Query = string.Concat(
                HttpUtility.UrlEncode(key),
                "=",
                HttpUtility.UrlEncode(value));

            return builder.Uri;
        }

        /// <summary>
        /// Gets the entire query string of the URI to the given pre-encoded query string.
        /// </summary>
        /// <param name="uri">The URI to set the query string of.</param>
        /// <param name="queryString">The query string to set.</param>
        /// <returns>The result URI.</returns>
        public static Uri WithQueryString(this Uri uri, string queryString)
        {
            UriBuilder builder = new UriBuilder(uri);
            builder.Query = queryString;

            return builder.Uri;
        }
    }
}
