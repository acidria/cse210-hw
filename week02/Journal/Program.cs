using System;
using System.IO;

class Program
{
    // Beyond the core requirements, each entry has a mood rating and the menu can search entries.
    private static readonly Journal _journal = new Journal();
    private static readonly PromptGenerator _promptGenerator = new PromptGenerator();

    static void Main()
    {
        Console.WriteLine("Welcome to your Journal!");

        bool running = true;
        while (running)
        {
            DisplayMenu();
            string choice = Console.ReadLine();

            if (choice == null)
            {
                break;
            }

            switch (choice.Trim())
            {
                case "1":
                    WriteEntry();
                    break;
                case "2":
                    _journal.DisplayEntries();
                    break;
                case "3":
                    SaveJournal();
                    break;
                case "4":
                    LoadJournal();
                    break;
                case "5":
                    SearchJournal();
                    break;
                case "6":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Please choose an option from 1 to 6.");
                    break;
            }
        }

        Console.WriteLine("Keep noticing the little moments. Goodbye!");
    }

    private static void DisplayMenu()
    {
        Console.WriteLine();
        Console.WriteLine("Please select one of the following choices:");
        Console.WriteLine("1. Write a new entry");
        Console.WriteLine("2. Display the journal");
        Console.WriteLine("3. Save the journal");
        Console.WriteLine("4. Load the journal");
        Console.WriteLine("5. Search entries");
        Console.WriteLine("6. Quit");
        Console.Write("What would you like to do? ");
    }

    private static void WriteEntry()
    {
        string prompt = _promptGenerator.GetRandomPrompt();
        Console.WriteLine(prompt);
        Console.Write("> ");
        string response = Console.ReadLine();

        if (response == null)
        {
            Console.WriteLine("Entry cancelled.");
            return;
        }

        if (string.IsNullOrWhiteSpace(response))
        {
            Console.WriteLine("An entry needs a response, so nothing was saved.");
            return;
        }

        int moodRating = ReadMoodRating();
        if (moodRating == 0)
        {
            Console.WriteLine("Entry cancelled.");
            return;
        }

        Entry entry = new Entry(
            DateTime.Now.ToString("yyyy-MM-dd HH:mm"),
            prompt,
            response.Trim(),
            moodRating);

        _journal.AddEntry(entry);
        Console.WriteLine("Your entry has been added.");
    }

    private static int ReadMoodRating()
    {
        while (true)
        {
            Console.Write("How would you rate your day from 1 (hard) to 5 (great)? ");
            string input = Console.ReadLine();

            if (input == null)
            {
                return 0;
            }

            if (int.TryParse(input, out int rating) && rating >= 1 && rating <= 5)
            {
                return rating;
            }

            Console.WriteLine("Please enter a whole number from 1 to 5.");
        }
    }

    private static void SaveJournal()
    {
        string filename = ReadFilename("Enter a filename to save to: ");
        if (filename == null)
        {
            return;
        }

        try
        {
            _journal.SaveToFile(filename);
            Console.WriteLine("Journal saved.");
        }
        catch (IOException exception)
        {
            Console.WriteLine($"Could not save the journal: {exception.Message}");
        }
        catch (UnauthorizedAccessException exception)
        {
            Console.WriteLine($"Could not save the journal: {exception.Message}");
        }
        catch (ArgumentException exception)
        {
            Console.WriteLine($"Could not save the journal: {exception.Message}");
        }
    }

    private static void LoadJournal()
    {
        string filename = ReadFilename("Enter a filename to load from: ");
        if (filename == null)
        {
            return;
        }

        try
        {
            _journal.LoadFromFile(filename);
            Console.WriteLine("Journal loaded. Existing entries were replaced.");
        }
        catch (IOException exception)
        {
            Console.WriteLine($"Could not load the journal: {exception.Message}");
        }
        catch (UnauthorizedAccessException exception)
        {
            Console.WriteLine($"Could not load the journal: {exception.Message}");
        }
        catch (InvalidDataException exception)
        {
            Console.WriteLine($"The file contains invalid journal data: {exception.Message}");
        }
        catch (ArgumentException exception)
        {
            Console.WriteLine($"Could not load the journal: {exception.Message}");
        }
    }

    private static void SearchJournal()
    {
        Console.Write("Enter a word or phrase to search for: ");
        string keyword = Console.ReadLine();

        if (keyword == null)
        {
            Console.WriteLine("Search cancelled.");
            return;
        }

        if (string.IsNullOrWhiteSpace(keyword))
        {
            Console.WriteLine("Enter a non-empty search phrase.");
            return;
        }

        _journal.DisplayMatchingEntries(keyword.Trim());
    }

    private static string ReadFilename(string message)
    {
        Console.Write(message);
        string filename = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(filename))
        {
            Console.WriteLine("A filename is required.");
            return null;
        }

        return filename.Trim();
    }
}