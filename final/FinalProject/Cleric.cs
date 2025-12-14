using System;

public class Cleric : CharacterClass
{
    
    public Cleric() : base("Cleric", 8)
    {
        
        AddSkill("History");
        AddSkill("Medicine");

        AddProficiency("Light Armor");
        AddProficiency("Medium Armor");
        AddProficiency("Shields");
        AddProficiency("All Simple Weapons");

    }



    public override void ApplyClassFeature(int level, string archetype, Character character)
    {
        if (level == 1)
        {
            
        }
    }

    public override void ApplyClassEquipment(Character character)
    {
        character.AddItem(new Item("Mace", "", 4, 1, 5));
        character.AddItem(new Item("Priest's Pack", "", 24, 1, 19));
        character.AddItem(new Item("Light Crossbow", "", 5, 1, 25));
        character.AddItem(new Item("Bolts (20)", "", 1.5, 1, 1));
        character.AddItem(new Item("Shield", "", 6, 1, 10));
        character.AddItem(new Item("Holy Symbol", "", 1, 1, 5));
        Item scaleMail = new Item("Scale Mail", "", 45, 1, 50);
        character.EquipArmor(scaleMail, 14, true);
    }

}