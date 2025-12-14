using System;

public class Entertainer : Background
{
    
    public Entertainer() : base("Entertainer")
    {
        AddSkill("Acrobatics");
        AddSkill("Performance");
        AddProficiency("Disguise Kit");
        AddProficiency("One type of Musical Instrument");
        AddFeature("By Popular Demand",
        "You can always find a place to perform, usually in an inn or tavern but possibly with a circus, at a theater, or even in a noble's court.\n At such a place, you receive free lodging and food of a modest or comfortable standard (depending on the quality of the establishment), as long as you perform each night.\n In addition, your performance makes you something of a local figure. When strangers recognize you in a town where you have performed, they typically take a liking to you.");

    }

    public override void ApplyBackgroundEquipment(Character character)
    {
        character.AddItem(new Item("A Musical Instrument", "", 3, 1, 18));
        character.AddItem(new Item("Favor of an Admirer", "", 0, 1, 0));
        character.AddItem(new Item("Costume", "", 4, 1, 5));
        character.AddItem(new Item("GP", "", 1, 15, 1));
    } 

}