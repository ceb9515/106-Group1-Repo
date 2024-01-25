namespace HW1___Story_Generator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string story = "";
            Conclusion conclusion = new Conclusion();
            Console.WriteLine("What kind of conclusion do you want? \n Tragic \t " +
                "Happy \t Comedic \n Cliffhanger \t Realistic \t Any");
            string userChoice = Console.ReadLine()!.Trim().ToLower();
            bool choosing = true;
            while (choosing == true)
            {
                switch (userChoice)
                {
                    case "tragic":
                        {
                            story = conclusion.Sort(userChoice);
                            choosing = false;
                            break;
                        }

                    case "happy":
                        {
                            story = conclusion.Sort(userChoice);
                            choosing = false;
                            break;
                        }

                    case "comedic":
                        {
                            story = conclusion.Sort(userChoice);
                            choosing = false;
                            break;
                        }

                    case "cliffhanger":
                        {
                            story = conclusion.Sort(userChoice);
                            choosing = false;
                            break;
                        }

                    case "realistic":
                        {
                            story = conclusion.Sort(userChoice);
                            choosing = false;
                            break;
                        }

                    case "any":
                        {
                            story = conclusion.AnyEnding();
                            choosing = false;
                            break;
                        }

                    default:
                        {
                            Console.WriteLine("Invalid genre.");
                            break;
                        }
                }

                Console.WriteLine(story);
            }





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