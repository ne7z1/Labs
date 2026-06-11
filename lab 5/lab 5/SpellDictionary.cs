using System.Collections.Generic;

namespace Lab5 {
  public class SpellDictionary {
    // Словарь: правильное слово -> список ошибочных вариантов
    Dictionary<string, List<string>> errorDictionary;

    public SpellDictionary() {
      errorDictionary = new Dictionary<string, List<string>>();
      FillDefaultDictionary();
    }

    void FillDefaultDictionary() {
      // Формат: правильное слово -> ошибочные варианты
      AddEntry("привет", new List<string> { "првиет", "пирвет", "привте" });
      AddEntry("пожалуйста", new List<string> { "пожалуста", "пожалуйсто", "пожалста" });
      AddEntry("спасибо", new List<string> { "спасиба", "спасибо", "спасибо" });
      AddEntry("программирование", new List<string> { "програмирование", "программированние", "прогрмирование" });
      AddEntry("компьютер", new List<string> { "компютер", "кампьютер", "компьютор" });
      AddEntry("файл", new List<string> { "фаил", "файил", "фйал" });
      AddEntry("директория", new List<string> { "директория", "диретория", "дирктория" });
    }

    public void AddEntry(string correctWord, List<string> errorList) {
      errorDictionary[correctWord] = errorList;
    }

    // Исправить текст по словарю
    public string FixText(string text) {
      string resultText = text;
      foreach (string correctWord in errorDictionary.Keys) {
        List<string> errorList = errorDictionary[correctWord];
        for (int errorIndex = 0; errorIndex < errorList.Count; ++errorIndex) {
          resultText = resultText.Replace(errorList[errorIndex], correctWord);
        }
      }
      return resultText;
    }

    public Dictionary<string, List<string>> GetDictionary() {
      return errorDictionary;
    }
  }
}
