using System;

public class Human : Race
{
    
    public Human() : base("Human")
    {
        SetSpeed(30);
        AddLanguage("Common");
        SetBonusLanguages(1);
    }

    public override void ApplyRacialTraits(AbilityScores abilities)
    {
        abilities.IncreaseStr(1);
        abilities.IncreaseDex(1);
        abilities.IncreaseCon(1);
        abilities.IncreaseInt(1);
        abilities.IncreaseWis(1);
        abilities.IncreaseCha(1);
    }

}