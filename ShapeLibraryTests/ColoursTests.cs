using ShapeLibrary;

namespace ShapeLibraryTests
{
    [TestClass]
    public class ColoursTests
    {
        [TestMethod]
        public void Constructor_ValidValues_ShouldCreateColour()
        {
            // Arrange
            int red = 100, green = 150, blue = 200;

            // Act
            Colour colour = new Colour(red, green, blue);

            // Assert
            Assert.AreEqual(red, colour.Red);
            Assert.AreEqual(green, colour.Green);
            Assert.AreEqual(blue, colour.Blue);
        }


        [TestMethod]
        public void Addition_ValidColours_ShouldReturnSum()
        {
            // Arrange
            Colour colour1 = new Colour(100, 150, 200);
            Colour colour2 = new Colour(50, 100, 50);

            // Act
            Colour result = colour1 + colour2;

            // Assert
            Assert.AreEqual(150, result.Red);
            Assert.AreEqual(250, result.Green);
            Assert.AreEqual(250, result.Blue);
        }

        [TestMethod]
        public void Subtraction_ValidColours_ShouldReturnDifference()
        {
            // Arrange
            Colour colour1 = new Colour(150, 200, 250);
            Colour colour2 = new Colour(50, 100, 150);

            // Act
            Colour result = colour1 - colour2;

            // Assert
            Assert.AreEqual(100, result.Red);
            Assert.AreEqual(100, result.Green);
            Assert.AreEqual(100, result.Blue);
        }

        [TestMethod]
        public void EqualityOperator_SameValues_ShouldReturnTrue()
        {
            // Arrange
            Colour colour1 = new Colour(100, 150, 200);
            Colour colour2 = new Colour(100, 150, 200);

            // Act & Assert
            Assert.IsTrue(colour1 == colour2);
        }

        [TestMethod]
        public void InequalityOperator_DifferentValues_ShouldReturnTrue()
        {
            // Arrange
            Colour colour1 = new Colour(100, 150, 200);
            Colour colour2 = new Colour(101, 150, 200);

            // Act & Assert
            Assert.IsTrue(colour1 != colour2);
        }

        [TestMethod]
        public void ToString_ShouldReturnCorrectFormat()
        {
            // Arrange
            Colour colour = new Colour(100, 150, 200);

            // Act
            string result = colour.ToString();

            // Assert
            Assert.AreEqual("Colour(R: 100, G: 150, B: 200)", result);
        }
    }
}