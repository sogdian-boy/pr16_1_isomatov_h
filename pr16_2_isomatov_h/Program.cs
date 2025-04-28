using System.Linq;
using System.IO;
using System;
using System.Collections.Generic;

namespace pr16_2_isomatov_h
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите элементы массива строк (разделяйте их нажатием на Enter, для завершения введите пустую строку)");
            List<string> list = new List<string>();
            string input;
            while (!string.IsNullOrWhiteSpace(input = Console.ReadLine()))
            {
                list.Add(input);
            }
            string[] stringMass = list.ToArray();
            A(stringMass);
            B(stringMass);
            С(stringMass);


        }
        static void A(string[] mass)
        {
            int DigitCount = mass.Sum(s => s.Count(char.IsDigit));

            var allDigits = mass
                .SelectMany(s => s.Where(char.IsDigit))
                .ToArray();
            Console.Write($"\nА:\nОбщее количество цифр в массиве: {DigitCount}\nНайденные цифры: ");
            if (allDigits.Length > 0)
            {
                Console.WriteLine(string.Join(", ", allDigits));
            }
            else
            {
                Console.WriteLine("нет");
            }
        }

        static void B(string[] mass)
        {
            Console.Write( $"\nB:\n");

            var beforeSlash = mass
                .TakeWhile(s => !s.Contains("/"))
                .ToArray();
            
            if (beforeSlash.Length > 0)
            {
                Console.WriteLine("Элементы до первого \"/\":");
                Console.WriteLine(string.Join(", ",beforeSlash));
            }
            else
            {
                Console.WriteLine("До \"/\" нет символов");
            }
        }
        
        static void С(string[] mass)
        {
            Console.Write($"\nC:\n");

            int slashIndex = Array.FindIndex(mass, s => s.Contains("/"));
            
            

            if (slashIndex > 0 && slashIndex < mass.Length-1)
            {
                var afterSlash = mass
                .Skip(slashIndex+1)
                .Select(s=>Change(s))
                .ToArray();
                Console.WriteLine("Элементы после первого \"/\" с заменой регистра:");
                Console.WriteLine(string.Join(", ", afterSlash));
                try
                {
                    File.WriteAllLines("result.txt",afterSlash);
                    Console.WriteLine("элементы нового массива сохранены в файл \"result.txt\"");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Ошибка при записи в файл: {e}");
                }
            }
            else
                {
                Console.WriteLine("После \"/\" нет символов");
            }
        }
        
        static string Change(string input)
        {
            return new string(input.Select(c=>char.IsLetter(c)?(char.IsUpper(c)?char.ToLower(c):char.ToUpper(c)) : c).ToArray());
        }
    }
}
