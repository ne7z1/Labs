namespace Lab2
{
    public class Bird : Animal
    {
        public double wingSpan;

        public Bird(string name, int age, string habitat, string dietType, double wingSpan)
          : base(name, age, habitat, dietType)
        {
            this.wingSpan = wingSpan;
        }

        public override string GetInfo()
        {
            return base.GetInfo() + ", Тип: Птица, Размах крыльев: " + wingSpan + "м";
        }
    }
}