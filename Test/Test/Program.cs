//this is robin typingz
namespace Test
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
           
           
        }
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
    }
}