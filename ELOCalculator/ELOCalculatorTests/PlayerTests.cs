using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ELOCalculator;

namespace ELOCalculatorTests
{
    [TestClass]
    public class PlayerTests
    {
        [TestMethod]
        public void ExperienceFactor_WorksAsExpected()
        {
            var p = new Player(1500.0, 0);
            Assert.AreEqual(5.0, p.ExperienceFactor);

            p = new Player(1500.0, 200);
            Assert.AreEqual(3.0, p.ExperienceFactor);

            p = new Player(1500.0, 400);
            Assert.AreEqual(1.0, p.ExperienceFactor);

            p = new Player(1500.0, int.MaxValue);
            Assert.AreEqual(1.0, p.ExperienceFactor);
        }
    }
}
