using System;
using System.ComponentModel.DataAnnotations;

class Program
{
    static Character currentCharacter = null;
    
    static void Main(string[] args)
    {

        bool running = true;

        while (running)
        {
            string choice = MainMenu();
            switch (choice)
            {
                case "1":
                    currentCharacter = CreateCharacter();
                    break;
                case "2":
                    if (currentCharacter != null)
                        DisplayMenu(currentCharacter);
                    else
                        Console.WriteLine("No character found. Please create or load a character from an existing file.");
                    break;
                case "3":
                    if (currentCharacter != null)
                    {   
                        EditCharacter(currentCharacter);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("You do not yet have a character to update.");
                        break;
                    }
                    
                case "4":
                    currentCharacter = LoadCharacter();
                    break;
                case "5":
                    if (currentCharacter != null)
                    {
                        Console.WriteLine("You currently have a character. Are you sure you want to Exit?(Y or N): ");
                        string quit = Console.ReadLine();
                        
                        if (quit.ToLower() == "y")
                        {
                            running = false;
                        }
                        break;
                    }
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;

            }
        }

    }

    private static string MainMenu()
    {
        Console.WriteLine("\n=== Welcome to the D&D Character Tracker ===");
        Console.WriteLine("1. Create New Character");
        Console.WriteLine("2. Display Current Character");
        Console.WriteLine("3. Update Character");
        Console.WriteLine("4. Load Existing Character");
        Console.WriteLine("5. Exit");
        Console.Write("Enter choice: ");
        return Console.ReadLine();
    }

    private static Character CreateCharacter()
    {  
        Console.WriteLine("\n=== Character Creator ===");

        string name = AskForName();
        AbilityScores abilities = CreateAbilityScores();
        Race race = ChooseRace();
        
        Background background = ChooseBackground();
        CharacterClass charClass = ChooseClass();
        
        
        race.ApplyRacialTraits(abilities);
        Character newChar = new Character(name, race, background, abilities);
        ClassLevel newClassLevel = new ClassLevel(charClass, newChar);

        newChar.AddClassLevel(newClassLevel);
        newChar.GetClassLevel(0).GetCharacterClass().ApplyClassEquipment(newChar);
        newChar.GetClassLevel(0).GetCharacterClass().ApplyClassFeature(1,"" ,newChar);
        newChar.GetBackground().ApplyBackgroundEquipment(newChar);
        
        newChar.CalculateMaxHp();
        newChar.Heal(4);
        Console.WriteLine($"Max HP: {newChar.GetMaxHp()}");

        
        
        if (race is Dwarf)
        {
            DwarvenTool(newChar);
        }
        return newChar;
    }

    private static string AskForName()
    {
        Console.Write("Enter your character's name: ");
        string name = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(name))
        {
            Console.Write("The name can not be left empty. Please enter a valid name: ");
            name = Console.ReadLine();
        }

