namespace Lab2
{
    public class Reptile : Animal
    {
        public bool isVenomous;

        public Reptile(string name, int age, string habitat, string dietType, bool isVenomous)
          : base(name, age, habitat, dietType)
        {
            this.isVenomous = isVenomous;
        }

        public override string GetInfo()
        {
            return base.GetInfo() + ", “ип: ѕресмыкающеес€, ядовитое: " + (isVenomous ? "да" : "нет");
        }
    }
}