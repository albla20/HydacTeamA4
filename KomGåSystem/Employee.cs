using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace KomGåSystem
{
    public class Employee
    {
        private string _employeeID;
        private string _department;
        private string _username;
        private string _name;
        private DateTime _arrivalTime;
        private DateTime _departureTime;
        private bool _isLoggedIn;

        public Employee(string name, string username, string employeeID, string department, bool isAdmin = false)
        {
            _name = name;
            _username = username;
            _employeeID = employeeID;
            _department = department;
            IsAdmin = isAdmin;
        }

        public bool IsAdmin {get; }
        public bool IsLoggedIn { get; set; }

        public Guest CheckInGuest()
        {
            Console.WriteLine("Indtast navn på gæst: ");
            string nameGuest = Console.ReadLine();
            Console.WriteLine("Indtast firmanavn: ");
            string nameCompany = Console.ReadLine();
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
            checkOutGuest 
        }
        public bool IsPresent()
        {

        }
        public string GetStatus()
        {

        }
        public Guest[] IsHostFor()
        {

        }
        

    }
}
