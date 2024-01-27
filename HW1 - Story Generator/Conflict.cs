using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1___Story_Generator
{
    internal class Conflict : DataProcessor
    {
        //fields
        private Random rng = new Random();
        private List<string[]> conflicts;

        public Conflict()
        {
            conflicts = Load("../../../conflictClass.txt");
        }

        public string GetConflict()
        {
            int number = conflicts.Count;
            return conflicts[rng.Next(number)][0];
        }



    }
}
