using System;
using System.Runtime.ConstrainedExecution;

class Program
{
    static void Main(string[] args)
    {

        Console.Write("What is your grade? ");
        
        string grade = Console.ReadLine();
        int percent = int.Parse(grade);

        string letter = "";

        if (percent >= 90)
        {
            letter = "A";
        }
        else if (percent >= 80)
        {
            letter = "B";
        }
        else if (percent >= 70)
        {
            letter = "C";
        }
        else if (percent >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }


        string result = "";

        if (percent >= 70)
        {
            result = "Congratulations! You passed the course!";
        }
        else
        {
            result = "Oh bummer. You failed the course. Try again next time, and don't be afraid to ask for help!";
        }

        Console.Write($"Your grade is {letter}. {result}");
    }
}