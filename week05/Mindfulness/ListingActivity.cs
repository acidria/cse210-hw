using System;
using System.Collections.Generic;

class ListingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _availablePrompts;
    private List<string> _items;

    public ListingActivity()
        : base("Listing Activity",
            "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt peace this month?",
            "Who are some of your personal heroes?"
        };
        _availablePrompts = new List<string>(_prompts);
        _items = new List<string>();
    }

    protected override void DoActivity()
    {
        string prompt = GetNextPrompt(_prompts, _availablePrompts);
        Console.WriteLine();
        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine("--- " + prompt + " ---");
        Console.WriteLine();
        Console.WriteLine("You may begin in:");
        PauseWithCountdown(5);

        _items.Clear();
        DateTime endTime = DateTime.Now.AddSeconds(DurationSeconds);
        Console.WriteLine("Start listing items. Press Enter after each item.");
        Console.Write("> ");

        while (DateTime.Now < endTime)
        {
            string item = Console.ReadLine();
            if (item == null)
            {
                break;
            }

            if (item != "")
            {
                _items.Add(item);
            }
        }

        Console.WriteLine();
        if (_items.Count == 1)
        {
            Console.WriteLine("You listed 1 item.");
        }
        else
        {
            Console.WriteLine("You listed " + _items.Count + " items.");
        }
    }
}
