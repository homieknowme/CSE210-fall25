using System;

class Program
{
    
    private static List<Entry> _entryList = new List<Entry>();
    private static Prompt _promptGenerator = new Prompt();
        static void Main(string[] args)
    {   
        Console.WriteLine("Welcome to the Journal Program!");

        while (true)
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Save");
            Console.WriteLine("4. Load");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Add();
                    break;
                case "2":
                    Display();
                    break;
                case "3":
                    Save();
                    break;
                case "4":
                    Load();
                    break;
                case "5":
                    Quit();
                    return;
                default:
                    Console.WriteLine("Not an option. Try again.");
                    break;
            }
        }
    }
     public static void Add()
    {
        string prompt = _promptGenerator.Random();
        Console.WriteLine($"{prompt}");
        Console.Write("> ");
        string response = Console.ReadLine();

        Entry newEntry = new Entry(prompt, response);
        _entryList.Add(newEntry);
    }

    public static void Display()
    {
        if (_entryList.Count == 0)
        {
            Console.WriteLine("\nNo journal entries found.");
            return;
        }

        
        foreach (Entry entry in _entryList)
        {
            entry.Display();
        }
    }

    public static void Save()
    {
        Console.Write("Enter filename to save journal (e.g., journal.csv): ");
        string filename = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (Entry entry in _entryList)
            {
                writer.WriteLine($"{entry.GenerateDate()};{entry._prompt};{entry._entry}");
            }
        }

        Console.WriteLine("Successfully saved Journal");
    }

    public static void Load()
    {
        Console.Write("Enter filename to load journal (e.g., journal.csv): ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("Failed to find file.");
            return;
        }

        _entryList.Clear();
        string[] lines = File.ReadAllLines(filename);
        foreach (string line in lines)
        {
            string[] parts = line.Split(';');
            if (parts.Length == 3)
            {
                Entry newEntry = new Entry(parts[1], parts[2]);
                _entryList.Add(newEntry);
            }
        }

        Console.WriteLine("Journal loaded successfully.");
    }

    public static void Quit()
    {
        Console.WriteLine("Exiting program. Have a nice day!");
    }
}