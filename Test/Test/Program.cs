//blank lines and comments

//Charlie


//this is robin typing

// this is jake typing

//this is Colby typing

//this is william typing
namespace Test
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
           
           
        }
        /// <summary>
        /// problem 4,find out length of increasing number in an Array.
        /// </summary>
        /// <param name="Arr"></param>
        /// <returns></returns>
        public static int LongestSortedSequence(int[] Arr)
        {
            int a = 0;
            int max = 0;
            for (int i = 1; i < Arr.Length; i++)
            {
                if (Arr[i] >= Arr[i - 1])
                {
                    a++;
                }
                else
                {
                    if (a > max)
                    {
                        max = a;
                    }
                    a = 0;
                    
                }
            }
            return max;
        }


        public string LastFirst(string name)
        {
            //split the name
            string[] nameSplit = name.Split(" ");
            //collect the parts
            string firstName = nameSplit[0];
            string lastName = nameSplit[1];
            //fix the formatting
            lastName = ", " + lastName.Substring(0, 1) + ".";
            //return the result
            return firstName + lastName;
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