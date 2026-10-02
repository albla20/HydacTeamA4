using System;
using System.Collections.Generic;
using System.Text;

namespace KomGåSystem
{
    public class CheckInSystem
    {
        private  Employee[] _employees;
        private int _employeeCount;
        private  Guest[] _guests;
        private int _guestCount;

        public CheckInSystem(int maxEmployees = 100, int maxGuests = 50)
        {
            _employees = new Employee[maxEmployees];
            _employeeCount = 0;
            _guests = new Guest[maxGuests];
            _guestCount = 0;
        }
        public void showPresent()
        {
            int ec = 0;
            for (int i = 0; i < _employeeCount; i++) if (_employees[i].IsCheckedIn) ec++;
            var emps = new Employee[ec];
            int ei = 0;
            for (int i = 0; i < _employeeCount; i++) if (_employees[i].IsCheckedIn) emps[ei++] = _employees[i];

            int gc = 0;
            for (int i = 0; i < _guestCount; i++) if (_guests[i].IsPresent) gc++;
            var guests = new Guest[gc];
            int gi = 0;
            for (int i = 0; i < _guestCount; i++) if (_guests[i].IsPresent) guests[gi++] = _guests[i];

        }

        public Employee createEmployee(string name, string department)
        {
            if (_employeeCount >= _employees.Length) return null;

            string id = "E" + (_employeeCount + 1).ToString("D4");
            string username = GenerateUsername(name);

            var emp = new Employee(name, username, id, department ?? string.Empty);
            _employees[_employeeCount++] = emp;
            return emp;
        }
        public Employee FindEmployeeByUsername(string username)
        {
            for (int i = 0; i < _employeeCount; i++)
            {
                var e = _employees[i];
                if (e != null && string.Equals(e.Username, username, StringComparison.OrdinalIgnoreCase))
                    return e;
            }
            return null;
        }

        public Employee FindEmployeeById(string id)
        {
            for (int i = 0; i < _employeeCount; i++)
            {
                var e = _employees[i];
                if (e != null && string.Equals(e.EmployeeID, id, StringComparison.OrdinalIgnoreCase))
                    return e;
            }
            return null;
        }

        public Employee Login(string username)
        {
            var e = FindEmployeeByUsername(username);
            if (e != null) e.IsLoggedIn = true;
            return e;
        }

        public void CheckInEmployee(string username)
        {
            var e = FindEmployeeByUsername(username);
            if (e == null) return;
            e.IsCheckedIn = true;
            e.ArrivalTime = DateTime.Now;
        }

        public void CheckOutEmployee(string username)
        {
            var e = FindEmployeeByUsername(username);
            if (e == null) return;
            e.IsCheckedIn = false;
            e.DepartureTime = DateTime.Now;
        }

        public void editEmployee(string id, string name, string department)
        {

        }
       
        public Guest registerGuests(string name, string company, Employee host)
        {
            if (_guestCount >= _guests.Length) return null;
            var g = new Guest(name, company ?? string.Empty, host, false);
            _guests[_guestCount++] = g;
            return g;
        }

        public void checkOutGuest(string name)
        {
            for (int i = 0; i < _guestCount; i++)
            {
                var g = _guests[i];
                if (g.IsPresent && string.Equals(g.ToString(), name, StringComparison.OrdinalIgnoreCase))
                {
                    g.DepartureTime = DateTime.Now;
                    g.IsPresent = false;
                    return;
                }
            }
        }

        public void markSafetyFolderHandedOut(string name)
        {
            for (int i = 0; i < _guestCount; i++)
            {
                var g = _guests[i];
                if (g.IsPresent && string.Equals(g.ToString(), name, StringComparison.OrdinalIgnoreCase))
                {
                    g.MarkSafetyFolderHandedOut();
                    return;
                }
            }
        }
        private string GenerateUsername(string name)
        {
            return name.Trim().ToLowerInvariant().Replace(' ', '.');
        }
    }
}