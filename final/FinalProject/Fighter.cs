using System;

public class Fighter : CharacterClass
{
    
    public Fighter() : base("Fighter", 10)
    {
        
        AddSkill("Intimidation");
        AddSkill("Percepion");

        AddProficiency("All Armor");
        AddProficiency("Shields");
        AddProficiency("Simple Weapons");
        AddProficiency("Martial Weapons");

    }



    public override void ApplyClassFeature(int level, string archetype, Character character)
    {
        if (level == 1)
        {
            
        }
    }

    public override void ApplyClassEquipment(Character character)
    {
        character.AddItem(new Item("Battleaxe", "", 4, 1, 10));
        character.AddItem(new Item("Dungeoneer's Pack", "", 26, 1, 12));
        character.AddItem(new Item("Warhammer", "", 2, 1, 15));
        character.AddItem(new Item("Handaxe", "", 2, 2, 5));
        Item chainMail = new Item("Chain Mail", "", 55, 1, 75);
        character.EquipArmor(chainMail, 16, false);
    }

}