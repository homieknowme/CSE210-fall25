using System;
using System.ComponentModel;

class Program
{
    static void Main(string[] args)
    {

        DisplayWelcome();

        string username = PromptUserName();
      
        int userNumber = PromptUserNumber();

        int YearofBirth = PromptUserBirthYear();

        int squarenum = SquareNumber(userNumber);

        DisplayResult(username, squarenum, YearofBirth);

    }
    static void DisplayWelcome()
        {

            Console.WriteLine("Welcome to the program!");
        }

    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");

        string name = Console.ReadLine();

        return name;
    }
    static int PromptUserNumber()
    {
      Console.Write("Please enter your favorite number: ");

    string favorite = Console.ReadLine();
    int number = int.Parse(favorite);
    return number;

    }

    static int PromptUserBirthYear()
    {
      Console.Write("Please enter your birth year: ");

    string birthYear = Console.ReadLine();
    int number = int.Parse(birthYear);
    return number;

    }
    static int SquareNumber(int number)
    {
        int square = number * number;

        return square;
    }


    static void DisplayResult(string name, int square, int year)
    {

        Console.WriteLine($"{name}, the square of your number is {square}");

        Console.Write($"{name}, you will turn {2025 - year} this year.");
    }
}