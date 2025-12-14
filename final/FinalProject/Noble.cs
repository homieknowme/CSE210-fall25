using System;

public class Noble : Background
{
    
    public Noble() : base("Noble")
    {
        AddSkill("History");
        AddSkill("Persuasion");
        AddProficiency("Type of Gaming Set");
        AddFeature("Position of Privilege",
        "Nobles are born and raised to a very different lifestyle than most people ever experience, and their personalities reflect that upbringing.\n A noble title comes with a plethora of bonds - responsibilities to family, to other nobles (including the sovereign), to the people entrusted to the family's care, or even to the title itself.\n But this responsibility is often a good way to undermine a noble.");

    }

    public override void ApplyBackgroundEquipment(Character character)
    {
        character.AddItem(new Item("Fine Clothes", "", 6, 1, 15));
        character.AddItem(new Item("Signet Ring", "", 0, 1, 5));
        character.AddItem(new Item("Scroll of Pedigree", "", 0, 1, 0));
        character.AddItem(new Item("GP", "", 1, 25, 1));
    } 

}