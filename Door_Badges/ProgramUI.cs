using Badge_Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Door_Badges
{
    class ProgramUI
    {
        private BadgeRepo _badgeRepo = new BadgeRepo();
        
        public void Run()
        {
            _badgeRepo.SeedMethod();
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Welcome to the Access Control Configuration App. Please select an option.\n" +
                    "1. View All Badges/Access\n" +
                    "2. Create A New Badge\n" +
                    "3. Update An Existing Badge\n" +
                    "4. Delete All Doors From An Existing Badge\n" +
                    "5. Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        ViewAllBadges();
                        break;
                    case "2":
                        CreateNewBadge();
                        break;
                    case "3":
                        UpdateExistingBadge();
                        break;
                    case "4":
                        DeleteDoorsFromBadge();
                        break;
                    case "5":
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please select a valid menu option.");
                        break;
                }

                Console.WriteLine("Please press any key to continue");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void ViewAllBadges()
        {
            Console.Clear();

            Dictionary<int, List<string>> dictionary = _badgeRepo.ViewAllBadges();

            foreach (KeyValuePair<int, List<string>> kvp in dictionary)
            {
                int displayBadgeKey = kvp.Key;
                foreach(string door in kvp.Value)
                {
                    string displayDoor = door;
                    Console.WriteLine($"{displayBadgeKey, -7} \t\t{displayDoor, -5}");
                }

            }
        }



        public void UpdateExistingBadge()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();

                Console.WriteLine("What would you like to do?\n" +
                    "1. Add doors to a badge.\n" +
                    "2. Delete doors from a badge.\n" +
                    "3. Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddExistingBadgeDoors();
                        break;
                    case "2":
                        DeleteDoorsFromBadge();
                        break;
                    case "3":
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please select a valid option.");
                        break;
                }
            }
        }


        private void CreateNewBadge()
        {
            Console.Clear();

            List<string> doorNames = new List<string>();

            Console.WriteLine("Name an ID for the badge.");
            string inputAsInt = Console.ReadLine();
            int iDAsNumber = int.Parse(inputAsInt);

            Console.WriteLine("What is the name of the door this badge accesses?");
            string doorOne = Console.ReadLine();
            doorNames.Add(doorOne);
            Console.WriteLine("Would you like to add another door?");
            string input = Console.ReadLine();

            switch (input)
            {
                case "Y":
                case "Yes":
                case "yes":
                case "y":
                    Console.WriteLine("What is the name of the door this badge accesses?");
                    string doorTwo = Console.ReadLine();
                    doorNames.Add(doorTwo);
                    Console.WriteLine("Would you like to add a third door?");
                    string input2 = Console.ReadLine();

                    if (input2 == "y" || input2 == "Y")
                    {
                        Console.WriteLine("What is the name of the third door?");
                        string doorThree = Console.ReadLine();
                        doorNames.Add(doorThree);
                    }
                    break;
                case "N":
                case "No":
                case "no":
                case "n":
                default:
                    break;



            }

            _badgeRepo.AddBadge(iDAsNumber, doorNames);

        }

        private void AddExistingBadgeDoors()
        {
            Console.Clear();

            List<string> doorNames = new List<string>();

            Console.WriteLine("What badge would you like to update?");
            string inputAsInt = Console.ReadLine();
            int oldID = int.Parse(inputAsInt);


            Console.WriteLine("What new door would you like this badge to access?");
            string doorOne = Console.ReadLine();
            doorNames.Add(doorOne);
            Console.WriteLine("Would you like to add another door?");
            string input = Console.ReadLine();

            switch (input)
            {
                case "Y":
                case "Yes":
                case "yes":
                case "y":
                    Console.WriteLine("What is the name of the door this badge accesses?");
                    string doorTwo = Console.ReadLine();
                    doorNames.Add(doorTwo);
                    Console.WriteLine("Would you like to add a third door?");
                    string input2 = Console.ReadLine();

                    if (input2 == "y" || input2 == "Y")
                    {
                        Console.WriteLine("What is the name of the third door?");
                        string doorThree = Console.ReadLine();
                        doorNames.Add(doorThree);
                    }
                    break;
                case "N":
                case "No":
                case "no":
                case "n":
                default:
                    break;

            }
            Badge Badge1 = new Badge(oldID, doorNames);

            _badgeRepo.UpdateBadge(Badge1, oldID);


        }

        private void DeleteDoorsFromBadge()
        {
            Console.Clear();

            List<string> doorNames = new List<string>();

            Console.WriteLine("Which badge would you like to remove access from?");
            string inputAsInt = Console.ReadLine();
            int badgeID = int.Parse(inputAsInt);

            Console.WriteLine("What door would you like to remove access allowance to?");
            string doorOne = Console.ReadLine();
            doorNames.Remove(doorOne);
            Console.WriteLine($"{doorOne} has been removed from this badge.");

            Console.WriteLine("Would you like to remove another door?");
            string input = Console.ReadLine();

            switch (input)
            {
                case "Y":
                case "Yes":
                case "yes":
                case "y":
                    Console.WriteLine("What is the name of the second door?");
                    string doorTwo = Console.ReadLine();
                    doorNames.Remove(doorTwo);
                    Console.WriteLine($"{doorTwo} has been removed from this badge.");
                    Console.WriteLine();
                    Console.WriteLine("Would you like to remove a third door?");
                    string input2 = Console.ReadLine();

                    if (input2 == "y" || input2 == "Y")
                    {
                        Console.WriteLine("What is the name of the third door?");
                        string doorThree = Console.ReadLine();
                        doorNames.Remove(doorThree);
                        Console.WriteLine($"{doorThree} has been removed from this badge.");
                    }
                    break;
                case "N":
                case "No":
                case "no":
                case "n":
                default:
                    break;



            }
            Badge Badge1 = new Badge(badgeID, doorNames);

            _badgeRepo.UpdateBadge(Badge1, badgeID);
        }

        

    }
}
