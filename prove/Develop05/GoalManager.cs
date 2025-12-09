using System;

class GoalManager
{
    
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public void DisplayScore()
    {
        Console.WriteLine($"Your current score: {_score}");
    }

    public void ListGoals()
    {
        Console.WriteLine("Goals");
        for (int i = 0; i < _goals.Count; i++)
        {
            Goal goal = _goals[i];
            Console.WriteLine($"{i + 1}. {goal.GetStatus()} {goal.GetName()} - {goal.GetDescription()}");
        }
    }

    public void RecordEvent(int index)
    {
        if (index >= 0 && index < _goals.Count)
        {
            Goal goal = _goals[index];
            int pointsEarned = goal.RecordEvent();
            _score += pointsEarned;
            Console.WriteLine($"You earned {pointsEarned} points!");
        }
        else
        {
            Console.WriteLine("Invalid goal index.");
        }
    }

    public void CreateGoal()
        {
            
            Console.WriteLine("Selcet Type of Goal:");
            Console.WriteLine("1. Simple Goal");
            Console.WriteLine("2. Eternal Goal");
            Console.WriteLine("3. Checklist Goal");

            string choice = Console.ReadLine();

            Console.WriteLine("Enter goal name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Enter goal description: ");
            string description = Console.ReadLine();

            Console.WriteLine("Enter points for this goal: ");
            int points = int.Parse(Console.ReadLine());

            Goal goal = null;

            switch (choice)
        {
            case "1":
                goal = new SimpleGoal(name, description, points);
                break;
            case "2":
                goal = new EternalGoal(name, description, points);
                break;
            case "3":
                Console.WriteLine("Enter target amount: ");
                int targetCount = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter bonus points: ");
                int bonusPoints = int.Parse(Console.ReadLine());
                goal = new ChecklistGoal(name, description, points, targetCount, bonusPoints);
                break;
            default:
                Console.WriteLine("InvalidChoice");
                break;
        }

        if (goal != null)
        {
            AddGoal(goal);
            Console.WriteLine("Goal was created.");
        }

        }

    public void ValidRecord()
    {
        Console.WriteLine("Enter the goal number to record: ");
        String input = Console.ReadLine();

        if (int.TryParse(input, out int choice))
        {
            RecordEvent(choice - 1);
        }
        else
        {
            Console.WriteLine("Invalid input. Please Look at your goals and enter a valid number.");
            return;
        }
    }

    public void SaveGoals()
    {
        Console.WriteLine("Enter a filename to save goals: ");
        string filename = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(_score);
            
            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.GetSaveString());
            }
        }

        Console.WriteLine($"Goals successfully saved to {filename}");

    }

    public void LoadGoals()
    {
        Console.WriteLine("Enter filename to load your goals: ");
        string filename = Console.ReadLine();

        using (StreamReader reader = new StreamReader(filename))
        {
            string firstLine = reader.ReadLine();
            _score = int.Parse(firstLine);

            _goals.Clear();

            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split('|');
                string type = parts[0];

                Goal goal = null;

                switch(type)
                {
                    case "SimpleGoal":
                        goal = new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]), bool.Parse(parts[4]));
                        _goals.Add(goal);
                        break;
                    case "EternalGoal":
                        goal = new EternalGoal(parts[1], parts[2], int.Parse(parts[3]));
                        _goals.Add(goal);
                        break;
                    case "ChecklistGoal":
                        goal = new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]),
                        int.Parse(parts[4]), int.Parse(parts[5]), int.Parse(parts[6]));
                        _goals.Add(goal);
                        break;
                }
            } 
            Console.WriteLine($"Goals successfully loaded from {filename}");
        }
    }



    public void Menu()
    {
        
        while (true)
        {
            Console.WriteLine("\nMain Menu:");
            Console.WriteLine("1. Add Goal");
            Console.WriteLine("2. Display Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Display Score");
            Console.WriteLine("5. Save Goals");
            Console.WriteLine("6. Load Goals");
            Console.WriteLine("7. Exit");
            Console.WriteLine("Choose and option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoals();
                    break;
                case "3":
                    ValidRecord();
                    break;
                case "4":
                    DisplayScore();
                    break;
                case "5":
                    SaveGoals();
                    break;
                case "6":
                    LoadGoals();
                    break;
                case "7":
                    return;
                default:
                    Console.WriteLine("Invalid Choice! Try Again.");
                    break;
            }
        }

    }

   

}