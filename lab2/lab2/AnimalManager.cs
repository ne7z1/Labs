using System;
using System.Collections.Generic;

namespace Lab2
{
    public class AnimalManager
    {
        static AnimalManager instance;

        public static AnimalManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AnimalManager();
                }
                return instance;
            }
        }

        AnimalManager()
        {
            animalList = new List<Animal>();
        }

        List<Animal> animalList;

        public void AddAnimal(Animal animal)
        {
            animalList.Add(animal);
            Console.WriteLine("Животное добавлено: " + animal.name);
        }

        public void PrintAll()
        {
            if (animalList.Count == 0)
            {
                Console.WriteLine("Список животных пуст.");
                return;
            }
            for (int animalIndex = 0; animalIndex < animalList.Count; ++animalIndex)
            {
                Console.WriteLine(animalIndex + ": " + animalList[animalIndex].GetInfo());
            }
        }

        public void PrintByIndex(int index)
        {
            if (index < 0 || index >= animalList.Count)
            {
                Console.WriteLine("Неверный индекс.");
                return;
            }
            Console.WriteLine(animalList[index].GetInfo());
        }

        public void ShowMenu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("\nМенеджер животных");
                Console.WriteLine("1. Показать всех животных");
                Console.WriteLine("2. Показать животное по индексу");
                Console.WriteLine("3. Добавить животное");
                Console.WriteLine("0. Выход");
                Console.Write("Выбор: ");

                string input = Console.ReadLine();

                if (input == "1")
                {
                    PrintAll();
                }
                else if (input == "2")
                {
                    Console.Write("Введите индекс: ");
                    string indexInput = Console.ReadLine();
                    int parsedIndex;
                    bool isParsed = int.TryParse(indexInput, out parsedIndex);
                    if (isParsed)
                    {
                        PrintByIndex(parsedIndex);
                    }
                    else
                    {
                        Console.WriteLine("Введите корректное число.");
                    }
                }
                else if (input == "3")
                {
                    AddAnimalFromMenu();
                }
                else if (input == "0")
                {
                    isRunning = false;
                }
                else
                {
                    Console.WriteLine("Неизвестная команда. Попробуйте снова.");
                }
            }
        }

        void AddAnimalFromMenu()
        {
            Console.WriteLine("Выберите тип животного:");
            Console.WriteLine("1. Млекопитающее");
            Console.WriteLine("2. Птица");
            Console.WriteLine("3. Рыба");
            Console.WriteLine("4. Пресмыкающееся");
            Console.WriteLine("5. Земноводное");
            Console.Write("Выбор: ");
            string typeInput = Console.ReadLine();

            Console.Write("Кличка: ");
            string animalName = Console.ReadLine();

            Console.Write("Возраст: ");
            int animalAge = int.Parse(Console.ReadLine());

            Console.Write("Среда обитания: ");
            string animalHabitat = Console.ReadLine();

            Console.Write("Тип питания: ");
            string animalDiet = Console.ReadLine();

            if (typeInput == "1")
            {
                Console.Write("Есть шерсть? (да/нет): ");
                bool hasFur = Console.ReadLine().ToLower() == "да";
                AddAnimal(new Mammal(animalName, animalAge, animalHabitat, animalDiet, hasFur));
            }
            else if (typeInput == "2")
            {
                Console.Write("Размах крыльев (метры): ");
                double wingSpan = double.Parse(Console.ReadLine());
                AddAnimal(new Bird(animalName, animalAge, animalHabitat, animalDiet, wingSpan));
            }
            else if (typeInput == "3")
            {
                Console.Write("Тип воды (пресная/морская): ");
                string waterType = Console.ReadLine();
                AddAnimal(new Fish(animalName, animalAge, animalHabitat, animalDiet, waterType));
            }
            else if (typeInput == "4")
            {
                Console.Write("Ядовитое? (да/нет): ");
                bool isVenomous = Console.ReadLine().ToLower() == "да";
                AddAnimal(new Reptile(animalName, animalAge, animalHabitat, animalDiet, isVenomous));
            }
            else if (typeInput == "5")
            {
                Console.Write("Влажность кожи (влажная/сухая/умеренная): ");
                string skinMoisture = Console.ReadLine();
                AddAnimal(new Amphibian(animalName, animalAge, animalHabitat, animalDiet, skinMoisture));
            }
            else
            {
                Console.WriteLine("Неизвестный тип.");
            }
        }
    }
}