namespace HW1___Story_Generator
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //COMMENTED OUT CODE IS FOR TESTING DataProcessor
            /*
            string story = "";
            Conclusion conclusion = new Conclusion();
            Console.WriteLine("What kind of conclusion do you want? \n Tragic \t " +
                "Happy \t Comedic \n Cliffhanger \t Realistic \t Any");
            string userChoice = Console.ReadLine()!.Trim().ToLower();
            bool choosing = true;
            while (choosing == true)
            {


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
            */


            Console.WriteLine("Welcome to the story generator!");
            string input = "";
            while(input.ToLower() != "no")
            {

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
                string storyEnding = "";
                Conclusion conclusion = new Conclusion();
                //establish loop for user input selection
                bool choosing = true;
                while (choosing)
                {
                    //introduce user to choice options 
                    Console.WriteLine("\nChoose a type of ending:\n\'happy\'\t\t\'tragic\'\t\'comedic\'\n\'cliffhanger\'\t\'realistic\'\t\'any ending\'");
                    Console.Write("\nYour choice >> ");
                    string storyType = Console.ReadLine()!.Trim().ToLower();

                    //switch to ensure valid user case selection
                    switch (storyType)
                    {
                        case "tragic":
                            {
                                storyEnding = conclusion.Sort(storyType);
                                choosing = false;
                                break;
                            }

                        case "happy":
                            {
                                storyEnding = conclusion.Sort(storyType);
                                choosing = false;
                                break;
                            }

                        case "comedic":
                            {
                                storyEnding = conclusion.Sort(storyType);
                                choosing = false;
                                break;
                            }

                        case "cliffhanger":
                            {
                                storyEnding = conclusion.Sort(storyType);
                                choosing = false;
                                break;
                            }

                        case "realistic":
                            {
                                storyEnding = conclusion.Sort(storyType);
                                choosing = false;
                                break;
                            }

                        case "any":
                            {
                                storyEnding = conclusion.AnyEnding();
                                choosing = false;
                                break;
                            }

                        default:
                            {
                                Console.WriteLine("Invalid genre. Please Try Again.");
                                break;
                            }
                    }
                }

                //begin writing the story
                Console.WriteLine("\nStory Idea:");
                Console.Write(actorStory);
                Console.Write(" " + setting.GetASetting() + ".");
                Console.Write(" However, " + pronouns + " " + conflict.GetConflict() + ".");
                Console.Write(" " + storyEnding);
                //--ENDING INFORMATION WILL GO HERE


                //prompt the user on whether they would like another story or not, restarting the while loop
                Console.Write("\n\nWould you like another story? (\'yes\' or \'no\') >> ");
                input = Console.ReadLine();
                while(input != "yes" && input != "no")
                {
                    Console.Write("\nInput Invalid. Would you like another story? (\'yes\' or \'no\') >> ");
                    input = Console.ReadLine();
                }
            }

            //print exit statement
            Console.WriteLine("Thanks for using our story generator! Goodbye.");
        }
    }
}