using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace pr16_4_isomatov_h
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var countries = ReadCountries("countries.txt");
                Console.WriteLine("Введите минимальную численность населения (например, 104000000): ");

                if (!long.TryParse(Console.ReadLine(), out long minPop))
                {
                    Console.WriteLine("Ошибка: введено некорректное число.");
                    return;
                }
                var sorted = FandS(countries, minPop);
                Result(sorted, minPop);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Файл не найден");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex}");
            }
        }
        static List<Country> ReadCountries(string fileName)
        {
            List<Country> countries = new List<Country>();
            foreach (var line in File.ReadAllLines(fileName))
            {
                var parts = line.Split(new[] {' ' },2,StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length == 2)
                {
                    var name = parts[0];
                    var population = long.Parse(parts[1].Replace(" ",""));
                    countries.Add(new Country { Name = name, Population = population });
                }
            }
            return countries;
        }

        static IEnumerable<Country> FandS(List<Country> countries, long minPop)
        {
            return countries
                .Where(c => c.Population > minPop)
                .OrderBy(c => c.Name.Length)
                .ThenBy(c => c.Name);
        }
        static void Result(IEnumerable<Country> countries, long minPop)
        {
            Console.WriteLine($"\nУпорядоченный список стран, у которых численность больше {minPop}:");

            foreach (var country in countries)
            {
                Console.WriteLine($"{country.Name} {country.Population}");
            }

            if (!countries.Any())
            {
                Console.WriteLine("Страны с указанной численностью не найдены.");
            }
        }
    }
}
