using System;

public class AbilityScores
{
    
    private int _strength;
    private int _dexterity;
    private int _constitution;
    private int _intelligence;
    private int _wisdom;
    private int _charisma;

    public int GetStr() {return _strength;}
    public void IncreaseStr(int amount) {_strength += amount;}

    public int GetDex() {return _dexterity;}
    public void IncreaseDex(int amount) {_dexterity += amount;}

    public int GetCon() {return _constitution;}
    public void IncreaseCon(int amount) {_constitution += amount;}

    public int GetInt() {return _intelligence;}
    public void IncreaseInt(int amount) {_intelligence += amount;}

    public int GetWis() {return _wisdom;}
    public void IncreaseWis(int amount) {_wisdom += amount;}

    public int GetCha() {return _charisma;}
    public void IncreaseCha(int amount) {_charisma += amount;}

    public int GetModifier(string statName)
    {
        int score = 0;

        switch (statName.ToLower())
        {
            case"str":
                score = _strength;
                break;

            case"dex":
                score = _dexterity;
                break;

            case"con":
                score = _constitution;
                break;

            case"int":
                score = _intelligence;
                break;

            case"wis":
                score = _wisdom;
                break;

            case"cha":
                score = _charisma;
                break;
        }

        return (int)Math.Floor((score - 10) / 2.0);
    }



}