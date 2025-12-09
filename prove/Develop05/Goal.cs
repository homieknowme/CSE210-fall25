using System;

class Goal
{
    private string _name;
    private string _description;
    private int _points;

    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    }

    public string GetName() => _name;

    public string GetDescription() => _description;
    public int GetPoints() => _points;

    public virtual bool IsComplete() => false;
    
    public virtual int RecordEvent() => 0;

    public virtual string GetStatus() => "[ ]";

    public virtual string GetSaveString()
    {
        return $"{_name}|{_description}|{_points}";
    }

}