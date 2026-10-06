using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KomGåSystem;

namespace KomGåSystem.Tests
{
    [TestClass]
    public class CheckInSystemTests
    {
        [TestMethod]
        public void RegisterGuest_CreatesGuestAndSetsHostAndIsPresent()
        {
            var sys = new CheckInSystem(maxEmployees: 10, maxGuests: 10);
            var emp = sys.CreateEmployee("Test User", "Dev");
            Assert.IsNotNull(emp);

            var guest = sys.RegisterGuests("Gæst One", "Acme", emp);
            Assert.IsNotNull(guest);
            Assert.IsTrue(guest.IsPresent);
            Assert.AreEqual(emp, guest.Host);
        }

        [TestMethod]
        public void FullFlow_CreateLoginCheckin_RegisterGuest_CheckoutAndMarkFolder()
        {
            var sys = new CheckInSystem(maxEmployees: 10, maxGuests: 10);

            // create employee
            var emp = sys.CreateEmployee("Anna Hansen", "Teknik");
            Assert.IsNotNull(emp);
            Assert.IsFalse(string.IsNullOrWhiteSpace(emp.Username));

            // login & check-in
            var logged = sys.Login(emp.Username);
            Assert.IsNotNull(logged);
            Assert.IsTrue(emp.IsLoggedIn);

            sys.CheckInEmployee(emp.Username);
            Assert.IsTrue(emp.IsCheckedIn);
            Assert.AreNotEqual(default(DateTime), emp.ArrivalTime);

            // register a guest for this host
            var guest = sys.RegisterGuests("Klaus", "Hydac", emp);
            Assert.IsNotNull(guest);
            Assert.IsTrue(guest.IsPresent);
            Assert.AreEqual(emp, guest.Host);

            // checkout guest and assert state
            sys.CheckOutGuest(guest.ToString());
            Assert.IsFalse(guest.IsPresent);
            Assert.AreNotEqual(default(DateTime), guest.DepartureTime);

            // mark safety folder handed out
            var guest2 = sys.RegisterGuests("Peter", "Firm", emp);
            Assert.IsNotNull(guest2);
            sys.MarkSafetyFolderHandedOut(guest2.ToString());
            StringAssert.Contains(guest2.GetStatus(), "Sikkerhedsfolder udleveret: Ja");

            // check out employee
            sys.CheckOutEmployee(emp.Username);
            Assert.IsFalse(emp.IsCheckedIn);
            Assert.AreNotEqual(default(DateTime), emp.DepartureTime);
        }
    }
}