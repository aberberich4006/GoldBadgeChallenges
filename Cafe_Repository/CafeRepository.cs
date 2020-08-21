using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe_Repository
{
    public class CafeRepository
    {
        private List<MenuItem> _listOfMenuItem = new List<MenuItem>();

        public void AddNewMenuItem(MenuItem menuItem)
        {
            _listOfMenuItem.Add(menuItem);
        }

        public List<MenuItem> GetMenuItems()
        {
            return _listOfMenuItem;
        }

        public bool UpdateExistingMenuItem(string originalItem, MenuItem newItem)
        {

            MenuItem oldItem = GetItemByName(originalItem);

            if (oldItem != null)
            {
                //oldItem.Name = newItem.Name;
                //oldItem.Description = newItem.Description;
                //oldItem.Ingredients = newItem.Ingredients;
                //oldItem.Price = newItem.Price;

                int itemIndex = _listOfMenuItem.IndexOf(oldItem);
                _listOfMenuItem[itemIndex] = newItem;

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteExistingItem(string name)
        {
            MenuItem menuItem = GetItemByName(name);

            if (menuItem == null)
            {
                return false;
            }

            int initialCount = _listOfMenuItem.Count;
            _listOfMenuItem.Remove(menuItem);

            if (initialCount > _listOfMenuItem.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public MenuItem GetItemByName(string name)
        {
            foreach (MenuItem menuItem in _listOfMenuItem)
            {
                if (menuItem.Name.ToLower() == name.ToLower())
                {
                    return menuItem;
                }
            }

            return null;
        }

        public void SeedMenuList()
        {
            MenuItem grilledCheese = new MenuItem("Grilled Cheese", "Colby Jack cheese in between two pieces of sourdough bread, thrown into a sizzling pan to fry", "Sourdough bread, Colby Jack Cheese, Salted Butter", 4.99);
            MenuItem hamAndCheese = new MenuItem("Ham and Cheese", "Swiss cheese on top of shaved honey ham thrown into a croissant.", "Honey ham, swiss cheese, croissant", 5.99);
            MenuItem bLT = new MenuItem("BLT", "Bacon, Lettuce, and Tomato in between some classic white bread.", "Bacon, Lettuce, Tomato, White bread", 3.99);
            MenuItem choppedChickenSalad = new MenuItem("Chopped Chicken Salad", "Chicken and hard boiled eggs laid gracefully atop a mix of iceberg and romaine lettuce spring mix.", "Romaine lettuce, iceberg lettuce, hard boiled eggs, chicken breast, cherry tomatoes, red onion.", 7.99);
            MenuItem tunaSalad = new MenuItem("Tuna Salad Sandwich", "Chunk tuna mixed in with mayonnaise, onion, celery, and soy sauce scooped into a brioche bun", "Mayo, tuna, onion, celery, soy sauce, brioche bun", 5.99);
            AddNewMenuItem(grilledCheese);
            AddNewMenuItem(hamAndCheese);
            AddNewMenuItem(bLT);
            AddNewMenuItem(choppedChickenSalad);
            AddNewMenuItem(tunaSalad);
        }
    }
}
