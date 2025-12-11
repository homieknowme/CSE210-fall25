using System;

public class Spell
{
    
    private string _name;
    private string _description;
    private int _level;
    private string _school;
    private string _castingTime;
    private string _range;
    private string _duration;
    private List<string> _components;

    public Spell(string name, string description, int level)
    {
        _name = name;
        _description = description;
        _level = level;

        _components = new List<string>();
    }

    public string GetName()
    {
        return _name;
    }

    public string GetDescription()
    {
        return _description;
    }

    public int GetLevel()
    {
        return _level;
    }

    public string GetSchool()
    {
        return _school;
    }

    public string GetCastingTime()
    {
        return _castingTime;
    }

    public string GetRange()
    {
        return _range;
    }

    public string GetDuration()
    {
        return _duration;
    }

    public List<string> GetComponents()
    {
        return _components;
    }

    public void SetSchool(string school)
    {
         _school = school;
    }

    public void SetCastingTime(string castingTime)
    {
        _castingTime = castingTime;
    }

    public void SetRange(string range)
    {
        _range = range;
    }

    public void SetDuration(string duration)
    {
        _duration = duration;
    }

    public void AddComponent(string component)
    {
        _components.Add(component);
    }

    public void Cast()
    {
        
    }

}