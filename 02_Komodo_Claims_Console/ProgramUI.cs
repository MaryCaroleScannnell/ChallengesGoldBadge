using _02_Komodo_Claims_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static _02_Komodo_Claims_Repo.KomodoClaims;

namespace _02_Komodo_Claims_Console
{
    class ProgramUI
    {
        private KomodoClaimRepo _claimRepo = new KomodoClaimRepo();
        public void Run()
        {
            SeedClaimList();
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {

                Console.WriteLine("Hello, please pick from the menu items below:\n" +
                    "1. See all claims\n" +
                    "2. Take care of next claim \n" +
                    "3. Enter a new claim\n" +
                    "4. Exit");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1": //see all claims
                        DisplayAllClaims();
                        break;
                    case "2": //take care of next claim
                        TakeCareNextClaim();
                        break;
                    case "3": //enter a new claim
                        CreateNewClaim();
                        break;
                    case "4": //exit
                        Console.WriteLine("Bye!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter valid number");
                        break;

                }
                Console.WriteLine("Please press any key to continue");
                Console.ReadKey();
                Console.Clear();

            }
        }

        //#1
        private void DisplayAllClaims()
        {
            Queue<KomodoClaims> queueOfClaims = _claimRepo.GetKomodoClaims();

            Console.WriteLine($"{"Claim ID",10} " +
                    $"{"Type of Claim",10} " +
                    $"{"Description",10} " +
                    $"{"Claim Amount",10} " +
                    $"{"Date of Incident",10} " +
                    $"{"Date of Claim",10} " +
                    $"{"Is Valid",10}");

            foreach (KomodoClaims claims in queueOfClaims)
            {

                Console.WriteLine($"{claims.ClaimID,10} " +
                    $"{claims.TypeOfClaim,10} " +
                    $"{claims.Description,10} " +
                    $"{claims.ClaimAmount,10} " +
                    $"{claims.DateOfIncident,10}  " +
                    $"{claims.DateOfClaim,10} " +
                    $"{claims.IsValid,10}");
            };
        }
        //#2
        private void TakeCareNextClaim()
        {
            Console.Clear();

            DisplayAllClaims();

            Console.WriteLine("Do you want to deal with the first claim listed (y/n)?");
            string dealWithClaim = Console.ReadLine();
            if (dealWithClaim == "y")
            {
                _claimRepo.RemoveClaimFromQueue();
            }
            else if (dealWithClaim == "n")
            {
                Console.Clear();
            }
            else
            {
                Console.WriteLine("error- please enter y or n:");
            }
        }

        //#3
        private void CreateNewClaim()
        {
            Console.Clear();

            KomodoClaims newClaims = new KomodoClaims();

            Console.WriteLine("Enter claim id:");
            string claimIDAsString = Console.ReadLine();
            newClaims.ClaimID = int.Parse(claimIDAsString);

            Console.WriteLine("Enter the claim type:\n" +
                "1. Car\n" +
                "2. Home\n" +
                "3. Theft");
            string claimTypeAsString = Console.ReadLine();
            int claimTypeAsInt = int.Parse(claimTypeAsString);
            newClaims.TypeOfClaim = (ClaimType)claimTypeAsInt;

            Console.WriteLine("Ennter a claim desription:");
            newClaims.Description = Console.ReadLine();

            Console.WriteLine("Amount of Damage:");
            string claimAmountAsString = Console.ReadLine();
            newClaims.ClaimAmount = decimal.Parse(claimAmountAsString);



            Console.WriteLine("Date of Accident (MM.DD.YYYY):");
            string dateOfIncidentAsString = Console.ReadLine();
            newClaims.DateOfIncident = DateTime.Parse(dateOfIncidentAsString);

            Console.WriteLine("Date of Claim (MM.DD.YYYY):");
            string dateOfClaimAsString = Console.ReadLine();
            newClaims.DateOfClaim = DateTime.Parse(dateOfClaimAsString);


            TimeSpan timeOfClaim = newClaims.DateOfClaim - newClaims.DateOfIncident;
            if (timeOfClaim.Days < 30)
            {
                newClaims.IsValid = true;
            }
            else
            {
                newClaims.IsValid = false;
            }

            _claimRepo.AddClaimToQueue(newClaims);

        }

        private void SeedClaimList()
        {
            KomodoClaims one = new KomodoClaims(1, ClaimType.Car, "car accident on 465", 400.00m, new DateTime(2018, 4, 25), new DateTime(2018, 4, 27), true);
            KomodoClaims two = new KomodoClaims(2, ClaimType.Home, "House fire in kitchen.", 400.00m, new DateTime(2018, 4, 11), new DateTime(2018, 4, 12), true);
            KomodoClaims three = new KomodoClaims(3, ClaimType.Theft, "Stolen pancakes.", 4.00m, new DateTime(2018, 4, 27), new DateTime(2018, 6, 1), false);

            _claimRepo.AddClaimToQueue(one);
            _claimRepo.AddClaimToQueue(two);
            _claimRepo.AddClaimToQueue(three);
        }
    }
}
