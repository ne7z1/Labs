using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lab4 {
  public class FileIndexer {
    Dictionary<string, List<string>> keywordIndex;

    public FileIndexer() {
      keywordIndex = new Dictionary<string, List<string>>();
    }

    public void IndexDirectory(string directoryPath, List<string> keywordList) {
      keywordIndex.Clear();

      if (!Directory.Exists(directoryPath)) {
        Console.WriteLine("Директория не найдена: " + directoryPath);
        return;
      }

      for (int kwIndex = 0; kwIndex < keywordList.Count; ++kwIndex) {
        keywordIndex[keywordList[kwIndex]] = new List<string>();
      }

      string[] allFileList = Directory.GetFiles(directoryPath, "*.txt", SearchOption.AllDirectories);

      for (int fileIndex = 0; fileIndex < allFileList.Length; ++fileIndex) {
        string fileContent = File.ReadAllText(allFileList[fileIndex], Encoding.UTF8).ToLower();

        for (int kwIndex = 0; kwIndex < keywordList.Count; ++kwIndex) {
          string currentKeyword = keywordList[kwIndex];
          if (fileContent.Contains(currentKeyword.ToLower())) {
            keywordIndex[currentKeyword].Add(allFileList[fileIndex]);
          }
        }
      }

      Console.WriteLine("Индексация завершена. Обработано файлов: " + allFileList.Length);
    }

    public void PrintIndex() {
      if (keywordIndex.Count == 0) {
        Console.WriteLine("Индекс пуст. Сначала выполните индексацию.");
        return;
      }
      foreach (string keyword in keywordIndex.Keys) {
        Console.WriteLine("Ключевое слово: \"" + keyword + "\"");
        List<string> fileList = keywordIndex[keyword];
        if (fileList.Count == 0) {
          Console.WriteLine("  Не найдено ни в одном файле.");
        } else {
          for (int fileIndex = 0; fileIndex < fileList.Count; ++fileIndex) {
            Console.WriteLine("  " + fileList[fileIndex]);
          }
        }
      }
    }
  }
}
