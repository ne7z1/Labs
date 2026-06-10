using System;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1

            // переменные
            int baseNumber;
            int exponent;
            long result;

            // ввод
            Console.Write("введите a: ");
            baseNumber = int.Parse(Console.ReadLine());

            Console.Write("введите n: ");
            exponent = int.Parse(Console.ReadLine());

            // подсчет
            result = 1;
            for (int powerIndex = 0; powerIndex < exponent; ++powerIndex)
            {
                result = result * baseNumber;
            }

            // вывод
            Console.WriteLine("a^n = " + result);




            // 2

            // переменные
            long inputNumber;
            string numberAsString;
            string secondDigit;
            string modifiedNumber;
            long finalNumber;

            // ввод
            Console.Write("введите x (>= 100): ");
            inputNumber = long.Parse(Console.ReadLine());

            // подсчет
            // переводим число в строку
            numberAsString = inputNumber.ToString();

            // запоминаем вторую цифру
            secondDigit = numberAsString[1].ToString();

            // уибраем вторую и берем первое чилсо и остальные после второй
            modifiedNumber = numberAsString[0] + numberAsString.Substring(2);

            // добавляем вторую справа
            modifiedNumber = modifiedNumber + secondDigit;

            finalNumber = long.Parse(modifiedNumber);

            // вывод
            Console.WriteLine("n = " + finalNumber);
        }
    }
}