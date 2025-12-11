using System;

public class Background
{
    
    private string _name;
    private List<string> _skillProficiencies;
    private List<string> _toolProficiencies;
    private List<string> _languages;
    private List<string> _features;
    private int _bonusLanguages;

    public Background(string name)
    {
        _name = name;
        _skillProficiencies = new List<string>();
        _toolProficiencies = new List<string>();
        _languages = new List<string>();
        _features = new List<string>();
    }


    public string GetName()
        {
            return _name;
        }

    public List<string> GetSkills()
    {
        return _skillProficiencies;
    }

    public List<string> GetTools()
    {
        return _toolProficiencies;
    }

    public List<string> GetLanguages()
    {
        return _languages;
    }

    public List<string> GetFeatures()
    {
        return _features;
    }

    public void AddSkill(string skill)
    {
        _skillProficiencies.Add(skill);
    }

    public void AddTool(string tool)
    {
        _toolProficiencies.Add(tool);
    }

    public void AddLanguage(string language)
    {
        _languages.Add(language);
    }

    public void AddFeature(string feature)
    {
        _features.Add(feature);
    }

    public int GetBonusLanguages()
    {
        return _bonusLanguages;
    }

    public void SetBonusLanguages(int amount)
    {
        _bonusLanguages = amount;
    }

    public virtual void ApplyBackgroundFeatures()
    {
        
    }


}