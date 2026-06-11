using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lab4 {
  public class TextEditor {
    TextFile currentFile;
    List<EditorMemento> historyList;

    public TextEditor() {
      historyList = new List<EditorMemento>();
    }

    public void OpenFile(string filePath) {
      currentFile = new TextFile(filePath);
      historyList.Clear();
      Console.WriteLine("Файл открыт: " + filePath);
    }

    public void CreateFile(string filePath) {
      currentFile = new TextFile(filePath);
      currentFile.content = "";
      historyList.Clear();
      Console.WriteLine("Файл создан: " + filePath);
    }

    public void ShowContent() {
      if (currentFile == null) {
        Console.WriteLine("Файл не открыт.");
        return;
      }
      Console.WriteLine("--- Содержимое файла ---");
      Console.WriteLine(currentFile.content);
      Console.WriteLine("------------------------");
    }

    public void AppendText(string text) {
      if (currentFile == null) {
        Console.WriteLine("Файл не открыт.");
        return;
      }
      historyList.Add(new EditorMemento(currentFile.content));
      currentFile.content += text + Environment.NewLine;
      Console.WriteLine("Текст добавлен.");
    }

    public void ReplaceText(string oldText, string newText) {
      if (currentFile == null) {
        Console.WriteLine("Файл не открыт.");
        return;
      }
      historyList.Add(new EditorMemento(currentFile.content));
      currentFile.content = currentFile.content.Replace(oldText, newText);
      Console.WriteLine("Замена выполнена.");
    }

    public void Undo() {
      if (currentFile == null) {
        Console.WriteLine("Файл не открыт.");
        return;
      }
      if (historyList.Count == 0) {
        Console.WriteLine("Нет истории для отката.");
        return;
      }
      int lastIndex = historyList.Count - 1;
      currentFile.content = historyList[lastIndex].savedContent;
      historyList.RemoveAt(lastIndex);
      Console.WriteLine("Откат выполнен.");
    }

    public void SaveFile() {
      if (currentFile == null) {
        Console.WriteLine("Файл не открыт.");
        return;
      }
      currentFile.Save();
      Console.WriteLine("Файл сохранён: " + currentFile.filePath);
    }

    public void SaveBinary() {
      if (currentFile == null) {
        Console.WriteLine("Файл не открыт.");
        return;
      }
      currentFile.SaveBinary(currentFile.filePath + ".bin");
    }

    public void SaveXml() {
      if (currentFile == null) {
        Console.WriteLine("Файл не открыт.");
        return;
      }
      currentFile.SaveXml(currentFile.filePath + ".xml");
    }
  }
}
