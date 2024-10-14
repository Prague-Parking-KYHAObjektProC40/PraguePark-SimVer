using System;
public class Program
{
    public static void Main()

    {
        bool running = true;
        while (running)
        {
            Console.WriteLine("\n|------------------------------------|");
            Console.WriteLine("|Program alternativ:                 |");
            Console.WriteLine("|------------------------------------|");
            Console.WriteLine("|M1.Parkera fordon                   |");
            Console.WriteLine("|------------------------------------|");
            Console.WriteLine("|M2. Hämta Parkerat fordon           |");
            Console.WriteLine("|------------------------------------|");
            Console.WriteLine("|M3. Kolla given plats för fordonet  |");
            Console.WriteLine("|------------------------------------|");
            Console.WriteLine("|M4. (Avsluta)                       |");
            Console.WriteLine("|------------------------------------|");
            Console.WriteLine("\n");
            Console.Write("Välj ett alternativ: ");
            string? choice = Console.ReadLine();
            Console.WriteLine("\n\n");



            if (string.IsNullOrEmpty(choice))
            {
                Console.WriteLine("Inmatningen är tom, försök igen.");
            }

            else if (choice.Equals("M1", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Du valde meny 1\n\n");
            }

            else if (choice.Equals("M2", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Du valde meny 2\n\n");
            }

            else if (choice.Equals("M3", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Du valde meny 3\n\n");
            }

            else if (choice.Equals("M4", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Du valde meny 4\n");
                Console.WriteLine("Avslutar programmet...");
                running = false;
            }

            else

            {
                Console.WriteLine("Ogiltigt val, försök igen.");
            }

        }

    }

}