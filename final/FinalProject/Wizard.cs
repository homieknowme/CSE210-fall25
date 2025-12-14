using System;

public class Wizard : CharacterClass
{
    
    public Wizard() : base("Wizard", 6)
    {

        AddSkill("Insight");
        AddSkill("Investigation");

        AddProficiency("Daggers");
        AddProficiency("Darts");
        AddProficiency("Slings");
        AddProficiency("Quarterstaffs");
        AddProficiency("Light Crossbows");
        
    }



    public override void ApplyClassFeature(int level, string archetype, Character character)
    {
        if (level == 1)
        {
            
        }
    }

    public override void ApplyClassEquipment(Character character)
    {
        character.AddItem(new Item("Quarterstaff", "", 4, 1, 0.2));
        character.AddItem(new Item("Scholar's Pack", "", 24, 1, 40));
        character.AddItem(new Item("Arcane Focus", "", 4, 1, 5));
        character.AddItem(new Item("Spellbook", "", 3, 1, 50));
    }

}