using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal class GameManager
    {
        private static GameManager _instance;
        public static GameManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new GameManager();
                return _instance;
            }
        }

        public Character player;
        private Dungeon dungeon;

        public Dungeon GetDungeon() => dungeon;

        public void InitGameManager()
        {
            CharacterMaking();
            Quest.Initialize(); // 퀘스트 리셋
            dungeon = new Dungeon(player);
        }

        private void CharacterMaking()
        {
            Console.Clear();
            Console.Write("이름을 입력해주세요.\n>> ");
            string name;

            while (true)
            {

                name = Console.ReadLine();
                if (name == null || name == "\n" || name == "")
                {
                    Console.SetCursorPosition(Console.CursorLeft + 3, Console.CursorTop - 1);
                    continue;
                }
                name = name.Trim();
                break;
            }

            
            JobSelect();
            
            while (true)
            {
                Console.Write("\n원하는 직업을 선택해주세요.\n>> ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int selectedNumber))
                {
                    switch (selectedNumber)
                    {
                        case 1:
                            player = new Character(name, JobData.Jobs[JobType.Warrior]);
                            break;
                        case 2:
                            player = new Character(name, JobData.Jobs[JobType.Archer]);
                            break;
                        case 3:
                            player = new Character(name, JobData.Jobs[JobType.Mage]);
                            break;
                        default:
                            Console.Clear();
                            JobSelect();
                            Console.WriteLine("\n잘못된 입력입니다.");
                            break;
                    }

                    if (player != null)
                    {
                        Console.Clear();
                        player.AddItem(ItemData.Instance.oldSword);
                        player.AddItem(ItemData.Instance.trinityForce);
                        player.AddItem(ItemData.Instance.potion);
                        Console.WriteLine("캐릭터 생성에 성공하였습니다!");
                        Console.WriteLine($"\n이름 : {name}");
                        Console.WriteLine($"직업 : {player.job}");
                        Console.WriteLine("\n계속하려면 아무 키나 눌러주세요...");
                        Console.ReadKey();
                        return;
                    }
                }
                else
                {
                    Console.Clear();
                    JobSelect();
                    Console.WriteLine("\n잘못된 입력입니다.");
                }
            }
        }

        private void JobSelect()
        {
            Console.Clear();
            Console.WriteLine($"직업 선택");
            Console.WriteLine("\n1. 전사\n2. 궁수\n3. 마법사");
        }
    }
}
