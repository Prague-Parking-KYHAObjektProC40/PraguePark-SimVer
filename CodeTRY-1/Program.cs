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



            switch (choice)

            {

                case "1":

                    // Gör något för m1 

                    Console.WriteLine("Du valde m1\n\n");

                    break;

                case "2":

                    // Gör något för m2 

                    Console.WriteLine("Du valde m2\n\n");

                    break;

                case "3":

                    // Gör något för m3 

                    Console.WriteLine("Du valde m3\n\n");

                    break;

                case "4":

                    // Avsluta programmet 

                    Console.WriteLine("Avslutar...\n\n");

                    running = false;

                    break;

                default:

                    Console.WriteLine("Ogiltigt val, försök igen.\n\n");

                    break;

            }

        }

    }

}