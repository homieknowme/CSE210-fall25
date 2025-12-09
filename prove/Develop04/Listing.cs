using System;

class ListingActivity : Activity
{
   

    private List<string> _prompts = new List<string>()
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };


    private List<string> _unusedPrompts;
    private List<string> _unusedQuestions;

    public ListingActivity(string name, string description) :base(name, description)
        {
            _unusedPrompts = new List<string>(_prompts);
        }
    

    private void ResetUnusedLists()
    {
        _unusedPrompts = new List<string>(_prompts);
    }
    private Random _rand = new Random();
    public void RunActivity()
    {
        StartMessage();

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(GetDuration());

        if (_unusedPrompts.Count == 0)
        {
            _unusedPrompts = new List<string>(_prompts);
        }

        
        int index = _rand.Next(_unusedPrompts.Count);

        string _prompt = _unusedPrompts[index];
        _unusedPrompts.RemoveAt(index);


        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine($"----{_prompt}---");
        Console.WriteLine("You may begin in: ");
        CountDown(5);

        int _count = 0;
        while (DateTime.Now < endTime)
        {
            Console.WriteLine(">");
            Console.ReadLine();
            _count += 1;
        
        }

        Console.WriteLine($"You listed {_count} items!");


        EndMessage();
    }


}