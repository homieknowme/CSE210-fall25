using System;

public class HalfOrc : Race
{
    
    public HalfOrc() : base("Half Orc")
    {
        SetSpeed(30);
        AddLanguage("Common");
        AddLanguage("Orc");

        AddTrait("Darkvision", 
        "Thanks to your Orc blood, you have superior vision in dark and dim conditions. You can see in dim light within 60 feet of you as if it were bright light, and in darkness as if it were dim light. You can't descern color in darkness, only shades of gray.");
        AddTrait("Relentless Endurance",
        "When you are reduced to 0 hit points but not killed outright, you can drop to 1 hit point instead. You can't use this feature again until you finish a long rest.");
        AddTrait("Savage Attacks",
        "When you score a critical hit with a melee weapon attack, you can roll one of the weapon's damage dice one additional time and add it to the extra damage of the critical hit");
        AddSkill("Intimidation");
    }

    public override void ApplyRacialTraits(AbilityScores abilities)
    {
        abilities.IncreaseStr(2);
        abilities.IncreaseCon(1);
    }

}