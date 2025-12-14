using System;
using System.Xml.Serialization;

public class Character
{
    
    private string _name;
    private int _level;
    private int _exp;
    private int _hp;
    private int _maxHp;
    private int _ac;
    private int _initiative;
    private List<string> _proficiencies;
    private string _notes;

    private Race _race;
    private List<ClassLevel> _classes;

    private CharacterClass _class;
    private Background _background;
    private AbilityScores _abilities;
    private List<Item> _inventory;
    private List<Spell> _spells;
    private Item _equippedArmor;
    private int _equippedAC;
    private bool _armorDex;
    private List<string> _classFeatures;



    public Character(string name, Race race, Background background, AbilityScores abilities)
    {
        _name = name;
        _race = race;
        _background = background;
        _abilities = abilities;
        _classes = new List<ClassLevel>();
        _class = null;
        _inventory = new List<Item>();
        _spells = new List<Spell>();
        _proficiencies = new List<string>();
        _classFeatures = new List<string>();

        int dexMod = _abilities.GetModifier("dex");

        _level = 1;
        _exp = 0;
        if (_classes.Count > 0)
       { int firstHitDIe = _classes[0].GetHitDie();
        int conMod = _abilities.GetModifier("con");
        _maxHp = firstHitDIe + conMod;}

        else
            _maxHp = 6 + _abilities.GetModifier("con");

        _hp = _maxHp;
        _ac = 10;
        _initiative = dexMod;
        _notes = "";
    }

    public string GetName()
    {
        return _name;
    }

    public Race GetRace()
    {
        return _race;
    }

    public int GetLevel()
    {
        return _level;
    }

    public int GetExp()
    {
        return _exp;
    }

    public Background GetBackground()
    {
        return _background;
    }
    
    public AbilityScores GetAbilities()
    {
        return _abilities;
    }

    public int GetHp()
    {
        return _hp;
    }

    public int GetMaxHp()
    {
        return _maxHp;
    }

    public void CalculateMaxHp()
    {
        int totalHp = 0;

        for (int i = 0; i < _classes.Count; i++)
        {
            ClassLevel cl = _classes[i];
            int hitDie = cl.GetHitDie();
            int level = cl.GetLevel();

            for (int l = 0; l < level; l++)
            {
                if (l == 0)
                {
                    totalHp += hitDie;
                }
                else
                {
                    totalHp += (hitDie / 2) + 1;
                }

                totalHp += _abilities.GetModifier("con");
            }
        }

        _maxHp = totalHp;

        if (_hp > _maxHp) _hp = _maxHp;

    }

    public int GetAc()
    {
        return _ac;
    }

    public List<Item> GetInventory()
    {
        return _inventory;
    }

    

    public void EquipArmor(Item armor, int ac, bool allowsDex)
    {
        _equippedArmor = armor;
        _equippedAC = ac;
        _armorDex = allowsDex;
    }

    public Item GetEquippedArmor()
    {
        return _equippedArmor;
    }

    public int CalculateAC()
    {
        int dexMod = _abilities.GetModifier("dex");

        if (_equippedArmor != null)
        {
            if (_armorDex == true )
            return _equippedAC + dexMod;
            else
            {
                return _equippedAC;
            }
        }

        return 10 + dexMod;
    }

    public List<string> GetProficiency()
    {
        return _proficiencies;
    }

