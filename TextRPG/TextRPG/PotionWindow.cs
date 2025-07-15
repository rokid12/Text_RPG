using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal class PotionWindow
    {
        public void Show()
        {
            Console.Clear();
            Console.WriteLine("회복");
            Console.WriteLine($"포션을 사용하면 체력을 30 회복할 수 있습니다. (남은 포션 : {ItemManager.potion.itemCount}"); // 인벤토리로 경로 설정 변경 필요
            Console.WriteLine();
            Console.WriteLine("1. 사용하기");
            Console.WriteLine("0. 나가기");

            switch (InputManager.PickNumber(1, 0))
            {
                case 0:
                    //기본 맵
                    return;
                case 1:
                    //ItemManager.potion.UsingPotion();
                    return;
            }
                
                
        }
    }
}
