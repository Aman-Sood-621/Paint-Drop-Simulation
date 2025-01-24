using ShapeLibrary;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ShapeLibraryTests")]
namespace PaintDropSimulation
{
    internal class Surface : ISurface
    {
        public int Width { get; }

        public int Height { get; }

        public IRectangle Border { get; }

        public List<IPaintDrop> Drops { get; }

        public Surface(int width, int height)
        {
            if (width < 0 || height < 0)
            {
                throw new ArgumentOutOfRangeException("Width and Height need to be greate than 0");
            }
            Colour colour = new Colour(1,1,1);
            Width = width;
            Height = height;
            Border = ShapesFactory.CreateRectangle(0,0,Width,Height,colour);
            Drops = new List<IPaintDrop>();
        }

        public void AddPaintDrop(IPaintDrop drop)
        {
            List<IPaintDrop> indexes = new List<IPaintDrop>();

            Parallel.ForEach(Drops, t =>
            {
                t.Marble(drop);

                if (!Border.Intersect(t.BoundingBox))
                {
                    indexes.Add(t);
                }
            });
            
            foreach (var d in indexes)
            {
                Drops.Remove(d);
            }

            Drops.Add(drop);
        }

        public event CalculatePatternPoint PatternGeneration;

        public void GeneratePaintDropPattern(float radius, Colour colour)
        {
            Vector? Center = PatternGeneration?.Invoke(this);
            if (Center != null) 
            {
                ICircle Circle = ShapesFactory.CreateCircle(radius, Center.Value, colour);
                PaintDrop drop = new PaintDrop(Circle);
                AddPaintDrop(drop);
            };
        }
    }
}