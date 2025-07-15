using System;
using System.Collections.Generic;

namespace GameCharacter
{
    public class EquipManager
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

            if (selectedItem.IsEquipped)
            {
                selectedItem.IsEquipped = false;
                Console.WriteLine($"{selectedItem.Name}을(를) 해제했습니다!");
            }
            else
            {
                foreach (var item in inventory)
                {
                    if (item.Type == selectedItem.Type)
                        item.IsEquipped = false;
                }

                selectedItem.IsEquipped = true;
                Console.WriteLine($"{selectedItem.Name}을(를) 장착했습니다!");
            }
        }
    }
}