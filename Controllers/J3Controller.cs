using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Assignment2.Controllers
{
    public class J3Controller : ApiController
    {
        /// <summary>
        /// Receives an input word to find the length of the longest palindrome contained in the given word. 2016 J3 problem
        /// </summary>
        /// <param name="word">The input word to check for the length of the longest palindrome contained in the given word</param>
        /// <returns>The length of the longest palindrome</returns>
        /// <example>
        ///     GET : /api/J3/HiddenPalindrome/banana => The length of longest palindrome in word banana is 5
        ///     GET : /api/J3/HiddenPalindrome/abracadabra => The length of longest palindrome in word abracadabra is 3
        ///     GET : /api/J3/HiddenPalindrome/abba => The length of longest palindrome in word abba is 4
        ///     GET : /api/J3/HiddenPalindrome/palindrome => The length of longest palindrome in word palindrome is 0
        ///     GET : /api/J3/HiddenPalindrome/Pneumonoultramicroscopicsilicovolcanoconiosis => Enter a word with length less than 40!
        /// </example>
        [Route("api/J3/HiddenPalindrome/{word}")]
        [HttpGet]
        public string HiddenPalindrome(string word)
        {
            if (word.Length >= 40)
            {
                return "Enter a word with length less than 40!";
            }
            int maxLength = 0;
            for (int i = 0; i < word.Length; i++)
            {
                for (int j = word.Length - 1; j >= i; j--)
                {
                    if (IsPalindrome(word.Substring(i, j - i + 1)))
                    {
                        int currentLength = j - i + 1;
                        if (currentLength > maxLength)
                        {
                            maxLength = currentLength;
                        }
                        break;
                    }
                }
            }
            if (maxLength == 1)
            {
                maxLength = 0;
            }
            return "The length of longest palindrome in word " + word + " is " + maxLength;
        }

        /// <summary>
        /// Function to checks if a given string is a palindrome.
        /// </summary>
        /// <param name="word">The input string</param>
        /// <returns>True if the string is a palindrome, otherwise false</returns>
        private bool IsPalindrome(string word)
        {
            int left = 0;
            int right = word.Length - 1;
            while (left < right)
            {
                if (word[left] != word[right])
                    return false;
                left++;
                right--;
            }
            return true;
        }
    }
}
