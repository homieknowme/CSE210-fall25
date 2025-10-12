public class Prompt
{

        private List<string> _promptList = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "How did I serve someone today?",
        "What did I learn today?",
        "Was there anyone new that I met today, if so who?",
        "How did my day differ from my plans for the day?"
    };

    private int _randomPrompt;

    public string Random()
    {
        Random rnd = new Random();
        _randomPrompt = rnd.Next(_promptList.Count);
        return _promptList[_randomPrompt];
    }

    public void Display()
    {
        foreach (string prompt in _promptList)
        {
            Console.WriteLine(prompt);
        }
    }
    
}