using System;

class ReflectionActivity : Activity
{
   

    private List<string> _prompts = new List<string>()
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new List<string>()
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    private List<string> _unusedPrompts;
    private List<string> _unusedQuestions;

    public ReflectionActivity(string name, string description) :base(name, description)
        {
            _unusedPrompts = new List<string>(_prompts);
            _unusedQuestions = new List<string>(_questions);
        }
    

    private void ResetUnusedLists()
    {
        _unusedPrompts = new List<string>(_prompts);
        _unusedQuestions = new List<string>(_questions);
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
        Console.WriteLine("When you have something in mind, press Enter to continue");
        Console.ReadLine();

        Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");
        Console.WriteLine("You may begin in: ");
        CountDown(5);
        Console.Clear();


        while (DateTime.Now < endTime)
        {
            if (_unusedQuestions.Count == 0)
            {
                _unusedQuestions = new List<string>(_questions);
            }
            
            index = _rand.Next(_unusedQuestions.Count);
            string _question = _unusedQuestions[index];
            _unusedQuestions.RemoveAt(index);

            Console.WriteLine($"{_question}");
            LoadingAnimation(9);

        }

        EndMessage();
    }


}