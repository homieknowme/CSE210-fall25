using System;

class Program
{
    static void Main(string[] args)
    {
        var breathing = new BreathingActivity(
                        "Breathing Activity",
                        "will help you relax by walking you through breathing in and out slowly.\n Clear your mind and focus on your breathing"
                    );

        var reflecting = new ReflectionActivity(
                        "Reflection Activity",
                        "will help you reflect on times in your life when you have shown strength and resilience.\n This will help you recognize the power you have and how you can use it in other aspects of your life"
                    );

         var listing = new ListingActivity(
                        "Listing Activity",
                        "will help you reflect on the good things in your life by having you list as many things as you can in a certain area"
                    );


        bool exit = false;
        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Breathing Avtivity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Avtivity");
            Console.WriteLine("4. Quit");
            Console.WriteLine("Choose an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    breathing.RunActivity();
                    break;
                case "2":
                    reflecting.RunActivity();
                    break;         
                case "3":
                    listing.RunActivity();
                    break;
                case "4":
                    exit = true;
                    Console.WriteLine("Goodbye!");
                    Thread.Sleep(1000);
                    break;
                default:
                    Console.WriteLine("Invalid, Try Agiain!");
                    Thread.Sleep(1000);
                    break;

            
            }

        }
    }
}