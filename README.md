# Assignment 9 – Advanced Phone Book Application (C#)

A C# console application that builds upon earlier phone book assignments by implementing structured data types, enumeration, and file persistence.  
This project demonstrates **structs**, **enums**, **lists**, **file I/O**, and **menu-driven program control**.

---

## Description
The Advanced Phone Book application enables users to manage contact information stored locally in a text file (`phonebook.txt`).  
Each contact includes a name, phone number, and contact type (Personal, Business, or Other).  
The program loads existing contacts at startup and allows users to add, search, view, and delete entries interactively.  
It also supports saving changes to the text file before exiting.

---

## Features
- **Persistent Storage:** Automatically loads and saves contacts to `phonebook.txt`.  
- **Structured Records:** Uses a `struct` named `PhoneBookEntry` to store contact information.  
- **Enumerations:** Defines a `ContactType` enum for clear contact categorization.  
- **Comprehensive Menu:**  
  - Add a new contact  
  - View all contacts  
  - Search for contacts by name  
  - Delete specific contacts  
  - Save and exit  
  - Exit without saving  
- **Case-Insensitive Search and Delete:** Ensures flexible name matching.  
- **Stream-Based File Handling:** Implements safe file reading/writing with `StreamReader` and `StreamWriter`.

---

## Core Logic
1. **LoadPhoneBook():**  
   - Checks for the existence of `phonebook.txt`.  
   - Reads each line and splits the data into `Name`, `PhoneNumber`, and `ContactType`.  
   - Parses and stores valid entries in a `List<PhoneBookEntry>`.  

2. **SavePhoneBook():**  
   - Iterates through all stored contacts and writes them to `phonebook.txt`.  
   - Uses comma-delimited formatting for readability and reusability.  

3. **AddContact():**  
   - Prompts for a name, phone number, and contact type selection.  
   - Creates a new `PhoneBookEntry` and appends it to the list.  

4. **ViewContacts():**  
   - Displays all contacts in formatted output using `ToString()`.  

5. **SearchContact():**  
   - Accepts a search term and finds all matches, ignoring case sensitivity.  
   - Prints any found results or a message if none exist.  

6. **DeleteContact():**  
   - Removes all entries matching the specified name, case-insensitively.  

7. **Main Menu Loop:**  
   - Displays available actions.  
   - Uses `TryParse()` to safely handle numeric menu input.  
   - Executes the chosen function through a `switch` statement.  

---

## Data Structures
### `enum ContactType`
```csharp
public enum ContactType
{
    Personal,
    Business,
    Other
}
