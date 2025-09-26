using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        List<int> numbers = new List<int>();

        Console.Write("Enter number: ");

        string input = Console.ReadLine();
        int inpnum = int.Parse(input);

        while (inpnum != 0)
        {
            numbers.Add(inpnum);
            
            Console.Write("Enter number: ");

            input = Console.ReadLine();
            inpnum = int.Parse(input);

        }

        int sum = numbers.Sum();
        
        Console.WriteLine($"The sum is: {sum}");

        float average = ((float)sum) / numbers.Count;

        Console.WriteLine($"The average is: {average}");

        int max = numbers.Max();

        Console.WriteLine($"The largest number is: {max}");

    }
}