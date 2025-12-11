using System;

public class Character
{
    
    private string _name;
    private int _level;
    private int _exp;
    private int _hp;
    private int _maxHp;
    private int _ac;
    private int _initiative;
    private string _notes;

    private Race _race;
    private List<ClassLevel> _classes;
    private Background _background;
    private AbilityScores _abilities;
    private List<Item> _inventory;
    private List<Spell> _spells;

    public Character(string name, Race race, Background background, AbilityScores abilities)
    {
        _name = name;
        _race = race;
        _background = background;
        _abilities = abilities;
        _classes = new List<ClassLevel>();
        _inventory = new List<Item>();
        _spells = new List<Spell>();

        _level = 1;
        _exp = 0;
        _hp = 10;
        _maxHp = 10;
        _ac = 10;
        _initiative = 0;
        _notes = "";
    }

    public string GetName()
    {
        return _name;
    }

    public int GetLevel()
    {
        return _level;
    }

    public int GetExp()
    {
        return _exp;
    }

    public int GetHp()
    {
        return _hp;
    }

    public int GetMaxHp()
    {
        return _maxHp;
    }

    public int GetAc()
    {
        return _ac;
    }

    public void AddExp(int amount)
    {
        _exp += amount;
    }

    public void TakeDamage(int amount)
    {
        _hp -= amount;
        if (_hp < 0)
        {
            _hp = 0;
        }
    }

    public void Heal(int amount)
    {
        _hp += amount;
        if (_hp > _maxHp)
        {
            _hp = _maxHp;
        }
    }

    public void AddItem(Item item)
    {
        _inventory.Add(item);
    }

    public void RemoveItem(Item item)
    {
        _inventory.Remove(item);
    }

    public void ShowCharacterSheet()
    {
        Console.WriteLine("===Character Sheet===");
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine($"Level: {_level}");
        Console.WriteLine($"EXP: {_exp}");
        Console.WriteLine($"HP: {_hp}");
        Console.WriteLine($"AC: {_ac}");
        Console.WriteLine($"Initiative: {_initiative}");

        if (_race != null)
        {
            Console.WriteLine($"Race: {_race.GetName()}");
        }

        if (_background != null)
        {
            Console.WriteLine($"BackGround: {_background.GetName()}");
        }
    }


}