//blank lines and comments

//Charlie

//this is robin typing

// this is jake typing

//this is Colby typing

//this is william typing
using System;

namespace Test
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            DiceSum();
            Console.WriteLine("\nLastFirst: " + LastFirst("Wedge Antilles"));

            Console.WriteLine();
            // checks if Tacocat is a palindrome
            if (IsPalindrome("Tacocat")) 
            {
                Console.WriteLine("Tacocat is palindrome");
            }
            else
            {
                Console.WriteLine("Tacocat isn't a palindrome");
            }

            // checks if happy birthday is a palindrome
            if (IsPalindrome("happy birthday"))
            {
                Console.WriteLine("happy birthday is palindrome");
            }
            else
            {
                Console.WriteLine("happy birthday isn't a palindrome");
            }

            int[] arr1 = { 3, 8, 10, 1, 9, 14, -3, 0, 14, 207, 56, 98 };
            Console.WriteLine("\nThe array { 3, 8, 10, 1, 9, 14, -3, 0, 14, 207, 56, 98 } has longest sorted sequence of " + LongestSortedSequence(arr1));
            int[] arr2 = { 17, 42, 3, 5, 5, 5, 8, 2, 4, 6, 1, 19 };
            Console.WriteLine("\nThe array { 17, 42, 3, 5, 5, 5, 8, 2, 4, 6, 1, 19 } has longest sorted sequence of " + LongestSortedSequence(arr2));
            int[] numbers1 = { 2, 2, 4, 10, 10, 10, 10, 4, 2, 2, 2, 4 };
            Console.WriteLine("\nThe array { 2, 2, 4, 10, 10, 10, 10, 4, 2, 2, 2, 4 } get longest duplicate " + GetLongestDuplicate(numbers1));
            int[] numbers2 = { 5, 2, 4, 4, 6, 6, 6, 7, 7, 7, 1, 2 };
            Console.WriteLine("\nThe array { 5, 2, 4, 4, 6, 6, 6, 7, 7, 7, 1, 2 } get longest duplicate " + GetLongestDuplicate(numbers2));

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
            int a = 1;
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
                    a = 1;
                    
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
            int maxCount = 1;
            int currentCount = 1;
            int result = numbers[0];

            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] == numbers[i - 1])
                {
                    currentCount++;
                    if (currentCount >= maxCount)
                    {
                        maxCount = currentCount;
                        result = numbers[i];
                    }
                }
                else
                {
                    currentCount = 1;
                }
            }

            return result;
        }
    }
}