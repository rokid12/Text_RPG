using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal class Potion : Items
    {
        public int itemCount = 0; // 포션 갯수
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
        //        inventory.itemCount -= 1;
        //    }
        //}
        // ctrl + K, ctrl + C 로 주석 설정, ctrl + K, ctrl + U 로 주석 해제
        // 각 항목 경로 설정 필요
    }
}
