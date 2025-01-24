using ShapeLibrary;
using PaintDropSimulation;

namespace ShapeLibraryTests
{
    [TestClass]
    public class SurfaceTestss
    {
        [TestMethod]
        public void Constructor_CreatesCorrectly()
        {
            // Arrange & act
            Surface surface = new Surface(1,1);

            // Assert
            Assert.AreEqual(surface.Height, 1);
            Assert.AreEqual(surface.Width, 1);
        }

        [TestMethod]
        public void AddPaintDrop_AddsADropCorrectly()
        {
            // Arrange
            Surface surface = new Surface(1,1);
            float x = 1.0f;
            float y = 2.0f;
            Vector vect = new Vector(x, y);
            float radius = 5.0f;
            Colour colour = new Colour(1, 1, 1);
            Circle circle = new Circle(radius, vect, colour);
            PaintDrop drop = new PaintDrop(circle);

            // Act
            surface.AddPaintDrop(drop);

            // Assert
            Assert.AreEqual(surface.Drops.Count, 1);
        }
    }
}
