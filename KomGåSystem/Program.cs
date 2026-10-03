namespace KomGåSystem
{
    public class Program
    {
        static void Main(string[] args)
        {

            CheckInSystem komOgGåSystem = new();
            komOgGåSystem.CreateEmployee("Admin Jensen", "IT", true);
            komOgGåSystem.CheckInEmployee("admin.jensen");
            komOgGåSystem.RegisterGuests("Lars Allan", "Sad Onion Inc.", komOgGåSystem.FindEmployeeByUsername("admin.jensen"));

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
                        Console.Write("Indtast brugernavn: ");
                        string userNameInput = Console.ReadLine() ?? string.Empty;
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
                        Console.ReadKey();
                        break;
                    case 2:
                        komOgGåSystem.CheckOutEmployee(loggedInUser.Username);
                        Console.WriteLine("Du er nu checked ud. Tryk på en tast for at fortsætte.");
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.Write("Indtats gæstens navn: ");
                        string guestName = Console.ReadLine();
                        Console.Write("Indtast navnet på firmaet gæsten kommer fra: ");
                        string guestCompany = Console.ReadLine();
                        komOgGåSystem.RegisterGuests(guestName, guestCompany, loggedInUser);
                        break;
                    case 4:
                        Console.Write("Indtast gæstens navn: ");
                        string guestName2 = Console.ReadLine();
                        komOgGåSystem.CheckOutGuest(guestName2);
                        Console.WriteLine($"{guestName2} er nu checked ind");
                        Console.ReadKey();
                        break;
                    case 5:
                        Console.Write("Indtast gæstens navn: ");
                        string guestName3 = Console.ReadLine();
                        komOgGåSystem.MarkSafetyFolderHandedOut(guestName3);
                        Console.WriteLine($"{guestName3} har fået sikkerhedsfolderen");
                        Console.ReadKey();
                        break;
                    case 6:
                        komOgGåSystem.ShowPresent();
                        Console.ReadKey();
                        break;
                    case 7:
                        Console.Write("Indstast navnet på den nye medarbejder: ");
                        string newEmployee = Console.ReadLine();
                        Console.Write("Indtast navnet på deres afdeling: ");
                        string newDepart = Console.ReadLine();
                        komOgGåSystem.CreateEmployee(newEmployee, newDepart);
                        Console.WriteLine("Ny medarbejder oprettet");
                        Console.ReadKey();
                        break;
                    case 8:
                        Console.Write("Indtast brugernavnet på medarbejderen du vil redigere: ");
                        string employeeUserName = Console.ReadLine();
                        Employee chosenEmployee = komOgGåSystem.FindEmployeeByUsername(employeeUserName);
                        komOgGåSystem.EditEmployee(chosenEmployee);
                        Console.ReadKey();
                        break;
                    case 0:
                        loggedInUser.IsLoggedIn = false;
                        return;
                    default:
                        break;
                }

            }

        }
    }
}
