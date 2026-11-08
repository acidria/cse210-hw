using System;
using System.Collections.Generic;
using System.IO;

class Journal
{
    private const string Separator = "~|~";
    private List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void DisplayEntries()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("Your journal is empty.");
            return;
        }

        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public int DisplayMatchingEntries(string keyword)
    {
        int matchCount = 0;

        foreach (Entry entry in _entries)
        {
            if (entry.Prompt.Contains(keyword) || entry.Response.Contains(keyword))
            {
                entry.Display();
                matchCount++;
            }
        }

        if (matchCount == 0)
        {
            Console.WriteLine("No entries matched that search.");
        }

        return matchCount;
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
                string line = entry.Date + Separator
                    + entry.Prompt + Separator
                    + entry.Response + Separator
                    + entry.MoodRating;
                outputFile.WriteLine(line);
            }
        }
    }

    public void LoadFromFile(string filename)
    {
        string[] lines = File.ReadAllLines(filename);
        List<Entry> loadedEntries = new List<Entry>();

        foreach (string line in lines)
        {
            string[] parts = line.Split(new string[] { Separator }, StringSplitOptions.None);
            int moodRating;

            if (parts.Length != 4
                || string.IsNullOrWhiteSpace(parts[0])
                || string.IsNullOrWhiteSpace(parts[1])
                || string.IsNullOrWhiteSpace(parts[2])
                || !int.TryParse(parts[3], out moodRating)
                || moodRating < 1
                || moodRating > 5)
            {
                throw new InvalidDataException("The file contains an invalid journal entry.");
            }

            loadedEntries.Add(new Entry(parts[0], parts[1], parts[2], moodRating));
        }

        _entries = loadedEntries;
    }
}
