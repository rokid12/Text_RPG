using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal class ItemPotion : Items
    {
        public int itemCount = 3;
        int hpPoint;

        public void UsingPotion()
        {
            var player = GameManager.Instance.player;
            int healingPoint = (player.maxHp - player.hp >= 30) ? healingPoint = 30 : healingPoint = player.maxHp - player.hp;

            {
                if (itemAttack != 0) // 공격력을 증가시키는 포션이 있다면.
                {
                    player.atk += itemAttack;
                }
                if (itemArmor != 0) // 방어력을 증가시키는 포션이 있다면.
                {
                    player.def += itemArmor;
                }
                if (itemHealth != 0)
                {
                    player.hp += healingPoint;
                    hpPoint = healingPoint;
                }

                player.PotionFinder().itemCount -= 1;

                if (itemCount == 0)
                {
                    player.GetInventory().Remove(player.PotionFinder());
                }
            }
        }

        public void PotionPotency()
        {
            if (itemAttack != 0)
            {
                Console.WriteLine($"공격력이 {itemAttack} 증가했습니다."); // 공격력을 증가시키는 포션이 있다면.
            }
            if (itemArmor != 0)
            {
                Console.WriteLine($"방어력이 {itemArmor} 증가했습니다."); // 방어력을 증가시키는 포션이 있다면.
            }
            if (itemHealth != 0)
            {
                Console.WriteLine($"체력이 {hpPoint} 회복됐습니다.");
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

        public ItemPotion()
        {
            itemType = 3;
        }
    }
}
