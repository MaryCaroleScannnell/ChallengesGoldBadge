using System;
using System.Collections.Generic;

namespace _01_Cafe_Repo
{
    public class CafeRepo
    {
        private List<CafeMenu> _listOfCafeMenu = new List<CafeMenu>();


        //create
        public void AddMealToList(CafeMenu meal)
        {
            _listOfCafeMenu.Add(meal);
        }

        //read

        public List<CafeMenu> GetCafeMenuList()
        {
            return _listOfCafeMenu;
        }

        //update
        public bool UpdateExistingMenu(string originalMealName, CafeMenu newMenu)
        {
            //find menu item
            CafeMenu oldCafeMenu = GetMenuByMealName(originalMealName);

            //update menu item
            if (oldCafeMenu != null)
            {
                oldCafeMenu.MealName = newMenu.MealName;
                oldCafeMenu.MealNumber = newMenu.MealNumber;
                oldCafeMenu.Description = newMenu.Description;
                oldCafeMenu.Ingredients = newMenu.Ingredients;
                oldCafeMenu.Price = newMenu.Price;
                return true;
            }
            else
            {
                return false;
            }
        }


        //delete
        public bool RemoveMealFromMenu(string mealName)
        {
            CafeMenu menu = GetMenuByMealName(mealName);

            if (menu == null)
            {
                return false;
            }
            int initialCount = _listOfCafeMenu.Count;
            _listOfCafeMenu.Remove(menu);

            if (initialCount > _listOfCafeMenu.Count)
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        //helper method
        public CafeMenu GetMenuByMealName(string mealName)
        {
            foreach (CafeMenu menu in _listOfCafeMenu)
            {
                if (menu.MealName.ToLower() == mealName)
                {
                    return menu;
                }
            }

            return null;
        }
    }
}
