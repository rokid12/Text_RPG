using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
<<<<<<< Updated upstream
    class Items
=======
    public abstract class Items
>>>>>>> Stashed changes
    {
        public int itemType; // 0 = 무기, 1 = 방패, 2 = 방어구, 3 = 포션 -- 아이템 타입이 같은 장비는 하나밖에 착용하지 못하고, 2번은 착용할 수 없음.
        public int itemAttack; // 아이템 공격
        public int itemArmor; // 아이템 방어력
        public int itemHealth; // 아이템 체력
        public string itemName; // 아이템 이름
        public string itemDescription; // 아이템 설명
<<<<<<< Updated upstream
        public bool isEquipped = false;

        public virtual void ItemInformation()
        {
            string equip = (isEquipped == true) ? " [장착 중]" : "";
=======

        public bool isEquipped = false;

        public void ItemInformation()
        {
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
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
=======
                statusList.Add($"체력 {itemHealth:+#;-#;0}");
            }

            Console.Write("\n - ");
            Console.Write($"{TextFormat(itemName)}");
            Console.Write($"| {TextFormat(statusList[0])}");
            Console.Write($"| {DescriptionFormat(itemDescription)}");

            for (int i = 1; i < statusList.Count; i++)
            {
                Console.Write($"\n   {TextFormat("")}");
                Console.Write($"| {TextFormat(statusList[i])}");
                Console.Write($"| {DescriptionFormat("")}");
            }
        }

        string TextFormat(string txt)
        {
            txt = txt.PadRight(16 - txt.Length);
            return txt;
        }
        string DescriptionFormat(string txt)
        {
            txt = txt.PadRight(32 - txt.Length);
            return txt;
        }

        public class Weapon : Items
        {
            public Weapon(string name, string desc, int atk)
            {
                itemType = 0;
                itemName = name;
                itemDescription = desc;
                itemAttack = atk;
            }
        }

        public class Shield : Items
        {
            public Shield(string name, string desc, int def)
            {
                itemType = 1;
                itemName = name;
                itemDescription = desc;
                itemArmor = def;
            }
        }

        public class Armor : Items
        {
            public Armor(string name, string desc, int def)
            {
                itemType = 2;
                itemName = name;
                itemDescription = desc;
                itemArmor = def;
>>>>>>> Stashed changes
            }
        }
    }
}
