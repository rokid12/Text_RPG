using TextRPG;

namespace TextRPG
{
    class Program
    {
        static void Main(string[] args)
        {
            var getInven = GameManager.Instance.player.GetInventory();

            ItemEquipable trinityForce = new ItemEquipable(ItemData.Instance.trinityForce); // 이런식으로 복사해서 넣으면 될듯?
            getInven.Add(trinityForce);

            GameManager.Instance.player.GetInventory().Add(ItemData.Instance.potion);
            Character player = new Character("rtan", 5, 5, 100, 100, 1, 0, "전사", 1000);

            UIManager.Instance.ShowIntro();
            UIManager.Instance.ShowMainMenu();
        }
    }
}