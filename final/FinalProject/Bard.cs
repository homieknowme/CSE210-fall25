using System;

public class Bard : CharacterClass
{
    
    public Bard() : base("Bard", 8)
    {
        
        AddSkill("Sleight of Hand");
        AddSkill("Athletics");
        AddSkill("Deception");

        AddProficiency("Light Armor");
        AddProficiency("Simple Weapons");
        AddProficiency("Hand Crossbows");
        AddProficiency("Longswords");
        AddProficiency("Rapiers");
        AddProficiency("Shortswords");
        AddProficiency("Musical Instruments");

    }



    public override void ApplyClassFeature(int level, string archetype, Character character)
    {
        if (level == 1)
        {
            AddClassFeature("Spellcasting",
            "You can cast bardic spells. Charisma is your spell casting ability for bard. Spell save = 8 + proficiency bonus + Charisma Modifier.");
            AddClassFeature("Bardic Inspiration",
            "You inpire others through stirring words or music. \nOn bonus action, you give 1d6(bardic inpiration) to a creature within 60 feet that is not you.\nOnce, within the next 10 minutes, the creature can roll and add the bardic inspiration to one ability check, attack roll, or saving throw.\nCan be used A number of times equal to your charisma modiefier(Minimum of once).");
            character.AddClassFeature("Spellcasting",
            "You can cast bardic spells. Charisma is your spell casting ability for bard. Spell save = 8 + proficiency bonus + Charisma Modifier.");
            character.AddClassFeature("Bardic Inspiration",
            "You inpire others through stirring words or music. \nOn bonus action, you give 1d6(bardic inpiration) to a creature within 60 feet that is not you.\nOnce, within the next 10 minutes, the creature can roll and add the bardic inspiration to one ability check, attack roll, or saving throw.\nCan be used A number of times equal to your charisma modiefier(Minimum of once).");
            
        }

        if (level == 2)
        {
            AddClassFeature("Jack of All Trades",
            "You can add half your proficiency bonus to any ability check that does not already include your proficiency bonus.");
            AddClassFeature("Song of Rest",
            "You can use soothing music or oration to revitalize wounded allies during a short rest.\n If you or any friendly creature who can hear your performance regain hit points at the end of the short rest, each of those creatures regain an extra 1d6 hit points.");
        }

        if (level == 3)
        {
            AddClassFeature("Expertise",
            "Your proficiency bonus is doubled for any ability check you make using skills you are proficient in.");

            if (archetype != null && archetype == "College of Lore")
            {
                AddSkill("Animal Handling");
                AddSkill("Persuasion");
                AddSkill("Perception");
                
                AddClassFeature("Cutting Words",
                "When a creature within 60 feet of you makes an attack roll, an ability check, or a damage roll, \nyou can use your reaction to expend one of your bardic inspiration and subtract the number rolled from the creature's roll.\n The creature is immune if it can not hear you or is immune to being charmed.");

            }

            if (archetype != null && archetype == "College of Valor")
            {
                AddProficiency("Medium Armor");
                AddProficiency("Shields");
                AddProficiency("Martial Weapons");

                AddClassFeature("Combat Inspiration",
                "A creature that has bardic inpiration from you can roll it and add that number to their damage roll.\n Alternatively, it can roll it to add to their Ac against an attack.");

            }
        }
    }

    public override void ApplyClassEquipment(Character character)
    {
        character.AddItem(new Item("Rapier", "1d8 Piercing. Finesse", 2, 1, 25));
        character.AddItem(new Item("Diplomat's Pack", "", 36, 1, 39));
        character.AddItem(new Item("Lute", "", 2, 1, 35));
        character.AddItem(new Item("Dagger", "", 1, 1, 2));
        Item leather = new Item("Leather Armor", "", 10, 1, 10);
        character.EquipArmor(leather, 11, true);
        
    }

}