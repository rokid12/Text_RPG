using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG.BattleSystem
{
    internal class Battle
    {
        // 플레이어 정보
        // 적 정보
        private List<Character> _allies;
        private List<Monster> _enemies;
        private Queue<Unit> _turnQueue;
        private Queue<Unit> _tempTurnQueue;

        private int _curTrun;

        public Battle(List<Character> allies, List<Monster> enemies)
        {
            _allies = allies;
            _enemies = enemies;

            _turnQueue = new Queue<Unit>();
            _tempTurnQueue = new Queue<Unit>();

            _curTrun = 0;

            foreach (Character character in _allies) // 전투에 참여하는 모든 인원을 턴큐에 삽입(아군->적 순서)
            {
                _turnQueue.Enqueue(character);
            }
            foreach (Monster monster in _enemies)
            {
                _turnQueue.Enqueue(monster);
            }
        }

        public void ExecuteBattle()
        {
            Console.WriteLine("전투 시작!");

            while (true)
            {
                Console.WriteLine($"\n현재 턴: {++_curTrun}");

                while(_turnQueue.Count > 0)
                {
                    Unit current = _turnQueue.Dequeue();
                    if (current.HP <= 0) // 사망한 인원은 제외
                        continue;

                    if (_allies.Contains(current))
                        PlayerTurn((Character)current, _enemies);
                    else
                        EnemyTurn((Monster)current, _allies);

                    if (CheckAllDead(_enemies.Cast<Unit>().ToList())) // 적 패배
                    {
                        // 승리 화면 표시
                    }
                    else if (CheckAllDead(_allies.Cast<Unit>().ToList())) // 플레이어 패배
                    {
                        // 패배 화면 표시
                    }

                    _tempTurnQueue.Enqueue(current);
                }
                
                while(_tempTurnQueue.Count > 0)
                {
                    _turnQueue.Enqueue(_tempTurnQueue.Dequeue());
                }

            }
        }

        private void PlayerTurn(Character player, List<Monster> enemies)
        {
            Console.WriteLine($"{player.Name}의 턴입니다.");
            Console.WriteLine("공격할 적을 선택하세요:");

            for (int i = 0; i < enemies.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {enemies[i].Name} (HP: {enemies[i].HP})");
            }

            int choice = int.Parse(Console.ReadLine()) - 1;
            player.Attack(enemies[choice]);
        }

        private void EnemyTurn(Monster enemy, List<Character> allies)
        {
            Unit? target = allies.FirstOrDefault();
            if (target != null)
            {
                Console.WriteLine($"{enemy.Name}이 {target.Name}을 공격합니다.");
                enemy.Attack(target);
            }
        }

        private bool CheckAllDead(List<Unit> units)
        {
            bool isAllDead = true;
            foreach(Unit unit  in units)
            {
                if(unit.HP > 0)
                {
                    isAllDead = false;
                    break;
                }
            }

            return isAllDead;
        }

        private void ShowWinUI()
        {
            Console.Clear();
            Console.WriteLine("승리하였습니다.");
        }

        private void ShowLoseUI()
        {
            Console.Clear();
            Console.WriteLine("패배하였습니다.");
        }
    }
}

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
        int TakeDamage = Atk - Def;
        Console.WriteLine($"{Name}이(가) {TakeDamage} 데미지를 입었습니다.");
    }

}

public class Character : Unit
{
    public int Exp;
    public string Job;
    public string Inventory;
    public int Gold;

    //public static List<Inventory> item = new List<Inventory>();

    public Character(string name, int atk, int def, int hp, int mp, int level, int exp, string job, int gold)
    : base(name, atk, def, hp, mp, level)
    {
        Exp = exp;
        Job = job;
        Gold = gold;
    }

    public void LevelUp()
    {   //레벨당 경험치가 가득찼을때

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