using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        while (true)
        {
            Console.Write("Enter number: ");
            string input = Console.ReadLine();

            if (input == null)
            {
                return;
            }

            if (!int.TryParse(input, out int number))
            {
                Console.WriteLine("Please enter a whole number.");
                continue;
            }

            if (number == 0)
            {
                break;
            }

            numbers.Add(number);
        }

        if (numbers.Count == 0)
        {
            Console.WriteLine("No numbers were entered.");
            return;
        }

        int sum = 0;
        int largest = numbers[0];
        int smallestPositive = 0;
        bool hasPositiveNumber = false;

        foreach (int number in numbers)
        {
            sum += number;

            if (number > largest)
            {
                largest = number;
            }

            if (number > 0 && (!hasPositiveNumber || number < smallestPositive))
            {
                smallestPositive = number;
                hasPositiveNumber = true;
            }
        }

        double average = (double)sum / numbers.Count;

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {largest}");

        if (hasPositiveNumber)
        {
            Console.WriteLine($"The smallest positive number is: {smallestPositive}");
        }
        else
        {
            Console.WriteLine("There are no positive numbers in the list.");
        }

        numbers.Sort();
        Console.WriteLine("The sorted list is:");

        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }
    }
}
