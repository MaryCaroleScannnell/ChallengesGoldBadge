using System;
using _02_Komodo_Claims_Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static _02_Komodo_Claims_Repo.KomodoClaims;

namespace _02_Komodo_Test
{
    [TestClass]
    public class KomodoClaimsRepoTest
    {
        private KomodoClaims _claims;
        private KomodoClaimRepo _repo;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new KomodoClaimRepo();
            _claims = new KomodoClaims(1, ClaimType.Car, "car accident on 465", 400.00m, new DateTime(2018, 4, 25), new DateTime(2018, 4, 27), true);

            _repo.AddClaimToQueue(_claims);
        }


        [TestMethod]
        public void AddToList_ShouldGetNotNull()
        {
            KomodoClaims claims = new KomodoClaims();
            claims.ClaimID = 1;
            claims.Description = "car accident on 465";
            claims.ClaimAmount = 400.00m;
            claims.DateOfIncident = new DateTime(2018, 4, 25);
            claims.DateOfClaim = new DateTime(2018, 4, 27);
            claims.IsValid = true;
            KomodoClaimRepo repository = new KomodoClaimRepo();
            //1, ClaimType.Car, "car accident on 465", 400.00m, new DateTime(2018, 4, 25),  new DateTime(2018, 4, 27), true)
            repository.AddClaimToQueue(claims);
            KomodoClaims claimsFromDirectory = repository.GetKomodoClaims(1,);

            Assert.IsNotNull(claimsFromDirectory);
        }

        [TestMethod]
        public void DeleteContent_ShouldReturnTrue()
        {

            bool deleteResults = _repo.RemoveClaimFromQueue(_claims.ClaimID);

            Assert.IsTrue(deleteResults);
        }
    }
}
