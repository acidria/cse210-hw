using System;

class Program
{
    static void Main(string[] args)
    {
        // Creative feature: activity prompts and reflection questions do not repeat until all have been used.
        BreathingActivity breathing = new BreathingActivity();
        ReflectionActivity reflection = new ReflectionActivity();
        ListingActivity listing = new ListingActivity();

        string choice = "";

        while (choice != "4")
        {
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine();
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");
            Console.Write("Choose an activity: ");
            choice = Console.ReadLine();

            if (choice == null)
            {
                break;
            }
            else if (choice == "1")
            {
                breathing.Run();
            }
            else if (choice == "2")
            {
                reflection.Run();
            }
            else if (choice == "3")
            {
                listing.Run();
            }
            else if (choice != "4")
            {
                Console.WriteLine("Please enter 1, 2, 3, or 4.");
                Thread.Sleep(1500);
            }
        }

        Console.WriteLine("Thank you for taking time to be mindful.");
    }
}
