using PaintDropSimulation;
using ShapeLibrary;

namespace ShapeLibraryTests
{
    [TestClass]
    public class PaintDropTests
    {
        [TestMethod]
        public void Constructor_ThrowArgumentNullException()
        {
            // A-A-A
            Assert.ThrowsException<ArgumentNullException>(() => new PaintDrop(null));
        }

        [TestMethod]
        public void Constructor_CorrecltyCreates()
        {
            // Arrange
            float x = 1.0f;
            float y = 2.0f;
            Vector vect = new Vector(x, y);
            float radius = 5.0f;
            Colour colour = new Colour(1, 1, 1);
            Circle circle = new Circle(radius, vect, colour);

            // Act
            PaintDrop drop = new PaintDrop(circle);

            // Assert
            Assert.AreEqual(drop.Circle, circle);

        }

        [TestMethod]
        public void Marble_CheckDisplacement()
        {
            // Arrange
            float x = 1.0f;
            float y = 2.0f;
            Vector vect = new Vector(x, y);
            float radius = 5.0f;
            Colour colour = new Colour(1, 1, 1);
            Circle circle = new Circle(radius, vect, colour);
            Circle circle2 = new Circle(radius, vect, colour);
            PaintDrop drop = new PaintDrop(circle);

            // Act
            drop.Marble(drop);

            // Assert
            Assert.AreNotEqual(drop.Circle.Vertices[1], circle2.Vertices[1]);

        }
    }
}
