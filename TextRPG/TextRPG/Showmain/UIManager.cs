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
★──────────────────────────────────────────────★
       Role Playing Legends 에 오신 여러분,
                    환영합니다!
★──────────────────────────────────────────────★";

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
                Thread.Sleep(20);//타이핑속도
            }

            Console.WriteLine();
            Console.ResetColor();
        }

        public void ShowMainMenu()
        {
            while (true)
            {
                Console.Clear();

                // 환영 문구
                Console.WriteLine("");
                Console.WriteLine("이곳에서 던전에 들어가기 전");
                Console.WriteLine("행동을 할 수 있습니다. \n");

                // 메뉴 출력
                Console.WriteLine("1. 상태 보기");
                Console.WriteLine("2. 전투 시작");
                Console.WriteLine("3. 회복 아이템");
                Console.WriteLine("4. 퀘스트");
                Console.WriteLine();

                // 아스키 아트 출력
                string[] cat = new string[]
                {
"                                                   |--__",
"                                                   |",
"                                                   X",
"                                          |-___   /        |--__",
"                                          |      =====      |",
"                                          X      | .:|      X",
"                                         /      | O |     / \\\\",
"                                        =====   |:  . |   =====",
"                                        |.: |__| .   : |__| :.|",
"                                        |  :|. :  ...   : |.  |",
"                                __   __W| .    .  ||| .      :|W__--",
"                             -- __ W  WWWW______'''______WWWW   W -----  --",
"                          -  -___---    ____     ____------__  -",
"                              --__----__     -___        __-   _",

                };


                ConsoleColor[] colors = new ConsoleColor[]
                {
                    ConsoleColor.Yellow,
                    ConsoleColor.DarkYellow,
                    ConsoleColor.White,
                    ConsoleColor.Gray,
                    ConsoleColor.DarkGray,
                    ConsoleColor.Cyan,
                    ConsoleColor.Magenta,
                    ConsoleColor.Blue,
                    ConsoleColor.Green
                };


                int startX = Console.WindowWidth - 25;
                int startY = (Console.WindowHeight - cat.Length) / 2;

                for (int i = 0; i < cat.Length; i++)
                {
                    if (startX >= 0 && startY + i < Console.WindowHeight)
                    {
                        Console.SetCursorPosition(startX, startY + i);
                        Console.ForegroundColor = colors[i % colors.Length]; // 각 줄에 색 지정
                        Console.WriteLine(cat[i]);
                    }
                }
                Console.ResetColor();

                Console.SetCursorPosition(0, startY + cat.Length + 2);
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
                    continue;
                }
                else if (input == "4")
                {
                    QuestManager.Show();
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    Console.WriteLine("아무 키나 누르면 계속...");
                    Console.ReadKey();
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