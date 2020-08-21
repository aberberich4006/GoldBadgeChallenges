using System;
using System.Collections.Generic;
using Komodo_Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KomodoTests
{
    [TestClass]
    public class UnitTest1
    {
        private KomodoRepository _repo = new KomodoRepository();

        Queue<Komodo> _komodoRepo = new Queue<Komodo>();

        private Komodo _claim;
        public void Arrange()
        {
            _claim = new Komodo(1, "House", "Fire in House", 100, new DateTime(2019, 02, 02), new DateTime(2019, 03, 02), true);
        }

        [TestMethod]
        public void KomodoClaimInitialization()
        {

        }

        [TestMethod]
        public void AddNewItem_ShouldAddNewItem()
        {
            Komodo claim = new Komodo();
            _repo.NewClaim(claim);

            Queue<Komodo> menu = _repo.GetClaimsList();

            bool menuHasClaim = menu.Contains(claim);

            Assert.IsTrue(menuHasClaim);
        }

        [TestMethod]
        public void GetClaimsList_ShouldGetClaims()
        {
            Arrange();

            Komodo claim = new Komodo();
            _repo.NewClaim(claim);

            Queue<Komodo> menu = _repo.GetClaimsList();

            bool menuHasClaim = menu.Contains(claim);

            Assert.IsTrue(menuHasClaim);
        }

        [TestMethod]
        public void ModifyClaim_ShouldModifyClaim()
        {
            Arrange();

            Komodo newClaim = new Komodo(2, "House", "House has a leak", 101, new DateTime(2020, 03, 03), new DateTime(2020, 04, 04), false);
            _repo.NewClaim(newClaim);

            _repo.ModifyClaim(1, newClaim);

            Assert.AreEqual(1, _komodoRepo);
        }
    }
}
