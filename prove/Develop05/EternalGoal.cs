using System;

class EternalGoal : Goal
{

    public EternalGoal(string name, string description, int points) : base(name, description, points)
    {
        
    }

    public override bool IsComplete() => false;

    public override int RecordEvent() => GetPoints();

    public override string GetStatus() => "[ ]";

    public override string GetSaveString()
    {
        return $"EternalGoal|{GetName()}|{GetDescription()}|{GetPoints()}";
    }

}