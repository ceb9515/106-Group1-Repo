namespace HW1___Story_Generator
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //COMMENTED OUT CODE IS FOR TESTING DataProcessor
            /*
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
            */


            Console.WriteLine("Welcome to the story generator!");
            string input = "";
            while(input.ToLower() != "no")
            {
                //introduce user to choice options 
                Console.WriteLine("\nChoose a type of ending:\n\'happy\'\t\t\'tragic\'\t\'romantic\'\n\'destructive\'\t\'twist\'\t\t\'any ending\'");
                Console.Write("\nYour choice >> ");
                string storyType = Console.ReadLine();

                //get actor story and pronouns
                Actor actor = new Actor();
                string[] actorsInfo = actor.Output();
                string pronouns = actorsInfo[0];
                string name = actorsInfo[1];
                string actorStory = actorsInfo[2];

                //generate setting
                Setting setting = new Setting();

                //generate conflict
                Conflict conflict = new Conflict();

                //generate ending based on user input
                //--ENDING GENERATION WILL GO HERE

                //begin writing the story
                Console.WriteLine("\nStory Idea:");
                Console.Write(actorStory);
                Console.Write(" in " + setting.GetASetting() + ".");
                Console.Write(" However, " + pronouns + " " + conflict.GetConflict() + ".");
                //--ENDING INFORMATION WILL GO HERE


                //prompt the user on whether they would like another story or not, restarting the while loop
                Console.Write("\n\nWould you like another story? (\'yes\' or \'no\') >> ");
                input = Console.ReadLine();
            }

            //print exit statement
            Console.WriteLine("Thanks for using our story generator! Goodbye.");
        }
    }
}