using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[assembly: InternalsVisibleTo("ShapeLibraryTests")]
namespace ShapeLibrary
{
    internal class Rectangle : IRectangle
    {
        public float X { get; }

        public float Y { get; }

        public float Width { get; }

        public float Height { get; }

        private Vector[]? _vertices;

        public Vector[] Vertices
        {
            get
            {
                if (_vertices == null)
                {
                    _vertices = new Vector[]
                    {
                        new Vector(X, Y),
                        new Vector(X, Y + Height),
                        new Vector(X + Width, Y + Height),
                        new Vector(X + Width, Y)
                    };
                }
                return _vertices;
            }
        }

        public Colour Colour { get; }

        public Rectangle(float x, float y, float width, float height, Colour color)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Colour = color;
        }

        public bool Intersect(IRectangle other)
        {
            // Bottom and Right Sides
            if (other.X > Width || other.Y > Height)
            {
                return false;
            }

            // Top and Left Sides 
            if (other.X + other.Width < 0 || other.Y + other.Height < 0)
            {
                return false;
            }

            return true;
        }
    }
}
