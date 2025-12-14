using System;

public abstract class CharacterClass
{
    
    private string _name;
    private int _hitDie;
    private List<string> _skills;
    private List<string> _savingThrows;
    private List<string> _proficiencies;
    private Dictionary<string, string> _classFeatures;
    private string _archetype;


    public CharacterClass(string name, int hitDie)
    {
        _name = name;
        _hitDie = hitDie;
        _skills = new List<string>();
        _savingThrows = new List<string>();
        _proficiencies = new List<string>();
        _classFeatures = new Dictionary<string, string>();
        _archetype = "";
        
    }

    public string GetName() {return _name;}
    public int GetHitDie() {return _hitDie;}
    public Dictionary<string, string> GetAllClassFeatures() {return _classFeatures;}

    public void AddSkill(string skill) { _skills.Add(skill);}

    public string GetClassFeatureDescription(string name)
    {
        if (_classFeatures.ContainsKey(name))
            return _classFeatures[name];
        
        return "Feature not found";
    }
    public void AddClassFeature(string name, string description) {
        if (!_classFeatures.ContainsKey(name))
            _classFeatures.Add(name, description);
    }

    public List<string> GetProficiency()
    {
        return _proficiencies;
    }

    public void AddProficiency(string proficiency)
    {
        _proficiencies.Add(proficiency);
    }

    public List<string> GetSkills()
    {
        return _skills;
    }

    public string GetArchetype()
    {
        return _archetype;
    }

    public void SetArchetype(string archetype)
    {
        _archetype = archetype;
    }

    public virtual void  ApplyClassEquipment(Character character)
    {
        
    }

    public abstract void ApplyClassFeature(int level, string archetype, Character character);


}