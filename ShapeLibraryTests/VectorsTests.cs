using ShapeLibrary;

namespace ShapeLibraryTests
{
    [TestClass]
    public class VectorsTests
    {
        [TestMethod]
        public void ConstructorFloat_ValidValues_ShouldCreateVector()
        {
            // Arrange
            float x = 1;
            float y = 2;

            // Act
            Vector v = new Vector(x, y);

            // Assert
            Assert.AreEqual(v.X, 1);
            Assert.AreEqual(v.Y, 2);
        }

        [TestMethod]
        public void ConstructorVector_ValidValues_ShouldCreateVector()
        {
            // Arrange
            float x = 1;
            float y = 2;

            // Act
            Vector v = new Vector(x, y);
            Vector v2 = new Vector(v);

            // Assert
            Assert.AreEqual(v, v2);
        }

        [TestMethod]
        public void Addition_ValidVector_ShouldReturnSum()
        {
            // Arrange
            Vector v = new Vector(1,1);
            Vector v2 = new Vector(1,1);
            Vector v3 = new Vector(2,2);

            // Act
            Vector vSum = v + v2;

            // Assert
            Assert.AreEqual(vSum, v3);
        }

        [TestMethod]
        public void Substraction_ValidVector_ShouldReturnSum()
        {
            // Arrange
            Vector v = new Vector(1, 1);
            Vector v2 = new Vector(1, 1);
            Vector v3 = new Vector(0, 0);

            // Act
            Vector vSum = v - v2;

            // Assert
            Assert.AreEqual(vSum, v3);
        }

        [TestMethod]
        public void Multiplication_ValidInt_ShouldReturnSum()
        {
            // Arrange
            Vector v = new Vector(1, 1);
            Vector v2 = new Vector(2, 2);

            // Act
            Vector vSum = v * 2;

            // Assert
            Assert.AreEqual(vSum, v2);
        }

        [TestMethod]
        public void Multiplication_ValidFloat_ShouldReturnSum()
        {
            // Arrange
            Vector v = new Vector(1, 1);
            Vector v2 = new Vector(2, 2);

            // Act
            Vector vSum = v * (float)2;

            // Assert
            Assert.AreEqual(vSum, v2);
        }

        [TestMethod]
        public void Division_ValidVector_ShouldReturnSum()
        {
            // Arrange
            Vector v = new Vector(1, 1);
            Vector v2 = new Vector(2, 2);

            // Act
            Vector vSum = v2 / 2;

            // Assert
            Assert.AreEqual(vSum, v);
        }

        [TestMethod]
        public void Division_InvalidInt_ShouldReturnSum()
        {
            // Arrange
            Vector v = new Vector(1, 1);

            // Act & Assert 
            Assert.ThrowsException<DivideByZeroException>(() => v / 0);
        }

        [TestMethod]
        public void Division_InvalidFloat_ShouldReturnSum()
        {
            // Arrange
            Vector v = new Vector(1, 1);

            // Act & Assert 
            Assert.ThrowsException<DivideByZeroException>(() => v / (float)0);
        }

        [TestMethod]
        public void Magnitude_ShouldReturnSum()
        {
            // Arrange
            Vector v = new Vector(1, 1);

            // Act
            float x = Vector.Magnitude(v);

            // Assert
            Assert.AreEqual(x, Math.Sqrt(2), 0.000001);
        }

        [TestMethod]
        public void Normalize_ShouldReturnSum()
        {
            // Arrange
            Vector v = new Vector(1, 1);
            Vector v2 = new Vector((float)(1 / Math.Sqrt(2)), (float)(1 / Math.Sqrt(2)));

            // Act
            Vector v3 = Vector.Normalize(v);

            // Assert
            Assert.AreEqual(v3, v2);
        }

        [TestMethod]
        public void Normalize_ShouldReturnInputVectorForZeroMagnitude()
        {
            // Arrange
            Vector v = new Vector(0.0f, 0.0f);

            // Act
            Vector result = Vector.Normalize(v);

            // Assert
            Assert.AreEqual(v, result);
        }
    }
}