
using ShapeLibrary;

namespace PaintDropSimulation
{
    public static class PaintDropSimulationFactory
    {
        public static IPaintDrop CreatePaintDrop(ICircle Circle)
        {
            return new PaintDrop(Circle);
        }

        public static ISurface CreateSurface(int width, int height)
        {
            return new Surface(width,height);
        }
    }
}
