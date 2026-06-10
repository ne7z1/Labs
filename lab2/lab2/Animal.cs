namespace Lab2
{
    public class Animal
    {
        public string name;
        public int age;
        public string habitat;
        public string dietType;

        public Animal(string name, int age, string habitat, string dietType)
        {
            this.name = name;
            this.age = age;
            this.habitat = habitat;
            this.dietType = dietType;
        }

        public virtual string GetInfo()
        {
            return "Кличка: " + name + ", Возраст: " + age +
                   ", Среда: " + habitat + ", Питание: " + dietType;
        }
    }
}