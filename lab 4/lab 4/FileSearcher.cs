using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lab4 {
  public class FileSearcher {
    public List<string> SearchByKeywords(string directoryPath, List<string> keywordList) {
      List<string> foundFileList = new List<string>();

      if (!Directory.Exists(directoryPath)) {
        Console.WriteLine("Директория не найдена: " + directoryPath);
        return foundFileList;
      }

      string[] allFileList = Directory.GetFiles(directoryPath, "*.txt", SearchOption.AllDirectories);

      for (int fileIndex = 0; fileIndex < allFileList.Length; ++fileIndex) {
        string fileContent = File.ReadAllText(allFileList[fileIndex], Encoding.UTF8).ToLower();
        bool hasAllKeywords = true;

        for (int keywordIndex = 0; keywordIndex < keywordList.Count; ++keywordIndex) {
          if (!fileContent.Contains(keywordList[keywordIndex].ToLower())) {
            hasAllKeywords = false;
            break;
          }
        }

        if (hasAllKeywords) {
          foundFileList.Add(allFileList[fileIndex]);
        }
      }

      return foundFileList;
    }
  }
}
