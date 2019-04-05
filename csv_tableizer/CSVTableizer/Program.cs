using System;
using System.IO;

namespace CSVTableizer
{
    class Program
    {
        static void Main(string[] args)
        {
            var csvData = File.ReadAllLines("data.csv");

            foreach (var item in Tablerizer.TablerizedCSVData(csvData))
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
    }
}