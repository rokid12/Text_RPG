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

            while (true)
            {
                Console.WriteLine("\n회복");
                Console.WriteLine($"{ItemManager.potion.itemDescription} ( 남은 포션 : {GameManager.Instance.player.GetPotion()} )");
                Console.WriteLine("\n1. 사용하기");
                Console.WriteLine("0. 나가기");

                switch (InputManager.PickNumber(1, 0))
                {
                    case 0:
                        UIManager.Instance.ShowMainMenu();
                        return;
                    case 1:
                        GameManager.Instance.player.PotionFinder().UsingPotion();
                        break;
                }
            }
        }
    }
}
