using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ShapeLibraryTests")]
namespace ShapeLibrary
{
    internal class Circle : ICircle
    {
        public float Radius { get; }

        public Vector Center { get; }

        private int VectorCount = 100;

        public Vector[] Vertices { get; }

        public Colour Colour { get; }

        private double doublePI = (2 * Math.PI) / 100;
        private float x {  get; }
        private float y { get; }
        public Circle (float radius, Vector center, Colour colour)
        {
            if (radius <= 0)
            {
                throw new ArgumentOutOfRangeException("Radius cant be 0 or negative");
            }
            Radius = radius;
            Center = center;
            x = center.X;
            y = center.Y;
            Colour = colour;
            Vertices = new Vector[VectorCount];
            VerticeCalculator();
        }

        private void VerticeCalculator()
        {
            for (int i = 0; i < VectorCount; i++)
            {
                Vertices[i] = new Vector((float)(this.x + Radius * Math.Cos((doublePI) * i)), (float)(this.y + Radius * Math.Sin((doublePI) * i)));
            }
        }
    }
}
