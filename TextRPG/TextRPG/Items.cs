using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    class Items
    {
        public int itemType; // 0 = 무기, 1 = 방패, 2 = 방어구, 3 = 포션 -- 아이템 타입이 같은 장비는 하나밖에 착용하지 못하고, 2번은 착용할 수 없음.
        public int itemAttack; // 아이템 공격
        public int itemArmor; // 아이템 방어력
        public int itemHealth; // 아이템 체력
        public string itemName; // 아이템 이름
        public string itemDescription; // 아이템 설명
        public bool isEquipped = false;

        public virtual void ItemInformation()
        {
            string equip = (isEquipped == true) ? " [장착 중]" : "";
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

            Console.Write($"{itemName.PadRight(13 - itemName.Length)}");

            if (statusList != null)
            {
                string status = statusList[0];
                Console.Write("| ");
                Console.Write(status.PadRight(13 - status.Length));
            }

            Console.Write(" | ");
            Console.Write(itemDescription.PadRight(32 - itemDescription.Length));
            Console.WriteLine(equip);

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