    public void AddExp(int amount)
    {
        int oldLevel = _level;
        
        _exp += amount;

        if (CheckLevelUp())
        {
            int levelsGained = _level - oldLevel;
            HandleLevelUp(levelsGained);
        }
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

    public void AddProficiency(string proficiency)
    {
        if(!_proficiencies.Contains(proficiency))
            _proficiencies.Add(proficiency);
    }

    public void AddClassLevel(ClassLevel cl)
    {
        if (cl == null) return;
        _classes.Add(cl);

        _level = CalculateTotalLevel();
    }

    public int GetClassCount()
    {
        return _classes.Count;
    }

    public ClassLevel GetClassLevel(int index)
    {
        if (index < 0 || index >= _classes.Count) return null;
        return _classes[index];
    }

    public CharacterClass GetClass()
    {
        return _class;
    }

    public void AddProficiency(IEnumerable<string> profs)
    {
        if (profs == null) return;
        foreach (string p in profs)
        {
            AddProficiency(p);
        }
    }

    

    public void AddClassFeature(string name, string description)
    {
        _classFeatures.Add($"{name}: {description}");
    }

    public List<string> GetClassFeatures()
    {
        return _classFeatures;
    }

    public int CalculateTotalLevel()
    {
        int total = 0;
        foreach (var cl in _classes)
        {
            total += cl.GetLevel();
        }
        return total;
    }

    public void AddSpell(Spell spell)
    {
        if (spell == null) return;
        _spells.Add(spell);
    }

    public List<Spell> GetSpell()
    {
        return _spells;
    }

    public  void ShowSpells()
    {

        Console.WriteLine("\n=== Spells ===");

        if(_spells == null || _spells.Count == 0)
        {
            Console.WriteLine("No Spells Known");
            Console.WriteLine("Spells will be added in the next Update.");
            return;
        }

        foreach (Spell spell in _spells)
        {
            Console.WriteLine($"{spell.GetName()} (Level {spell.GetLevel()})");
            Console.WriteLine($" {spell.GetDescription()}");
        }

    }

    static int[] experienceTable = new int[]
    {
        0,
        300,
        900,
        2700,
        6500,
        14000
    };

    public bool CheckLevelUp()
    {
        int newLevel = _level;

        while(newLevel < 20 && _exp >= experienceTable[newLevel])
        {
            newLevel++;
            
        }

        if (newLevel > _level)
        {
            _level = newLevel;
            return true;
        }

        return false;
    }

    private void HandleLevelUp(int levelsGained)
    {
        for (int i = 0; i < levelsGained; i++)
        {
            Console.WriteLine("Choose a class to level up:");

            for (int c = 0; c< _classes.Count; c++)
            {
                Console.WriteLine($"{c + 1}. {_classes[c].GetCharacterClass().GetName()} (Level {_classes[c].GetLevel()})");
            }

            Console.Write("Multiclass feature coming Soon!");
            int choice = int.Parse(Console.ReadLine()) - 1;
            
            if (choice >= 0 && choice < _classes.Count)
            {
                _classes[choice].LevelUp();
            }
        }

        CalculateMaxHp();
        _hp = GetMaxHp();
    }

    public void ShowCharacterSheet()
    {
        Console.WriteLine("===Character Sheet===");
        Console.WriteLine($"Name: {_name}");

        if (_race != null)
        {
            Console.WriteLine($"Race: {_race.GetName()}");
        }

        if (_classes.Count == 1)
        {
            Console.WriteLine($"Class: {_classes[0].GetCharacterClass().GetName()} Level {_classes[0].GetLevel()}");
        }
        else
        {
            Console.WriteLine("Classes:");
            for (int i = 0; i < _classes.Count; i++)
            {
                Console.WriteLine($"{_classes[i].GetCharacterClass().GetName()} Level {_classes[i].GetLevel()}");

                if (_classes[i].HasArchetype())
                {
                    Console.Write($" ({_classes[i].GetArchetype()})");
                }
            }
            Console.WriteLine($"Player Level: {GetLevel()}");
        }

        Console.WriteLine($"EXP: {_exp}");

        if (_background != null)
        {
            Console.WriteLine($"BackGround: {_background.GetName()}");
        }

        int dexMod = _abilities.GetModifier("dex");

        Console.WriteLine($"Max HP: {_maxHp}");
        Console.WriteLine($"Current HP: {_hp}");
        Console.WriteLine($"AC: {CalculateAC()}");
        Console.WriteLine($"Initiative: {_initiative}");

        

        
    }


}