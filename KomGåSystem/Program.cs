namespace KomGåSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool running = true;

            while (running)
            {
                Console.Clear();
                Console.WriteLine("Hydac Main Menu");
                Console.WriteLine("*****************");
                Console.WriteLine("");
                Console.WriteLine("1. Log ind som medarbejder");
                Console.WriteLine("2. se personer til stede");
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
