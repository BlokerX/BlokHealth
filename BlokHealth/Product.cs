using System.Drawing;

namespace BlokHealth
{
    public class Product
    {
        public string Name = "<nazwa>";
        public string Describe = "<opis>";

        // -----------------------
        public double EnergyValue = 0;
        public string EnergyValueVarible = "kcal";

        public double Protein = 0;
        public string ProteinVarible = "g";

        public double Fat = 0;
        public string FatVarible = "g";

        public double Carbohydrates = 0;
        public string CarbohydratesVarible = "g";

        public double Fiber = 0;
        public string FiberVarible = "g";

        public string Vitamins = "<witaminy>";

        public string Minerals = "<mineraly>";
        // -----------------------

        public Image ExampleImage = BlokHealth.Properties.Resources.brak_zdjęcia;
        public string ExampleImagePath = "";

        public bool StaticProduct = false;

        public Product
        (string name,
         string describe,
         double energyValue,
         double protein,
         double fat,
         double carbohydrates,
         double fiber,
         string vitamins,
         string minerals,
         Image exampleImage,
         bool staticProduct)
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
            StaticProduct = staticProduct;
        }
        
        public Product
        (string name,
         string describe,
         double energyValue,
         string energyValueVarible,
         double protein,
         string proteinVarible,
         double fat,
         string fatVarible,
         double carbohydrates,
         string carbohydratesVarible,
         double fiber,
         string fiberVarible,
         string vitamins,
         string minerals,
         string exampleImagePath,
         bool staticProduct)
        {
            Name = name;
            Describe = describe;
            EnergyValue = energyValue;
            EnergyValueVarible = energyValueVarible;
            Protein = protein;
            ProteinVarible = proteinVarible;
            Fat = fat;
            FatVarible = fatVarible;
            Carbohydrates = carbohydrates;
            CarbohydratesVarible = carbohydratesVarible;
            Fiber = fiber;
            FiberVarible = fiberVarible;
            Vitamins = vitamins;
            Minerals = minerals;
            ExampleImagePath = exampleImagePath;
            StaticProduct = staticProduct;
        }

        public Product
        (string name,
         string describe,
         double energyValue,
         string energyValueVarible,
         double protein,
         double fat,
         double carbohydrates,
         double fiber,
         string vitamins,
         string minerals,
         Image exampleImage,
         bool staticProduct)
        {
            Name = name;
            Describe = describe;
            EnergyValue = energyValue;
            EnergyValueVarible = energyValueVarible;
            Protein = protein;
            Fat = fat;
            Carbohydrates = carbohydrates;
            Fiber = fiber;
            Vitamins = vitamins;
            Minerals = minerals;
            ExampleImage = exampleImage;
            StaticProduct = staticProduct;
        }

        public Product
        (string name,
         string describe,
         double energyValue,
         string energyValueVarible,
         double protein,
         string proteinVarible,
         double fat,
         string fatVarible,
         double carbohydrates,
         string carbohydratesVarible,
         double fiber,
         string fiberVarible,
         string vitamins,
         string minerals,
         Image exampleImage,
         bool staticProduct)
        {
            Name = name;
            Describe = describe;
            EnergyValue = energyValue;
            EnergyValueVarible = energyValueVarible;
            Protein = protein;
            ProteinVarible = proteinVarible;
            Fat = fat;
            FatVarible = fatVarible;
            Carbohydrates = carbohydrates;
            CarbohydratesVarible = carbohydratesVarible;
            Fiber = fiber;
            FiberVarible = fiberVarible;
            Vitamins = vitamins;
            Minerals = minerals;
            ExampleImage = exampleImage;
            StaticProduct = staticProduct;
        }

    }
}
