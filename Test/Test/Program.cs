//blank lines and comments

//Charlie


//this is robin typing

// this is jake typing

//this is Colby typing

namespace Test
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        /// <summary>
        /// determines if a word is a palindrome
        /// </summary>
        /// <param name="word">incoming word to be checked</param>
        /// <returns>true if palindrome, false otherwise</returns>
        public static bool IsPalindrome(string word)
        {
            int count = word.Length - 1;
            word = word.ToLower();
            for (int x = 0; x < word.Length; x++) 
            {
                if (word[x] != word[count])
                {
                    return false;
                }
                count--;
            }
            return true;
        }
    }


}