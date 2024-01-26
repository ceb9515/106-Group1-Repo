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
            Actors = Load("Actor.txt");
            rand = new Random();
        }
        /// <summary>
        /// return a random character intro sentence
        /// </summary>
        /// <returns></returns>
        public string output()
        {
            int n=rand.Next(Actors.Count);
            if (Actors[n][1] == "male")
            {
                Pronone = "he";
            }
            else
            {
                Pronone = "her";
            }
            return Actors[n][0]+pronone+" is " + Actors[n][4]+" and "+pronone+" is  " + Actors[n][2]+ " around " + Actors[n][3]+" " + pronone + Actors[n][5];
            
        }
    }
}
