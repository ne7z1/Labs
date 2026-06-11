using System;
using System.IO;
using System.Text;

namespace Lab5 {
  public class SpellFixer {
    SpellDictionary spellDictionary;

    public SpellFixer(SpellDictionary spellDictionary) {
      this.spellDictionary = spellDictionary;
    }

    // Исправить все .txt файлы в директории
    public void FixDirectory(string directoryPath) {
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
        string fixedContent = spellDictionary.FixText(originalContent);

        if (originalContent != fixedContent) {
          File.WriteAllText(fileList[fileIndex], fixedContent, Encoding.UTF8);
          Console.WriteLine("Исправлен: " + fileList[fileIndex]);
        } else {
          Console.WriteLine("Без изменений: " + fileList[fileIndex]);
        }
      }

      Console.WriteLine("Обработка завершена. Файлов: " + fileList.Length);
    }
  }
}
