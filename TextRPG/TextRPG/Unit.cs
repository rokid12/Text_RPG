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
        public int Mp;
        public int Level;


        //생성자
        public Unit(string name, int atk, int def, int hp, int mp, int level)
        {
            Name = name;
            Atk = atk;
            Def = def;
            HP = hp;
            Mp = mp;
            Level = level;
        }

        //공격
        public void Attack(Unit target)
        {
            Console.WriteLine($"{Name}이(가) {target.Name}을(를) 공격하였습니다.");
            target.TakeDamage(Atk);
        }

        //피격
        public void TakeDamage(int atk)
        {
            TakeDamage = Atk - Def;
            Console.WriteLine($"{Name}이(가) {TakeDamage} 데미지를 입었습니다.")
        }

    }

        public class Character : Unit
        {
            public int Exp;
            public string Job;
            public string Inventory;
            public int Gold;

            public static List<Inventory> item = new List<Inventory>();

            public Character(string name, int atk, int def, int hp, int mp, int level, int exp, string job, int gold)
            :base(name, atk, def, hp, mp, level)   
            {
                Exp = exp;
                Job = job;
                Gold = gold;
            }

            public void LevelUp()
            {   //레벨당 경험치가 가득찼을때
                if(Exp = )
                {
                    Level++;
                    Atk = +2;
                    Def = 
                    HP =
                    Mp =
                    Exp = 0;
                }
            }
        }

        public class Monster : Unit
        {
            public string DropItem;
            public int DropExp;
            public int DropGold;

            // 몬스터 배열
            public static Monster[] MonsterArray;

            // 생성자
            public Monster(string name, int atk, int def, int hp, int mp, int level, string dropItem, int dropExp, int dropGold)
            : base(name, atk, def, hp, mp, level)
            {
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
}