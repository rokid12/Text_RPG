using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal class ItemData
    {
        private static ItemData _instance;
        public static ItemData Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ItemData();
                return _instance;
            }
        }

        public ItemPotion potion = new ItemPotion()
        {
            itemAttack = 0,
            itemArmor = 0,
            itemHealth = 30,
            itemName = "포션",
            itemDescription = "사용하면 체력을 30 회복할 수 있습니다."
        };

        public ItemEquipable oldSword = new ItemEquipable()
        {
            itemType = 0,
            itemAttack = 2,
            itemArmor = 0,
            itemHealth = 0,
            itemName = "롱 소드",
            itemDescription = "쉽게 볼 수 있는 낡은 검입니다."
        };

        public ItemEquipable bronzeAxe = new ItemEquipable()
        {
            itemType = 0,
            itemAttack = 5,
            itemArmor = 0,
            itemHealth = 0,
            itemName = "청동 도끼",
            itemDescription = "어디선가 사용됐던거 같은 도끼입니다."
        };

        public ItemEquipable spartaSpear = new ItemEquipable()
        {
            itemType = 0,
            itemAttack = 15,
            itemArmor = 0,
            itemHealth = 0,
            itemName = "스파르타의 창",
            itemDescription = "스파르타 전사들이 사용했다는 전설의 창입니다."
        };

        public ItemEquipable trinityForce = new ItemEquipable()
        {
            itemType = 0,
            itemAttack = 33,
            itemArmor = 33,
            itemHealth = 33,
            itemName = "삼위일체",
            itemDescription = "위대한 전사 잭시무스가 사용한 무기입니다."
        };

        public ItemEquipable usefulShield = new ItemEquipable()
        {
            itemType = 1,
            itemAttack = 0,
            itemArmor = 1,
            itemHealth = 0,
            itemName = "쓸만한 방패",
            itemDescription = "방어에 도움이 되는 방패입니다."
        };

        public ItemEquipable traineeArmor = new ItemEquipable()
        {
            itemType = 2,
            itemAttack = 0,
            itemArmor = 5,
            itemHealth = 0,
            itemName = "수련자 갑옷",
            itemDescription = "수련에 도움을 주는 갑옷입니다."
        };

        public ItemEquipable steelArmor = new ItemEquipable()
        {
            itemType = 2,
            itemAttack = 0,
            itemArmor = 9,
            itemHealth = 0,
            itemName = "무쇠 갑옷",
            itemDescription = "무쇠로 만들어져 튼튼한 갑옷입니다."
        };

        public ItemEquipable spartaArmor = new ItemEquipable()
        {
            itemType = 2,
            itemAttack = 0,
            itemArmor = 15,
            itemHealth = 0,
            itemName = "스파르타 갑옷",
            itemDescription = "스파르타 전사들이 사용했다는 전설의 갑옷입니다."
        };

        public ItemEquipable thornMail = new ItemEquipable()
        {
            itemType = 2,
            itemAttack = 0,
            itemArmor = 20,
            itemHealth = 20,
            itemName = "가시 갑옷",
            itemDescription = "공격자는 갑옷의 날카로운 칼날에 피해를 입습니다."
        };
    }
}
