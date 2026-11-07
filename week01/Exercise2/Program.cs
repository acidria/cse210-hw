using System;

class Program
{
    static void Main()
    {
        int grade;

        while (true)
        {
            Console.Write("Enter your grade percentage: ");
            string input = Console.ReadLine() ?? string.Empty;

            if (int.TryParse(input, out grade) && grade >= 0 && grade <= 100)
            {
                break;
            }

            Console.WriteLine("Please enter a whole-number percentage from 0 to 100.");
        }

        string letter;

        if (grade >= 90)
        {
            letter = "A";
        }
        else if (grade >= 80)
        {
            letter = "B";
        }
        else if (grade >= 70)
        {
            letter = "C";
        }
        else if (grade >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        string sign = "";

        if (letter == "A")
        {
            if (grade < 93)
            {
                sign = "-";
            }
        }
        else if (letter != "F")
        {
            int lastDigit = grade % 10;

            if (lastDigit >= 7)
            {
                sign = "+";
            }
            else if (lastDigit < 3)
            {
                sign = "-";
            }
        }

        Console.WriteLine($"Your grade is: {letter}{sign}");

        if (grade >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course.");
        }
        else
        {
            Console.WriteLine("Keep working hard, and you will do better next time.");
        }
    }
}
