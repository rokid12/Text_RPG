using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal class ItemManager
    {
        public static Potion potion = new Potion()
        {
            itemHealth = 30,
            itemName = "포션",
            itemDescription = "사용하면 체력을 30 회복할 수 있습니다."
        };
    }
}
