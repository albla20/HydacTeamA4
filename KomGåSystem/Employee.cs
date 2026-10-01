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

        public bool IsAdmin {get; }
        public bool IsLoggedIn { get; set; }

        public void CheckInGuest()
        {

        }
        public void CheckOutGuest()
        {

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
