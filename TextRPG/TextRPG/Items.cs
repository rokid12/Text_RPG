using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    abstract class Items
    {
        public int itemType;
        public int itemAttack;
        public int itemArmor;
        public int itemHealth;
        public string itemName;
        public string itemDescription;
        public bool isEquipped = false;

        public virtual void ItemInformation() { } // 아이템 정보 출력 메서드

        public Items() { }
        public Items(Items orginal)
        {
            itemType = orginal.itemType;
            itemAttack = orginal.itemAttack;
            itemArmor = orginal.itemArmor;
            itemHealth = orginal.itemHealth;
            itemName = orginal.itemName;
            itemDescription = orginal.itemDescription;
        }
    }
}