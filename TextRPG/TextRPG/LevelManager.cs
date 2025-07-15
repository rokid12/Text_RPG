using System;
using TextRPG;

class LevelManager
{
    private Character character;

    public LevelManager(Character character)
    {
        this.character = character;
    }

    public void AddExperience(int exp)
    {
        character.exp += exp; // 경험치 누적
        Console.WriteLine($"{character.name}이(가) 경험치 {exp}을 얻었습니다.");
        character.LevelUp(); // unit에 있는 LevelUp 호출?
    }
}
