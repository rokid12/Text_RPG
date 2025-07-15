using System.Numerics;

public class LevelManager
{
    private Player player;

    public LevelManager(Player player)
    {
        this.player = player;
    }

    public void Experience(int exp)
    {
        Console.WriteLine($"경험치 {exp}을(를) 획득했습니다!");
        player.Experience += exp;

        while (player.Experience >= player.MaxExperience)
        {
            player.Experience -= player.MaxExperience;
            LevelUp();
        }
    }

    private void LevelUp()
    {
        player.Level++;
        player.MaxExperience += 50;
        player.Attack += 2;

        Console.WriteLine($"레벨업! 현재 레벨은 {player.Level} 입니다!");
        Console.WriteLine($"공격력이 {player.Attack}로 증가했습니다!");
    }
}
