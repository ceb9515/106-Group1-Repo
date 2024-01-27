using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1___Story_Generator
{
    internal class Setting : DataProcessor
    {
        // fields
        private Random rand;
        private List<string[]> settings;

        // constructor

        /// <summary>
        /// loads a list of all the settings
        /// </summary>
        public Setting()
        {
            settings = Load("../../../setting.txt");
            rand = new Random();
        }

        // methods

        /// <summary>
        /// gets a random setting from the list of settings
        /// </summary>
        /// <returns>returns a random setting that holds location and time of day</returns>
        public string GetASetting()
        {
            int randomSetting = rand.Next(0, 5);
            return settings[randomSetting][0] + " at " + settings[randomSetting][1];
        }
    }
}
