using TextRPG;
using System;
using TextRPG.BattleSystem;
using System.Threading;

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
            string text = @"
★────────────────────────────★
       스파르타 던전에 오신
       여러분, 환영합니다!
★────────────────────────────★";

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

            Quest.Initialize(); // 퀘스트 리셋

            for (int i = 0; i < text.Length; i++)
            {
                Console.ForegroundColor = rainbowColors[i % rainbowColors.Length];
                Console.Write(text[i]);
                Thread.Sleep(20);//타이핑속도
            }

            Console.WriteLine();
            Console.ResetColor();
        }

        public void ShowMainMenu()
        {
            while (true)
            {
                Console.WriteLine("　");
                Console.WriteLine("1. 상태 보기");
                Console.WriteLine("2. 전투 시작");
                Console.WriteLine("3. 회복 아이템");
                Console.WriteLine("4. 퀘스트(test)"); //퀘스트 테스트메뉴
                Console.WriteLine("　");
                Console.Write("원하시는 행동을 입력해주세요.>> ");
                
                string input = Console.ReadLine() ?? "";

                if (input == "1")
                {
                    ShowStatus();
                }
                else if (input == "2")
                {
                    Console.WriteLine("이제 전투를 시작할 수 있습니다.");
                    GameManager.Instance.GetDungeon().ShowDungeonUI();
                }
                else if (input == "3")
                {
                    PotionWindow.Show();
                    break;
                }
                else if (input == "4")
                {
                    QuestManager.Show();
                    // 퀘스트메뉴에서 나오면 메인으로 못돌아와서 break; 제거함
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

                GameManager.Instance.player.ShowStatus();

                Console.WriteLine("1. 인벤토리 보기 및 장착");
                Console.WriteLine("0. 나가기");
                Console.Write(">> ");
                string input = Console.ReadLine() ?? "";

                if (input == "0")
                {
                    break;
                }
                else if (input == "1")
                {
                    GameManager.Instance.player.ShowInventory();
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