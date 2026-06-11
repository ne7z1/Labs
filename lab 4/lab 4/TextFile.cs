using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Lab4 {
  [Serializable]
  public class TextFile {
    public string filePath;
    public string content;
    public List<string> keywordList;

    public TextFile() {
      keywordList = new List<string>();
      content = "";
      filePath = "";
    }

    public TextFile(string filePath) {
      this.filePath = filePath;
      keywordList = new List<string>();
      content = File.Exists(filePath) ? File.ReadAllText(filePath, Encoding.UTF8) : "";
    }

    public void Save() {
      File.WriteAllText(filePath, content, Encoding.UTF8);
    }

    public void AddKeyword(string keyword) {
      if (!keywordList.Contains(keyword)) {
        keywordList.Add(keyword);
      }
    }

    // Бинарная сериализация
    public void SaveBinary(string outputPath) {
      using (FileStream fileStream = new FileStream(outputPath, FileMode.Create)) {
        System.Runtime.Serialization.Formatters.Binary.BinaryFormatter formatter =
          new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
        formatter.Serialize(fileStream, this);
      }
      Console.WriteLine("Бинарная сериализация выполнена: " + outputPath);
    }

    public static TextFile LoadBinary(string inputPath) {
      using (FileStream fileStream = new FileStream(inputPath, FileMode.Open)) {
        System.Runtime.Serialization.Formatters.Binary.BinaryFormatter formatter =
          new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
        return (TextFile)formatter.Deserialize(fileStream);
      }
    }

    // XML сериализация
    public void SaveXml(string outputPath) {
      XmlSerializer xmlSerializer = new XmlSerializer(typeof(TextFile));
      using (StreamWriter streamWriter = new StreamWriter(outputPath, false, Encoding.UTF8)) {
        xmlSerializer.Serialize(streamWriter, this);
      }
      Console.WriteLine("XML сериализация выполнена: " + outputPath);
    }

    public static TextFile LoadXml(string inputPath) {
      XmlSerializer xmlSerializer = new XmlSerializer(typeof(TextFile));
      using (StreamReader streamReader = new StreamReader(inputPath, Encoding.UTF8)) {
        return (TextFile)xmlSerializer.Deserialize(streamReader);
      }
    }
  }
}
