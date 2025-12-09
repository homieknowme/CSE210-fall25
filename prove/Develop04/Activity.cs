using System;

class Activity
{
    
private string _name;
private string _description;
private int _duration;

public Activity(string name, string description)
    {
        _name = name;
        _description = description;
        _duration = 30;
    }

    public void StartMessage()
    {
        Console.Clear();
        Console.WriteLine($"\nWelcome to the {_name}.");
        Console.WriteLine($"\nThis activity {_description}.");
        Console.WriteLine($"How long, in seconds, would you like for your session to be?");
        _duration = int.Parse(Console.ReadLine());
        Console.Clear();
        Console.WriteLine("Get Ready...");
        LoadingAnimation(4);
    }

    public void EndMessage()
    {
        Console.WriteLine("\nWell Done!");
        LoadingAnimation(2);
        Console.WriteLine($"You have completed {_duration} seconds of the {_name}.");
        LoadingAnimation(4);
    }

    public void LoadingAnimation(int seconds)
    {
        List<string> animationStrings = new List<string>();
        animationStrings.Add("|");
        animationStrings.Add("/");
        animationStrings.Add("-");
        animationStrings.Add("\\");
        animationStrings.Add("|");
        animationStrings.Add("/");
        animationStrings.Add("-");
        animationStrings.Add("\\");


        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(seconds);

        int i = 0;

        while (DateTime.Now < endTime)
        {
            string s = animationStrings[i];
            Console.Write(s);
            Thread.Sleep(250);
            Console.Write("\b \b");

            i++;

            if (i >= animationStrings.Count)
            {
                i = 0;
            }
        }
    }

    public void CountDown(int seconds)
    {
        for (int i = seconds; i> 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }



    public string GetName()
    {
        return _name;
    }

    public string GetDescription()
    {
        return _description;
    }

    public int GetDuration()
    {
        return _duration;
    }

}