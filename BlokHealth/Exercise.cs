using System.Drawing;

namespace BlokHealth
{
    class Exercise
    {
        public string Name = "Exercise";
        public string Describe = "Exercise";
        public string PartOfBody = "Exercise";
        public Image ExampleImage;

        public Exercise(string name, string describe, string patrOfBody, Image exampleImage)
        {
            Name = name;
            Describe = describe;
            PartOfBody = patrOfBody;
            ExampleImage = exampleImage;
        }

    }
}
