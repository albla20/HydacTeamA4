namespace KomGåSystem
{
    public class Program
    {
        static void Main(string[] args)
        {

            CheckInSystem komOgGåSystem = new();
            komOgGåSystem.CreateEmployee("Admin Jensen", "IT", true);

            bool running = true;

            while (running)
            {
                Console.Clear();
                Console.WriteLine("KomOgGåSystem");
                Console.WriteLine("*****************");
                Console.WriteLine("");
                Console.WriteLine("1. Log ind som medarbejder");
                Console.WriteLine("2. Se personer til stede");
                Console.WriteLine("0. Afslut");
                Console.Write(": ");

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
