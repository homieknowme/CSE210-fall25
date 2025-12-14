using System;

public class Sage : Background
{
    
    public Sage() : base("Sage")
    {
        AddSkill("Arcana");
        AddSkill("History");
        AddFeature("Researcher",
        "When you attempt to learn or recall a piece of lore, if you do not know that information, you often know where and from whom you can obtain it.\n Usually, this information comes from a library, scriptorium, university, or a sage or other learned person or creature.\n Your DM might rule that the knowledge you seek is secreted away in an almost inaccessible place, or that it simply cannot be found.\n Unearthing the deepest secrets of the multiverse can require an adventure or even a whole campaign.");

    }

    public override void ApplyBackgroundEquipment(Character character)
    {
        character.AddItem(new Item("Bottle of Black Ink", "", 0, 1, 10));
        character.AddItem(new Item("Quill", "", 0, 1, 0.02));
        character.AddItem(new Item("Small Knife", "", 1, 1, 2));
        character.AddItem(new Item("Letter", "From a dead colleague posing a question you have yet to find the answer to.", 0, 1, 0.2));
        character.AddItem(new Item("Common Clothes", "", 3, 1, 5));
        character.AddItem(new Item("GP", "", 1, 10, 1));
    } 

}