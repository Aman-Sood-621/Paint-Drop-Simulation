using ShapeLibrary;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ShapeLibraryTests")]
namespace PaintDropSimulation
{
    internal class PaintDrop : IPaintDrop
    {
        public ICircle Circle { get; }

        public IRectangle BoundingBox { get; private set; }

        private Colour _color = new(1, 1, 1);

        public PaintDrop(ICircle circle)
        {
            if (circle == null)
            {
                throw new ArgumentNullException("Circle cannot be null!");
            }

            Circle = circle;
        }

        public void Marble(IPaintDrop other)
        {
            Vector[] points = Circle.Vertices;
            ICircle newCircle = other.Circle;
            Vector center = newCircle.Center;
            float _radExpTwo = newCircle.Radius * newCircle.Radius;
            float minX = float.MaxValue;
            float minY = float.MaxValue;
            float maxX = float.MinValue;
            float maxY = float.MinValue;
            int lenght = points.Length;


            for (int i = 0; i < lenght; i++)
            {
                Vector PminusC = points[i] - center;

                // Combine constant multiplication and inverse computation
                float ratio = _radExpTwo / Vector.MagnitudeWithoutSQRT(PminusC);
                float UnderSQRT = (float)Math.Sqrt(1 + ratio);

                Circle.Vertices[i] = center + (PminusC * UnderSQRT);

                float X = points[i].X;
                float Y = points[i].Y;

                minX = X < minX ? X : minX;
                maxX = X > maxX ? X : maxX;
                minY = Y < minY ? Y : minY;
                maxY = Y > maxY ? Y : maxY;
            }

            BoundingBox = ShapesFactory.CreateRectangle(minX, minY, maxX - minX, maxY - minY, _color);
        }
    }
}
