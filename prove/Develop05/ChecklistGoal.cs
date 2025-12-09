using System;
using System.Reflection;

class ChecklistGoal : Goal
{

    private int _targetCount;
    private int _currentCount;
    private int _bonusPoints;


     public ChecklistGoal(string name, string description, int points, int targetCount, int bonusPoints) : base(name, description, points)
    {
        _targetCount = targetCount;
        _bonusPoints = bonusPoints;
        _currentCount = 0;
    }

     public ChecklistGoal(string name, string description, int points, int targetCount, int currentCount, int bonusPoints) : base(name, description, points)
    {
        _targetCount = targetCount;
        _bonusPoints = bonusPoints;
        _currentCount = currentCount;
    }

    public override bool IsComplete() => _currentCount >= _targetCount;

    public override int RecordEvent()
    {
        if (!IsComplete())
        {
            _currentCount ++;
            int totalPoints = GetPoints();
            if (_currentCount == _targetCount)
            {
                totalPoints += _bonusPoints;
            }
            return totalPoints;
        }

        return 0;
    }

    public override string GetStatus() => $"[{_currentCount}/{_targetCount}]";

    public override string GetSaveString()
    {
        return $"ChecklistGoal|{GetName()}|{GetDescription()}|{GetPoints()}|{_targetCount}|{_currentCount}|{_bonusPoints}";
    }

}