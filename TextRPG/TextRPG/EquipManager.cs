using System;
using System.Collections.Generic;
using TextRPG;

namespace TextRPG
{
    public class EquipManager
    {
        private static EquipManager _instance;
        public static EquipManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new EquipManager();
                return _instance;
            }
        }
        public void EquipItem(int index)
        {
            int equipable = GameManager.Instance.player.GetInventory()[index].itemType;

            if (equipable == 0 || equipable == 1 || equipable == 2)
            {
                var inventory = GameManager.Instance.player.GetInventory();

                if (index < 0 || index >= inventory.Count)
                {
                    Console.WriteLine("잘못된 형식입니다.");
                    return;
                }

                var selectedItem = inventory[index];

                if (selectedItem.isEquipped)
                {
                    selectedItem.isEquipped = false;
                    Console.WriteLine($"{selectedItem.itemName}을(를) 해제했습니다!");
                    GameManager.Instance.player.EquipmentStatMinus(selectedItem);

                }
                else
                {
                    foreach (var item in inventory)
                    {
                        if (item.itemType == selectedItem.itemType)
                            item.isEquipped = false;
                    }

                    selectedItem.isEquipped = true;
                    Console.WriteLine($"{selectedItem.itemName}을(를) 장착했습니다!");
                    GameManager.Instance.player.EquipmentStatPlus(selectedItem);
                }
            }
            else
            {
                Console.WriteLine("장착할 수 없는 아이템입니다.");
            }
        }

    }

}
