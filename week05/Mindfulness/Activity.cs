using System;
using System.Collections.Generic;
using System.Threading;

abstract class Activity
{
    private string _name;
    private string _description;
    private int _durationSeconds;
    private static Random _random = new Random();

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
        _durationSeconds = 0;
    }

    protected int DurationSeconds
    {
        get { return _durationSeconds; }
    }

    public void Run()
    {
        DisplayStartingMessage();
        DoActivity();
        DisplayEndingMessage();
    }

    protected abstract void DoActivity();

    private void DisplayStartingMessage()
    {
        Console.WriteLine();
        Console.WriteLine(_name);
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();

        while (_durationSeconds < 1)
        {
            Console.Write("How long, in seconds, would you like for your session? ");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out _durationSeconds) || _durationSeconds < 1)
            {
                _durationSeconds = 0;
                Console.WriteLine("Please enter a whole number greater than zero.");
            }
        }

        Console.WriteLine();
        Console.WriteLine("Get ready...");
        ShowSpinner(3);
    }

    private void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Good job!");
        ShowSpinner(2);
        Console.WriteLine("You have completed the " + _name + " for " + _durationSeconds + " seconds.");
        ShowSpinner(3);
    }

    protected void PauseWithCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i + " ");
            Thread.Sleep(1000);
        }

        Console.WriteLine();
    }

    protected void ShowSpinner(int seconds)
    {
        string[] spinner = { "|", "/", "-", "\\" };

        for (int i = 0; i < seconds * 4; i++)
        {
            Console.Write(spinner[i % spinner.Length]);
            Thread.Sleep(250);
            Console.Write("\b \b");
        }

        Console.WriteLine();
    }

    protected int GetPauseLength(DateTime endTime, int maximumSeconds)
    {
        int remainingSeconds = (int)Math.Ceiling((endTime - DateTime.Now).TotalSeconds);
        return Math.Min(maximumSeconds, remainingSeconds);
    }

    protected string GetNextPrompt(List<string> allPrompts, List<string> availablePrompts)
    {
        if (availablePrompts.Count == 0)
        {
            availablePrompts.AddRange(allPrompts);
        }

        int index = _random.Next(availablePrompts.Count);
        string prompt = availablePrompts[index];
        availablePrompts.RemoveAt(index);
        return prompt;
    }
}
