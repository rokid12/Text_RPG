using System;
using System.Collections.Generic;
using TextRPG;

namespace TextRPG
{
    class EquipManager
    {
        private Character character;

        public EquipManager(Character character)
        {
            this.character = character;
        }

        public void EquipItem(int index)
        {
            var inventory = character.GetInventory();

            if (index < 0 || index >= inventory.Count)
            {
                Console.WriteLine("잘못된 형식입니다.");
                return;
            }

            var selectedItem = inventory[index];

            if (selectedItem.isEquipped)
            {
                selectedItem.isEquipped = false;
                character.UnEquipment(selectedItem);
                Console.WriteLine($"{selectedItem.itemName}을(를) 해제했습니다!");
            }
            else
            {
                foreach (var item in inventory)
                {
                    if (item.itemType == selectedItem.itemType && item.isEquipped)
                    {
                        item.isEquipped = false;
                        character.UnEquipment(item);
                    }
                }

                selectedItem.isEquipped = true;
                character.Equipment(selectedItem);
                Console.WriteLine($"{selectedItem.itemName}을(를) 장착했습니다!");
            }

            selectedItem.ItemInformation();
        }
    }
}
