using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pluralsight.BegCShCollections.TopTenPops
{
	class Program
	{
		static void Main(string[] args)
		{
			string filePath = @"D:\Bootcamp\C_Sharp\pluralsight\C# Collections\src\Pop by Largest Final.csv";
			CsvReader reader = new CsvReader(filePath);

			Country[] countries = reader.ReadFirstNCountries(10);
			
			foreach (Country country in countries)
			{
				Console.WriteLine($"{PopulationFormatter.FormatPopulation (country.Population).PadLeft(15)}: {country.Name}");
			}
			Console.ReadLine();
		}
	}
}
