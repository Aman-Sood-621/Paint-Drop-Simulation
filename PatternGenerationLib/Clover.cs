using PaintDropSimulation;
using ShapeLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternGenerationLib
{
    internal class Clover : IPatternGenerator
    {
        private float ScalingFactor = 100;
        private float tIncrement = 0.2f;
        private int index = 0;


        public Vector? CalculatePatternPoint(ISurface surface)
        {
            if (surface == null) return null;

            Vector surfaceCenter = new(surface.Width / 2, surface.Height / 2);

            float t = index * tIncrement;
            float radius = ScalingFactor * (float)(Math.Sqrt(Math.Abs(Math.Cos(2 * t))));
            float x = (float)(surfaceCenter.X + (radius * Math.Cos(t)));
            float y = (float)(surfaceCenter.Y + (radius * Math.Sin(t)));

            index++;
            return new Vector(x, y);
        }

        public void DecreaseGA()
        {
            throw new NotImplementedException("Clover does not support this feature");
        }

        public void DecreaseSF()
        {
            throw new NotImplementedException("Clover does not support this feature");
        }

        public void IncrementGA()
        {
            throw new NotImplementedException("Clover does not support this feature");
        }

        public void IncrementSF()
        {
            throw new NotImplementedException("Clover does not support this feature");
        }

        public void reset()
        {
            throw new NotImplementedException("Clover does not support this feature");
        }

        public float ReturnGoldenAngle()
        {
            throw new NotImplementedException("Clover does not support this feature");
        }

        public int ReturnScalingFactor()
        {
            throw new NotImplementedException("Clover does not support this feature");
        }
    }
}
