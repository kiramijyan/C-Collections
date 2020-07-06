using System;
using System.Collections.Generic;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"D:\Bootcamp\C_Sharp\pluralsight\C# Collections\src\Pop by Largest Final.csv";
            CsvReader reader = new CsvReader(filePath);

            Dictionary<string, Country> countries = reader.ReadAllCountries();

            Console.WriteLine("Which country code you want to look up? ");

            string userInput = Console.ReadLine();

            bool exist = countries.TryGetValue(userInput, out Country country);

            if (exist)
            {
                Console.WriteLine($"{country.Name} has population " +
                    $"{PopulationFormatter.FormatPopulation(country.Population)}");
            }
            else
            {
                Console.WriteLine($"No country with {userInput} code was found");
            }
        }
    }
}
