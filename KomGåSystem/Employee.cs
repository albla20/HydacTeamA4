using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace KomGåSystem
{
    public class Employee
    {
        private string _department;
        private string _username;
        private string _name;
        private DateTime _arrivalTime;
        private DateTime _departureTime;
        private bool _isLoggedIn;

        public Employee(string name, string username, string department, bool isAdmin = false)
        {
            _name = name;
            _username = username;
            _department = department;
            IsAdmin = isAdmin;
        }
        public string Username => _username;
        public bool IsLoggedIn { get; set; }
        public bool IsCheckedIn { get; set; }
        public bool IsAdmin { get; }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public string Department
        {
            get => _department;
            set => _department = value;
        }
        // Properties tilføjet så vi nemt kan tilgå dem i andre klasser.
        public DateTime ArrivalTime
        {
            get => _arrivalTime;
            set => _arrivalTime = value;
        }

        public DateTime DepartureTime
        {
            get => _departureTime;
            set => _departureTime = value;
        }

        public Guest CheckInGuest()
        {
            string nameGuest = Helpers.GetUserString("Indtast navn på gæst");
            string nameCompany = Helpers.GetUserString("Indtast firmanavn");
            Console.WriteLine("Sikkerhedsfolder J/N");
            char safetyFolderChar = Console.ReadKey().KeyChar;

            //Vi antager at alt andet end J er et Nej
            bool safetyFolderBool = false;
            if (safetyFolderChar == 'J')
                safetyFolderBool = true;

            Guest newGuest = new(nameGuest, nameCompany, this, safetyFolderBool);

            return newGuest;
        }
        public void CheckOutGuest(Guest checkOutGuest)
        {
            checkOutGuest.DepartureTime = DateTime.Now;
            checkOutGuest.IsPresent = false;
        }
        public bool IsPresent()
        {
            return IsCheckedIn;
        }
        public string GetStatus()
        {
            string isAdminDA;
            if (IsAdmin)
                isAdminDA = "Ja";
            else
                isAdminDA = "Nej";

            return $"Navn: {_name}\nBrugernavn: {_username}\nAfdeling: {_department}\nAdim: {isAdminDA}";
        }
        public void IsHostFor(Guest[] allGuest)
        {
            foreach (Guest oneGuest in allGuest)
            {
                if (oneGuest.Host == this)
                {
                    Console.WriteLine(oneGuest.ToString());
                }
            }
        }
        

    }
}
