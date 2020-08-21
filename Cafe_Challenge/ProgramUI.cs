using Cafe_Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace Cafe_Challenge
{
    class ProgramUI
    {
        private CafeRepository _menuRepository = new CafeRepository();
        public void Run()
        {
            _menuRepository.SeedMenuList();
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Welcome to the Cafe! Please select a menu option: \n" +
                    "1. Update Menu Item\n" +
                    "2. View All Combos\n" +
                    "3. Delete Menu Item\n" +
                    "4. Add Menu Item\n" +
                    "5. Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        UpdateExistingMenuItem();
                        break;
                    case "2":
                        DisplayAllMenuItems();
                        break;
                    case "3":
                        DeleteExistingItem();
                        break;
                    case "4":
                        AddNewMenuItem();
                        break;
                    case "5":
                        Console.WriteLine("Goodbye!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please select a valid option.");
                        break;
                }

                Console.WriteLine("Please press any key to continue.");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void AddNewMenuItem()
        {
            Console.Clear();
            MenuItem newItem = new MenuItem();

            Console.WriteLine("Enter the name of the Menu Item");
            newItem.Name = Console.ReadLine();

            Console.WriteLine("Enter the description for this item");
            newItem.Description = Console.ReadLine();

            Console.WriteLine("Enter the ingredients for this item.");
            newItem.Ingredients = Console.ReadLine();

            Console.WriteLine("Enter the price for this item");
            string priceAsString = Console.ReadLine();
            newItem.Price = double.Parse(priceAsString);

            _menuRepository.AddNewMenuItem(newItem);
        }

        private void DisplayAllMenuItems()
        {
            Console.Clear();

            List<MenuItem> listOfMenuItems = _menuRepository.GetMenuItems();

            foreach (MenuItem menuItem in listOfMenuItems)
            {
                Console.WriteLine($"Name of food: {menuItem.Name}\n" +
                    $"Description: {menuItem.Description}\n" +
                    $"Ingredients: {menuItem.Ingredients}\n" +
                    $"Price: {menuItem.Price}");
            }
        }

        private void UpdateExistingMenuItem()
        {
            DisplayAllMenuItems();

            Console.WriteLine("Enter the name of the item you would like to update.");

            string oldItem = Console.ReadLine();

            MenuItem newItem = new MenuItem();

            Console.WriteLine("Enter the name of the item.");
            newItem.Name = Console.ReadLine();

            Console.WriteLine("Enter the description of the item.");
            newItem.Description = Console.ReadLine();

            Console.WriteLine("Enter the ingredients for this time.");
            newItem.Ingredients = Console.ReadLine();

            Console.WriteLine("Enter the price for this item.");
            string priceAsString = Console.ReadLine();
            newItem.Price = double.Parse(priceAsString);
        }


        private void DeleteExistingItem()
        {
            DisplayAllMenuItems();

            Console.WriteLine("Enter the name of the item you would like to remove.");
            string input = Console.ReadLine();

            bool wasDeleted = _menuRepository.DeleteExistingItem(input);

            if (wasDeleted)
            {
                Console.WriteLine("The content was successfully deleted.");
            }
            else
            {
                Console.WriteLine("The content could not be deleted.");
            }
        }


    }
}
