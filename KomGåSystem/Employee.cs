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
        //private dateTime 
        //private departureTime
        public bool IsAdmin {get; }
        public bool IsLoggedIn { get; set; }

        private bool _isLoggedIn;
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
