using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal class ItemEquipable : Items
    {
        public override void ItemInformation()
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

        public ItemEquipable() { }
        public ItemEquipable(ItemEquipable original) : base(original)
        {
        }
    }
}
