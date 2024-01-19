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

        public static bool IsPalindrome(string word)
        {
            int count = word.Length - 1;
            for (int x = 0; x < word.Length; x++) 
            {
                if (word[x] != word[count])
                {
                    return false;
                }
            }
            return true;
        }
    }


}