using System;
using System.Collections.Generic;

namespace Lab4
{
    class Program
    {
        static TextEditor editor = new TextEditor();
        static FileSearcher searcher = new FileSearcher();
        static FileIndexer indexer = new FileIndexer();

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("\n--- Консольный редактор текстовых файлов ---");
                Console.WriteLine("1. Создать новый файл");
                Console.WriteLine("2. Открыть файл");
                Console.WriteLine("3. Показать содержимое");
                Console.WriteLine("4. Добавить текст");
                Console.WriteLine("5. Заменить текст");
                Console.WriteLine("6. Отменить последнее действие");
                Console.WriteLine("7. Сохранить файл");
                Console.WriteLine("8. Сохранить в бинарном формате");
                Console.WriteLine("9. Сохранить в XML формате");
                Console.WriteLine("10. Поиск файлов по ключевым словам");
                Console.WriteLine("11. Индексация директории");
                Console.WriteLine("0. Выход");
                Console.Write("Выбор: ");

                string input = Console.ReadLine();

                try
                {
                    if (input == "1")
                    {
                        CreateNewFile();
                    }
                    else if (input == "2")
                    {
                        OpenFile();
                    }
                    else if (input == "3")
                    {
                        editor.ShowContent();
                    }
                    else if (input == "4")
                    {
                        AppendText();
                    }
                    else if (input == "5")
                    {
                        ReplaceText();
                    }
                    else if (input == "6")
                    {
                        editor.Undo();
                    }
                    else if (input == "7")
                    {
                        editor.SaveFile();
                    }
                    else if (input == "8")
                    {
                        editor.SaveBinary();
                    }
                    else if (input == "9")
                    {
                        editor.SaveXml();
                    }
                    else if (input == "10")
                    {
                        SearchFiles();
                    }
                    else if (input == "11")
                    {
                        IndexDirectory();
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

        static void CreateNewFile()
        {
            Console.Write("Введите путь к новому файлу: ");
            string filePath = Console.ReadLine();
            editor.CreateFile(filePath);
        }

        static void OpenFile()
        {
            Console.Write("Введите путь к файлу: ");
            string filePath = Console.ReadLine();
            editor.OpenFile(filePath);
        }

        static void AppendText()
        {
            Console.Write("Введите текст для добавления: ");
            string text = Console.ReadLine();
            editor.AppendText(text);
        }

        static void ReplaceText()
        {
            Console.Write("Что заменить: ");
            string oldText = Console.ReadLine();
            Console.Write("На что заменить: ");
            string newText = Console.ReadLine();
            editor.ReplaceText(oldText, newText);
        }

        static void SearchFiles()
        {
            Console.Write("Введите путь к директории: ");
            string directoryPath = Console.ReadLine();
            Console.Write("Введите ключевые слова через запятую: ");
            string keywordsInput = Console.ReadLine();

            List<string> keywordList = new List<string>(keywordsInput.Split(','));
            for (int keywordIndex = 0; keywordIndex < keywordList.Count; ++keywordIndex)
            {
                keywordList[keywordIndex] = keywordList[keywordIndex].Trim();
            }

            List<string> foundFileList = searcher.SearchByKeywords(directoryPath, keywordList);

            if (foundFileList.Count == 0)
            {
                Console.WriteLine("Файлы не найдены.");
            }
            else
            {
                Console.WriteLine("Найдены файлы:");
                for (int fileIndex = 0; fileIndex < foundFileList.Count; ++fileIndex)
                {
                    Console.WriteLine("  " + foundFileList[fileIndex]);
                }
            }
        }

        static void IndexDirectory()
        {
            Console.Write("Введите путь к директории: ");
            string directoryPath = Console.ReadLine();
            Console.Write("Введите ключевые слова через запятую: ");
            string keywordsInput = Console.ReadLine();

            List<string> keywordList = new List<string>(keywordsInput.Split(','));
            for (int keywordIndex = 0; keywordIndex < keywordList.Count; ++keywordIndex)
            {
                keywordList[keywordIndex] = keywordList[keywordIndex].Trim();
            }

            indexer.IndexDirectory(directoryPath, keywordList);
            indexer.PrintIndex();
        }
    }
}