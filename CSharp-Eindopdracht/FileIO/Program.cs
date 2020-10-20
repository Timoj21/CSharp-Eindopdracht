using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FileIO
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteToFile("jorn");
            ReadFromFile();
            
        }

        public static void WriteToFile(string playername)
        {

            string filepath = @"ScoreBoard.txt";
            List<string> lines = new List<string>();
            lines = File.ReadAllLines(filepath).ToList();
            int counter = lines.Count + 1;

            lines.Add(playername + " won game " + counter + "!");

            File.WriteAllLines(filepath, lines);

        }

        public static void ReadFromFile()
        {
            StreamReader reader = new StreamReader(@"ScoreBoard.txt");
            Console.WriteLine(reader.ReadToEnd());
            reader.Close();
        }
    }
}
