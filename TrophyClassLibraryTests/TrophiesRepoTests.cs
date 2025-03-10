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
    public class TrophiesRepoTests
    {
        private TrophiesRepo _repo;

        [TestInitialize]
        public void Setup()
        {
            _repo = new TrophiesRepo();
            _repo.Add(new Trophy { Competition = "Comp F", Year = 2024 });
            _repo.Add(new Trophy { Competition = "Comp G", Year = 2019 });
            _repo.Add(new Trophy { Competition = "Comp H", Year = 2017 });
            _repo.Add(new Trophy { Competition = "Comp I", Year = 2021 });
        }

        [TestMethod()]
        public void GetTrophyByIdTest()
        {
            Trophy? trophy = _repo.GetTrophyById(1);
            Assert.AreEqual("Comp A", trophy?.Competition);
            Assert.AreEqual(2018, trophy?.Year);
        }

        [TestMethod()]
        public void AddTest()
        {
            Trophy? trophy = _repo.GetTrophyById(10);
            Assert.IsNull(trophy);
            _repo.Add(new Trophy { Competition = "Comp J", Year = 2015 });
            trophy = _repo.GetTrophyById(10);
            Assert.AreEqual("Comp J", trophy?.Competition);
            Assert.AreEqual(2015, trophy?.Year);
        }

        [TestMethod()]
        public void GetTrophies_FilterByYearBeforeTest()
        {
            IEnumerable<Trophy> trophies = _repo.GetTrophies(trophyYearBefore: 2019);
            Assert.AreEqual(3, trophies.Count());
        }

        [TestMethod()]
        public void GetTrophies_FilterByYearDescTest()
        {
            IEnumerable<Trophy> trophies = _repo.GetTrophies(orderBy: "year_desc");
            Assert.AreEqual(9, trophies.Count());
            Assert.AreEqual(2024, trophies.First().Year);
        }

        [TestMethod()]
        public void UpdateTest()
        {
            Trophy? trophy = _repo.GetTrophyById(1);
            Assert.AreEqual("Comp A", trophy?.Competition);
            Assert.AreEqual(2018, trophy?.Year);
            trophy.Competition = "Comp Z";
            trophy.Year = 2025;
            _repo.Update(1, trophy);
            trophy = _repo.GetTrophyById(1);
            Assert.AreEqual("Comp Z", trophy?.Competition);
            Assert.AreEqual(2025, trophy?.Year);
        }

    }
}