using System;

class KeyStorage
{
    static string[] keys = new string[100]; // Array to store up to 100 slots
    static double totalSpace = 100; // Total space where normal = 1 and digital = 0.5
    static bool[] digitalKeySecondSlot = new bool[100]; // Tracks if a second digital key is using half of a slot
    static int keyCounter = 0; // Counter to assign unique key numbers

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Enter a command (add, collect, status, exit): ");
            string command = Console.ReadLine();

            switch (command)
            {
                case "add":
                    AddKey();
                    break;

                case "collect":
                    CollectKey();
                    break;

                case "status":
                    DisplayStatus();
                    break;

                case "exit":
                    return;

                default:
                    Console.WriteLine("Unknown command.");
                    break;
            }
        }
    }

    // Add a key to the storage
    static void AddKey()
    {
        Console.WriteLine("Enter key type (normal/digital): ");
        string keyType = Console.ReadLine();

        if (keyType == "normal")
        {
            if (totalSpace >= 1)
            {
                int index = FindEmptySlotForNormalKey();
                if (index != -1)
                {
                    keyCounter++; // Increment key counter
                    string keyID = $"N-{keyCounter}"; // Generate key ID
                    keys[index] = keyID;
                    totalSpace -= 1;
                    Console.WriteLine($"Normal key '{keyID}' added at position {index + 1}.");
                }
                else
                {
                    Console.WriteLine("No available space for a normal key.");
                }
            }
            else
            {
                Console.WriteLine("Not enough space for a normal key.");
            }
        }
        else if (keyType == "digital")
        {
            if (totalSpace >= 0.5)
            {
                int index = FindSlotForDigitalKey();
                if (index != -1)
                {
                    keyCounter++; // Increment key counter
                    string keyID = $"D-{keyCounter}"; // Generate key ID

                    if (keys[index] == null)
                    {
                        keys[index] = keyID;
                        totalSpace -= 0.5;
                        Console.WriteLine($"Digital key '{keyID}' added at position {index + 1}.");
                    }
                    else if (digitalKeySecondSlot[index] == false) // Add second digital key in the same slot
                    {
                        keys[index] += $", {keyID}"; // Store both digital keys in the same slot
                        digitalKeySecondSlot[index] = true;
                        totalSpace -= 0.5;
                        Console.WriteLine($"Second digital key '{keyID}' added at position {index + 1}.");
                    }
                }
                else
                {
                    Console.WriteLine("No available space for a digital key.");
                }
            }
            else
            {
                Console.WriteLine("Not enough space for a digital key.");
            }
        }
        else
        {
            Console.WriteLine("Invalid key type.");
        }
    }

    // Method to find an empty slot for a normal key
    static int FindEmptySlotForNormalKey()
    {
        for (int i = 0; i < keys.Length; i++)
        {
            if (keys[i] == null) // Slot is empty
            {
                return i;
            }
        }
        return -1; // No empty slot found
    }

    // Method to find a slot for a digital key (either empty or shareable)
    static int FindSlotForDigitalKey()
    {
        for (int i = 0; i < keys.Length; i++)
        {
            if (keys[i] == null) // Completely empty slot
            {
                return i;
            }
            else if (keys[i] != null && digitalKeySecondSlot[i] == false) // Slot with space for another digital key
            {
                return i;
            }
        }
        return -1; // No slot found
    }

    // Method to collect a key
    static void CollectKey()
    {
        Console.WriteLine("Enter key ID to collect: ");
        string keyID = Console.ReadLine();

        for (int i = 0; i < keys.Length; i++)
        {
            if (keys[i] != null && keys[i].Contains(keyID))
            {
                if (keys[i].Contains(",") && keys[i].Contains(keyID)) // It's a digital key pair
                {
                    string[] digitalKeys = keys[i].Split(", ");
                    if (digitalKeys[0] == keyID) // Remove the first digital key
                    {
                        keys[i] = digitalKeys[1]; // Keep the second digital key
                    }
                    else
                    {
                        keys[i] = digitalKeys[0]; // Keep the first digital key
                    }
                    digitalKeySecondSlot[i] = false; // Mark as no second digital key
                    totalSpace += 0.5;
                    Console.WriteLine("Digital key collected.");
                }
                else if (keys[i] == keyID) // Normal key or single digital key
                {
                    keys[i] = null;
                    if (digitalKeySecondSlot[i]) // If there was a second digital key in the slot
                    {
                        totalSpace += 0.5; // Add back 0.5 space if only one digital key was removed
                    }
                    else
                    {
                        totalSpace += 1; // Add back 1 space for normal keys or last digital key
                    }
                    digitalKeySecondSlot[i] = false;
                    Console.WriteLine("Key collected.");
                }
                return;
            }
        }
        Console.WriteLine("Key ID not found.");
    }

    // Display the current status of the key storage
    static void DisplayStatus()
    {
        Console.WriteLine($"Available space: {totalSpace} (100 max)");
        Console.WriteLine("Stored keys:");
        for (int i = 0; i < keys.Length; i++)
        {
            if (keys[i] != null)
            {
                Console.WriteLine($"Position {i + 1}: {keys[i]} {(digitalKeySecondSlot[i] ? "(2 digital keys)" : "")}");
            }
        }
    }
}
