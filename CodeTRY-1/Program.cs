using System;

class ParkingGarage
{
    static double[] parkingGarage = new double[100]; // Array to store 100 spaces
    static string[] registrationNumbers = new string[100]; // Array to store registration numbers
    static double totalSpace = 100; // Maximum total space in the garage

    static void Main(string[] args)
    {
        while (true)
        {


            Console.WriteLine("\n|------------------------------------|");

            Console.WriteLine("|Program alternativ:                 |");

            Console.WriteLine("|------------------------------------|");

            Console.WriteLine("|M1.Parkera fordon                   |");

            Console.WriteLine("|------------------------------------|");

            Console.WriteLine("|M2. Hämta Parkerat fordon           |");

            Console.WriteLine("|------------------------------------|");

            Console.WriteLine("|M3. Sökning                         |");

            Console.WriteLine("|M3. a) Efter givet fordon           |");

            Console.WriteLine("|M3. b) Efter ledig plats för given fordonstyp |");

            Console.WriteLine("|M3. c) Av enskild P - plats         |");

            Console.WriteLine("|M3. d) Av hela P-huset              |");

            Console.WriteLine("|------------------------------------|");

            Console.WriteLine("|M4. Parkerat om fordon              |");

            Console.WriteLine("|------------------------------------|");

            Console.WriteLine("|M5. (Avsluta)                       |");

            Console.WriteLine("|------------------------------------|");

            Console.WriteLine("\n");

            Console.Write("Välj ett alternativ: ");

            string? choice = Console.ReadLine();

            Console.WriteLine("\n\n");

            switch (choice)
            {
                case "M1":
                case "m1":
                case "1":
                    {
                        // Method to add a vehicle with a registration number
                        Console.WriteLine("Enter vehicle reg number:");
                        string regNumber = GetValidRegistrationNumber();

                        Console.WriteLine("Enter vehicle type (car/motorcycle): ");
                        string vehicleType = Console.ReadLine();

                        if (vehicleType == "car")
                        {
                            if (totalSpace >= 1)
                            {
                                int index = FindEmptySpot(1); // Find spot for car
                                if (index != -1)
                                {
                                    parkingGarage[index] = 1; // Car takes 1 unit of space
                                    registrationNumbers[index] = regNumber;
                                    totalSpace -= 1;
                                    Console.WriteLine($"Car with reg number '{regNumber}' added to spot {index + 1}. Remaining space: {totalSpace}");
                                }
                                else
                                {
                                    Console.WriteLine("No space available for a car.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Not enough space for a car.");
                            }
                        }
                        else if (vehicleType == "motorcycle")
                        {
                            if (totalSpace >= 0.5)
                            {
                                int index = FindSpotForMotorcycle();
                                if (index != -1)
                                {
                                    parkingGarage[index] += 0.5; // Motorcycle takes 0.5 space
                                    if (parkingGarage[index] == 0.5) // First motorcycle in spot
                                    {
                                        registrationNumbers[index] = regNumber;
                                    }
                                    else // Second motorcycle in the same spot
                                    {
                                        registrationNumbers[index] += $", {regNumber}";
                                    }
                                    totalSpace -= 0.5;
                                    Console.WriteLine($"Motorcycle with reg number '{regNumber}' added to spot {index + 1}. Remaining space: {totalSpace}");
                                }
                                else
                                {
                                    Console.WriteLine("No space available for a motorcycle.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Not enough space for a motorcycle.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid vehicle type.");
                        }
                    }

                    break;

                case "M2":
                case "m2":
                case "2":
                    // Remove a vehicle by registration number
                    {
                        Console.WriteLine("Enter the registration number of the vehicle to remove:");
                        string regNumber = Console.ReadLine();

                        // Find the spot with the matching registration number
                        for (int i = 0; i < registrationNumbers.Length; i++)
                        {
                            if (registrationNumbers[i] != null && registrationNumbers[i].Contains(regNumber))
                            {
                                if (parkingGarage[i] == 1) // Car in the spot
                                {
                                    parkingGarage[i] = 0;
                                    Console.WriteLine($"Car with reg number '{registrationNumbers[i]}' removed from spot {i + 1}.");
                                    registrationNumbers[i] = null; // Remove registration number
                                    totalSpace += 1;
                                }
                                else if (parkingGarage[i] == 0.5) // Motorcycle in the spot
                                {
                                    // If there are multiple motorcycles (comma-separated)
                                    if (registrationNumbers[i].Contains(","))
                                    {
                                        // Remove the specific motorcycle's registration number
                                        registrationNumbers[i] = registrationNumbers[i].Replace(regNumber, "").Replace(", ,", ",").Trim();
                                        if (registrationNumbers[i].EndsWith(",")) // Clean trailing commas
                                        {
                                            registrationNumbers[i] = registrationNumbers[i].TrimEnd(',');
                                        }

                                        Console.WriteLine($"Motorcycle with reg number '{regNumber}' removed from spot {i + 1}.");
                                    }
                                    else
                                    {
                                        // Only one motorcycle in the spot
                                        parkingGarage[i] = 0;
                                        registrationNumbers[i] = null; // Remove registration number
                                        Console.WriteLine($"Motorcycle with reg number '{regNumber}' removed from spot {i + 1}.");
                                    }
                                    totalSpace += 0.5;
                                }
                                return; // Exit the method once the vehicle is found and removed
                            }
                        }
                        Console.WriteLine($"No vehicle found with the registration number '{regNumber}'.");
                    }
                    break;

                case "M3":
                case "m3":
                case "3":

                    Console.WriteLine("Enter the option: a) b) c) d)");
                    string find = Console.ReadLine();
                    
                    if (string.IsNullOrEmpty(find))
                    {
                        Console.WriteLine("Inmatningen är tom, försök igen.");
                    }

                    else if (find.Equals("a", StringComparison.OrdinalIgnoreCase))
                    {
                        // Find and display the parking spot of a vehicle by its registration number
                        {
                            Console.WriteLine("Enter the registration number to search for: ");
                            string regNumber = Console.ReadLine();

                            bool found = false;

                            for (int i = 0; i < registrationNumbers.Length; i++)
                            {
                                if (registrationNumbers[i] != null && registrationNumbers[i].Contains(regNumber)) // Search for registration number
                                {
                                    Console.WriteLine($"Vehicle with reg number '{regNumber}' is parked at spot {i + 1}.");
                                    found = true;
                                    break; // Stop after finding the first match
                                }
                            }

                            if (!found)
                            {
                                Console.WriteLine($"No vehicle with reg number '{regNumber}' found in the garage.");
                            }
                        }
                    }

                    else if (find.Equals("b", StringComparison.OrdinalIgnoreCase))
                    {
                        // Search for free space for a given vehicle type
                        Console.WriteLine("Sök efter ledig plats för vilken fordonstyp (car/motorcycle)?");
                        string vehicleType = Console.ReadLine();

                        if (vehicleType.Equals("car", StringComparison.OrdinalIgnoreCase))
                        {
                            int availableSpots = CountAvailableSpotsForCar();
                            Console.WriteLine($"Det finns {availableSpots} lediga platser för bilar.");
                        }
                        else if (vehicleType.Equals("motorcycle", StringComparison.OrdinalIgnoreCase))
                        {
                            int availableSpots = CountAvailableSpotsForMotorcycle();
                            Console.WriteLine($"Det finns {availableSpots} lediga platser för motorcyklar.");
                        }
                        else
                        {
                            Console.WriteLine("Ogiltig fordonstyp. Ange 'car' eller 'motorcycle'.");
                        }
                    }

                    else if (find.Equals("c", StringComparison.OrdinalIgnoreCase))
                    {
                        //Check if a specific parking spot is occupied or not
                        Console.WriteLine("Enter the parking spot number to check (1-100): ");
                            int spotNumber;
                            if (int.TryParse(Console.ReadLine(), out spotNumber) && spotNumber >= 1 && spotNumber <= 100)
                            {
                                int index = spotNumber - 1;

                                // Check if the spot is occupied or not
                                if (parkingGarage[index] == 0)
                                {
                                    Console.WriteLine($"Parking spot {spotNumber} is available.");
                                }
                                else
                                {
                                    Console.WriteLine($"Parking spot {spotNumber} is occupied. Reg number(s): {registrationNumbers[index]}");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid parking spot number.");
                            }
                        
                    }
                    else if (find.Equals("d", StringComparison.OrdinalIgnoreCase))
                    {
                        // Display the current status of the parking garage
                        {
                            Console.WriteLine($"Remaining space: {totalSpace}");
                            for (int i = 0; i < parkingGarage.Length; i++)
                            {
                                if (parkingGarage[i] > 0)
                                {
                                    Console.WriteLine($"Spot {i + 1}: {parkingGarage[i]} occupied. Reg number(s): {registrationNumbers[i]}");
                                }
                            }
                        }
                    }
                    break;

                case "M4":
                case "m4":
                case "4":
                    //Move a vehicle based on parking spot number
                    {
                        Console.WriteLine("Enter the current spot number of the vehicle to move (1-100): ");
                        int fromSpotNumber;
                        if (int.TryParse(Console.ReadLine(), out fromSpotNumber) && fromSpotNumber >= 1 && fromSpotNumber <= 100)
                        {
                            int fromIndex = fromSpotNumber - 1;

                            // Check if there's a car or motorcycle in the current spot
                            if (parkingGarage[fromIndex] == 1) // Car
                            {
                                Console.WriteLine($"Car with reg number '{registrationNumbers[fromIndex]}' found at spot {fromSpotNumber}.");

                                // Ask for the new destination spot
                                Console.WriteLine("Enter the new spot number to move the car to (1-100): ");
                                int toSpotNumber;
                                if (int.TryParse(Console.ReadLine(), out toSpotNumber) && toSpotNumber >= 1 && toSpotNumber <= 100)
                                {
                                    int toIndex = toSpotNumber - 1;

                                    // Check if the destination spot is empty
                                    if (parkingGarage[toIndex] == 0)
                                    {
                                        // Move the car
                                        parkingGarage[toIndex] = 1;
                                        registrationNumbers[toIndex] = registrationNumbers[fromIndex];
                                        parkingGarage[fromIndex] = 0;
                                        registrationNumbers[fromIndex] = null;

                                        Console.WriteLine($"Car moved from spot {fromSpotNumber} to spot {toSpotNumber}.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("The destination spot is not empty. Try another spot.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Invalid destination spot number.");
                                }
                            }
                            else if (parkingGarage[fromIndex] == 0.5) // Motorcycle
                            {
                                Console.WriteLine($"Motorcycle with reg number '{registrationNumbers[fromIndex]}' found at spot {fromSpotNumber}.");

                                // Ask for the new destination spot
                                Console.WriteLine("Enter the new spot number to move the motorcycle to (1-100): ");
                                int toSpotNumber;
                                if (int.TryParse(Console.ReadLine(), out toSpotNumber) && toSpotNumber >= 1 && toSpotNumber <= 100)
                                {
                                    int toIndex = toSpotNumber - 1;

                                    // Check if the destination spot has space for a motorcycle (either empty or half-occupied by another motorcycle)
                                    if (parkingGarage[toIndex] == 0 || parkingGarage[toIndex] == 0.5)
                                    {
                                        // Move the motorcycle
                                        if (parkingGarage[toIndex] == 0) // Completely empty spot
                                        {
                                            parkingGarage[toIndex] = 0.5;
                                            registrationNumbers[toIndex] = registrationNumbers[fromIndex];
                                        }
                                        else if (parkingGarage[toIndex] == 0.5) // Half-occupied spot
                                        {
                                            parkingGarage[toIndex] = 1; // Two motorcycles now occupy the spot
                                            registrationNumbers[toIndex] += $", {registrationNumbers[fromIndex]}"; // Add to the same spot
                                        }

                                        parkingGarage[fromIndex] = 0; // Free the original spot
                                        registrationNumbers[fromIndex] = null;

                                        Console.WriteLine($"Motorcycle moved from spot {fromSpotNumber} to spot {toSpotNumber}.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("The destination spot is not suitable for a motorcycle. Try another spot.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Invalid destination spot number.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("No vehicle found in the specified spot.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid spot number.");
                        }
                    }
                    break;

                case "M5":
                case "m5":
                case "5":
                    return;

                default:
                    Console.WriteLine("Unknown command.");
                    break;
            }
        }
    }

    // Method to get a valid registration number (10 characters)
    static string GetValidRegistrationNumber()
    {
        while (true)
        {
            Console.WriteLine("Enter the registration number (must be 10 characters): ");
            string regNumber = Console.ReadLine();

            if (regNumber.Length == 10)
            {
                return regNumber; // Valid registration number
            }
            else
            {
                Console.WriteLine("Invalid registration number. It must be exactly 10 characters.");
            }
        }
    }

    // Find an empty spot for a car
    static int FindEmptySpot(double requiredSpace)
    {
        for (int i = 0; i < parkingGarage.Length; i++)
        {
            if (parkingGarage[i] == 0) // Spot is completely empty
            {
                return i;
            }
        }
        return -1; // No empty spot found
    }

    // Find a spot for a motorcycle
    static int FindSpotForMotorcycle()
    {
        for (int i = 0; i < parkingGarage.Length; i++)
        {
            if (parkingGarage[i] == 0) // Completely empty spot
            {
                return i;
            }
            else if (parkingGarage[i] == 0.5) // Half-occupied spot (by another motorcycle)
            {
                return i;
            }
        }
        return -1; // No spot found
    }

    // Method to count available spots for cars
    static int CountAvailableSpotsForCar()
    {
        int availableSpots = 0;
        for (int i = 0; i < parkingGarage.Length; i++)
        {
            if (parkingGarage[i] == 0) // Spot is completely empty
            {
                availableSpots++;
            }
        }
        return availableSpots;
    }

    // Method to count available spots for motorcycles
    static int CountAvailableSpotsForMotorcycle()
    {
        int availableSpots = 0;
        for (int i = 0; i < parkingGarage.Length; i++)
        {
            if (parkingGarage[i] == 0) // Completely empty spot
            {
                availableSpots += 2; // Two motorcycles can fit here
            }
            else if (parkingGarage[i] == 0.5) // Half-occupied spot (one motorcycle already)
            {
                availableSpots += 1; // One more motorcycle can fit here
            }
        }
        return availableSpots;
    }



}
