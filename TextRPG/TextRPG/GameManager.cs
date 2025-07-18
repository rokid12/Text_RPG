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
            Console.Write("이름을 입력해주세요.\n>> ");
            string name;

            while(true)
            {
                name = Console.ReadLine();
                if(name == null || name == "\n" || name == "")
                {
                    Console.SetCursorPosition(Console.CursorLeft + 3, Console.CursorTop - 1);
                    continue;
                }
                name = name.Trim();
                break;
            }

            // 직업 선택?
            Console.WriteLine("\n1. 전사\n2. 궁수\n3. 마법사\n");
            //Console.Write("\n직업을 선택해주세요.\n>> ");

            int choice = InputManager.PickNumber(3, 1);
            switch(choice)
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
            }

            player.AddItem(ItemData.Instance.trinityForce);
            player.AddItem(ItemData.Instance.potion);

            Console.WriteLine("\n캐릭터 생성에 성공하였습니다!\n계속하시려면 아무 키나 눌러주세요...");
            Console.ReadKey();
        }
    }
}
