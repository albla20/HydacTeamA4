using System;
using System.Collections.Generic;
using System.Text;

namespace KomGåSystem
{
    public static class Setup
    {
        public static Menu SetupMainMenu()
        {
            Menu mainMenu = new("Hovedmenu");

            mainMenu.AddMenuItem("1. Log ind");
            mainMenu.AddMenuItem("2. Se personer tilstede");
            mainMenu.AddMenuItem("0. Afslut");

            return mainMenu;
        }

        public static Menu SetupUserMenu()
        {
            Menu userMenu = new("Menu");

            userMenu.AddMenuItem("1. Check ind");
            userMenu.AddMenuItem("2. Check ud");
            userMenu.AddMenuItem("3. Check gæst ind");
            userMenu.AddMenuItem("4. Check gæst ud");
            userMenu.AddMenuItem("5. Marker sikkerhedsfolder udleveret");
            userMenu.AddMenuItem("6. Se personer tilstede");
            userMenu.AddMenuItem("0. Tilbage");

            return userMenu;
        }

        public static Menu SetupAdminMenu()
        {
            Menu adminMenu = new("Administrator Menu");

            adminMenu.AddMenuItem("1. Check ind");
            adminMenu.AddMenuItem("2. Check ud");
            adminMenu.AddMenuItem("3. Check gæst ind");
            adminMenu.AddMenuItem("4. Check gæst ud");
            adminMenu.AddMenuItem("5. Marker sikkerhedsfolder udleveret");
            adminMenu.AddMenuItem("6. Se personer tilstede");
            adminMenu.AddMenuItem("7. Tilføj medarbejder");
            adminMenu.AddMenuItem("8. Rediger medarbejder");
            adminMenu.AddMenuItem("0. Tilbage");

            return adminMenu;
        }

        public static void AddUsers(CheckInSystem komOgGåSystem)
        {
            // Employees
            komOgGåSystem.CreateEmployee("Admin Jensen", "IT", true);
            komOgGåSystem.CheckInEmployee("admin.jensen");
            
            komOgGåSystem.CreateEmployee("Rene Hansen", "IT");
            komOgGåSystem.CheckInEmployee("rene.hansen");

            komOgGåSystem.CreateEmployee("Daniel R.", "HR", true);


            // Guests
            komOgGåSystem.RegisterGuest("Mikkel Holst", "Murr Elektronik", komOgGåSystem.FindEmployeeByUsername("rene.hansen"));
            komOgGåSystem.CheckOutGuest("Mikkel Holst");
            komOgGåSystem.RegisterGuest("Kasper Edal", "Nidec", komOgGåSystem.FindEmployeeByUsername("rene.hansen"));
            komOgGåSystem.RegisterGuest("Lars Allan", "Sad Onion Inc.", komOgGåSystem.FindEmployeeByUsername("admin.jensen"));
            komOgGåSystem.MarkSafetyFolderHandedOut("Lars Allan");

        }
    }
}
