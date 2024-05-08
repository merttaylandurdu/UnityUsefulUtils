using System;

namespace UnityUsefulUtils
{


    public static class StringExtensions
    {
        /// <summary>Checks if a string is null, empty, or consists only of white-space characters.</summary>
        public static bool IsNullOrWhiteSpace(this string val) => string.IsNullOrWhiteSpace(val);

        /// <summary>Checks if a string is null or an empty string ("").</summary>
        public static bool IsNullOrEmpty(this string value) => string.IsNullOrEmpty(value);

        /// <summary>Checks if a string contains null, empty, or is only white space.</summary>
        public static bool IsBlank(this string val) => string.IsNullOrWhiteSpace(val);

        /// <summary>Returns the string itself if it's not null; otherwise, returns an empty string.</summary>
        public static string OrEmpty(this string val) => val ?? string.Empty;

        /// <summary>Shortens a string to the specified maximum length, returning the original string if it is already shorter.</summary>
        /// <param name="val">The string to shorten.</param>
        /// <param name="maxLength">The maximum length of the string to return.</param>
        /// <returns>The shortened string.</returns>
        public static string Shorten(this string val, int maxLength)
        {
            if (val.IsBlank()) return val;
            return val.Length <= maxLength ? val : val.Substring(0, maxLength);
        }

        /// <summary>Slices a string from the start index to the end index, inclusive of the start index and exclusive of the end index.</summary>
        /// <param name="val">The string to slice.</param>
        /// <param name="startIndex">The zero-based starting character position.</param>
        /// <param name="endIndex">The zero-based ending character position, which is exclusive. Negative values count back from the end of the string.</param>
        /// <returns>The sliced string.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the string is null or blank.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if the start or end indexes are out of the string's bounds.</exception>
        public static string Slice(this string val, int startIndex, int endIndex)
        {
            if (val.IsBlank())
            {
                throw new ArgumentNullException(nameof(val), "Value cannot be null or empty.");
            }

            if (startIndex < 0 || startIndex > val.Length - 1)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex), "Start index is out of range.");
            }

            endIndex = endIndex < 0 ? val.Length + endIndex : endIndex;

            if (endIndex < 0 || endIndex < startIndex || endIndex > val.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(endIndex), "End index is out of range.");
            }

            return val.Substring(startIndex, endIndex - startIndex);
        }

        /// <summary>Ensures a string starts with a specific prefix.</summary>
        /// <param name="val">The string to check and modify.</param>
        /// <param name="prefix">The prefix the string should start with.</param>
        /// <returns>The modified string with the specified prefix.</returns>
        public static string EnsureStartsWith(this string val, string prefix)
        {
            if (!val.StartsWith(prefix))
            {
                return prefix + val;
            }
            return val;
        }

    }

}