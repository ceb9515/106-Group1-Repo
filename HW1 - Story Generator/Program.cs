namespace HW1___Story_Generator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //create a DataProcessor and read your file (change "testData" to the name of your file"
            DataProcessor dataProcessor = new DataProcessor();
            List<string[]> storyData = dataProcessor.Load("../../../testData.txt");
            //loop through string arrays in list
            for(int i = 0; i < storyData.Count(); i++)
            {
                //loop through strings in array
                for(int k = 0; k < storyData[i].Length; k++)
                {
                    //write data point with a space inbetween each
                    Console.Write(storyData[i][k] + " ");
                }
                //add line break
                Console.WriteLine();
            }
        }
    }
}