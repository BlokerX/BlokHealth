using System.Drawing;

namespace BlokHealth
{
    class Product
    {
        public string Name = "<nazwa>";
        public string Describe = "<opis>";

        // -----------------------
        public string EnergyValue = "<wartosc-energetyczna>";
        public string Protein = "<bialko>";
        public string Fat = "<tluszcz>";
        public string Carbohydrates = "<weglowodany>";
        public string Fiber = "<blonnik>";

        public string Vitamins = "<witaminy>";

        public string Minerals = "<mineraly>";
        // -----------------------

        public Image ExampleImage;

        public Product
        (string name,
         string describe,
         string energyValue,
         string protein,
         string fat,
         string carbohydrates,
         string fiber,
         string vitamins,
         string minerals,
         Image exampleImage)
        {
            Name = name;
            Describe = describe;
            EnergyValue = energyValue;
            Protein = protein;
            Fat = fat;
            Carbohydrates = carbohydrates;
            Fiber = fiber;
            Vitamins = vitamins;
            Minerals = minerals;
            ExampleImage = exampleImage;
        }

    }
}