        return name;

    }

    private static Race ChooseRace()
    {
        Console.WriteLine("\nChoose a race for your character:");
        Console.WriteLine("1. Human");
        Console.WriteLine("2. Elf");
        Console.WriteLine("3. Dwarf");
        Console.WriteLine("4. Half Orc");

        while (true)
        {
            Console.Write("Enter choice (1-4): ");
            string input = Console.ReadLine();
            switch (input)
            {
                case"1" : return new Human();
                case"2" : return new Elf();
                case"3" : return new Dwarf();
                case"4" : return new HalfOrc();
                default: Console.WriteLine("Invalid choice. Try again."); break;
            }
        }
    }

    private static void DwarvenTool(Character character)
    {
        Console.WriteLine("As a Dwarf, Choose one tool to be proficient in:");
        Console.WriteLine("1. Smith's Tools");
        Console.WriteLine("2. Brewer's Tools");
        Console.WriteLine("3. Mason's Tools");

        while (true)
        {
            Console.Write("Enter Choice: ");
            string input = Console.ReadLine();
            switch (input)
            {
                case"1" : character.AddProficiency("Smith's Tools"); return;
                case"2" : character.AddProficiency("Brewer's Tools"); return;
                case"3" : character.AddProficiency("Mason's Tools"); return;
                default: Console.WriteLine("Invalid Choice. Try Again."); break;
            }
        }

    }

    private static Background ChooseBackground()
    {
        Console.WriteLine("\nChoose a background for your character:");
        Console.WriteLine("1. Acolyte");
        Console.WriteLine("2. Entertainer");
        Console.WriteLine("3. Hermit");
        Console.WriteLine("4. Noble");
        Console.WriteLine("5. Sage");


        while (true)
        {
            Console.Write("Enter choice (1-5): ");
            string input = Console.ReadLine();
            switch (input)
            {
                case"1" : return new Acolyte();
                case"2" : return new Entertainer();
                case"3" : return new Hermit();
                case"4" : return new Noble();
                case"5" : return new Sage();
                default: Console.WriteLine("Invalid choice. Try again."); break;
            }
        }
    }


    public static CharacterClass ChooseClass()
    {

        Console.WriteLine("\nChoose your character class:");
        Console.WriteLine("1. Bard");
        Console.WriteLine("2. Cleric");
        Console.WriteLine("3. Fighter");
        Console.WriteLine("4. Wizard");

        while (true)
        {
            Console.Write("Enter choice (1-4)");
            string input = Console.ReadLine();

            switch (input)
            {
                case"1": return new Bard();
                case"2": return new Cleric();
                case"3": return new Fighter();
                case"4": return new Wizard();
                default: Console.WriteLine("Invalid choice. Please try again"); break;
            }
        }
        
    }

    private static AbilityScores CreateAbilityScores()
    {
        AbilityScores abilities = new AbilityScores();

        Console.WriteLine("Enter your ability scores.");
        Console.WriteLine("If you are not going to use the standard ability scores,");
        Console.WriteLine("you may roll 4 six sided dice(4d6) a total of 6 times. ");
        Console.WriteLine("Each time you roll the 4d6, you will add the 3 highest numbers.");
        Console.WriteLine("Once you have your 6 numbers, you can assign them to whichever");
        Console.WriteLine("Ability Score you prefer. Otherwise your 6 numbers will be:");
        Console.WriteLine("15, 14, 13, 12, 10, 8\n");
        
        abilities.IncreaseStr(AskForStat("Strength"));
        abilities.IncreaseDex(AskForStat("Dexterity"));
        abilities.IncreaseCon(AskForStat("Constitution"));
        abilities.IncreaseInt(AskForStat("Intelligence"));
        abilities.IncreaseWis(AskForStat("Wisdom"));
        abilities.IncreaseCha(AskForStat("Charisma"));

        return abilities;
    }

    private static int AskForStat(string statName)
    {
        while (true)
        {
            Console.Write($"Enter {statName}: ");
            if (int.TryParse(Console.ReadLine(), out int value))
            {
                if (value >= 3 && value <= 18) return value;
            }

            Console.WriteLine("Invalid input. Enter a Valid number.");
        }
    }


    private static void EditCharacter(Character character)
    {
        
        bool exit = false;

        while (!exit)
        {

            Console.WriteLine("\n=== Update Character Info ===");
            Console.WriteLine("1. Take Damage");
            Console.WriteLine("2. Heal");
            Console.WriteLine("3. Gain Experience");
            Console.WriteLine("4. Back to Main Menu");
            Console.WriteLine("Enter Choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case"1": 
                    Console.Write("Enter damage taken: ");
                    if (int.TryParse(Console.ReadLine(), out int dmg))
                    {
                        character.TakeDamage(dmg);
                        Console.WriteLine($"Current HP: {character.GetHp()}");
                    }
                    break;

                case"2": 
                    Console.Write("Enter amount healed: ");
                    if (int.TryParse(Console.ReadLine(), out int heal))
                    {
                        character.Heal(heal);
                        Console.WriteLine($"Current HP: {character.GetHp()}");
                    }
                    break;

                case"3":
                    Console.Write("Enter experience gained: ");
                    if (int.TryParse(Console.ReadLine(), out int exp))
                    {
                        character.AddExp(exp);
                        Console.WriteLine($"Total Exp: {character.GetExp()}");
                    }
                    break;

                case"4": exit = true; break;

                default: Console.WriteLine("Invalid Choice"); break;
            }
        }

    }



    private static void DisplayMenu(Character character)
    {
        
        bool viewing = true;
        while (viewing)
        {
            character.ShowCharacterSheet();
             character.GetClassLevel(0).GetCharacterClass().ApplyClassFeature(1,"" ,character);
            


            Console.WriteLine("\n=== Character Menu ===");
            Console.WriteLine("1. Show Abilities");
            Console.WriteLine("2. Show Skills");
            Console.WriteLine("3. Show Proficiencies");
            Console.WriteLine("4. Show Inventory");
            Console.WriteLine("5. Show Spells");
            Console.WriteLine("6. Show Traits/Features");
            Console.WriteLine("7. Back to Main Menu");
            Console.WriteLine("Enter Choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case"1": ShowAbilities(character); break;

                case"2": ShowSkills(character); break;

                case"3": ShowProficiencies(character); break;

                case"4": ShowInventory(character); break;

                case"5": character.ShowSpells(); break;

                case"6": ShowTraits(character); break;

                case"7": viewing = false; break;

                default: Console.WriteLine("Invalid Choice"); break;
            }
            
        }

    }

    private static void ShowAbilities(Character character)
    {
        AbilityScores abilities = character.GetAbilities();
        
        Console.WriteLine("\n=== Ability Scores ===");
        Console.WriteLine($"STR: {abilities.GetStr()} Modifier: {abilities.GetModifier("str")}");
        Console.WriteLine($"DEX: {abilities.GetDex()} Modifier: {abilities.GetModifier("dex")}");
        Console.WriteLine($"CON: {abilities.GetCon()} Modifier: {abilities.GetModifier("con")}");
        Console.WriteLine($"INT: {abilities.GetInt()} Modifier: {abilities.GetModifier("int")}");
        Console.WriteLine($"WIS: {abilities.GetWis()} Modifier: {abilities.GetModifier("wis")}");
        Console.WriteLine($"CHA: {abilities.GetCha()} Modifier: {abilities.GetModifier("cha")}");

    }

    private static void ShowSkills(Character character)
    {
        
        Console.WriteLine("\n=== Skills ===");
        List<string> allSkills = new List<string>();

        for(int i = 0; i < character.GetClassCount(); i++)
        {
            List<string> classSkills = character.GetClassLevel(i).GetCharacterClass().GetSkills();
            foreach(string skill in classSkills)
            {
                if (!allSkills.Contains(skill))
                    allSkills.Add(skill);
            }

        }

        List<string> bgSkills = character.GetBackground().GetSkills();
        if (bgSkills != null && bgSkills.Count > 0)
        {
            foreach(string skill in bgSkills)
            {
                if (!allSkills.Contains(skill))
                    allSkills.Add(skill);
            }
        }

        List<string> raceSKills = character.GetRace().GetSkill();
        if (raceSKills != null && raceSKills.Count > 0)
        { 
            foreach(string skill in raceSKills)
            {
                if (!allSkills.Contains(skill))
                    allSkills.Add(skill);
            }
        }

        if (allSkills.Count == 0)
        {
            Console.WriteLine("No skill proficiency");
            return;
        }

        for(int i = 0; i < allSkills.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {allSkills[i]}");
        }

    }

    private static void ShowProficiencies(Character character)
    {




        Console.WriteLine("\n=== Proficiencies ===");

        List<string> allProfs = new List<string>();

        for(int i = 0; i < character.GetClassCount(); i++)
        {
            List<string> classProfs = character.GetClassLevel(i).GetCharacterClass().GetProficiency();
            foreach(string prof in classProfs)
            {
                if (!allProfs.Contains(prof))
                    allProfs.Add(prof);
            }

        }

        List<string> bgProfs = character.GetBackground().GetProficiency();
        if (bgProfs != null && bgProfs.Count > 0)
        {
            foreach(string prof in bgProfs)
            {
                if (!allProfs.Contains(prof))
                    allProfs.Add(prof);
            }
        }

        List<string> raceProfs = character.GetRace().GetProficiency();
        if (raceProfs != null && raceProfs.Count > 0)
        { 
            foreach(string prof in raceProfs)
            {
                if (!allProfs.Contains(prof))
                    allProfs.Add(prof);
            }
        }

        if (allProfs.Count == 0)
        {
            Console.WriteLine("No skill proficiency");
            return;
        }

        for(int i = 0; i < allProfs.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {allProfs[i]}");
        }
        
    }

    private static void ShowInventory(Character character)
    {
        
        Console.WriteLine("\n=== Inventory ===");


        List<Item> inventory = character.GetInventory();

        if(inventory == null)
        {
            Console.WriteLine("Something went wrong...");
        }

        if(inventory.Count == 0)
        {
            Console.WriteLine("Inventory is emoty.");
            return;
        }

        for (int i = 0; i < inventory.Count; ++i)
        {
            Item item = inventory[i];
            Console.WriteLine($"{i + 1}. {item.GetName()} (Value: {item.GetValue()} gp, Weight: {item.GetWeight()})");
        }

    }


    private static void ShowTraits(Character character)
    {
        
        Console.WriteLine("\n=== Traits ===");
        Dictionary<string, string> allTraits = new Dictionary<string, string>();

        Race race = character.GetRace();
        if(race != null)
        {
            Dictionary<string, string> raceTraits = race.GetAllTraits();
            if (raceTraits != null)
            {
                foreach (var trait in raceTraits)
                {
                    if (!allTraits.ContainsKey(trait.Key))
                        allTraits.Add(trait.Key, trait.Value);
                }
            }
        }

        Background bg = character.GetBackground();
        if(bg != null)
        {
            Dictionary<string, string> bgTraits = bg.GetFeatures();
            if (bgTraits != null)
            {
                foreach (var trait in bgTraits)
                {
                    if (!allTraits.ContainsKey(trait.Key))
                        allTraits.Add(trait.Key, trait.Value);
                }
            }
        }

        CharacterClass charClass = character.GetClass();
        if(charClass != null)
        {
            Dictionary<string, string> charTraits = charClass.GetAllClassFeatures();
            if (charTraits != null)
            {
                foreach (var trait in charTraits)
                {
                    if (!allTraits.ContainsKey(trait.Key))
                        allTraits.Add(trait.Key, trait.Value);
                }
            }
        }

        if (allTraits.Count == 0)
        {
            Console.WriteLine("No Traits");
            return;
        }

        int i = 1;

        foreach (var trait in allTraits)
        {
            Console.WriteLine($"{i}. {trait.Key}: \n{trait.Value}");
            i++;
        }

        
    }

    private static Character LoadCharacter()
    {
        Console.WriteLine("Load Function Not Implemented yet.");
        return null;
    }


}