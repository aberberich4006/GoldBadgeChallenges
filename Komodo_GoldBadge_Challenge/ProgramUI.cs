using Komodo_Repo;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_GoldBadge_Challenge
{
    class ProgramUI
    {
        private KomodoRepository _komodoRepo = new KomodoRepository();
        public void Run()
        {
            _komodoRepo.SeedClaimList();
            Menu();
        }

        private void Menu()
        {

            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Select a menu option: \n" +
                    "1. View all claims \n" +
                    "2. Handle next claim \n" +
                    "3. Enter a new claim \n" +
                    "4. Modify an existing claim\n" +
                    "5. Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        ViewAllClaims();
                        break;
                    case "2":
                        HandleClaim();
                        break;
                    case "3":
                        NewClaim();
                        break;
                    case "4":
                        ModifyClaim();
                        break;
                    case "5":
                        Console.WriteLine("Goodbye");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please select a valid menu option.");
                        break;
                }

                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                Console.Clear();
            }
        }

        public void ViewAllClaims()
        {
            Console.Clear();
            Queue<Komodo> queueOfClaims = _komodoRepo.GetClaimsList();

            foreach (Komodo claim in queueOfClaims)
            {
                ViewClaim(claim);
            }

        }

        public void ViewClaim(Komodo claim)
        {

            Console.WriteLine($"\n {"ID",-27}  {"Type",-28}  {"Description",-29} {"Amount",-30} {"Date Of Accident",-28} {"Date Of Claim",-29} {"Is This Claim Valid"}\n" +
                $"{ claim.ClaimID,-30}{ claim.Type,-30}{ claim.Description,-30}{ claim.Amount,-30}{ claim.DateOfAccident,-30}{ claim.DateOfClaim,-30}{ claim.IsValid,-30}");
        }



        private void NewClaim()
        {
            Console.Clear();
            Komodo newClaim = new Komodo();

            Console.WriteLine("Enter the number for this claim");
            string claimIDAsString = Console.ReadLine();
            newClaim.ClaimID = int.Parse(claimIDAsString);

            Console.WriteLine("Enter the type of claim");
            newClaim.Type = Console.ReadLine();

            Console.WriteLine("Enter the description for this claim");
            newClaim.Description = Console.ReadLine();

            Console.WriteLine("Enter the amount for this claim");
            string claimAmountAsString = Console.ReadLine();
            newClaim.Amount = double.Parse(claimAmountAsString);

            Console.WriteLine("Enter the date of the accident");
            string dateAsString = Console.ReadLine();
            newClaim.DateOfAccident = DateTime.Parse(dateAsString);

            Console.WriteLine("Enter the date of the claim");
            string dateAsString2 = Console.ReadLine();
            newClaim.DateOfClaim = DateTime.Parse(dateAsString2);

            Console.WriteLine("Is this claim valid? Y/N");
            string input2 = Console.ReadLine().ToLower();


            switch (input2)
            {
                case "y":
                    newClaim.IsValid = true;
                    break;
                case "n":
                    newClaim.IsValid = false;
                    break;
            }

            _komodoRepo.NewClaim(newClaim);
        }

        private void ModifyClaim()
        {
            Console.Clear();

            Console.WriteLine("Enter the number ID of the claim you would like to modify.");

            string oldClaimAsString = Console.ReadLine();
            int oldClaimID = int.Parse(oldClaimAsString);


            Komodo newClaim = new Komodo();

            Console.WriteLine("Enter the type for this claim.");
            newClaim.Type = Console.ReadLine();

            Console.WriteLine("Enter the description for this claim.");
            newClaim.Description = Console.ReadLine();

            Console.WriteLine("Enter the amount for this claim.");
            string amountAsString = Console.ReadLine();
            newClaim.Amount = double.Parse(amountAsString);

            Console.WriteLine("Enter the date of the accident.");
            string dateAsString = Console.ReadLine();
            newClaim.DateOfAccident = DateTime.Parse(dateAsString);

            Console.WriteLine("Enter the date of the claim.");
            string dateAsString2 = Console.ReadLine();
            newClaim.DateOfClaim = DateTime.Parse(dateAsString2);

            Console.WriteLine("Is this claim valid? Y/N");
            string input2 = Console.ReadLine().ToLower();


            switch (input2)
            {
                case "y":
                    newClaim.IsValid = true;
                    break;
                case "n":
                    newClaim.IsValid = false;
                    break;
            }

            _komodoRepo.ModifyClaim(oldClaimID, newClaim);

        }

        private void HandleClaim()
        {
            Console.Clear();

            Queue<Komodo> claimQueue = _komodoRepo.GetClaimsList();
            bool claimExists = true;

            while (claimExists)
            {
                if (claimQueue.Count > 0)
                {
                    var claims = claimQueue.Peek();
                    ViewClaim(claims);
                }

                Console.WriteLine("Do you want to process this claim now? Y/N");
                string userInput = Console.ReadLine();

                if (userInput == "Y")
                {
                    claimQueue.Dequeue();
                }
                else claimExists = false;
            }



        }
    }
}
