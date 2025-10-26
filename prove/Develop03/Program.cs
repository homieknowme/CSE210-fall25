using System;


//I programed it so that it can access the library of different scriptures
// that I put together, and pick a random scripture from that list to memorize.


class Program
{
    static void Main(string[] args)
    {
         ScriptureLibrary scriptureLibrary = new ScriptureLibrary();
        scriptureLibrary.LoadScripturesFromFile("scriptures.csv");

        
        (Reference reference, string randomScriptureText) = scriptureLibrary.GetRandomScripture();

        
        Scripture scripture = new Scripture(reference, randomScriptureText);

        bool scriptureCompletelyHidden = false;

        
        while (!scriptureCompletelyHidden)
        {
           
            Console.Clear();

            
            Console.WriteLine(reference.Display());
            Console.WriteLine(scripture.Display());

            
            Console.WriteLine("\nPress Enter to hide words, or type 'quit' to exit.");

           
            string userInput = Console.ReadLine();

            if (userInput.ToLower() == "quit")
            {
                break; 
            }
            int visibleWordsCount = scripture.CountVisibleWords();

           
            if (visibleWordsCount == 3)
            {
                scripture.HideMultipleWords(3); 
            }
           
            else if (visibleWordsCount >= 2)
            {
                scripture.HideMultipleWords(2); 
            }
            scriptureCompletelyHidden = scripture.IsCompletelyHidden(); 
        }

    
        Console.Clear();
        Console.WriteLine("All words are hidden! The program will now end.");
    }
}