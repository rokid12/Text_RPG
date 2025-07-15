using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal class Potion : Items
    {
        public int itemCount = 1; // 포션 갯수는 추가할 때 갯수를 추가 저장해야함.
        public Potion()
        {
            itemType = 2;
        }

        //public void UsingPotion()
        //{
        //    if (itemAttack != 0)
        //    {
        //        attack = attack + itemAttack;
        //    }
        //    if (itemArmor != 0)
        //    {
        //        armor = armor + itemArmor;
        //    }
        //    if (itemHealth != 0)
        //    {
        //        int healingPoint = (maxHealth - health >= 30) ? healingPoint = 30 : healingPoint = Maxhealth - health;
        //        health = health + healingPoint;
        //    }
        //
        //    Console.WriteLine($"{itemName} 을 사용했습니다.");
        //
        //    if (itemCount == 0)
        //    {
        //        inventory.Remove(potion)
        //    }
        //    else
        //    {
        //        inventory.itemCount -= 1;
        //    }
        //}
        // ctrl + K, ctrl + C 로 주석 설정, ctrl + K, ctrl + U 로 주석 해제
        // 각 항목 경로 설정 필요
    }
}
