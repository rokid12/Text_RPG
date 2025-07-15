using TextRPG;
using System;
using TextRPG.BattleSystem;

namespace TextRPG
{
    class UIManager
    {
        private Character character;

        public UIManager(Character character)
        {
            this.character = character;
        }

        public void ShowIntro()
        {
            Console.Clear();
            string text = "스파르타 던전에 오신 여러분 환영합니다.";

            ConsoleColor[] rainbowColors = new ConsoleColor[]
            {
                ConsoleColor.Red,
                ConsoleColor.DarkYellow,
                ConsoleColor.Yellow,
                ConsoleColor.Green,
                ConsoleColor.Blue,
                ConsoleColor.DarkBlue,
                ConsoleColor.Magenta
            };

            for (int i = 0; i < text.Length; i++)
            {
                Console.ForegroundColor = rainbowColors[i % rainbowColors.Length];
                Console.Write(text[i]);
            }

            Console.WriteLine();
            Console.ResetColor();
        }

        public void ShowMainMenu()
        {
            while (true)
            {
                Console.WriteLine("\n1. 상태 보기");
                Console.WriteLine("2. 전투 시작");
                Console.WriteLine("3. 회복 아이템");
                Console.Write("\n원하시는 행동을 입력해주세요.\n>> ");
                string input = Console.ReadLine() ?? "";

                if (input == "1")
                {
                    ShowStatus();
                }
                else if (input == "2")
                {
                    Console.WriteLine("\n이제 전투를 시작할 수 있습니다.");
                    BattleManager.Instance.DebugBattleSystem();
                    break;
                }
                else if (input == "3")
                {
                    PotionWindow.Show();
                    break;
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                }
            }
        }

        public void ShowStatus()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("상태 보기");

                character.ShowStatus();

                Console.WriteLine("\n1. 인벤토리 보기 및 장착");
                Console.WriteLine("0. 나가기");
                Console.Write(">> ");
                string input = Console.ReadLine() ?? "";

                if (input == "0")
                {
                    break;
                }
                else if (input == "1")
                {
                    character.ShowInventory();
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                }

                Console.WriteLine("\n아무 키나 누르면 계속...");
                Console.ReadKey();
            }
        }
    }
}