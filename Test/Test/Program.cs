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
            DiceSum();
            Console.WriteLine("\nLastFirst: " + LastFirst("Wedge Antilles"));
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

        /// <summary>
        /// reformats a given name to firstname, last initial
        /// </summary>
        /// <param name="name">name to be formatted</param>
        /// <returns>properly formatted name</returns>
        public static string LastFirst(string name)
        {
            //split the name
            string[] nameSplit = name.Split(" ");
            //collect the parts
            string lastName = nameSplit[0];
            string firstName = nameSplit[1];
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

        /// <summary>
        /// find the longest duplicate number in an array
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns>the number which is longest duplicated array</returns>
        public static int GetLongestDuplicate(int[] numbers)
        {
            int num;
            int record = 0;
            int count = 1;
            int maxCount = 1;
            for (int i = 1; i < numbers.Length; i++)
            {
                num = numbers[i];
                if (num == numbers[i - 1])
                {
                    count++;
                    if (count > maxCount)
                    {
                        maxCount = count;
                        record = num;
                    }
                }
                else
                {
                    count = -1;
                }
            }
            if (record != 0)
            {
                return record;
            }
            else
            {
                return numbers[numbers.Length - 1];
            }
        }
    }
}