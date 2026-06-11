using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Lab5 {
  public class PhoneReplacer {
    // Паттерн для номеров вида (012) 345-67-89
    static string phonePattern = @"\((\d{3})\)\s*(\d{3})-(\d{2})-(\d{2})";

    // Заменить все номера телефонов в файлах директории
    public void ReplaceInDirectory(string directoryPath) {
      if (!Directory.Exists(directoryPath)) {
        Console.WriteLine("Директория не найдена: " + directoryPath);
        return;
      }

      string[] fileList = Directory.GetFiles(directoryPath, "*.txt", SearchOption.AllDirectories);

      if (fileList.Length == 0) {
        Console.WriteLine("Текстовые файлы не найдены.");
        return;
      }

      for (int fileIndex = 0; fileIndex < fileList.Length; ++fileIndex) {
        string originalContent = File.ReadAllText(fileList[fileIndex], Encoding.UTF8);
        string fixedContent = ReplacePhones(originalContent);

        if (originalContent != fixedContent) {
          File.WriteAllText(fileList[fileIndex], fixedContent, Encoding.UTF8);
          Console.WriteLine("Номера заменены в: " + fileList[fileIndex]);
        } else {
          Console.WriteLine("Номера не найдены: " + fileList[fileIndex]);
        }
      }
    }

    public string ReplacePhones(string text) {
      return Regex.Replace(text, phonePattern, phoneMatch => {
        string areaCode = phoneMatch.Groups[1].Value;
        string firstPart = phoneMatch.Groups[2].Value;
        string secondPart = phoneMatch.Groups[3].Value;
        string thirdPart = phoneMatch.Groups[4].Value;
        return "+380 " + areaCode.Substring(1) + " " + firstPart + " " + secondPart + " " + thirdPart;
      });
    }
  }
}
