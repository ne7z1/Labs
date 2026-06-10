namespace Lab2
{
    public class Amphibian : Animal
    {
        public string skinMoisture;

        public Amphibian(string name, int age, string habitat, string dietType, string skinMoisture)
          : base(name, age, habitat, dietType)
        {
            this.skinMoisture = skinMoisture;
        }

        public override string GetInfo()
        {
            return base.GetInfo() + ", Тип: Земноводное, Кожа: " + skinMoisture;
        }
    }
}