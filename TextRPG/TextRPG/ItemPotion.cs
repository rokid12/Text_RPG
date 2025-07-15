using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal class ItemPotion : Items
    {
        public int itemCount = 3; // 포션 갯수는 추가할 때 갯수를 추가 저장해야함.
        public ItemPotion()
        {
            itemType = 3; // 포션은 아이템 타입이 고정
        }

        public void UsingPotion()
        {
            if (GameManager.Instance.player.GetPotion() > 0)
            {
                if (itemAttack != 0)
                {
                    GameManager.Instance.player.atk += itemAttack;
                }
                if (itemArmor != 0)
                {
                    GameManager.Instance.player.def += itemArmor;
                }
                if (itemHealth != 0)
                {
                    int MHP = GameManager.Instance.player.maxHp;
                    int HP = GameManager.Instance.player.hp;
                    int healingPoint = (MHP - HP >= 30) ? healingPoint = 30 : healingPoint = MHP - HP;
                    GameManager.Instance.player.maxHp += +healingPoint;
                    Console.WriteLine($"체력을 {healingPoint} 회복했습니다.");
                }

                Console.WriteLine($"{itemName}을 사용했습니다.");

                GameManager.Instance.player.PotionFinder().itemCount -= 1;

                if (itemCount == 0)
                {
                    GameManager.Instance.player.GetInventory().Remove(GameManager.Instance.player.PotionFinder());
                }
            }
            else
            {
                Console.WriteLine("\n포션이 부족합니다.");
            }
        }
    }
}
