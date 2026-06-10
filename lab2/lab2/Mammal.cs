namespace Lab2
{
    public class Mammal : Animal
    {
        public bool hasFur;

        public Mammal(string name, int age, string habitat, string dietType, bool hasFur)
          : base(name, age, habitat, dietType)
        {
            this.hasFur = hasFur;
        }

        public override string GetInfo()
        {
            return base.GetInfo() + ", “ип: ћлекопитающее, Ўерсть: " + (hasFur ? "есть" : "нет");
        }
    }
}