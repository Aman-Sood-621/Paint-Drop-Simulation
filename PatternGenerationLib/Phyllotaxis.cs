using PaintDropSimulation;
using ShapeLibrary;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ShapeLibraryTests")]
namespace PatternGenerationLib
{
    internal class Phyllotaxis : IPatternGenerator
    {
        private float GoldenAngle = 137.5f;
        private int ScalingFactor = 15;
        internal int index = 0;

        public Vector? CalculatePatternPoint(ISurface surface)
        {
            if (surface == null) return null;

            Vector surfaceCenter = new(surface.Width/2, surface.Height/2);
            float radians = (float)((Math.PI / 180) * GoldenAngle);

            float angle = index * radians;
            float radius = (float)(ScalingFactor * (Math.Sqrt(index)));
            
            float x = (float)(surfaceCenter.X + (radius * (Math.Cos(angle))));
            float y = (float)(surfaceCenter.Y + (radius * (Math.Sin(angle))));

            if (x < 0 || x > surface.Width || y < 0 || y > surface.Height)
            {
                index = 0;
                return CalculatePatternPoint(surface);
            }

            index++;
            return new Vector(x, y);
        }

        public void reset()
        {
            index = 0;
        }

        public void IncrementGA()
        {
            GoldenAngle += 10;
        }

        public void DecreaseGA()
        {
            GoldenAngle -= 10;
        }

        public void IncrementSF()
        {
            ScalingFactor += 10;
        }

        public void DecreaseSF()
        {
            ScalingFactor -= 10;
        }

        public float ReturnGoldenAngle()
        {
            return GoldenAngle;
        }

        public int ReturnScalingFactor()
        {
            return ScalingFactor;
        }

    }
}
