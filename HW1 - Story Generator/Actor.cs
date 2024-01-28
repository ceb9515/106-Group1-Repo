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
        private string pronones;
        private string pronone3;
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
                pronones = "his";
                pronone3 = "him";
            }
            else
            {
                Pronone = "she";
                pronones = "her";
                pronone3 = "her";
            }

            //create outputInfo string array to return pronouns + actor's story
            string[] outputInfo = new string[3];
            outputInfo[0] = pronone;
            outputInfo[1] = Actors[n][0];
            outputInfo[2] = Actors[n][0] + " is " + Actors[n][4]+ " and " + Actors[n][2]+". "+ pronones.Substring(0, 1).ToUpper() + pronones.Substring(1) + " age is around " + Actors[n][3]+ ", and " + pronone + " " + Actors[n][5]+". " + Actors[n][6]+" "+pronone3+" to";
            
            return outputInfo;
        }
    }
}
