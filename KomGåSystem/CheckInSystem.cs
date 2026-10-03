using System;
using System.Collections.Generic;
using System.Text;

namespace KomGåSystem
{
    public class CheckInSystem
    {
        private Employee[] _employees;
        private int _employeeCount;
        private Guest[] _guests;
        private int _guestCount;

        public CheckInSystem(int maxEmployees = 100, int maxGuests = 50)
        {
            _employees = new Employee[maxEmployees];
            _employeeCount = 0;
            _guests = new Guest[maxGuests];
            _guestCount = 0;
        }
        public void ShowPresent()
        {
            Console.WriteLine("Medarbejdere tilstede:");
            for (int i = 0; i < _employeeCount; i++)
            {
                if (_employees[i].IsCheckedIn)
                    Console.WriteLine(_employees[i].Name);
            }

            Console.WriteLine("Gæster tilstede:");
            for (int i = 0; i < _guestCount; i++)
            {
                if (_guests[i].IsPresent)
                    Console.WriteLine(_guests[i].Name);
            }
        }

        public Employee CreateEmployee(string name, string department, bool giveAdmin = false)
        {

            string id = "E" + (_employeeCount + 1).ToString("D4");
            string username = GenerateUsername(name);

            Employee emp = new(name, username, department, giveAdmin);
            _employees[_employeeCount] = emp;
            _employeeCount++;
            return emp;
        }

        public Employee? FindEmployeeByUsername(string username)
        {
            for (int i = 0; i < _employeeCount; i++)
            {
                Employee e = _employees[i];
                if (e != null && string.Equals(e.Username, username, StringComparison.OrdinalIgnoreCase))
                    return e;
            }
            Console.WriteLine("Ingen medarbejdere med det brugernavn fundet");
            Console.ReadKey();
            return null;
        }

        //public Employee? FindEmployeeById(string id)
        //{
        //    for (int i = 0; i < _employeeCount; i++)
        //    {
        //        var e = _employees[i];
        //        if (e != null && string.Equals(e.EmployeeID, id, StringComparison.OrdinalIgnoreCase))
        //            return e;
        //    }
        //    return null;
        //}

        public Employee? Login(string username)
        {
            Employee? employee = FindEmployeeByUsername(username);
            // Following if-statement (null check), can also be written like this: employee?.IsLoggedIn = true;
            if (employee is not null) 
                employee.IsLoggedIn = true;
            return employee;
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

        public void EditEmployee(Employee employeeToEdit)
        {
            Console.Write("Indtast nyt navn: ");
            string newName = Console.ReadLine();
            Console.Write("Indtast ny afdeling: ");
            string newDepartment = Console.ReadLine();
            Console.WriteLine("* * *");
            Console.WriteLine("Ændret:");
            Console.WriteLine($"{employeeToEdit.Name} -> {newName}");
            Console.WriteLine($"{employeeToEdit.Department} -> {newDepartment}");
            employeeToEdit.Name = newName;
            employeeToEdit.Department = newDepartment;
        }
       
        public Guest RegisterGuests(string name, string company, Employee host)
        {
            Guest g = new(name, company ?? string.Empty, host, false);
            _guests[_guestCount++] = g;
            return g;
        }

        public void CheckOutGuest(string name)
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

        public void MarkSafetyFolderHandedOut(string name)
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