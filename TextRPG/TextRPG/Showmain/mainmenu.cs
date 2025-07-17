using TextRPG;

namespace TextRPG
{
    class Program
    {
        static void Main(string[] args)
        {
            GameManager.Instance.player.GetInventory().Add(ItemManager.potion);
            GameManager.Instance.player.GetInventory().Add(ItemManager.trinityForce);
            Character player = new Character("rtan", 5, 5, 100, 100, 1, 0, "전사", 1000);

            UIManager.Instance.ShowIntro();
            UIManager.Instance.ShowMainMenu();
        }
    }
}