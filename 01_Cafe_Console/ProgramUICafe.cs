using _01_Cafe_Repo;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01_Cafe_Console
{
    class ProgramUICafe
    {
        //this is a field
        private CafeRepo _menuRepo = new CafeRepo();

        //This is the method that starts the app
        public void Run()
        {
            SeedCafeMenuList();
            MenuScreen();
        }

        //Method for the Menu
        private void MenuScreen()
        {
            bool keepRunning = true;
            while (keepRunning)
            {

                //Display options
                Console.WriteLine("Welcome to the Komodo Cafe! Please select an option below: \n" +
                    "1. Create New Menu Item\n" +
                    "2. View Full Menu\n" +
                    "3. Update Existing Menu Items\n" +
                    "4. Delete Existing Menu Items\n" +
                    "5. Exit");

                //Ask user what option they want
                string input = Console.ReadLine();

                //Evaluate what the user picked
                switch (input)
                {
                    case "1": //create
                        CreateNewMenuItem();
                        break;
                    case "2": //view all
                        ViewAllMenuItems();
                        break;
                    case "3": //update
                        UpdateMenuItems();
                        break;
                    case "4": //delete
                        DeleteMenuItems();
                        break;
                    case "5": //exit
                        Console.WriteLine("Goodbye!");
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

        //1
        private void CreateNewMenuItem()
        {
            Console.Clear();

            CafeMenu newMenu = new CafeMenu();
            //Meal Number
            Console.WriteLine("Please enter meal number:");
            string mealNumberAsString = Console.ReadLine();
            newMenu.MealNumber = int.Parse(mealNumberAsString);

            //Meal Name
            Console.WriteLine("Please enter name of meal:");
            newMenu.MealName = Console.ReadLine();

            //Description
            Console.WriteLine("Please enter description of meal:");
            newMenu.Description = Console.ReadLine();

            //Ingredients
            Console.WriteLine("Please enter ingredients of meal:");
            newMenu.Ingredients = Console.ReadLine();

            //Price
            Console.WriteLine("Please enter price of meal:");
            string priceAsString = Console.ReadLine();
            newMenu.Price = decimal.Parse(priceAsString);

            _menuRepo.AddMealToList(newMenu);
        }

        //2
        private void ViewAllMenuItems()
        {
            Console.Clear();

            List<CafeMenu> listOfMenu = _menuRepo.GetCafeMenuList();

            foreach (CafeMenu menu in listOfMenu)
            {
                Console.WriteLine($"Menu Items:\n" +
                    $"#{menu.MealNumber}: {menu.MealName}\n" +
                    $"{menu.Description}\n" +
                    $"Ingredients: {menu.Ingredients}\n" +
                    $"Price: ${menu.Price}");
            }
        }
        //3
        private void UpdateMenuItems()
        {
            ViewAllMenuItems();

            Console.WriteLine("\nEnter the name of the meal you want to update:");

            string oldMealName = Console.ReadLine();

            CafeMenu newMenu = new CafeMenu();
            //Meal Number
            Console.WriteLine("Please enter meal number:");
            string mealNumberAsString = Console.ReadLine();
            newMenu.MealNumber = int.Parse(mealNumberAsString);

            //Meal Name
            Console.WriteLine("Please enter name of meal:");
            newMenu.MealName = Console.ReadLine();

            //Description
            Console.WriteLine("Please enter description of meal:");
            newMenu.Description = Console.ReadLine();

            //Ingredients
            Console.WriteLine("Please enter ingredients of meal:");
            newMenu.Ingredients = Console.ReadLine();

            //Price
            Console.WriteLine("Please enter price of meal:");
            string priceAsString = Console.ReadLine();
            newMenu.Price = decimal.Parse(priceAsString);

            bool wasUpdated = _menuRepo.UpdateExistingMenu(oldMealName, newMenu);

            if (wasUpdated)
            {
                Console.WriteLine("Update was successful!");
            }
            else
            {
                Console.WriteLine("Update was not successful");
            }

        }

        //4
        private void DeleteMenuItems()
        {

            ViewAllMenuItems();


            Console.WriteLine("\nEnter the name of the meal you want removed:");
            string input = Console.ReadLine();

            bool wasDeleted = _menuRepo.RemoveMealFromMenu(input);

            if (wasDeleted)
            {
                Console.WriteLine("Meal was deleted");
            }
            else
            {
                Console.WriteLine("Could not be deleted");
            }
        }

        //seed method
        private void SeedCafeMenuList()
        {
            CafeMenu cheeseBurger = new CafeMenu(1, "Cheese Burger", "Fresh, never frozen, beef with colby jack cheese on a sesame seed bun", "beef, colby jack, bun, tomato, lettuce", 8.50m);
            CafeMenu chickenTenderBasket = new CafeMenu(2, "Chicken Tender Basket", "Four Chicken Tenders with choice of dipping sauce and waffle fries", "chicken, breading, potatoes, salt, canola oil", 7.50m);
            CafeMenu salad = new CafeMenu(3, "Salad", "Fresh salad with your choice of dressing. Add chicken for an extra $1", "romaine lettuce, iceberg lettuce, cucumbers, tomatoes, croutons, hard boil egg", 5.50m);
            CafeMenu soup = new CafeMenu(4, "Soup", "Today's soup is chicken noodle! Packed with chicken, veggies, and swirly noodles", "chicken broth, chicken, pasta, celery, carrots, onion, salt, pepper", 4.50m);

            _menuRepo.AddMealToList(cheeseBurger);
            _menuRepo.AddMealToList(chickenTenderBasket);
            _menuRepo.AddMealToList(soup);
            _menuRepo.AddMealToList(salad);
        }
    }
}
