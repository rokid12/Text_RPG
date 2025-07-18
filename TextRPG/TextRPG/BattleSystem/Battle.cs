using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG.BattleSystem
{
    internal class Battle
    {
        // 플레이어&적 정보
        private List<Character> _allies; // 파티 기능을 추가할 수 있기에, 일단 리스트로 생성은 해둠
        private List<Monster> _enemies;

        private Queue<Unit> _turnQueue; // 각 유닛들이 행동하는 순서를 담는 큐
        private Queue<Unit> _tempTurnQueue; // 임시로 이곳에 넣고 다음 라운드에서 다시 큐에 넣음

        // 해당 전투 보상 리스트
        private int rewardExp = 0;
        private int rewardGold = 0;
        private List<Items> rewardItems = new List<Items>();

        private int _curTrun; // 현재 턴수, 나중에 턴 제한 같은 기능 고려해서 넣음

        public bool isAct = false; // 캐릭터의 행동 여부를 담는 변수, 만약 파티 시스템을 넣으면 캐릭터가 갖게 만들어야 함

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

        public bool ExecuteBattle()
        {
            while (true)
            {
                while (_turnQueue.Count > 0) // 턴 큐에 담긴 모든 Unit들의 턴 진행
                {
                    Unit current = _turnQueue.Dequeue();
                    if (current.hp <= 0) // 사망한 인원의 차례는 제외
                        continue;

                    current.MpRegen();

                    if (_allies.Contains(current))
                        PlayerTurn((Character)current, _enemies);
                    else
                        EnemyTurn((Monster)current, _allies);

                    if (CheckAllDead(_enemies.Cast<Unit>().ToList())) // 적 패배
                    {
                        // 승리 화면 표시
                        ShowWinUI();
                        return true;
                    }
                    else if (CheckAllDead(_allies.Cast<Unit>().ToList())) // 플레이어 패배
                    {
                        // 패배 화면 표시
                        ShowLoseUI();
                        return false;
                    }

                    _tempTurnQueue.Enqueue(current);
                }
                Console.WriteLine("\n다음으로 넘어가려면 아무 키나 입력하세요...");
                Console.ReadKey();

                // 임시 큐에 있던 순서를 다시 턴큐에 삽입
                while (_tempTurnQueue.Count > 0)
                {
                    _turnQueue.Enqueue(_tempTurnQueue.Dequeue());
                }
            }
        }

        private void PlayerTurn(Character player, List<Monster> enemies)
        {
            while (!isAct) // 행동하지 않았으면 반복
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Battle!!\n");
                Console.ResetColor();

                //Console.WriteLine($"{player.name}의 턴입니다."); // 일단 미관상 주석처리

                for (int i = 0; i < enemies.Count; i++)
                {
                    if (enemies[i].hp <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine($"Lv.{enemies[i].level} {enemies[i].name} Dead");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write("Lv.");
                        ColoredWrite($"{enemies[i].level} ", ConsoleColor.Red);
                        Console.Write($"{enemies[i].name} HP ");
                        ColoredWrite($"{enemies[i].hp}", ConsoleColor.Red);
                        Console.Write(" MP ");
                        ColoredWrite($"{enemies[i].mp}\n", ConsoleColor.Blue);
                    }
                }

                Console.WriteLine("\n[내정보]");
                Console.Write("Lv.");
                ColoredWrite($"{player.level} ", ConsoleColor.Red);
                Console.Write($"{player.name} ({player.job})\nHP ");
                ColoredWrite($"{player.hp}", ConsoleColor.Red);
                Console.Write(" / ");
                ColoredWrite($"{player.maxHp}\n", ConsoleColor.Red);
                Console.Write("MP ");
                ColoredWrite($"{player.mp}", ConsoleColor.Blue);
                Console.Write(" / ");
                ColoredWrite($"{player.maxMp}\n", ConsoleColor.Blue);
                Console.WriteLine();

                ColoredWrite("1", ConsoleColor.Red);
                Console.WriteLine(". 공격");
                Console.WriteLine("\n원하시는 행동을 입력해주세요.");
                Console.Write(">> ");

                int choice;
                while (true)
                {
                    string input = Console.ReadLine();
                    if (int.TryParse(input, out choice))
                    {
                        if (choice == 1)
                        {
                            AttackCommand(player, enemies);
                            break;
                        }
                    }
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n잘못된 입력입니다.");
                    Console.ResetColor();
                    Pair originPos = new Pair(Console.CursorLeft + 3, Console.CursorTop - 3);
                    Console.SetCursorPosition(originPos.first, originPos.second);
                    Console.Write(new string(' ', Console.WindowWidth));
                    Console.SetCursorPosition(originPos.first, originPos.second);
                }
            }
            isAct = false;
        }

        private void EnemyTurn(Monster enemy, List<Character> allies)
        {
            Unit? target = allies.FirstOrDefault();
            if (target == null)
                return;
            if (enemy.skill != null && enemy.mp >= enemy.skill.mpCost)
            {
                Console.WriteLine($"{enemy.name}이(가) {enemy.skill.skillName}을(를) 사용합니다!!");
                enemy.UseSkill(enemy.skill, target);
            }
            else
            {
                Console.WriteLine($"{enemy.name}이(가) {target.name}을(를) 공격합니다."); // 이거 필요없으면 주석 처리해도 되요
                enemy.Attack(target);
            }
        }


        private void AttackCommand(Character player, List<Monster> enemies)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Battle!!\n");
            Console.ResetColor();

            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i].hp <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine($"{i + 1}. Lv.{enemies[i].level} {enemies[i].name} Dead");
                    Console.ResetColor();
                }
                else
                {
                    ColoredWrite($"{i + 1} ", ConsoleColor.Cyan);
                    Console.Write("Lv.");
                    ColoredWrite($"{enemies[i].level} ", ConsoleColor.Red);
                    Console.Write($"{enemies[i].name} HP ");
                    ColoredWrite($"{enemies[i].hp}", ConsoleColor.Red);
                    Console.Write(" ");
                    Console.Write(" MP ");
                    ColoredWrite($"{enemies[i].mp}\n", ConsoleColor.Blue);
                }
                //Console.WriteLine($"Lv.{enemies[i].level} {enemies[i].name} HP {enemies[i].hp}");
            }

            Console.WriteLine("\n[내정보]");
            Console.Write("Lv.");
            ColoredWrite($"{player.level} ", ConsoleColor.Red);
            Console.Write($"{player.name} ({player.job})\nHP ");
            ColoredWrite($"{player.hp}", ConsoleColor.Red);
            Console.Write(" / ");
            ColoredWrite($"{player.maxHp}\n", ConsoleColor.Red);
            Console.Write("MP ");
            ColoredWrite($"{player.mp}", ConsoleColor.Blue);
            Console.Write(" / ");
            ColoredWrite($"{player.maxMp}\n", ConsoleColor.Blue);
            Console.WriteLine();

            ColoredWrite("0", ConsoleColor.Red);
            Console.WriteLine(". 취소\n");

            Console.Write("대상을 선택해주세요.\n>> ");
            int choice;
            while (true)
            {
                string input = Console.ReadLine(); // 죽은 적 선택 못하게 막을 필요 있음
                if (int.TryParse(input, out choice))
                {
                    if (choice == 0)
                        return;
                    if (choice >= 1 && choice <= enemies.Count)
                    {
                        if (enemies[choice - 1].hp > 0)
                            break;
                    }
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n잘못된 입력입니다.");
                Console.ResetColor();
                Pair originPos = new Pair(Console.CursorLeft + 3, Console.CursorTop - 3);
                Console.SetCursorPosition(originPos.first, originPos.second);
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(originPos.first, originPos.second);
            }
            Console.WriteLine();
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, Console.CursorTop);
            player.Attack(enemies[choice - 1]);
            if (enemies[choice - 1].hp <= 0) //몬스터가 죽었는지 확인
            {
                QuestManager.RegisterKill(enemies[choice - 1].name); // 정확한 몬스터 이름을 퀘스트에 전달
            }
            isAct = true;
            Console.WriteLine();
        }

        private bool CheckAllDead(List<Unit> units) // 아군 또는 적이 전멸했는지 확인하는 함수
        {
            bool isAllDead = true;
            foreach (Unit unit in units)
            {
                if (unit.hp > 0)
                {
                    isAllDead = false;
                    break;
                }
            }

            return isAllDead;
        }

        private void ShowWinUI() // 승리 시 보여줄 UI
        {
            MyDelay(1500);
            Console.Clear();
            Console.WriteLine("승리하였습니다.\n");

            RewardCheck();

            Console.WriteLine("\n3초 뒤에 던전으로 돌아갑니다...");
            MyDelay(3000);
        }

        private void ShowLoseUI() // 패배 시 보여줄 UI
        {
            MyDelay(1500);
            Console.Clear();
            Console.WriteLine("패배하였습니다.");

            Console.WriteLine("\n3초 뒤에 던전으로 돌아갑니다...");
            MyDelay(3000);
        }

        private void RewardCheck() // 보상 정리 및 플레이어에게 추가
        {
            foreach (Monster monster in _enemies)
            {
                rewardExp += monster.dropExp;
                rewardGold += monster.dropGold;
                Random random = new Random(); // 이거 랜덤도 그냥 특정 클래스 하나 만들어서 유틸함수로 쓰면 편할듯
                int itemDropChance = random.Next(0, 100);
                if(itemDropChance < 60) // 아이템 클래스 상태가 애매해서 일단 장비만 추가되도록 구현
                {
                    ItemEquipable temp;
                    if (monster.dropItem.GetType() == typeof(ItemEquipable))
                    {
                        temp = new ItemEquipable((ItemEquipable)monster.dropItem);
                        rewardItems.Add(temp);
                    }
                }

                QuestManager.RegisterKill(monster.name); //퀘스트 관련 메뉴 (몬스터 상태 호출)
            }
            Console.WriteLine($"경험치 {rewardExp}를 얻었습니다!");
            Console.WriteLine($"{rewardGold} 골드를 얻었습니다!");
            for (int i = 0; i < rewardItems.Count; i++)
            {
                _allies[0].AddItem(rewardItems[i]);
                Console.WriteLine($"{rewardItems[i].itemName}을(를) 획득하였습니다!");
            }
            Console.WriteLine();

            // 실제 아이템&보상 획득 기능
            // 현재는 플레이어 한명만 있으므로 한명에게만 보상 부여
            _allies[0].gold += rewardGold;
            _allies[0].AddExp(rewardExp);

            // 아이템 리스트로 보상 아이템 획득 기능 구현 필요
        }

        void MyDelay(int ms) // 딜레이용으로 만든 함수
        {
            Thread.Sleep(ms);
        }

        void ColoredWrite(string text, ConsoleColor color) // 글자 색 입히는 함수
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ResetColor();
        }
    }
}