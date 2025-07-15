using System;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG;

namespace TextRPG
{     
    //유닛
    public class Unit
    {
        public string Name;
        public int Atk;
        public int Def;
        public int Hp;
        public int Mp;
        public int Level;

        public int TotalAtk;
        public int TotalDef;
        public int TotalHp;


        //생성자
        public Unit(string name, int atk, int def, int hp, int mp, int level)
        {
            Name = name;
            Atk = atk;
            Def = def;
            Hp = hp;
            Mp = mp;
            Level = level;
        }

        //공격
        public void Attack(Unit target)
        {
            Console.WriteLine($"{Name}이(가) {target.Name}을(를) 공격하였습니다.");
            target.TakeDamage(TotalAtk);
        }

        //피격
        public void TakeDamage(int trueatk)
        {
            int damage = trueatk - TotalDef;
            if (TotalDef >= trueatk)
                damage = 0;
            Console.WriteLine("Miss");
            Hp -= damage;
            if (Hp <= 0)
                Hp = 0;
            Console.WriteLine($"{Name}이(가) {damage} 데미지를 입었습니다. (남은 Hp : {Hp})");
        }

        //마나소비
        public void UseMp (int mp)
        {
            if (Mp <= 0)
            {
                Console.WriteLine("마나가 부족합니다.");
            }
        }

    }
    //캐릭터
    public class Character : Unit
    {
        public int Exp;
        public string Job;
        public int Gold;

        public int EquipAtk;
        public int EquipDef;
        public int EquipHp;

        public Items itemAttack;
        public Items itemArmor;          //아이템에서 가져오기
        public Items itemHealth;

        //장착
        public Items EquippedWeapon;
        public Items EquippedArmor;

        public void Equipment(Items item)
        {
            if (item == null)
            {
                Console.WriteLine("장착할 아이템이 없습니다.");
                return;
            }
                
            switch (item.itemType)
            {
                case 0:
                    EquippedWeapon = item;
                    Console.WriteLine($"{item.itemName}을(를) 장착했습니다.");
                    break;
                case 1:
                    EquippedArmor = item;
                    Console.WriteLine($"{item.itemName}을(를) 장착했습니다.");
                    break;
                default :
                    Console.WriteLine("잘못된 장착입니다.");
                    break;
            }

            EquipmentStat();      //스탯 업데이트
        }
        //인벤토리 리스트
        public static List<Items> Inventory = new List<Items>();
        //캐릭터 생성자
        public Character(string name, int atk, int def, int hp, int mp, int level, int exp, string job, int gold)
        :base(name, atk, def, hp, mp, level)   
        {
            Exp = exp;
            Job = job;
            Gold = gold;
        }

        public void LevelUp()
        {   //레벨당 경험치가 가득찼을때
            int CharacterExp = Level * 5;
            if (Exp >= CharacterExp)
            {
                Level++;
                Atk += 2;
                Def += 2;
                Hp += 5;
                Mp += 5;
                Exp -= CharacterExp;

                Console.WriteLine($"{Name}이(가) 레벨업했습니다. 레벨 : {Level}");
            }
        }
        //장착시 스탯
        public void EquipmentStat()
        {
            EquipAtk = 0;
            EquipDef = 0;
            EquipHp = 0;

            if (EquippedWeapon != null)
            {
                EquipAtk += EquippedWeapon.itemAttack;
                EquipDef += EquippedWeapon.itemArmor;
                EquipHp += EquippedWeapon.itemHealth;
            }
            if (EquippedArmor != null)
            {
                EquipAtk += EquippedArmor.itemAttack;
                EquipDef += EquippedArmor.itemArmor;
                EquipHp += EquippedArmor.itemHealth;
            }

            TotalAtk = Atk + EquipAtk;
            TotalDef = Def + EquipDef;
            TotalHp = Hp + EquipHp;
        }
    }
    //몬스터
    public class Monster : Unit
    {
        public string DropItem;
        public int DropExp;
        public int DropGold;

        // 몬스터 배열
        public static Monster[] MonsterArray;

        //몬스터 생성자
        public Monster(string name, int atk, int def, int hp, int mp, int level, string dropItem, int dropExp, int dropGold)
        : base(name, atk, def, hp, mp, level)
        {
            DropItem = dropItem;
            DropExp = dropExp;
            DropGold = dropGold;
        }
        // 몬스터 정보
        public static void MonsterInfo()
        {
            MonsterArray = new Monster[]
            {
                new Monster("미니언", 5, 0, 15, 10, 2, "", 2, 5),
                new Monster("공허충", 9, 2, 10, 10, 3, "", 3, 10),
                new Monster("대포미니언", 8, 5, 25, 20, 5, "", 5, 20)
                //,new Monster("협곡의 전령"), 15,
            };
        }
    }
}