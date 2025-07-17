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
            while (true)
            {
                Console.Clear();

                Console.WriteLine("\n회복");
                Console.WriteLine($"{ItemManager.potion.itemDescription} ( 남은 포션 : {GameManager.Instance.player.GetPotion()} )");
                Console.WriteLine("\n1. 사용하기");
                Console.WriteLine("0. 나가기");

                switch (InputManager.PickNumber(1, 0))
                {
                    case 0:
                        return; // 여기서 끝내고, 메인 메뉴는 호출한 쪽에서 실행
                    case 1:
                        if (GameManager.Instance.player.PotionFinder() != null)
                        {
                            Console.Clear();
                            GameManager.Instance.player.PotionFinder().UsingPotion();
                            Console.WriteLine("\n아무 키나 누르면 계속...");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("\n포션이 부족합니다.");
                            Console.WriteLine("아무 키나 누르면 계속...");
                            Console.ReadKey();
                        }
                        break;
                }
            }
        }

    }
}
