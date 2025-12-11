using System;

public class Dwarf : Race
{

    public Dwarf() : base("Dwarf")
    {
        SetSpeed(25);
        AddLanguage("Common");
        AddLanguage("Dwarvish");

        AddTrait("Darkvision",
        "Accustomed to life underground, you have superior vision in dark and dim conditions. You can see in dim light within 60 feet of you as if it were bright light, and in darkness as if it were dim light. You can't descern color in darkness, only shades of gray.");
        AddTrait("Dwarven Resilience",
        "You have advantage on saving throws against poison, and you have resistance against poison damage.");
        AddTrait("Stone Cunning",
        "Whenever you make an Intelligence(History) check related to the origin of stonework, you are considered proficient in the History skill and add double your proficiency bonusto the check, instead of your normal proficiency bonus.");
        
    }

    public override void ApplyRacialTraits(AbilityScores abilities)
    {
        abilities.IncreaseCon(2);
    }
    
}