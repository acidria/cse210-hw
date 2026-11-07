using System;

class Program
{
    static void Main()
    {
        DisplayWelcome();

        string name = PromptUserName();
        int number = PromptUserNumber();
        int squaredNumber = SquareNumber(number);

        DisplayResult(name, squaredNumber);
    }

    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the program!");
    }

    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        return (Console.ReadLine() ?? string.Empty).Trim();
    }

    static int PromptUserNumber()
    {
        while (true)
        {
            Console.Write("Please enter your favorite number: ");
            string input = Console.ReadLine();

            if (input == null)
            {
                return 0;
            }

            if (int.TryParse(input, out int number))
            {
                return number;
            }

            Console.WriteLine("Please enter a whole number.");
        }
    }

    static int SquareNumber(int number)
    {
        return number * number;
    }

    static void DisplayResult(string name, int squaredNumber)
    {
        Console.WriteLine($"{name}, the square of your number is {squaredNumber}");
    }
}
