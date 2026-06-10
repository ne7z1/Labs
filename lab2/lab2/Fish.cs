namespace Lab2
{
    public class Fish : Animal
    {
        public string waterType;

        public Fish(string name, int age, string habitat, string dietType, string waterType)
          : base(name, age, habitat, dietType)
        {
            this.waterType = waterType;
        }

        public override string GetInfo()
        {
            return base.GetInfo() + ", Тип: Рыба, Вода: " + waterType;
        }
    }
}