using System;

public abstract class Race
{
    
    private string _name;
    private int _speed;
    private string _size;
    private Dictionary<string, string> _traits;
    private List<string> _skills;
    private List<string> _proficiencies;
    private List<string> _languages;
    private int _bonusLanguages;

    public Race(string name)
    {
        _name = name;
        _speed = 30;
        _size = "medium";
        _traits = new Dictionary<string, string>();
        _languages = new List<string>();
        _bonusLanguages = 0;
        _skills = new List<string>();
        _proficiencies = new List<string>();
    }


    public string GetName()
        {
            return _name;
        }

    public void SetName(string name)
    {
        _name = name;
    }

    public int GetSpeed()
    {
        return _speed;
    }

    public void SetSpeed(int speed)
    {
        _speed = speed;
    }

     public List<string> GetSkill()
    {
        return _skills;
    }

    public void AddSkill(string skill)
    {
        _skills.Add(skill);
    }

    public List<string> GetProficiency()
    {
        return _proficiencies;
    }

    public void AddProficiency(string proficiency)
    {
        _proficiencies.Add(proficiency);
    }

    public void AddLanguage(string language)
    {
        _languages.Add(language);
    }

    public List<string> GetLanguages()
    {
        return _languages;
    }

    public int GetBonusLanguages()
    {
        return _bonusLanguages;
    }

    public void SetBonusLanguages(int amount)
    {
        _bonusLanguages = amount;
    }

    public void AddTrait(string name, string description)
    {
        if (!_traits.ContainsKey(name))
        {
            _traits.Add(name, description);
        }
    }

    public string GetTraitDescription(string name)
    {
        if (_traits.ContainsKey(name))
            {return _traits[name];}

        return "Trait not found";
    }

    public Dictionary<string, string> GetAllTraits()
    {
        return _traits;
    }

    
    public abstract void ApplyRacialTraits(AbilityScores abilities);

}