using System;
using System.Collections.Generic;
using System.Linq;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"D:\Bootcamp\C_Sharp\pluralsight\C# Collections\src\Pop by Largest Final.csv";
            CsvReader reader = new CsvReader(filePath);

            Dictionary<string, List <Country>> countries = reader.ReadAllCountriesListCollection();

            foreach(string region in countries.Keys)
            {
                Console.WriteLine(region);
            }

            Console.Write("Which of the above regions do you want? ");
            string choesenRegion = Console.ReadLine();

            if (countries.ContainsKey(choesenRegion))
            {
                foreach(Country country in countries[choesenRegion].Take(10))
                {
                    Console.WriteLine($"{PopulationFormatter.FormatPopulation(country.Population).PadLeft(15)}: {country.Name}");
                }
            }

        }

        static void DictionaryListLINQ()
        {
            string filePath = @"D:\Bootcamp\C_Sharp\pluralsight\C# Collections\src\Pop by Largest Final.csv";
            CsvReader reader = new CsvReader(filePath);

            Dictionary<string, Country> countries = reader.ReadAllCountriesDic();

            List<Country> countriesList = reader.ReadAllCountriesList();
            // ForDemo(countriesList);

            // ForDemoRemoveContries(countriesList);
            // countriesList.RemoveAll(x => x.Name.Contains(','));

            // ForDemoNCountriesInTime(countriesList);


            foreach (Country country in countriesList.Where(x => !x.Name.Contains(',')).Take(30))
            {
                Console.WriteLine($"{PopulationFormatter.FormatPopulation(country.Population).PadLeft(15)}: {country.Name}");
            }
        }


        static void ForDemoRemoveContries (List<Country> countriesList)
        {
            for (int i = countriesList.Count - 1; i >= 0; i--)
            {
                if (countriesList[i].Name.Contains(','))
                {
                    countriesList.RemoveAt(i);
                }
            }
        }

        static void ForDemoReverse(List<Country> countriesList)
        {

            Console.WriteLine("Eter no. of countries to display");
            bool inputIsInt = int.TryParse(Console.ReadLine(), out int userInput);

            if (!inputIsInt || userInput <= 0)
            {
                Console.WriteLine("You must positive integer.");
                return;
            }

            int maxToDisplay = userInput;

            for (int i = countriesList.Count -1; i >= 0; i--)
            {
                int displayOrder = countriesList.Count - 1 - i;
                if (displayOrder > 0 && (displayOrder % maxToDisplay == 0))
                {
                    Console.WriteLine("Hit the return to continue, anything else to quit > ");
                    if (Console.ReadLine() != "")
                    {
                        break;
                    }
                }
                Country country = countriesList[i];
                Console.WriteLine($"{displayOrder + 1}: {PopulationFormatter.FormatPopulation(country.Population).PadLeft(15)}: {country.Name}");
            }
        }

        static void ForDemoNCountriesInTime(List<Country> countriesList)
        {

            Console.WriteLine("Eter no. of countries to display");
            bool inputIsInt = int.TryParse(Console.ReadLine(), out int userInput);

            if (!inputIsInt || userInput <= 0)
            {
                Console.WriteLine("You must positive integer.");
                return;
            }

            int maxToDisplay = userInput;

            for (int i = 0; i < countriesList.Count; i++)
            {
                if(i > 0 && (i % maxToDisplay == 0))
                {
                    Console.WriteLine("Hit the return to continue, anything else to quit > ");
                    if(Console.ReadLine() != "")
                    {
                        break;
                    }
                }
                Country country = countriesList[i];
                Console.WriteLine($"{i+1}: {PopulationFormatter.FormatPopulation(country.Population).PadLeft(15)}: {country.Name}");
            }
        }


        static void ForNDemo(List<Country> countriesList)
        {
            Console.WriteLine("Eter no. of countries to display");
            bool inputIsInt = int.TryParse(Console.ReadLine(), out int userInput);

            if(!inputIsInt || userInput <= 0)
            {
                Console.WriteLine("You must positive integer.");
                return;
            }

            int maxToDisplay = Math.Min(userInput, countriesList.Count);

            for (int i = 0; i < maxToDisplay; i++)
            {
                Country country = countriesList[i];
                Console.WriteLine($"{PopulationFormatter.FormatPopulation(country.Population).PadLeft(15)}: {country.Name}");
            }
        }

        static void ForDemo(List<Country> countriesList)
        {
            for(int i = 0; i < countriesList.Count; i++) {
                Country country = countriesList[i];
                Console.WriteLine($"{PopulationFormatter.FormatPopulation(country.Population).PadLeft(15)}: {country.Name}");
            }
        }

        static void ForEachDemo(List<Country> countriesList)
        {
            foreach(Country country in countriesList)
            {
                Console.WriteLine($"{PopulationFormatter.FormatPopulation(country.Population).PadLeft(15)}: {country.Name}");
            }
        }

        static void TryGetValueDemo(Dictionary <string, Country> countriesDic)
        {

            Console.WriteLine("Which country code you want to look up? ");
            string userInput = Console.ReadLine();
            bool exist = countriesDic.TryGetValue(userInput, out Country country);
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
