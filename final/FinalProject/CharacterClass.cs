using System;

public abstract class CharacterClass
{
    
    private string _name;
    private int _hitDie;
    private List<string> _skillProficiencies;
    private List<string> _savingThrows;
    private List<string> _armorProficiencies;
    private List<string> _weaponProficiencies;
    private Dictionary<string, string> _classFeatures;


    public CharacterClass(string name, int hitDie)
    {
        _name = name;
        _hitDie = hitDie;
        _skillProficiencies = new List<string>();
        _savingThrows = new List<string>();
        _armorProficiencies = new List<string>();
        _weaponProficiencies = new List<string>();
        _classFeatures = new Dictionary<string, string>();
        
    }

    public string GetName() {return _name;}
    public int GetHitDie() {return _hitDie;}
    public Dictionary<string, string> GetAllClassFeatures() {return _classFeatures;}

    public void AddSkill(string skill) { _skillProficiencies.Add(skill);}

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



    public abstract void ApplyClassFeature(int level);

}