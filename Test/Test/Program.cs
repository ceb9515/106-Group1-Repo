//this is robin typingz
namespace Test
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
        public int LongestSortedSequence(int[] Arr)
        {
            int a = 0;
            for (int i = 1; i < Arr.Length; i++)
            {
                if (Arr[i] >= Arr[i - 1])
                {
                    a++;
                }
                else
                {
                    a = 0;
                    
                }
            }
            return a;
        }
    }
}