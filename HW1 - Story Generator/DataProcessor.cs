using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1___Story_Generator
{
    internal class DataProcessor
    {
        /// <summary>
        /// Converts a text file into a nested list of useable strings from each line of the file.
        /// </summary>
        /// <param name="filename">file to be read</param>
        /// <returns>list of data lines formatted as strings</returns>
        public List<string[]> Load(string filename)
        {
            //setup stream reader to grab input from file + establish nested list
            StreamReader input = null;
            input = new StreamReader(filename);
            List<string[]> dataList = new List<string[]>();

            //loop for reading each line
            string line = "";
            while ((line = input.ReadLine()) != null)
            {
                //split the line into strings
                string[] splitLine = line.Split("|");
                dataList.Add(splitLine);
            }
            //return the finalized list
            return dataList;
        }
    }
}
