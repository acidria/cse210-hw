using System;

class PromptGenerator
{
    private string[] _prompts;
    private Random _random;

    public PromptGenerator()
    {
        _random = new Random();
        _prompts = new string[]
        {
            "What small moment made you smile today?",
            "What is one thing you learned about yourself today?",
            "Who helped make your day better, and how?",
            "What challenge did you handle better than you expected?",
            "What is something you are grateful for right now?",
            "Which moment from today would you like to remember next year?",
            "What is one kind thing you did for yourself or someone else today?",
            "What would make tomorrow feel a little easier?"
        };
    }

    public string GetRandomPrompt()
    {
        int randomIndex = _random.Next(_prompts.Length);
        return _prompts[randomIndex];
    }
}
