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
            DiceSum();
        }

        /// <summary>
        /// First Problem
        /// User enters sum for the program to roll for
        /// </summary>
        public static void DiceSum()
        {
            int sumToRoll = 0;
            Random rng = new Random();

            int rollOne = 0;
            int rollTwo = 0;

            bool desireCheck = false;
            while (desireCheck == false)
            {
                Console.Write("Desired dice sum: ");
                sumToRoll = int.Parse(Console.ReadLine()!.Trim());
                if (sumToRoll >= 2 & sumToRoll <= 12)
                {
                    desireCheck = true;
                }
                else
                {
                    Console.WriteLine("Invalid sum\n");
                }
            }

            while (rollOne + rollTwo != sumToRoll)
            {
                rollOne = rng.Next(1, 7);
                rollTwo = rng.Next(1, 7);
                Console.WriteLine(rollOne + " and " + rollTwo + " = " + (rollOne + rollTwo));
            }
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