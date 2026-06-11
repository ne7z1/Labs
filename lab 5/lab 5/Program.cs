using System;
using System.Collections.Generic;

namespace Lab5
{
    class Program
    {
        static SpellDictionary spellDictionary = new SpellDictionary();
        static SpellFixer spellFixer;
        static PhoneReplacer phoneReplacer = new PhoneReplacer();

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            spellFixer = new SpellFixer(spellDictionary);

            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("\n--- Исправление текстов ---");
                Console.WriteLine("1. Показать словарь ошибок");
                Console.WriteLine("2. Добавить слово в словарь");
                Console.WriteLine("3. Исправить ошибки в файлах директории");
                Console.WriteLine("4. Заменить номера телефонов в файлах директории");
                Console.WriteLine("5. Проверить строку на ошибки");
                Console.WriteLine("6. Проверить строку на телефоны");
                Console.WriteLine("0. Выход");
                Console.Write("Выбор: ");

                string input = Console.ReadLine();

                try
                {
                    if (input == "1")
                    {
                        ShowDictionary();
                    }
                    else if (input == "2")
                    {
                        AddWord();
                    }
                    else if (input == "3")
                    {
                        FixDirectory();
                    }
                    else if (input == "4")
                    {
                        ReplacePhones();
                    }
                    else if (input == "5")
                    {
                        CheckString();
                    }
                    else if (input == "6")
                    {
                        CheckPhones();
                    }
                    else if (input == "0")
                    {
                        isRunning = false;
                    }
                    else
                    {
                        Console.WriteLine("Неизвестная команда.");
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine("Ошибка: " + exception.Message);
                }
            }
        }

        static void ShowDictionary()
        {
            Dictionary<string, List<string>> dictionary = spellDictionary.GetDictionary();
            Console.WriteLine("--- Словарь ошибок ---");
            foreach (string correctWord in dictionary.Keys)
            {
                List<string> errorList = dictionary[correctWord];
                string errors = "";
                for (int errorIndex = 0; errorIndex < errorList.Count; ++errorIndex)
                {
                    errors += errorList[errorIndex];
                    if (errorIndex < errorList.Count - 1)
                    {
                        errors += ", ";
                    }
                }
                Console.WriteLine(correctWord + " -> " + errors);
            }
        }

        static void AddWord()
        {
            Console.Write("Правильное слово: ");
            string correctWord = Console.ReadLine();
            Console.Write("Ошибочные варианты через запятую: ");
            string errorsInput = Console.ReadLine();

            string[] errorArray = errorsInput.Split(',');
            List<string> errorList = new List<string>();
            for (int errorIndex = 0; errorIndex < errorArray.Length; ++errorIndex)
            {
                errorList.Add(errorArray[errorIndex].Trim());
            }

            spellDictionary.AddEntry(correctWord, errorList);
            Console.WriteLine("Слово добавлено в словарь.");
        }

        static void FixDirectory()
        {
            Console.Write("Введите путь к директории: ");
            string directoryPath = Console.ReadLine();
            spellFixer.FixDirectory(directoryPath);
        }

        static void ReplacePhones()
        {
            Console.Write("Введите путь к директории: ");
            string directoryPath = Console.ReadLine();
            phoneReplacer.ReplaceInDirectory(directoryPath);
        }

        static void CheckString()
        {
            Console.Write("Введите строку для проверки: ");
            string inputText = Console.ReadLine();
            string fixedText = spellDictionary.FixText(inputText);
            Console.WriteLine("Исходный текст:   " + inputText);
            Console.WriteLine("Исправленный текст: " + fixedText);
        }

        static void CheckPhones()
        {
            Console.Write("Введите строку с номерами телефонов: ");
            string inputText = Console.ReadLine();
            string fixedText = phoneReplacer.ReplacePhones(inputText);
            Console.WriteLine("Исходный текст:   " + inputText);
            Console.WriteLine("Исправленный текст: " + fixedText);
        }
    }
}