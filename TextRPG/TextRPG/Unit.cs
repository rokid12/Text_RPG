using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG;

namespace TextRPG
{
    public class Unit
    {
        public string Name;
        public int Atk;
        public int Def;
        public int HP;
        public int Level;
        public int Mp;
    }

    public class Character : Unit
        {
            public int Exp;
            public string Job;
            public string Inventory;
            public int Gold;

            public static List<Inventory> item = new List<Inventory>();
        }

        public class Monster : Unit
        {
            public string DropItem;
            public int DropExp;
            public int DropGold;

            // 몬스터 배열
            public static Monster[] MonsterArray;

            // 생성자
            public Monster(string name, int atk, int def, int hp, int level, int mp, string dropItem, int dropExp, int dropGold)
            {
                Name = name;
                Atk = atk;
                Def = def;
                HP = hp;
                Level = level;
                Mp = mp;
                DropItem = dropItem;
                DropExp = dropExp;
                DropGold = dropGold;

            }
            
            public static void MonsterInfo()
            {
            MonsterArray = new Monster[]
        {
            new Monster("미니언", 5, 0, 15, 2, 10, "", 2, 5),
            new Monster("공허충", 9, 2, 10, 3, 10, "", 3, 10),
            new Monster("대포미니언", 8, 5, 25, 5, 20, "", 5, 20)
        };
        }
}