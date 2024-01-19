//blank lines and comments

//Charlie


//this is robin typing

// this is jake typing

//this is Colby typing

namespace Test
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }


        public string LastFirst(string name)
        {
            //split the name
            string[] nameSplit = name.Split(" ");
            //collect the parts
            string firstName = nameSplit[0];
            string lastName = nameSplit[1];
            //fix the formatting
            lastName = ", " + lastName.Substring(0, 1) + ".";
            //return the result
            return firstName + lastName;
        }
    }

}