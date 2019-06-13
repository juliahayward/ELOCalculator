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

        [TestMethod]
        public void WinAgainst_EqualRatingLengthOneNoK_WorksAsExpected()
        {
            var p1 = new Player(1500.0, 500);
            var p2 = new Player(1500.0, 500);
            p1.WinAgainst(p2, 1);
            Assert.AreEqual(p1.Experience, 501);
            Assert.AreEqual(p1.Rating, 1502.0);
        }

        [TestMethod]
        public void WinAgainst_EqualRatingLengthFiveNoK_WorksAsExpected()
        {
            var p1 = new Player(1500.0, 500);
            var p2 = new Player(1500.0, 500);
            p1.WinAgainst(p2, 5);
            Assert.AreEqual(p1.Experience, 505);
            Assert.AreEqual(p1.Rating, 1504.4721359549997); // goes up 2 * sqrt(5)
        }

        [TestMethod]
        public void WinAgainst_EqualRatingLengthOneWithK_WorksAsExpected()
        {
            var p1 = new Player(1500.0, 0);
            var p2 = new Player(1500.0, 0);
            p1.WinAgainst(p2, 1);
            Assert.AreEqual(p1.Experience, 1);
            Assert.AreEqual(p1.Rating, 1509.98);    // goes up a tad less than 5 * 2
        }
    }
}
