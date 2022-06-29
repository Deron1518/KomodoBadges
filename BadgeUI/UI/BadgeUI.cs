using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


    public class BadgeUI
    {
        private BadgeRepo _bRepo = new BadgeRepo();

        public void Run()
        {
            SeedData();
            RunApplication();
        }

        public void SeedData()
        {
            BadgeData badgeOne = new BadgeData(12345, new List<string> {"Door A7"});
            BadgeData badgeTwo = new BadgeData(22345, new List<string> {"Door A1, A4, B1, B2"});
            BadgeData badgeThree = new BadgeData(32345, new List<string> {"Door A4, A5"});

            _bRepo.AddBadgeToDictionary(badgeOne);
            _bRepo.AddBadgeToDictionary(badgeTwo);
            _bRepo.AddBadgeToDictionary(badgeThree);
        }

        private void PressAnyKey()
        {
            System.Console.WriteLine("Press Any Key to Continue...");
            Console.ReadKey();
        }

        public void RunApplication()
        {
            bool isRunning = true;
            while(isRunning)
            {
                Console.Clear();
                System.Console.WriteLine("Hello Security Admin, What would you like to do?\n" +
                "1. Add a badge \n" +
                "2. Edit a badge \n" +
                "3. List all badges \n" +
                "4. Exit \n"
                );

                string userInput = Console.ReadLine().ToLower();

                switch(userInput)
                {
                    case "1":
                    case "one":
                        AddBadge();
                        break;
                    case "2":
                    case "two":
                        EditBadge();
                        break;
                    case "3":
                    case "three":
                        ViewAllBadges();
                        break;
                    case "4":
                    case "four":
                        isRunning = false;
                        System.Console.WriteLine("Have a good day!");
                        break;
                    default:
                        System.Console.WriteLine("Please enter a valid option.");
                        break;
                }
            }
        }

        public void AddBadge()
        {
            BadgeData badge = new BadgeData();
            badge.DoorAccess = new List<string>();
            Console.Clear();

            System.Console.WriteLine("=== Create a new badge ===");
            System.Console.WriteLine("Please enter a badge number");
            badge.BadgeID = int.Parse(Console.ReadLine());
            Console.Clear();

            System.Console.WriteLine($"Please enter the door you want Badge {badge.BadgeID} to access: ");
            badge.DoorAccess.Add(Console.ReadLine());

            bool addDoor = true;

            System.Console.WriteLine($"Door access has been added to Badge {badge.BadgeID}");

            while(addDoor)
            {
                System.Console.WriteLine("Would you like to add another door to this badge?(y/n)");
                string userInput = Console.ReadLine().ToLower();

                switch(userInput)
                {
                    case "y":
                    case "yes":
                        System.Console.WriteLine($"Please enter the door you want Badge {badge.BadgeID} to access: ");
                        badge.DoorAccess.Add(Console.ReadLine());
                        break;
                    case "n":
                    case "no":
                        addDoor = false;
                        System.Console.WriteLine($"Door access successfully added for Badge {badge.BadgeID}");
                        PressAnyKey();
                        break;
                }

            }

            _bRepo.AddBadgeToDictionary(badge);
            Console.Clear();
            System.Console.WriteLine($"Badge #{badge.BadgeID} has been added to the list!");
            PressAnyKey();

        }

        private void EditBadge()
        {
            BadgeData badge = new BadgeData();
            badge.DoorAccess = new List<string>();
            Console.Clear();

            System.Console.WriteLine("Please enter the badge number you would like to edit: ");
            badge.BadgeID = int.Parse(Console.ReadLine());
            Console.Clear();

            System.Console.WriteLine($"What changes would you like to make to Badge {badge.BadgeID} \n" +
            "1. Add a door \n" +
            "2. Remove a door \n" +
            "3. Previous Menu \n"
            );

            string userInput = Console.ReadLine().ToLower();

            switch(userInput)
            {
                case "1":
                case "one":
                    AddDoorToBadge(badge.BadgeID);
                    break;
                case "2":
                case "two":
                    RemoveDoorFromBadge(badge.BadgeID);
                    break;
                case "3":
                case "three":
                    RunApplication();
                    break;
            }

        }

        public void AddDoorToBadge(int badgeID)
        {
            System.Console.WriteLine("Please enter the door you would like to add to this badge: ");
            string door = Console.ReadLine();
            _bRepo.AddDoorToBadge(badgeID, door);

            System.Console.WriteLine("Access has been added");
            PressAnyKey();
        }

        public void RemoveDoorFromBadge(int badgeID)
        {
            System.Console.WriteLine("Please enter the door you would like to remove from this badge");
            string door = Console.ReadLine();
            _bRepo.RemoveDoorFromBadge(badgeID, door);

            System.Console.WriteLine("Door access has been removed from this badge");
            PressAnyKey();
        }

        public void ViewAllBadges()
        {
            Dictionary<int, List<string>> ListOfBadges = _bRepo.GetAllDoors();
            
            foreach(KeyValuePair<int, List<string>> badge in ListOfBadges)
            {
                System.Console.WriteLine($"Badge: {badge.Key}");

                foreach(string door in badge.Value)
                {

                    System.Console.WriteLine(door);
                    System.Console.WriteLine("-------------------------------------------------------");
                }

            }
            PressAnyKey();
        }
    }
