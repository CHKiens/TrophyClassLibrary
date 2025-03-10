using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrophyClassLibrary.TrophyClassLibrary;

namespace TrophyClassLibraryTests.TrophyClassLibraryTests
{
    [TestClass()]
    public class TrophyTests
    {
        private readonly Trophy _trophy = new(1, "Comp X", 1980);

        [TestMethod()]
        public void TrophyTest()
        {
            Assert.AreEqual(1, _trophy.Id);
            Assert.AreEqual("Comp X", _trophy.Competition);
            Assert.AreEqual(1980, _trophy.Year);

            Assert.ThrowsException<ArgumentNullException>(() => _trophy.Competition = null);
            Assert.ThrowsException<ArgumentException>(() => _trophy.Competition = "AB");
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => _trophy.Year = 1969);
        }

        [TestMethod()]
        public void NoArgConstructorTest()
        {
            Trophy trophy = new Trophy();
            Assert.AreEqual(0, trophy.Id);
            Assert.AreEqual("Unknown", trophy.Competition);
            Assert.AreEqual(2000, trophy.Year);
        }

        [TestMethod()]
        public void ToStringTest()
        {
            Assert.AreEqual("Trophy: 1, Comp X - 1980", _trophy.ToString());
        }
    }
}