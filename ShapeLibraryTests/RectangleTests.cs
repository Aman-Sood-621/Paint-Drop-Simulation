using ShapeLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("ShapeLibraryTests")]
namespace ShapeLibraryTests
{
    [TestClass]
    public class RectangleTests
    {
        [TestMethod]
        public void Constructor_ShouldInitializeProperties()
        {
            // Arrange
            float x = 1.0f;
            float y = 2.0f;
            float width = 3.0f;
            float height = 4.0f;
            Colour colour = new Colour(1,1,1);

            // Act
            Rectangle rectangle = new Rectangle(x, y, width, height, colour);

            // Assert
            Assert.AreEqual(x, rectangle.X);
            Assert.AreEqual(y, rectangle.Y);
            Assert.AreEqual(width, rectangle.Width);
            Assert.AreEqual(height, rectangle.Height);
            Assert.AreEqual(colour, rectangle.Colour);
        }

        [TestMethod]
        public void Vertices_ShouldReturnCorrectVertices()
        {
            // Arrange
            float x = 0.0f;
            float y = 0.0f;
            float width = 5.0f;
            float height = 10.0f;
            Rectangle rectangle = new Rectangle(x, y, width, height, new Colour(1, 1, 1));

            // Act
            Vector[] vertices = rectangle.Vertices;

            // Assert
            Assert.AreEqual(4, vertices.Length);
            Assert.AreEqual(new Vector(x, y), vertices[0]);
            Assert.AreEqual(new Vector(x, y + height), vertices[1]);
            Assert.AreEqual(new Vector(x + width, y + height), vertices[2]);
            Assert.AreEqual(new Vector(x + width, y), vertices[3]);
        }
    }
}
