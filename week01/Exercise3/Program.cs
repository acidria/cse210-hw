using System;

class Program
{
    static void Main()
    {
        Random randomGenerator = new Random();
        string playAgain = "yes";

        while (playAgain == "yes")
        {
            int magicNumber = randomGenerator.Next(1, 101);
            int guessCount = 0;
            int guess = 0;

            Console.WriteLine("I have a magic number between 1 and 100.");

            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                string input = Console.ReadLine();

                if (input == null)
                {
                    return;
                }

                if (!int.TryParse(input, out guess))
                {
                    Console.WriteLine("Please enter a whole number.");
                    continue;
                }

                guessCount++;

                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine($"You guessed it! It took you {guessCount} guesses.");
                }
            }

            Console.Write("Would you like to play again? ");
            playAgain = (Console.ReadLine() ?? string.Empty).Trim().ToLowerInvariant();
        }
    }
}
