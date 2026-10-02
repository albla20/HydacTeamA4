using System;
using System.Collections.Generic;
using System.Text;

namespace KomGåSystem
{
    // Static = der kan ikke laves instancer af klassen
    static public class Helpers
    {
        public static int GetUserInt(string message = "Enter a whole number:")
        {
            int userInt;

            Console.WriteLine(message);
            string userInput = Console.ReadLine() ?? string.Empty;

            while (!int.TryParse(userInput, out userInt))
            {
                Console.WriteLine("Invalid input, please try again:");
                userInput = Console.ReadLine() ?? string.Empty;
            }

            return userInt;
        }

    }
}
