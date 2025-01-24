using System.Runtime.CompilerServices;
using PatternGenerationLib;
using PaintDropSimulation;

namespace ShapeLibraryTests
{
    [TestClass]
    public class PhyllotaxisTests
    {
        [TestMethod]
        public void ResetMethod_ResetsIndex()
        {
            Surface surface = new Surface(0, 0);
            Phyllotaxis phyllotaxis = new Phyllotaxis();
            phyllotaxis.CalculatePatternPoint(surface);

            phyllotaxis.reset();

            Assert.AreEqual(phyllotaxis.index, 0);
        }

        [TestMethod]
        public void IncrementGAngle_MethodIncrementsBy10()
        {
            Phyllotaxis phyllotaxis = new Phyllotaxis();
            phyllotaxis.IncrementGA();

            Assert.AreEqual(phyllotaxis.ReturnGoldenAngle(), 147.5f);
        }

        [TestMethod]
        public void DecreaseGAngle_MethodDecreaseBy10()
        {
            Phyllotaxis phyllotaxis = new Phyllotaxis();
            phyllotaxis.DecreaseGA();

            Assert.AreEqual(phyllotaxis.ReturnGoldenAngle(), 127.5f);
        }

        [TestMethod]
        public void IncrementSFactor_MethodIncreaseBy10()
        {
            Phyllotaxis phyllotaxis = new Phyllotaxis();
            phyllotaxis.IncrementSF();

            Assert.AreEqual(phyllotaxis.ReturnScalingFactor(), 25);
        }

        [TestMethod]
        public void DecreaseSFactor_MethodDecreaseBy10()
        {
            Phyllotaxis phyllotaxis = new Phyllotaxis();
            phyllotaxis.DecreaseSF();

            Assert.AreEqual(phyllotaxis.ReturnScalingFactor(), 5);
        }
    }
}
