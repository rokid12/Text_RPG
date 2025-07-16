using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal class ItemPotion : Items
    {
        public int itemCount = 3; // 포션 갯수는 추가할 때 갯수를 추가 저장해야함.
        public ItemPotion()
        {
            itemType = 3; // 포션은 아이템 타입이 고정
        }

        public void UsingPotion()
        {
            if (itemAttack != 0)
            {
                GameManager.Instance.player.atk += itemAttack;
            }
            if (itemArmor != 0)
            {
                GameManager.Instance.player.def += itemArmor;
            }
            if (itemHealth != 0)
            {
                int MHP = GameManager.Instance.player.maxHp;
                int HP = GameManager.Instance.player.hp;
                int healingPoint = (MHP - HP >= 30) ? healingPoint = 30 : healingPoint = MHP - HP;
                GameManager.Instance.player.maxHp += +healingPoint;
                Console.WriteLine($"체력을 {healingPoint} 회복했습니다.");
            }

            Console.WriteLine($"{itemName}을 사용했습니다.");

            GameManager.Instance.player.PotionFinder().itemCount -= 1;

            if (itemCount == 0)
            {
                GameManager.Instance.player.GetInventory().Remove(GameManager.Instance.player.PotionFinder());
            }
        }

        public override void ItemInformation()
        {
            string itemCountText;
            string count = (itemCount > 1) ? itemCountText = $"{itemName} x{itemCount}" : itemCountText = itemName;
            List<string> statusList = new List<string>();

            if (itemAttack != 0)
            {
                statusList.Add($"공격력 {itemAttack:+#;-#;0}");
            }
            if (itemArmor != 0)
            {
                statusList.Add($"방어력 {itemArmor:+#;-#;0}");
            }
            if (itemHealth != 0)
            {
                statusList.Add($"체  력 {itemHealth:+#;-#;0}");
            }

            Console.Write($"{itemCountText.PadRight(13 - itemName.Length)}");

            if (statusList != null)
            {
                string status = statusList[0];
                Console.Write("| ");
                Console.Write(status.PadRight(13 - status.Length));
            }

            Console.Write(" | ");
            Console.WriteLine(itemDescription.PadRight(32 - itemDescription.Length));

            for (int i = 1; i < statusList.Count; i++)
            {
                string status = statusList[i];
                Console.Write($"".PadRight(16));
                Console.Write("| ");
                Console.Write(status.PadRight(13 - status.Length));
                Console.WriteLine(" |");
            }
        }
    }
}
