/*
Student Name: Xavier Nazario
COP2360 - Assignment 9
Collaboration Statement: I used myself.
I used my notes when creating this program.
*/

using System;
using System.Collections.Generic;
using System.IO;

namespace PhoneBookTwo;

class Program
{
    // Define ContactType enum
    // Personal, Business, and Other types
    public enum ContactType
    {
        Personal,
        Business,
        Other
    }

    // Define PhoneBookEntry struct
    //  Use public and string
    //  Contains Name, PhoneNumber, ContactType
    public struct PhoneBookEntry
    {
        public string Name;
        public string PhoneNumber;
        public ContactType Type;

        // Declare PhoneBookEntry initializer
        public PhoneBookEntry(string name, string phoneNumber, ContactType type)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            Type = type;
        }

        // Display Output
        //  Format accordingly
        //  Use ToString() and public
        public override string ToString()
        {
            return $"Name: {Name}, Phone: {PhoneNumber}, Type: {Type}";
        }
    }

    // PhoneBookEntry list
    static List<PhoneBookEntry> phoneBook = new List<PhoneBookEntry>();

    // filePath phonebook.txt
    static string filePath = "phonebook.txt";

    // Main method
    static void Main()
    {
        // Load Phonebook
        // Declare choice and use int
        // do loop
        LoadPhoneBook();
        int choice;
        do
        {
            // Display Menu
            //  Format accordingly
            Console.WriteLine("\nPhone Book Application");
            Console.WriteLine("1. Add Contact");
            Console.WriteLine("2. View All Contacts");
            Console.WriteLine("3. Search Contact");
            Console.WriteLine("4. Delete Contact");
            Console.WriteLine("5. Save and Exit");
            Console.WriteLine("-1. Exit without Saving");

            // Prompt user choice
            // Use if statement for choice
            //  switch to handle all cases
            //  REMEMBER break keyword and TryParse()
            Console.Write("Enter your choice: ");
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        AddContact();
                        break;
                    case 2:
                        ViewContacts();
                        break;
                    case 3:
                        SearchContact();
                        break;
                    case 4:
                        DeleteContact();
                        break;
                    case 5:
                        SavePhoneBook();
                        break;
                    case -1:
                        Console.WriteLine("Exiting without saving.");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            // loop ends
        } while (choice != -1);
    }

    // LoadPhoneBook method
    static void LoadPhoneBook()
    {
        // Check for file
        // Use if-else statement
        // StreamReader and StreamWriter
        // I believe I coded this method correctly. Just have that single exception.
        if (File.Exists(filePath))
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                // Read each line
                //  Use while statement
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    // Split line according to name, number, and contacttype
                    // May need ContactType to be separate, could be wrong
                    var parts = line.Split(',');
                    if (parts.Length == 3)
                    {
                        string name = parts[0];
                        string phoneNumber = parts[1];

                        // Nest if statement for ContactType enum
                        if (Enum.TryParse(parts[2], out ContactType type))
                        {
                            phoneBook.Add(new PhoneBookEntry(name, phoneNumber, type));
                        }
                    }
                }
            }
            Console.WriteLine("Phonebook loaded.");
        }
        else
        {
            Console.WriteLine("No phonebook found.");
        }
    }

    // SavePhoneBook method
    static void SavePhoneBook()
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            // Write entry
            //  Format Accordingly
            foreach (var entry in phoneBook)
            {
                writer.WriteLine($"{entry.Name},{entry.PhoneNumber},{entry.Type}");
            }
        }
        Console.WriteLine("Phonebook saved.");
    }

    // AddContact method
    static void AddContact()
    {
        // Prompt user for contact name, number, and type
        //  Use switch for ContactType cases
        //    Use int and Parse
        Console.Write("Enter name: ");
        string name = Console.ReadLine();
        Console.Write("Enter phone number: ");
        string phoneNumber = Console.ReadLine();

        Console.WriteLine("Select contact type: 1. Personal  2. Business  3. Other");
        // Declare typeChoice
        int typeChoice = int.Parse(Console.ReadLine());
        ContactType type = ContactType.Other;

        // Remember break keyword
        switch (typeChoice)
        {
            case 1:
                type = ContactType.Personal;
                break;
            case 2:
                type = ContactType.Business;
                break;
            case 3:
                type = ContactType.Other;
                break;
            default:
                // Display output
                Console.WriteLine("Invalid choice, assigning to 'Other'.");
                break;
        }

        // Add new contact
        phoneBook.Add(new PhoneBookEntry(name, phoneNumber, type));
        Console.WriteLine("Contact added.");
    }

    // ViewContacts method
    static void ViewContacts()
    {
        // Display menu and contacts
        Console.WriteLine("\nPhone Book Entries:");
        Console.WriteLine("===================");
        foreach (var entry in phoneBook)
        {
            Console.WriteLine(entry);
        }
    }

    // SearchContact method
    static void SearchContact()
    {
        // Prompt for search
        // Declare searchName
        Console.Write("Enter the name to search: ");
        string searchName = Console.ReadLine();

        // Return any entries
        var foundEntries = phoneBook.FindAll(e => e.Name.Equals(searchName, StringComparison.OrdinalIgnoreCase));

        // Display results
        //  Use if-else statement
        if (foundEntries.Count > 0)
        {
            Console.WriteLine("Contact(s) found:");
            foreach (var entry in foundEntries)
            {
                Console.WriteLine(entry);
            }
        }
        else
        {
            Console.WriteLine("No contact(s) found.");
        }
    }

    // DeleteContact method
    static void DeleteContact()
    {
        // Prompt user for name
        // Declare deleteName
        Console.Write("Enter the name to delete: ");
        string deleteName = Console.ReadLine();

        // Delete any entry with name
        phoneBook.RemoveAll(e => e.Name.Equals(deleteName, StringComparison.OrdinalIgnoreCase));
        Console.WriteLine("Contact(s) deleted.");
    }
}