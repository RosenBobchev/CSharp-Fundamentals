using System;
using System.IO;

namespace _01.OddLines
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("text.txt");
            using (reader)
            {
                string line = string.Empty;
                int counter = 0;
                while (line != null)
                {

                    line = reader.ReadLine();
                    if (counter % 2 == 1)
                    {
                        Console.WriteLine(line);
                        break;
                    }
                    counter++;
                }
                
            }
        }
    }
}
