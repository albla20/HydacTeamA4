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
            string menuItemTitle;

            menuItemTitle = "1. Log ind";
            mainMenu.AddMenuItem(menuItemTitle);

            menuItemTitle = "2. Se personer tilstede";
            mainMenu.AddMenuItem(menuItemTitle);

            menuItemTitle = "0. Afslut";
            mainMenu.AddMenuItem(menuItemTitle);

            return mainMenu;
        }

        public static Menu SetupUserMenu()
        {
            Menu userMenu = new("Menu");
            string menuItemTitle;

            menuItemTitle = "1. Check ind";
            userMenu.AddMenuItem(menuItemTitle);

            menuItemTitle = "2. Check ud";
            userMenu.AddMenuItem(menuItemTitle);

            menuItemTitle = "3. Check gæst ind";
            userMenu.AddMenuItem(menuItemTitle);

            menuItemTitle = "4. Check gæst ud";
            userMenu.AddMenuItem(menuItemTitle);

            menuItemTitle = "5. Marker sikkerhedsfolder udleveret";
            userMenu.AddMenuItem(menuItemTitle);

            menuItemTitle = "6. Se personer tilstede";
            userMenu.AddMenuItem(menuItemTitle);

            menuItemTitle = "0. Tilbage";
            userMenu.AddMenuItem(menuItemTitle);

            return userMenu;
        }

        public static Menu SetupAdminMenu()
        {
            Menu adminMenu = new("Administrator Menu");
            string menuItemTitle;

            menuItemTitle = "1. Check ind";
            adminMenu.AddMenuItem(menuItemTitle);

            menuItemTitle = "2. Check ud";
            adminMenu.AddMenuItem(menuItemTitle);

            menuItemTitle = "3. Check gæst ind";
            adminMenu.AddMenuItem(menuItemTitle);

            menuItemTitle = "4. Check gæst ud";
            adminMenu.AddMenuItem(menuItemTitle);

            menuItemTitle = "5. Marker sikkerhedsfolder udleveret";
            adminMenu.AddMenuItem(menuItemTitle);

            menuItemTitle = "6. Se personer tilstede";
            adminMenu.AddMenuItem(menuItemTitle);
            
            menuItemTitle = "7. Tilføj medarbejder";
            adminMenu.AddMenuItem(menuItemTitle);

            menuItemTitle = "8. Rediger medarbejder";
            adminMenu.AddMenuItem(menuItemTitle);

            menuItemTitle = "0. Tilbage";
            adminMenu.AddMenuItem(menuItemTitle);

            return adminMenu;
        }
    }
}
