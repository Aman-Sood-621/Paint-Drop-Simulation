using ShapeLibrary;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ShapeLibraryTests")]
namespace ShapeLibraryTests
{
    [TestClass]
    public class CicleTests
    {
        [TestMethod]
        public void Constructor_ShouldInitializeProperties()
        {
            // Arrange
            float x = 1.0f;
            float y = 2.0f;
            Vector vect = new Vector(x, y);
            float radius = 5.0f;
            Colour colour = new Colour(1, 1, 1);

            // Act
            Circle circle = new Circle(radius, vect, colour);

            // Assert
            Assert.AreEqual(radius, circle.Radius);
            Assert.AreEqual(x, circle.Center.X);
            Assert.AreEqual(y, circle.Center.Y);
            Assert.AreEqual(colour, circle.Colour);
            Assert.AreEqual(100, circle.Vertices.Length);
        }

        [TestMethod]
        public void Constructor_ShouldthrowException()
        {
            // Arrange
            float x = 1.0f;
            float y = 2.0f;
            Vector vect = new Vector(x, y);
            float radius = 0.0f;
            Colour colour = new Colour(1, 1, 1);

            // Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
                new Circle(radius, vect, colour));
        }

        [TestMethod]
        public void Vertices_CheckIndex5()
        {
            // Arrange
            float x = 1.0f;
            float y = 1.0f;
            Vector vect = new Vector(x, y);
            float radius = 5.0f;
            Colour colour = new Colour(1, 1, 1);
            float vertX = (float)(x + radius * Math.Cos(((2 * Math.PI) / 100) * 5));
            float vertY = (float)(y + radius * Math.Sin(((2 * Math.PI) / 100) * 5));

            // Act
            Circle circle = new Circle(radius, vect, colour);

            // Assert
            Assert.AreEqual(vertX, circle.Vertices[5].X);
            Assert.AreEqual(vertY, circle.Vertices[5].Y);
        }
    }
}
