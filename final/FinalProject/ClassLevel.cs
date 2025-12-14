using System;

public class ClassLevel
{
    
    private CharacterClass _characterClass;
    private int _level;
    private string _archetype;
    private bool _archChosen;

    private Character _character;
    

    public ClassLevel(CharacterClass CharacterClass, Character character)
    {
        _character = character;
        _characterClass = CharacterClass;
        _level = 1;
    }

    public CharacterClass GetCharacterClass() {return _characterClass;}
    public int GetLevel() {return _level;}

    public void LevelUp(int amount = 1)
    {
        
        _characterClass.ApplyClassFeature(_level, _characterClass.GetArchetype(), _character);
        _level += amount;

        if (!_archChosen)
        {
            int requiredLevel = 1;

             if (_characterClass.GetName() == "Cleric" || _characterClass.GetName() == "Wizard")
            {
                requiredLevel = 1;
            }

            if (_characterClass.GetName() == "Bard" || _characterClass.GetName() == "Fighter")
            {
                requiredLevel = 3;
            }

            if (_level >= requiredLevel)
            {
                Console.WriteLine($"Choose your {_characterClass.GetName()} archetype");

                if (_characterClass.GetName() == "Cleric")
                {
                    Console.WriteLine("1. Knowledge Domain");
                    Console.WriteLine("2. Life Domain");
                    Console.WriteLine("3. Light Domain");
                    Console.WriteLine("4. Nature Domain");
                    Console.WriteLine("5. Tempest Domain");
                    Console.WriteLine("6. Trickery Domain");
                    Console.WriteLine("7. War Domain");
                    Console.Write("Pick your choice: ");
                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case"1":
                            SetArchetype("Knowledge Domain");
                            break;
                        case"2":
                            SetArchetype("Life Domain");
                            break;
                        case"3":
                            SetArchetype("Light Domain");
                            break;
                        case"4":
                            SetArchetype("Nature Domain");
                            break;
                        case"5":
                            SetArchetype("Tempest Domain");
                            break;
                        case"6":
                            SetArchetype("Trickery Domain");
                            break;
                        case"7":
                            SetArchetype("War Domain");
                            break;
                        default:
                            Console.WriteLine("That is not an available Archetype.");
                            break;
                            
                    }

                }

                if (_characterClass.GetName() == "Wizard")
                {
                    Console.WriteLine("1. School of Abjuration");
                    Console.WriteLine("2. School of Conjuration");
                    Console.WriteLine("3. School of Divination");
                    Console.WriteLine("4. School of Enchantment");
                    Console.WriteLine("5. School of Evocation");
                    Console.WriteLine("6. School of Illusion");
                    Console.WriteLine("7. School of Necromancy");
                    Console.WriteLine("8. School of Transmutation");
                    Console.Write("Pick your choice: ");
                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case"1":
                            SetArchetype("School of Abjuration");
                            break;
                        case"2":
                            SetArchetype("School of Conjuration");
                            break;
                        case"3":
                            SetArchetype("School of Divination");
                            break;
                        case"4":
                            SetArchetype("School of Enchantment");
                            break;
                        case"5":
                            SetArchetype("School of Evocation");
                            break;
                        case"6":
                            SetArchetype("School of Illusion");
                            break;
                        case"7":
                            SetArchetype("School of Necromancy");
                            break;
                        case"8":
                            SetArchetype("School of Transmutation");
                            break;
                        default:
                            Console.WriteLine("That is not an available Archetype.");
                            break;
                            
                    }
                }

                if (_characterClass.GetName() == "Bard")
                {
                    Console.WriteLine("1. College of Lore");
                    Console.WriteLine("2. College of Valor");
                    Console.Write("Pick your choice: ");
                    string choice = Console.ReadLine();

                    if (choice == "1")
                    {
                        SetArchetype("College of Lore");
                    }

                    if (choice == "2")
                    {
                        SetArchetype("College of Valor");
                    }

                }

                if (_characterClass.GetName() == "Fighter")
                {
                    Console.WriteLine("1. Champion");
                    Console.WriteLine("2. Battle Master");
                    Console.WriteLine("3. Eldritch Knight");
                    Console.Write("Pick your choice: ");
                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case"1":
                            SetArchetype("Champion");
                            break;
                        case"2":
                            SetArchetype("Battle Master");
                            break;
                        case"3":
                            SetArchetype("Eldritch Knight");
                            break;
                        default:
                            Console.WriteLine("That is not an available Archetype.");
                            break;
                            
                    }
                }
                

            }
        }
    }

    
    public int GetHitDie() {return _characterClass.GetHitDie();}

    public string GetArchetype() {return _archetype;}
    public bool HasArchetype() {return _archChosen;}
    public void SetArchetype(string archetype)
    {
        _archetype = archetype;
        _archChosen = true;
    }


}