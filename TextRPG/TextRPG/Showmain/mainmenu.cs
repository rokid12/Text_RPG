using TextRPG;

namespace TextRPG
{
    class Program
    {
        static void Main(string[] args)
        {
            UIManager.Instance.ShowIntro();
            Console.WriteLine("\n\n시작하시려면 아무키나 입력하세요...");
            Console.ReadKey();

            var getInven = GameManager.Instance.player.GetInventory();

            ItemEquipable trinityForce = new ItemEquipable(ItemData.Instance.trinityForce); // 이런식으로 복사해서 넣으면 될듯?
            getInven.Add(trinityForce);

            GameManager.Instance.player.GetInventory().Add(ItemData.Instance.potion);

            UIManager.Instance.ShowMainMenu();
        }
    }
}