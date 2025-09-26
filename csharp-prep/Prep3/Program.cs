using System;

class Program
{
    static void Main(string[] args)
    {

        Console.Write("Can you guess the Magic Number?");

        string response = "yes";

        while (response == "yes")
        {
           
            Random randomGenerator = new Random();
            int mgcnum = randomGenerator.Next(1, 101);

            Console.Write("What is your guess? ");

            string guess = Console.ReadLine();
            int guessnum = int.Parse(guess);

            int guesses = 1;

            do
            { 
                if (guessnum < mgcnum)
                {
                    Console.WriteLine("Higher");
                }
                else if (guessnum > mgcnum)
                {
                    Console.WriteLine("Lower");
                }

                Console.Write("What is your guess? ");

                guess = Console.ReadLine();
                guessnum = int.Parse(guess);

                guesses ++;

            } while (guessnum != mgcnum);

            
            Console.Write($"You guessed it in {guesses} guess(es)!");
            
            Console.Write("Do you want to continue? ");
            response = Console.ReadLine();
        }

    }
}