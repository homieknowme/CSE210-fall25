using System;

public class Elf : Race
{
    
    public Elf() : base("Elf")
    {
        SetSpeed(30);
        AddLanguage("Common");
        AddLanguage("Elvish");

        AddTrait("Darkvision",
        "Accustomed to twilit forests and the night sky, you have superior vision in dark and dim conditions. You can see in dim light within 60 feet of you as if it were bright light, and in darkness as if it were dim light. You can't descern color in darkness, only shades of gray.");
        AddTrait("Fey Ancestry",
        "You have advantage on saving throws against being charmed, and magic can't put you to sleep.");
        AddTrait("Trance",
        "Elves don't need to sleep. Instead they meditate deeply, remaining semiconcious, for 4 hours a day. (The Common word for such meditation is 'trance.') While meditating, you can dream after a fashion; such dreams are actually mental excersises that have become reflexive through the years of practice. After resting in this way, you gain the same benefit that a human does from 8 hours of sleep.");
        AddSkill("Perception");
    }

    public override void ApplyRacialTraits(AbilityScores abilities)
    {
        abilities.IncreaseDex(2);
    }

}