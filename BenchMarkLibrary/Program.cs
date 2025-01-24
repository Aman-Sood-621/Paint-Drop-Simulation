using PaintDropSimulation;
using ShapeLibrary;
using System.Diagnostics;

internal class Program
{
    private static void Main(string[] args)
    {
        // Benchmarks
        Stopwatch stopwatch = new Stopwatch();

        // Surface Parameters
        int SurfaceSize = 500;
        int SurfacesRuns = 10;

        // Drop Parameters
        int RandomDropsSize = 250;
        float Radius = 25.0f;
        Colour Colour = new Colour(1, 1, 1);
        Random rnd = new Random();

        // Time
        long NumberOfRuns = 100;
        long time = 0;

        // Create Surface
        for (int i = 0; i < SurfacesRuns; i++)
        {
            Console.WriteLine($"Surface Size: {SurfaceSize}");
            Console.WriteLine($"Amount of Drops: {RandomDropsSize}");
            for (int t = 0; t < NumberOfRuns; t++)
            {
                stopwatch.Start();
                ISurface Surface = PaintDropSimulationFactory.CreateSurface(SurfaceSize, SurfaceSize);

                // Create Drops to insert 
                for (int d = 0; d < RandomDropsSize; d++)
                {
                    Vector Center = new Vector((float)rnd.Next(0, SurfaceSize), (float)rnd.Next(0, SurfaceSize));
                    ICircle Circle = ShapesFactory.CreateCircle(Radius, Center, Colour);
                    IPaintDrop drop = PaintDropSimulationFactory.CreatePaintDrop(Circle);
                    Surface.AddPaintDrop(drop);
                }
                stopwatch.Stop();
                time += stopwatch.ElapsedMilliseconds;
                stopwatch.Reset();
            }

            // Time Stamp
            Console.WriteLine($"Average Time (Ms): {time/NumberOfRuns}");

            // Read Key to Stop/Continue
            Console.WriteLine("Press a Key to Continue");
            Console.WriteLine("");
            Console.ReadKey();

            RandomDropsSize += 250;
            SurfaceSize += 500;
        }
    }
}