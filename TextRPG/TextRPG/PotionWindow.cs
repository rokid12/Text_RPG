using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace TextRPG
{
    internal class PotionWindow
    {
        static void ShowUi()
        {
            var player = GameManager.Instance.player;

            Console.WriteLine("회복");
            Console.WriteLine($"포션을 {ItemData.Instance.potion.itemDescription}");
            Console.WriteLine();
            Console.WriteLine($"남은 포션 : {player.GetPotion()}");
            Console.WriteLine($"체력 : {player.hp} / {player.maxHp}");
            Console.WriteLine();
            Console.WriteLine("1. 사용하기");
            Console.WriteLine("0. 나가기");
        }

        public static void Show()
        {
            Console.Clear();

            var player = GameManager.Instance.player;

            ShowUi();

            while (true)
            {
                Console.WriteLine("\n원하시는 행동을 입력해주세요.");
                Console.Write(">>");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int selectedNumber))
                {
                    switch (selectedNumber)
                    {
                        case 0:
                            Console.Clear();
                            return;
                        case 1:
                            if (player.PotionFinder() != null)
                            {
                                if (player.maxHp > player.hp)
                                {
                                    var potionFinder = player.PotionFinder();
                                    Console.Clear();
                                    potionFinder.UsingPotion();
                                    ShowUi();
                                    Console.WriteLine();
                                    Console.WriteLine("포션을 사용했습니다.");
                                    potionFinder.PotionPotency();
                                }
                                else
                                {
                                    Console.Clear();
                                    ShowUi();
                                    Console.WriteLine();
                                    Console.WriteLine($"체력이 이미 모두 회복되었습니다.");
                                }
                            }
                            else
                            {
                                Console.Clear();
                                ShowUi();
                                Console.WriteLine();
                                Console.WriteLine("포션이 부족합니다.");
                            }
                            break;
                        default:
                            Console.Clear();
                            ShowUi();
                            Console.WriteLine("\n잘못된 입력입니다.");
                            break;
                    }
                }
                else
                {
                    Console.Clear();
                    ShowUi();
                    Console.WriteLine("\n잘못된 입력입니다.");
                }
            }
        }
    }
}