namespace KomGåSystem
{
    public class Program
    {
        static void Main(string[] args)
        {
            const int MAX_EMPLOYEES = 100;
            const int MAX_GUEST = 50;

            Employee[] allEmployees = new Employee[MAX_EMPLOYEES];
            Guest[] allGuest = new Guest[MAX_GUEST];

            bool running = true;

            while (running)
            {
                Console.Clear();
                Console.WriteLine("Hydac Main Menu");
                Console.WriteLine("*****************");
                Console.WriteLine("");
                Console.WriteLine("1. Log ind som medarbejder");
                Console.WriteLine("2. Se personer til stede");
                Console.WriteLine("0. afslut");
                Console.Write("vælg: ");

                string? vælg = Console.ReadLine();
                
                switch (vælg)
                {
                    case "1":
                        Console.Clear();

                    break;

                    case "2":
                        Console.Clear();

                    break;

                }

            }

        }
    }
}
