using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

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
            Console.WriteLine("MEDARBEJDERE TILSTEDE:");
            for (int i = 0; i < _employeeCount; i++)
            {
                Employee emp = _employees[i];
                if (emp == null) continue;
                if (emp.IsCheckedIn)
                    Console.WriteLine(emp.Name);
            }

            Console.WriteLine("GÆSTER TILSTEDE:");
            for (int i = 0; i < _guestCount; i++)
            {
                Guest g = _guests[i];
                if (g == null) continue;
                if (g.IsPresent)
                    Console.WriteLine(g.ToString());
            }
        }

        public Employee CreateEmployee(string name, string department, bool giveAdmin = false)
        {
            if (string.IsNullOrWhiteSpace(name)) return null;
            if (_employeeCount >= _employees.Length) return null;
            string username = GenerateUsername(name);

            Employee emp = new Employee(name, username, department ?? string.Empty, giveAdmin);
            _employees[_employeeCount] = emp;
            _employeeCount++;
            return emp;
        }

        public Employee FindEmployeeByUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username)) return null;
            for (int i = 0; i < _employeeCount; i++)
            {
                Employee e = _employees[i];
                if (e == null) continue;
                if (string.Equals(e.Username, username, StringComparison.OrdinalIgnoreCase))
                    return e;
            }
            return null;
        }


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
            Employee e = FindEmployeeByUsername(username);
            if (e == null) return;
            e.IsCheckedIn = true;
            e.ArrivalTime = DateTime.Now;
        }

        public void CheckOutEmployee(string username)
        {
            Employee e = FindEmployeeByUsername(username);
            if (e == null) return;
            e.IsCheckedIn = false;
            e.DepartureTime = DateTime.Now;
        }

        public void EditEmployee(Employee employeeToEdit)
        {
            if (employeeToEdit == null) return;

            Console.Write("Indtast nyt navn (eller tryk enter for at beholde): ");
            string? newName = Console.ReadLine();
            Console.Write("Indtast ny afdeling (eller tryk enter for at beholde): ");
            string? newDepartment = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(newName))
                employeeToEdit.Name = newName;
            if (!string.IsNullOrWhiteSpace(newDepartment))
                employeeToEdit.Department = newDepartment;
        }

        public Guest RegisterGuest(string name, string company, Employee host)
        {
            if (string.IsNullOrWhiteSpace(name) || host == null) return null;
            if (_guestCount >= _guests.Length) return null;

            Guest g = new Guest(name, company ?? string.Empty, host, false);
            _guests[_guestCount] = g;
            _guestCount++;
            return g;
        }

        public void CheckOutGuest(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return;
            for (int i = 0; i < _guestCount; i++)
            {
                Guest g = _guests[i];
                if (g == null) continue;
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
            if (string.IsNullOrWhiteSpace(name)) return;
            for (int i = 0; i < _guestCount; i++)
            {
                Guest g = _guests[i];
                if (g == null) continue;
                if (g.IsPresent && string.Equals(g.ToString(), name, StringComparison.OrdinalIgnoreCase))
                {
                    g.MarkSafetyFolderHandedOut();
                    return;
                }
            }
        }

        private string GenerateUsername(string name)
        {
            return (name ?? string.Empty).Trim().ToLowerInvariant().Replace(' ', '.');
        }
    }
}