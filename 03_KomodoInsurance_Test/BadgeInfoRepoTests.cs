using System;
using System.Collections.Generic;
using _03_KomodoInsurance_Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _03_KomodoInsurance_Test
{
    [TestClass]
    public class BadgeInfoRepoTests
    {
        private BadgeInfoRepo _repo;
        private BadgeInfo _badge;

        [TestInitialize]
        public void Arrange()
        {
            List<string> listOfDoors = new List<string>();
            _repo = new BadgeInfoRepo();
            _badge = new BadgeInfo(12345, listOfDoors.Add("a7"));

            _repo.AddABadge(_badge);
        }


        //Test Add Method
        [TestMethod]
        public void AddToList_ShouldGetNotNull()
        {
            //Arrange
            BadgeInfo badge = new BadgeInfo();
            badge.BadgeID = 12345;
            BadgeInfoRepo repository = new BadgeInfoRepo();

            //Act
            repository.AddABadge(badge);
            BadgeInfo badgeFromDirectory = repository.GetBadgeList(12345);

            Assert.IsNotNull(badgeFromDirectory);
        }

        //Test Update Method
        [TestMethod]
        public void UpdateBadge_ShouldReturnTrue()
        {
            BadgeInfo newBadge = new BadgeInfo(12345, listOfDoors.Add("A1"));

            bool updateResult = _repo.UpdateDoors(12345, newBadge);

            Assert.IsTrue(updateResult);
        }

        //Test Delete Method
        [TestMethod]
        public void DeleteDoor_ShouldReturnTrue()
        {
            bool deleteResult = _repo.RemoveDoorFromList(_badge.BadgeID);

            Assert.IsTrue(deleteResult);
        }
    }
}
