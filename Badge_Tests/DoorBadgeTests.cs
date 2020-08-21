using System;
using System.Collections.Generic;
using Badge_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Badge_Tests
{
    [TestClass]
    public class DoorBadgeTests
    {
        private BadgeRepo _badgeRepo;
        private Dictionary<int, List<string>> _doorBadgeNumbers;
        [TestMethod]
        public void Arrange()
        {
            _badgeRepo = new BadgeRepo();
            _doorBadgeNumbers = new Dictionary<int, List<string>>();
        }

        [TestMethod]
        public void DisplayAllBadges_ShouldDisplayBadges()
        {
            _badgeRepo.ViewAllBadges();
        }
    }
}
