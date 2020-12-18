using System;
using _01_Cafe_Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _01_Cafe_Test
{
    [TestClass]
    public class CafeMenuRepoTest
    {
        private CafeMenu _menu;
        private CafeRepo _repo;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new CafeRepo();
            _menu = new CafeMenu(1, "Cheese Burger", "Fresh, never frozen, beef with colby jack cheese on a sesame seed bun", "beef, colby jack, bun, tomato, lettuce", 8.50m);

            _repo.AddMealToList(_menu);
        }

        [TestMethod]
        public void AddToMenu_ShouldGetNotNull()
        {
            CafeMenu menu = new CafeMenu();
            menu.MealName = "Salad";
            CafeRepo repository = new CafeRepo();

            repository.AddMealToList(menu);
            CafeRepo contentFromDirectory = repository.GetMenuByMealName("Salad");

            Assert.IsNotNull(contentFromDirectory);
        }

        [TestMethod]
        public void UpdateExistingMenu_ShouldReturnTrue()
        {
            CafeMenu newMenu = new CafeMenu(1, "Cheese Burger", "Fresh, never frozen, beef w/ colby jack cheese on a sesame seed bun", "beef, colby jack, bun, tomato, lettuce", 8.50m);

            bool updateResults = _repo.UpdateExistingMenu("Cheese Burger", newMenu);
            Assert.IsTrue(updateResults);
        }

        [TestMethod]
        public void DeleteMenu_ShouldReturnTrue()
        {
            bool deleteResults = _repo.RemoveMealFromMenu(_menu.MealName);
            Assert.IsTrue(deleteResults);
        }
    }
}
