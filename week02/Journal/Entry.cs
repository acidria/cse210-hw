class Entry
{
    public string Date { get; set; } = string.Empty;
    public string Prompt { get; set; } = string.Empty;
    public string Response { get; set; } = string.Empty;
    public int MoodRating { get; set; }

    public Entry()
    {
    }

    public Entry(string date, string prompt, string response, int moodRating)
    {
        Date = date;
        Prompt = prompt;
        Response = response;
        MoodRating = moodRating;
    }

    public void Display()
    {
        System.Console.WriteLine($"Date: {Date}");
        System.Console.WriteLine($"Prompt: {Prompt}");
        System.Console.WriteLine($"Response: {Response}");
        System.Console.WriteLine($"Mood: {MoodRating}/5");
        System.Console.WriteLine();
    }
}
