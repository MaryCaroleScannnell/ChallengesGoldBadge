using _03_KomodoInsurance_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_KomodoInsurance_Console
{
    class ProgramUI
    {
        private BadgeInfoRepo _badgeInfoRepo = new BadgeInfoRepo();
        List<string> _ListDoors = new List<string>();
        Dictionary<int, List<string>> _badgeDictionary = new Dictionary<int, List<string>>();

        public void Run()
        {
            SeedContentList();
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Select a new option\n" +
                    "1. Create New Badge\n" +
                    "2. Update doors on an existing badge\n" +
                    "3. Delete all doors from an existing badge\n" +
                    "4. Show a list with all badge numbers and door access\n" +
                    "5. Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1": //create new badge
                        CreateNewBadge();
                        break;
                    case "2": //update doors
                        UpdateDoorsOnBadge();
                        break;
                    case "3": //Delete all doors from badge
                        DeleteAllDoorsFromBadge();
                        break;
                    case "4": //show a list of all
                        ShowListOfAllBadgeInfo();
                        break;
                    case "5":
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter valid numer.");
                        break;
                }

                Console.WriteLine("Please press any key to continue");
                Console.ReadKey();
                Console.Clear();
            }
        }
        private void CreateNewBadge()
        {
            Console.Clear();
            BadgeInfo newBadgeInfo = new BadgeInfo();

            Console.WriteLine("Enter the badge number for the door list");
            string badgeNumbAsString = Console.ReadLine();
            newBadgeInfo.BadgeID = int.Parse(badgeNumbAsString);

            Console.WriteLine("Add door to badge number:");
            string door1 = Console.ReadLine();
            _ListDoors.Add(door1);

            Console.WriteLine("Do you need to add another door (y/n)?");
            string response = Console.ReadLine().ToLower();
            if (response == "y")
            {
                Console.WriteLine("Enter door to add to badge number:");
                string door2 = Console.ReadLine();
                _ListDoors.Add(door2);
            }
            else if (response == "n")
            {
                Console.WriteLine("Door has been added!");
            }
            else
            {
                Console.WriteLine("please use 'y' or 'n '");
            }
            _badgeInfoRepo.AddABadge(newBadgeInfo);
        }



        private void UpdateDoorsOnBadge()
        {
            ShowListOfAllBadgeInfo();
            BadgeInfo newBadgeInfo = new BadgeInfo();

            Console.WriteLine("Enter the badge number for the door list");
            string badgeNumbAsString = Console.ReadLine();
            newBadgeInfo.BadgeID = int.Parse(badgeNumbAsString);

            Console.WriteLine("Add door to badge number:");
            string door1 = Console.ReadLine();
            _ListDoors.Add(door1);

            Console.WriteLine("Do you need to add another door (y/n)?");
            string response = Console.ReadLine().ToLower();
            if (response == "y")
            {
                Console.WriteLine("Enter door to add to badge number:");
                string door2 = Console.ReadLine();
                _ListDoors.Add(door2);
                Console.WriteLine("Door has been added");

            }
            else if (response == "n")
            {
                Console.WriteLine("Door has been added!");
            }
            else
            {
                Console.WriteLine("please use 'y' or 'n '");
            }

            bool wasUpdated = _badgeInfoRepo.UpdateDoors(newBadgeInfo.BadgeID, _ListDoors);
            if (wasUpdated)
            {
                Console.WriteLine("Successful Update");
            }
            else
            {
                Console.WriteLine("Could not update");
            }
        }

        private void DeleteAllDoorsFromBadge()
        {
            ShowListOfAllBadgeInfo();
            Console.WriteLine("Which Badge Do You Need to Delete Doors From?");

            string BadgeInputAsString = Console.ReadLine();
            int input = int.Parse(BadgeInputAsString);

            bool wasDeleted = _badgeInfoRepo.RemoveDoorFromList(input);
            if (wasDeleted)
            {
                Console.WriteLine("Door was deleted");
            }
            else
            {
                Console.WriteLine("Door could not be deleted");
            }

        }
        private void ShowListOfAllBadgeInfo()

        {
            Console.Clear();
            Dictionary<int, List<string>> listOfBadgeInfo = _badgeInfoRepo.GetBadgeList();

            Console.WriteLine($"{"Badge #",10} " +
                    $"{"Door Access",10}");

            foreach (var badge in listOfBadgeInfo)
            {
                string badgeDoors = string.Join(",", badge.Value);
                Console.WriteLine($"{badge.Key,10} " +
                    $"{badgeDoors,10} ");
            };

        }

        private void SeedContentList()
        {


            var badge1 = new BadgeInfo(12345, new List<string> { "A7" });

            var badge2 = new BadgeInfo(22345, new List<string> { "A1", "A4", "B1", "B2" });

            var badge3 = new BadgeInfo(32345, new List<string> { "A4", "A5" });



            _badgeInfoRepo.AddABadge(badge1);
            _badgeInfoRepo.AddABadge(badge2);
            _badgeInfoRepo.AddABadge(badge3);
        }
    }
}
