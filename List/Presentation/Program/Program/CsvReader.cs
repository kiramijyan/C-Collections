using Pluralsight.BegCShCollections.TopTenPops;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Program
{
    class CsvReader
    {
        private string _csvFilePath;

        public CsvReader(string csvFilePath)
        {
            this._csvFilePath = csvFilePath;
        }

        public List<Country> ReadAllCountries ()
        {
            List<Country> countries = new List<Country>();

            using(StreamReader sr = new StreamReader(_csvFilePath))
            {
                sr.ReadLine();
                string csvLine = sr.ReadLine();
                while ((csvLine = sr.ReadLine()) != null)
                {
                    countries.Add(ReadCountryFromCsvLine(csvLine));
                }
            }
            return countries;
        }

        public Country ReadCountryFromCsvLine(string csvLine)
        {
            string[] parts = csvLine.Split(',');

            string name;
            string code;
            string region;
            string popText;

            switch (parts.Length)
            {
                case 4:
                    name = parts[0];
                    code = parts[1];
                    region = parts[2];
                    popText = parts[3];
                    break;
                case 5:
                    name = parts[0] + ", " + parts[1];
                    name = name.Replace("\"", null).Trim();
                    code = parts[2];
                    region = parts[3];
                    popText = parts[4];
                    break;
                default:
                    throw new Exception($"Can't parse country from csvLine: {csvLine}");
            }

            // int population = int.Parse(parts[3]);

            int.TryParse(popText, out int population);
            Country country = new Country(name, code, region, population);
            return country;
        }
    }
}
