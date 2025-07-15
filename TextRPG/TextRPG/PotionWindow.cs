using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal class PotionWindow
    {
        public static void Show()
        {
            Console.Clear();
            Console.WriteLine("회복");
            Console.WriteLine($"{ItemManager.potion.itemDescription} ( 남은 포션 : {ItemManager.potion.itemCount} )"); 
            // 남은 포션 > 인벤토리로 경로 설정 변경 필요
            
            while (true)
            {
                Console.WriteLine("\n1. 사용하기");
                Console.WriteLine("0. 나가기");

                switch (InputManager.PickNumber(1, 0))
                {
                    case 0:
                        return;
                    case 1:
                        if (ItemManager.potion.itemCount < 1) // 인벤토리로 경로 설정 필요
                        {
                            Console.WriteLine("\n포션이 부족합니다.");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("\n포션 사용 완료");
                            //ItemManager.potion.UsingPotion();
                            break;
                        }
                }
            }
        }
    }
}
