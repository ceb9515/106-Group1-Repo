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
            DiceSum();
        }


        /// <summary>
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
    }

}