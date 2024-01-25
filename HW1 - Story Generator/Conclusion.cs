using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1___Story_Generator
{
    /// <summary>
    /// Uses data processor to process conclusion file, 
    /// then select a conclusion based on the chosen genre
    /// </summary>
    internal class Conclusion
    {
        Random rng;

        //List generated from data file
        List<string[]> conclusionGenerator;

        //Data processor
        DataProcessor dataProcessor;

        //List to fill with endings to be randomly selected
        List<string> appropriateConclusions;

        public Conclusion()
        {
            dataProcessor = new DataProcessor();
            conclusionGenerator = dataProcessor.Load("../../../Conclusions.txt");
            appropriateConclusions = new List<string>();
            rng = new Random();
        }

        /// <summary>
        /// filters the conclusion genres, and selects one
        /// </summary>
        /// <param name="choice"> type of ending requested </param>
        /// <returns> an ending </returns>
        public string Sort(string choice)
        {
            appropriateConclusions.Clear();
            for (int i = 0; i < conclusionGenerator.Count; i++)
            {
                if (conclusionGenerator[i][0] == choice)
                {
                    appropriateConclusions.Add(conclusionGenerator[i][1]);
                }
            }

            return appropriateConclusions[rng.Next(0, appropriateConclusions.Count())];
        }

        /// <summary>
        /// Adds all endings to the list, then randomly selects one
        /// </summary>
        /// <returns> one ending </returns>
        public string AnyEnding()
        {
            appropriateConclusions.Clear();
            for (int i = 0; i < conclusionGenerator.Count; i++)
            {
                appropriateConclusions.Add(conclusionGenerator[i][1]);
            }

            return appropriateConclusions[rng.Next(0, appropriateConclusions.Count())];
        }
    }
}
