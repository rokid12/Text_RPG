using System;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG;

namespace TextRPG
{
    //유닛
    public abstract class Unit
    {
        public string name;
        public int atk;
        public int def;
        public int maxHp;
        public int hp;
        public int maxMp;
        public int mp;
        public int level;

        public List<Skill> skills = new List<Skill>();  // 스킬 리스트

        public int totalAtk;
        public int totalDef;
        public int totalHp;

        //생성자
        public Unit(string name, int atk, int def, int maxHp, int maxMp, int level)
        {
            this.name = name;
            this.atk = atk;
            this.def = def;
            this.maxHp = maxHp;
            this.hp = maxHp;
            this.maxMp = maxMp;
            this.mp = 0;
            this.level = level;

            totalAtk = atk;
            totalDef = def;
            totalHp = maxHp;
        }

        //스킬 보유 여부
        public void UseSkill(Skill skill, Unit target)
        {
            if (!skills.Contains(skill))
            {
                Console.WriteLine("사용할 수 없는 스킬입니다.");
                return;
            }
            skill.UseSkill(this, target);
        }

        //공격
        public void Attack(Unit target)
        {
            Console.WriteLine($"{name}이(가) {target.name}을(를) 공격하였습니다.");
            target.TakeDamage(totalAtk);
        }

        //피격
        public void TakeDamage(int trueatk)
        {
            int damage = trueatk - totalDef;
            if (totalDef >= trueatk)
            {
                damage = 0;
                Console.WriteLine("Miss");
            }
            else
            {
                hp -= damage;
                if (hp <= 0)
                {
                    hp = 0;
                }
                Console.WriteLine($"{name}이(가) {damage} 데미지를 입었습니다. (남은 Hp : {hp})");
            }
        }

        //마나소비
        public void UseMp(int mp)
        {
            if (mp <= 0)
            {
                Console.WriteLine("마나가 부족합니다.");
            }
        }


        //마나재생
        public void MpRegen()
        {
            int regen = 5;
            mp += regen;

            if (mp > maxMp)
                mp = maxMp;
            Console.WriteLine($"{name}의 (현재 MP : {mp} / {maxMp})");
        }
    }
    //캐릭터
    class Character : Unit
    {
        public int exp;
        public string job;
        public int gold;

        public int equipAtk;
        public int equipDef;
        public int equipHp;

        //장착
        public Items equippedWeapon;
        public Items equippedArmor;

        public List<Items> GetInventory()
        {
            return inventory;
        }

        public ItemPotion PotionFinder()
        {
            var findPotion = GetInventory().Find(item => item.itemName == "포션") as ItemPotion;
            return findPotion;
        }

        public int GetPotion()
        {
            int potionCount;

            if (PotionFinder() != null)
            {
                return potionCount = PotionFinder().itemCount;
            }
            else
            {
                return potionCount = 0;
            }
        }
        public void AddItem(Items name)
        {
            inventory.Add(name);
        }

        public void ShowStatus()
        {
            Console.WriteLine($"\nLv. {level:00}");
            Console.WriteLine($"{name}");
            Console.WriteLine($"체력 : {hp}");
            Console.WriteLine($"Gold : {gold} G");

            Console.WriteLine("\n[장착중인 장비]");
            foreach (var item in inventory)
            {
                if (item.isEquipped)
                {
                    Console.Write(" - ");
                    item.ItemInformation();
                    Console.WriteLine();
                }
            }
        }

        public void ShowInventory()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("[ 인벤토리 ]");

                if (inventory.Count == 0)
                {
                    Console.WriteLine("보유한 아이템이 없습니다.");
                    break;
                }

                for (int i = 0; i < inventory.Count; i++)
                {
                    var item = inventory[i];
                    Console.Write($"{i + 1}. ");
                    item.ItemInformation();
                }

                Console.WriteLine("\n0. 나가기");
                Console.Write("장착할 아이템 번호를 입력해주세요: ");
                string input = Console.ReadLine() ?? "";

