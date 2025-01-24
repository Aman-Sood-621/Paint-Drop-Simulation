using PaintDropSimulation;
using ShapeLibrary;
using System.Diagnostics;

internal class Program
{
    private static void Main(string[] args)
    {
        bool interactive = false;
        bool memoryTest = false;
        string userName = "The Undefeated Dirk";
        if (args.Contains("-i"))
        {
            interactive = true;
        }
        if (args.Contains("-m"))
        {
            memoryTest = true;
        }
        var rng = new Random();
        int numOfDataPoints = 100;
        int size = 1000;
        string points = Environment.GetEnvironmentVariable("DATA_POINTS");
        if (!string.IsNullOrEmpty(points))
        {
            numOfDataPoints = int.Parse(points);
        }
        Console.WriteLine($"Benching a surface size of {size}x{size}");
        double sum = 0;
        for (int i = 0; i < numOfDataPoints; i++)
        {

            var result = Bench(() =>
            {
                int dropCount = RunSurface(rng, size);
                //For memory tests
                if (memoryTest)
                {
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    Console.WriteLine("Ran GC");
                }
            });
            sum += result;
        }
        sum = sum / numOfDataPoints;

        Console.WriteLine($"{userName}: Total average time with {numOfDataPoints} points: {sum}ms");
        var path = Environment.GetEnvironmentVariable("DATA_PATH");
        if (string.IsNullOrEmpty(path))
        {
            throw new Exception("Cannot find DATA_PATH");
        }
        File.AppendAllText(path, $"{userName} : {sum}" + Environment.NewLine);
        if (interactive)
        {
            Console.ReadKey();
        }
        Console.WriteLine($"Bench Marking finished");
    }
    private static long Bench(Action task)
    {
        var stopWatch = new Stopwatch();
        stopWatch.Restart();
        stopWatch.Start();

        task?.Invoke();

        stopWatch.Stop();
        return stopWatch.ElapsedMilliseconds;
    }
    private static int RunSurface(Random rng, int i)
    {
        var surface = PaintDropSimulationFactory.CreateSurface(i, i);
        int dropCount = (int)((float)i * 0.75);
        int drop = 0;

        while (drop < dropCount)
        {
            //Uses rng and i to add a paint drop inside the surface
            //Uses rng and a fudge factor to create a random radius inside the surface
            surface.AddPaintDrop(
                PaintDropSimulationFactory.CreatePaintDrop(ShapesFactory.CreateCircle(rng.Next(1, i / 20), new Vector(rng.Next(i), rng.Next(i)), new Colour(0, 0, 0)))
            );
            drop++;
        }

        return dropCount;
    }
}
