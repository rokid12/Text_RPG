using TextRPG;
using System;
using TextRPG.BattleSystem;

namespace TextRPG
{
    class UIManager
    {
        private static UIManager _instance;
        public static UIManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UIManager();
                return _instance;
            }
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
                Console.WriteLine("<< 상태 보기 >>\n");

                var player = GameManager.Instance.player;

                Console.WriteLine($"이름     : {player.name}");
                Console.WriteLine($"직업     : {player.job}");
                Console.WriteLine($"레벨     : {player.level}");
                Console.WriteLine($"체력     : {player.hp} / {player.totalHp}");
                Console.WriteLine($"마나     : {player.mp}");
                Console.WriteLine($"공격력   : {player.atk} + {player.equipAtk} = {player.totalAtk}");
                Console.WriteLine($"방어력   : {player.def} + {player.equipDef} = {player.totalDef}");
                Console.WriteLine($"소지금   : {player.gold} G");
                Console.WriteLine($"포션 개수: {player.GetPotion()}개");

                Console.WriteLine("\n[장착 중인 장비]");
                if (player.equippedWeapon != null)
                {
                    Console.Write("무기 - ");
                    player.equippedWeapon.ItemInformation();
                }
                else Console.WriteLine("무기 - 없음");

                if (player.equippedArmor != null)
                {
                    Console.Write("방어구 - ");
                    player.equippedArmor.ItemInformation();
                }
                else Console.WriteLine("방어구 - 없음");

                Console.WriteLine("\n1. 인벤토리 보기 및 장착");
                Console.WriteLine("0. 나가기");
                Console.Write(">> ");
                string input = Console.ReadLine() ?? "";

                if (input == "0") break;
                else if (input == "1") player.ShowInventory();
                else Console.WriteLine("잘못된 입력입니다.");

                Console.WriteLine("\n아무 키나 누르면 계속...");
                Console.ReadKey();
            }
        }
    }
}