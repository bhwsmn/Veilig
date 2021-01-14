using System;
using System.Linq;

namespace Veilig.Helpers
{
    public static class SlugGenerator
    {
        /// <summary>
        /// Generate a string based on a constant list of chars of random length defined by parameters.
        /// </summary>
        /// <param name="length">Length of the generated slug string</param>
        /// <returns>Generated slug string containing random characters from the constant list of chars</returns>
        public static string Generate(int length)
        {
            // Avoid using 1, l, I, o, O, 0 and similar ambiguous characters
            const string chars = "ABCDEFGHJKLMNPQRSTUVWXYZabcdefghijkmnpqrstuvwxyz23456789";

            var random = new Random();

            var slugString = new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)])
                .ToArray());

            return slugString;
        }
    }
}