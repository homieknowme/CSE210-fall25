using System;

public class ClassLevel
{
    
    private CharacterClass _characterClass;
    private int _level;

    public ClassLevel(CharacterClass CharacterClass)
    {
        _characterClass = CharacterClass;
        _level = 1;
    }

    public CharacterClass GetCharacterClass() {return _characterClass;}
    public int GetLevel() {return _level;}

    public void LevelUp(int amount = 1)
    {
        _level += amount;
        _characterClass.ApplyClassFeature(_level);
    }

    public int GetHitDie() => _characterClass.GetHitDie();

}