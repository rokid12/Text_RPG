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

        private GameManager()
        {
            CharacterMaking();
            dungeon = new Dungeon(player);
        }

        public Dungeon GetDungeon() => dungeon;

        private void CharacterMaking()
        {
            Console.Write("이름을 입력해주세요.\n>> ");
            string name = Console.ReadLine();

            // 직업 선택?
            Console.WriteLine("\n1. 전사\n2. 궁수\n3. 마법사\n");
            //Console.Write("\n직업을 선택해주세요.\n>> ");

            int choice = InputManager.PickNumber(3, 1);
            switch(choice)
            {
                case 1:
                    player = new Character(name, JobData.Warrior._atk, JobData.Warrior._def, JobData.Warrior._maxHp, JobData.Warrior._maxMp, 1, 0, JobData.Warrior._jobName, 1000);
                    break;
                case 2:
                    player = new Character(name, JobData.Archor._atk, JobData.Archor._def, JobData.Archor._maxHp, JobData.Archor._maxMp, 1, 0, JobData.Archor._jobName, 1000);
                    break;
                case 3:
                    player = new Character(name, JobData.Mage._atk, JobData.Mage._def, JobData.Mage._maxHp, JobData.Mage._maxMp, 1, 0, JobData.Mage._jobName, 1000);
                    break;
            }

            Console.WriteLine("\n캐릭터 생성에 성공하였습니다!\n계속하시려면 아무 키나 눌러주세요...");
            Console.ReadKey();
        }
    }
}
