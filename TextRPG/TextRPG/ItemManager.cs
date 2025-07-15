using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal class ItemManager
    {
        public static ItemPotion potion = new ItemPotion()
        {
            itemAttack = 0,
            itemArmor = 0,
            itemHealth = 30,
            itemName = "포션",
            itemDescription = "사용하면 체력을 30 회복할 수 있습니다."
        };

        public static ItemEquipable usefulShield = new ItemEquipable()
        {
            itemAttack = 0,
            itemArmor = 1,
            itemHealth = 0,
            itemName = "쓸만한 방패",
            itemDescription = "방어에 도움이 되는 방패입니다."
        };
    }
}
