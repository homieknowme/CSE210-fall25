using System;

public class Hermit : Background
{
    
    public Hermit() : base("Hermit")
    {
        AddSkill("Medicine");
        AddSkill("Religion");
        AddProficiency("Herbalism Kit");
        AddFeature("Discovery",
        "The quiet seclusion of your extended hermitage gave you access to a unique and powerful discovery. The exact nature of this revelation depends on the nature of your seclusion.\n It might be a great truth about the cosmos, the deities, the powerful beings of the outer planes, or the forces of nature.\n It could be a site that no one else has ever seen. You might have uncovered a fact that has long been forgotten, or unearthed some relic of the past that could rewrite history.\n It might be information that would be damaging to the people who or consigned you to exile, and hence the reason for your return to society.\n Work with your DM to determine the details of your discovery and its impact on the campaign.");

    }

    public override void ApplyBackgroundEquipment(Character character)
    {
        character.AddItem(new Item("Scroll Case", "", 1, 1, 1));
        character.AddItem(new Item("Winter Blanket", ".", 3, 1, 0.5));
        character.AddItem(new Item("Common Clothes", "", 3, 5, 5));
        character.AddItem(new Item("Herbalism Kit", "", 3, 1, 5));
        character.AddItem(new Item("GP", "", 1, 5, 1));
    } 

}