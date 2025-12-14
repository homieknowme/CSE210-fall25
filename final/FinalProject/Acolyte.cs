using System;

public class Acolyte : Background
{
    
    public Acolyte() : base("Acolyte")
    {
        AddSkill("Insight");
        AddSkill("Religion");
        AddFeature("Shelter of The Faithful",
        "As an acolyte, you command the respect of those who share your faith, and you can perform the religious ceremonies of your deity.\n You and your adventuring companions can expect to receive free healing and care at a temple, shrine, or other established presence of your faith, though you must provide any material components needed for spells.\n Those who share your religion will support you (but only you) at a modest lifestyle.\n You might also have ties to a specific temple dedicated to your chosen deity or pantheon, and you have a residence there.\n This could be the temple where you used to serve, if you remain on good terms with it, or a temple where you have found a new home.\n While near your temple, you can call upon the priests for assistance, provided the assistance you ask for is not hazardous and you remain in good standing with your temple.");
        
    }

    public override void ApplyBackgroundEquipment(Character character)
    {
        character.AddItem(new Item("Holy Symbol", "A gift when you entered the pristhood.", 1, 1, 5));
        character.AddItem(new Item("Prayer Book", "A book with prayers.", 5, 1, 25));
        character.AddItem(new Item("Stick of Incense", "", 1, 5, 0.1));
        character.AddItem(new Item("Vestments", "", 4, 1, 1));
        character.AddItem(new Item("Common Clothes", "", 3, 1, 5));
        character.AddItem(new Item("GP", "", 1, 15, 1));
    } 

}