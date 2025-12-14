using System;

public class Background
{
    
    private string _name;
    private List<string> _skills;
    private List<string> _proficiencies;
    private List<string> _languages;
    private Dictionary<string, string> _features;
    private int _bonusLanguages;

    public Background(string name)
    {
        _name = name;
        _skills = new List<string>();
        _proficiencies = new List<string>();
        _languages = new List<string>();
        _features = new Dictionary<string, string>();
    }


    public string GetName()
        {
            return _name;
        }

    public List<string> GetSkills()
    {
        return _skills;
    }

    public List<string> GetProficiency()
    {
        return _proficiencies;
    }

    public List<string> GetLanguages()
    {
        return _languages;
    }

    public Dictionary<string, string> GetFeatures()
    {
        return _features;
    }

    public void AddSkill(string skill)
    {
        _skills.Add(skill);
    }

    public void AddProficiency(string tool)
    {
        _proficiencies.Add(tool);
    }

    public void AddLanguage(string language)
    {
        _languages.Add(language);
    }

    public void AddFeature(string feature, string description)
    {
        _features.Add(feature, description);
    }

    public int GetBonusLanguages()
    {
        return _bonusLanguages;
    }

    public void SetBonusLanguages(int amount)
    {
        _bonusLanguages = amount;
    }

    public virtual void  ApplyBackgroundEquipment(Character character)
    {
        
    }



}