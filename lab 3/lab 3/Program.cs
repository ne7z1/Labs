using System;

namespace Lab3
{
    class Program
    {
        static SquareMatrix firstMatrix;
        static SquareMatrix secondMatrix;

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("\n--- Матричный калькулятор ---");
                Console.WriteLine("1. Создать матрицы случайно");
                Console.WriteLine("2. Показать матрицы");
                Console.WriteLine("3. Сложить матрицы");
                Console.WriteLine("4. Умножить матрицы");
                Console.WriteLine("5. Определитель первой матрицы");
                Console.WriteLine("6. Обратная матрица (первая)");
                Console.WriteLine("7. Сравнить матрицы");
                Console.WriteLine("8. Клонировать первую матрицу");
                Console.WriteLine("0. Выход");
                Console.Write("Выбор: ");

                string input = Console.ReadLine();

                try
                {
                    if (input == "1")
                    {
                        CreateMatrices();
                    }
                    else if (input == "2")
                    {
                        ShowMatrices();
                    }
                    else if (input == "3")
                    {
                        AddMatrices();
                    }
                    else if (input == "4")
                    {
                        MultiplyMatrices();
                    }
                    else if (input == "5")
                    {
                        ShowDeterminant();
                    }
                    else if (input == "6")
                    {
                        ShowInverse();
                    }
                    else if (input == "7")
                    {
                        CompareMatrices();
                    }
                    else if (input == "8")
                    {
                        CloneMatrix();
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
                catch (MatrixException matrixException)
                {
                    Console.WriteLine("Ошибка матрицы: " + matrixException.Message);
                }
                catch (Exception exception)
                {
                    Console.WriteLine("Ошибка: " + exception.Message);
                }
            }
        }

        static void CreateMatrices()
        {
            Console.Write("Введите размер матриц: ");
            int matrixSize = int.Parse(Console.ReadLine());
            firstMatrix = new SquareMatrix(matrixSize);
            secondMatrix = new SquareMatrix(matrixSize);
            Console.WriteLine("Матрицы созданы.");
        }

        static void ShowMatrices()
        {
            if (firstMatrix == null)
            {
                Console.WriteLine("Сначала создайте матрицы (пункт 1).");
                return;
            }
            Console.WriteLine("Первая матрица:");
            Console.WriteLine(firstMatrix.ToString());
            Console.WriteLine("Вторая матрица:");
            Console.WriteLine(secondMatrix.ToString());
        }

        static void AddMatrices()
        {
            if (firstMatrix == null)
            {
                Console.WriteLine("Сначала создайте матрицы (пункт 1).");
                return;
            }
            SquareMatrix resultMatrix = firstMatrix + secondMatrix;
            Console.WriteLine("Результат сложения:");
            Console.WriteLine(resultMatrix.ToString());
        }

        static void MultiplyMatrices()
        {
            if (firstMatrix == null)
            {
                Console.WriteLine("Сначала создайте матрицы (пункт 1).");
                return;
            }
            SquareMatrix resultMatrix = firstMatrix * secondMatrix;
            Console.WriteLine("Результат умножения:");
            Console.WriteLine(resultMatrix.ToString());
        }

        static void ShowDeterminant()
        {
            if (firstMatrix == null)
            {
                Console.WriteLine("Сначала создайте матрицы (пункт 1).");
                return;
            }
            Console.WriteLine("Определитель первой матрицы: " + firstMatrix.Determinant());
        }

        static void ShowInverse()
        {
            if (firstMatrix == null)
            {
                Console.WriteLine("Сначала создайте матрицы (пункт 1).");
                return;
            }
            SquareMatrix inverseMatrix = firstMatrix.Inverse();
            Console.WriteLine("Обратная матрица:");
            Console.WriteLine(inverseMatrix.ToString());
        }

        static void CompareMatrices()
        {
            if (firstMatrix == null)
            {
                Console.WriteLine("Сначала создайте матрицы (пункт 1).");
                return;
            }
            Console.WriteLine("Первая > Вторая: " + (firstMatrix > secondMatrix));
            Console.WriteLine("Первая < Вторая: " + (firstMatrix < secondMatrix));
            Console.WriteLine("Первая == Вторая: " + (firstMatrix == secondMatrix));
            Console.WriteLine("CompareTo: " + firstMatrix.CompareTo(secondMatrix));
        }

        static void CloneMatrix()
        {
            if (firstMatrix == null)
            {
                Console.WriteLine("Сначала создайте матрицы (пункт 1).");
                return;
            }
            SquareMatrix clonedMatrix = firstMatrix.Clone();
            Console.WriteLine("Клон первой матрицы:");
            Console.WriteLine(clonedMatrix.ToString());
            Console.WriteLine("Equals (клон == оригинал): " + firstMatrix.Equals(clonedMatrix));
        }
    }
}