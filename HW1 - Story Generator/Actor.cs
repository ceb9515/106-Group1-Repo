//Sanxing wang
//1/25/2024
//actorclass in HW1
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1___Story_Generator
{
    internal class Actor : DataProcessor
    {
        // fields
        private Random rand;
        private List<string[]> Actors;
        private string pronone;
        /// <summary>
        /// propertie
        /// </summary>

        public string Pronone { get { return pronone; }set { pronone = value; } }
        /// <summary>
        /// constructor
        /// </summary>
        public Actor()
        {
            Actors = Load("../../../Actor.txt");
            rand = new Random();
        }
        /// <summary>
        /// return a random character intro sentence
        /// </summary>
        /// <returns></returns>
        public string[] Output()
        {
            int n=rand.Next(Actors.Count);
            if (Actors[n][1] == "male")
            {
                Pronone = "he";
            }
            else
            {
                Pronone = "she";
            }

            //create outputInfo string array to return pronouns + actor's story
            string[] outputInfo = new string[3];
            outputInfo[0] = pronone;
            outputInfo[1] = Actors[n][0];
            outputInfo[2] = Actors[n][0] + " is " + Actors[n][4]+ " and " +pronone+ " is " + Actors[n][2]+ " around " + Actors[n][3]+ " " + pronone + " " + Actors[n][5];
            
            return outputInfo;
        }
    }
}
