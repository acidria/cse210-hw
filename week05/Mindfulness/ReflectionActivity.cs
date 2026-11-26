using System;
using System.Collections.Generic;

class ReflectionActivity : Activity
{
    private List<string> _prompts;
    private List<string> _availablePrompts;
    private List<string> _questions;
    private List<string> _availableQuestions;

    public ReflectionActivity()
        : base("Reflection Activity",
            "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
        _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };
        _availablePrompts = new List<string>(_prompts);

        _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };
        _availableQuestions = new List<string>(_questions);
    }

    protected override void DoActivity()
    {
        string prompt = GetNextPrompt(_prompts, _availablePrompts);
        Console.WriteLine();
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine("--- " + prompt + " ---");
        Console.WriteLine("When you have something in mind, press Enter to continue.");
        Console.ReadLine();

        DateTime endTime = DateTime.Now.AddSeconds(DurationSeconds);
        Console.WriteLine();
        Console.WriteLine("Reflect on each question as it appears.");

        while (DateTime.Now < endTime)
        {
            string question = GetNextPrompt(_questions, _availableQuestions);
            Console.WriteLine();
            Console.WriteLine(question);

            if (DateTime.Now < endTime)
            {
                ShowSpinner(5);
            }
        }
    }
}
