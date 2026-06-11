namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            // добавление животных
            AnimalManager.Instance.AddAnimal(new Mammal("Барсик", 5, "лес", "хищник", true));
            AnimalManager.Instance.AddAnimal(new Bird("Попугай Кеша", 3, "небо", "всеядное", 0.5));
            AnimalManager.Instance.AddAnimal(new Fish("Рыбка Немо", 2, "океан", "всеядное", "морская"));
            AnimalManager.Instance.AddAnimal(new Reptile("Геннадий", 7, "пустыня", "хищник", false));
            AnimalManager.Instance.AddAnimal(new Amphibian("Ящерка", 4, "болото", "всеядное", "влажная"));

            // меню
            AnimalManager.Instance.ShowMenu();
        }
    }
}