                if (input == "0")
                    break;

                if (int.TryParse(input, out int index) && index >= 1 && index <= inventory.Count)
                {
                    EquipManager.Instance.EquipItem(index - 1);
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                }

                Console.WriteLine("\n아무 키나 누르면 계속...");
                Console.ReadKey();
            }
        }

        //인벤토리 리스트
        public static List<Items> inventory = new List<Items>();
        //캐릭터 생성자
        public Character(string name, int atk, int def, int maxHp, int maxMp, int level, int exp, string job, int gold)
        : base(name, atk, def, maxHp, maxMp, level)
        {
            this.exp = exp;
            this.job = job;
            this.gold = gold;
        }

        public void LevelUp()
        {   //레벨당 경험치가 가득찼을때
            while (true)                    //while로 2렙업 가능하게
            {
                int CharacterExp = level * 5;     // 경험치통 렙당 렙*5
                if (exp >= CharacterExp)
                {
                    level++;
                    atk += 2;
                    def += 2;
                    hp += 5;
                    mp += 5;
                    exp -= CharacterExp;

                    Console.WriteLine($"{name}이(가) 레벨업했습니다. 레벨 : {level}");
                }
                else
                {
                    break;
                }
            }
           
        }
        //장착시 스탯
        public void EquipmentStat()
        {
            equipAtk = 0;
            equipDef = 0;
            equipHp = 0;

            if (equippedWeapon != null)
            {
                equipAtk += equippedWeapon.itemAttack;
                equipDef += equippedWeapon.itemArmor;
                equipHp += equippedWeapon.itemHealth;
            }
            if (equippedArmor != null)
            {
                equipAtk += equippedArmor.itemAttack;
                equipDef += equippedArmor.itemArmor;
                equipHp += equippedArmor.itemHealth;
            }

            totalAtk = atk + equipAtk;
            totalDef = def + equipDef;
            totalHp = maxHp + equipHp;
        }
    }
}

    //몬스터
    class Monster : Unit
    {
        public Items dropItem;
        public int dropExp;
        public int dropGold;
        public Skill skill;

        // 몬스터 배열
        public static Monster[] MonsterArray;

    //몬스터 생성자
    public Monster(string name, int atk, int def, int maxHp, int maxMp, int level, Items dropItem, int dropExp, int dropGold, Skill skill)
    : base(name, atk, def, maxHp, maxHp, level)
    {
        this.dropItem = dropItem;
        this.dropExp = dropExp;
        this.dropGold = dropGold;
        this.skill = skill; 
    }

    //몬스터 복사 생성자
    public Monster(Monster original)
    : base(original.name, original.atk, original.def, original.maxHp, original.maxMp, original.level)
    {
        this.dropItem = original.dropItem;
        this.dropExp = original.dropExp;
        this.dropGold = original.dropGold;
        this.skill = original.skill;

        this.maxHp = original.maxHp;
    }


    // 몬스터 정보
    public static void MonsterInfo()
        {
            MonsterArray = new Monster[]
            {
                new Monster("미니언", 5, 0, 15, 15, 2, ItemManager.oldSword, 2, 5, null),
                new Monster("공허충", 9, 2, 10, 10, 3, ItemManager.usefulShield, 3, 10, SkillManager.bite),
                new Monster("대포미니언", 8, 5, 15, 20, 5, ItemManager.steelArmor, 5, 20, SkillManager.cannon)
                //,new Monster("람머스"), 10, 30, 30, 30, 8, ItemManager.thornMail, 10, 500, SkillManager.raisethorn)
                //,new Monster("판테온"), 25, 25, 40, 30, 10, ItemManager.spartaArmor, 15, 1000, SkillManager.javelin)
                //,new Monster("잭시무스"), 33, 33, 53, 30, 15, ItemManager.trinityForce, 20, 2000, SkillManager.counterattack)
            };
        }
    }