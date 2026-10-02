using System;
using System.Collections.Generic;
using System.Text;

namespace KomGåSystem
{
    // Static = der kan ikke laves instancer af klassen
    static public class Helpers
    {
        public static int GetUserInt(string message = "Indtast et heltal:")
        {
            int userInt;

            Console.WriteLine(message);
            string userInput = Console.ReadLine() ?? string.Empty;

            while (!int.TryParse(userInput, out userInt))
            {
                Console.WriteLine("Ugyldigt input. Prøv igen:");
                userInput = Console.ReadLine() ?? string.Empty;
            }

            return userInt;
        }

        public static int GetChoiceInRange(int upperLimit, int lowerLimit = 0)
        {
            int choice;
            do
            {
                choice = GetUserInt($"Indtast et tal fra {lowerLimit} til {upperLimit} (begge inluderet):");
            }
            while (choice < lowerLimit || choice > upperLimit);

            return choice;
        }
    }
}
