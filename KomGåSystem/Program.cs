namespace KomGåSystem
{
    public class Program
    {
        static void Main(string[] args)
        {

            CheckInSystem komOgGåSystem = new();
            komOgGåSystem.CreateEmployee("Admin Jensen", "IT", true);
            komOgGåSystem.CheckInEmployee("admin.jensen");
            komOgGåSystem.RegisterGuest("Lars Allan", "Sad Onion Inc.", komOgGåSystem.FindEmployeeByUsername("admin.jensen"));

            Menu mainMenu = Setup.SetupMainMenu();

            while (true)
            {
                Employee? loggedInUser;
                int userChoice;

                Console.Clear();
                mainMenu.Show();
                userChoice = Helpers.GetChoiceInRange(mainMenu.ItemCount - 1);

                switch (userChoice)
                {
                    case 1:
                        Console.Clear();
                        string userNameInput = Helpers.GetUserString("Indtast brugernavn");
                        loggedInUser = komOgGåSystem.Login(userNameInput);
                        if (loggedInUser is not null && loggedInUser.IsLoggedIn)
                            SubMenu(loggedInUser, komOgGåSystem);
                        break;
                    case 2:
                        Console.Clear();
                        komOgGåSystem.ShowPresent();
                        Console.ReadKey();
                        break;
                    case 0:
                        return;
                    default:
                        break;
                }
            }
        }

        static void SubMenu(Employee loggedInUser, CheckInSystem komOgGåSystem)
        {
            Menu subMenu;

            if (loggedInUser.IsAdmin)
                subMenu = Setup.SetupAdminMenu();
            else
                subMenu = Setup.SetupUserMenu();

            while (true)
            {
                Console.Clear();
                subMenu.Show();

                int userChoice = Helpers.GetChoiceInRange(subMenu.ItemCount - 1);
                Console.Clear();
                switch (userChoice)
                {
                    case 1:
                        komOgGåSystem.CheckInEmployee(loggedInUser.Username);
                        Console.WriteLine("Du er nu checked ind. Tryk på en tast for at fortsætte.");
                        break;
                    case 2:
                        komOgGåSystem.CheckOutEmployee(loggedInUser.Username);
                        Console.WriteLine("Du er nu checked ud. Tryk på en tast for at fortsætte.");
                        break;
                    case 3:
                        string guestName = Helpers.GetUserString("Indtats gæstens navn");
                        string guestCompany = Helpers.GetUserString("Indtast navnet på firmaet gæsten kommer fra");
                        komOgGåSystem.RegisterGuest(guestName, guestCompany, loggedInUser);
                        Console.WriteLine($"{guestName} er nu checked ind.");
                        break;
                    case 4:
                        string guestName2 = Helpers.GetUserString("Indtast gæstens navn");
                        komOgGåSystem.CheckOutGuest(guestName2);
                        Console.WriteLine($"{guestName2} er nu checked ud.");
                        break;
                    case 5:
                        string guestName3 = Helpers.GetUserString("Indtast gæstens navn");
                        komOgGåSystem.MarkSafetyFolderHandedOut(guestName3);
                        Console.WriteLine($"{guestName3} har fået sikkerhedsfolderen.");
                        break;
                    case 6:
                        komOgGåSystem.ShowPresent();
                        break;
                    case 7:
                        string newEmployee = Helpers.GetUserString("Indstast navnet på den nye medarbejder");
                        string newDepart = Helpers.GetUserString("Indtast navnet på deres afdeling");
                        komOgGåSystem.CreateEmployee(newEmployee, newDepart);
                        Console.WriteLine("Ny medarbejder oprettet.");
                        break;
                    case 8:
                        string employeeUserName = Helpers.GetUserString("Indtast brugernavnet på medarbejderen du vil redigere");
                        Employee chosenEmployee = komOgGåSystem.FindEmployeeByUsername(employeeUserName);
                        komOgGåSystem.EditEmployee(chosenEmployee);
                        break;
                    case 0:
                        loggedInUser.IsLoggedIn = false;
                        return;
                    default:
                        break;
                }
                Console.ReadKey();
            }
        }
    }
}
