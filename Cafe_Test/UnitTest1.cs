using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Cafe_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cafe_Test
{
    [TestClass]
    public class CafeTest
    {
        List<MenuItem> _menuList = new List<MenuItem>();

        CafeRepository _repo = new CafeRepository();

        private MenuItem _item;

        List<MenuItem> _listOfMenuItem = new List<MenuItem>();

        public void Arrange()
        {
            _item = new MenuItem("Salami Sandwich", "Salami and bread", "Salami and bread", 5.99);
            _repo.AddNewMenuItem(_item);
            _listOfMenuItem = _repo.GetMenuItems();
        }
        [TestMethod]
        public void AddToList_ShouldAddToList()
        {
            MenuItem item = new MenuItem("Salami Sandwich", "Salami and bread", "Salami and bread", 5.99);
            _repo.AddNewMenuItem(item);
            var menu = _repo.GetMenuItems();
            bool isInList = menu.Contains(item);
            Assert.IsTrue(isInList);
        }

        [TestMethod]
        public void GetMenuItems_ShouldGetMenuItems()
        {
            MenuItem sandwich = new MenuItem();
            _repo.AddNewMenuItem(sandwich);

            List<MenuItem> menu = _repo.GetMenuItems();

            bool menuHasSandwich = menu.Contains(sandwich);

            Assert.IsTrue(menuHasSandwich);
        }

        [TestMethod]
        public void UpdateMenu_ShouldUpdateMenu()
        {
            Arrange();

            MenuItem newItem = new MenuItem("Spaghetti", "Spaghetti and sauce", "Spaghetti and Sauce", 5.99);
            _repo.AddNewMenuItem(newItem);

            _repo.UpdateExistingMenuItem("Salami Sandwich", newItem);


            Assert.AreEqual(0, _listOfMenuItem.IndexOf(newItem));
        }

        [TestMethod]
        public void DeleteMenuItem_ShouldDeleteMenuItem()
        {
            Arrange();

            _repo.DeleteExistingItem("Salami Sandwich");
            int itemCount = _listOfMenuItem.Count;
            Assert.AreEqual(0, itemCount);

        }

        [TestMethod]
        [DataRow("Salami Sandwich", true)]
        [DataRow("Spaghetti and Sauce", false)]
        public void GetItemByName_ShouldGetItemByName(string _item, bool itemName)
        {
            Arrange();

            //bool actualResult = _repo.GetItemByName(itemName);

            //Assert.AreEqual(_item, itemName);

        }



    }
}
