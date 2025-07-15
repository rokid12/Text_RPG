using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    abstract class Items
    {
        public int itemType; // 0 = 무기, 1 = 방어구, 2 = 포션
        public int itemValue; // 아이템 효과
        public int itemAttack; // 아이템 공격
        public int itemArmor; // 아이템 방어력
        public int itemHealth; // 아이템 체력
        public string itemName; // 아이템 이름
        public string itemDescription; // 아이템 설명


        public void ItemInformation()
        {
            List<string> statusList = new List<string>();

            int itemNameWidth = 12;
            int statusWidth = 12;
            int itemDescriptionWidth = 26;

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
                statusList.Add($"체력 {itemHealth:+#;-#;0}");
            }

            Console.Write("\n - ");
            Console.Write($"{itemName.PadRight(itemNameWidth)}");
            Console.Write($"| {statusList[0].PadRight(itemNameWidth)}");
            Console.Write($"| {itemDescription.PadRight(itemDescriptionWidth)}");

            for (int i = 1; i < statusList.Count; i++)
            {
                Console.Write($"\n".PadRight(15));
                Console.Write($"| {statusList[i]}");
                Console.WriteLine($"| ".PadRight(28));
            }
        }
    }
}
