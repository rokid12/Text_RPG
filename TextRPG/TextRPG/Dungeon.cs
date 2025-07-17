using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal class Dungeon
    {
        int curFloor; // 던전의 현재 층수
        int maxFloor;// 던전 최대 층수

        
        List<Monster> monsterDB; // 던전에서 출현 가능한 몬스터 리스트
        List<List<Monster>> monsterList; // 층마다 등장 가능한 몬스터 리스트
        List<Pair> monsterNumList; // 층마다 등장 가능한 몬스터의 최소/최대 수

        private List<Character> _allies; // 던전에 입장한 캐릭터 리스트

        public Dungeon(Character character)
        {
            _allies = new List<Character>();
            _allies.Add(character);
            curFloor = 1;
            maxFloor = 3;

            InitDungeon();
        }

        public Dungeon(List<Character> characters)
        {
            _allies = characters;
            curFloor = 1;
            maxFloor = 3;

            InitDungeon();
        }

        public void ShowDungeonUI() // 던전 입장 UI 표시
        {
            while(true)
            {
                Console.Clear();
                ShowDungeonInfo();

                Console.WriteLine("\n1. 던전에 입장한다.\n0. 돌아간다.");
                Console.WriteLine("\n행동을 입력하세요.");
                Console.Write(">> ");

                int choice;
                while (true)
                {
                    string input = Console.ReadLine();
                    if (int.TryParse(input, out choice))
                    {
                        if (choice == 0)
                        {
                            Console.Clear();
                            return;
                        }
                        if (choice == 1)
                        {
                            if (_allies[0].hp <= 0) // 현재 플레이어는 한 명이니까 첫번째 캐릭터로 확인
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\n체력이 부족하여 던전에 입장할 수 없습니다.");
                                Console.ResetColor();
                                Console.SetCursorPosition(Console.CursorLeft + 3, Console.CursorTop - 3);
                                continue;
                            }
                            else
                            {
                                EnterDungeonFloor();
                                break;
                            }
                             
                        }
                    }
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n잘못된 입력입니다.");
                    Console.ResetColor();
                    Console.SetCursorPosition(Console.CursorLeft + 3, Console.CursorTop - 3);
                }
            }
        }

        private void ShowDungeonInfo() // 현재 층수에 대한 던전 정보표시
        {
            // 현재 층수
            Console.WriteLine($"현재 층수 : {curFloor}층");
            // 현재 층에서 등장가능한 몬스터 이름
            Console.Write("등장하는 몬스터 목록 : ");
            for(int i=0; i<monsterList[curFloor-1].Count;i++)
            {
                Console.Write($"{monsterList[curFloor-1][i].name}");
                if(i < monsterList[curFloor - 1].Count - 1)
                    Console.Write(", ");
            }
            Console.WriteLine();
            // 현재 층에서 등장가능한 몬스터 수
            Console.WriteLine($"등장 가능한 몬스터 수 : {monsterNumList[curFloor-1].first} ~ {monsterNumList[curFloor-1].second}");
        }

        private void EnterDungeonFloor() // 현재 층 입장 함수
        {
            // 현재 층에서 나오는 몬스터 정보를 바탕으로 몬스터 리스트 생성
            List<Monster> _monsters = new List<Monster>();

            Random rand = new Random();

            int monsterNum = rand.Next(monsterNumList[curFloor - 1].first, monsterNumList[curFloor - 1].second + 1);

            for(int i=0;i<monsterNum;i++)
            {
                int t = rand.Next(0, monsterList[curFloor - 1].Count);
                // 몬스터 복사 생성자 필요함
                Monster tmpMst = new Monster(monsterList[curFloor - 1][t]);
                _monsters.Add(tmpMst);
                //_monsters.Add(new Monster(tmpMst.name, tmpMst.atk, tmpMst.def, tmpMst.maxHp, tmpMst.mp, tmpMst.level, tmpMst.dropItem, tmpMst.dropExp, tmpMst.dropGold));
            }

            bool isWin = BattleSystem.BattleManager.Instance.StartBattle(_allies, _monsters);

            if(isWin && curFloor < maxFloor)
            {
                curFloor++;
            }
        }

        public int GetDungeonFloor() => curFloor;

        private void InitDungeon() // 던전 정보 초기화 함수
        {
            monsterDB = new List<Monster>();
            monsterList = new List<List<Monster>>();
            monsterNumList = new List<Pair>();

            // 던전 출현 몬스터 설정
            monsterDB.Add(new Monster("미니언", 5, 0, 15, 10, 2, ItemManager.oldSword, 2, 5, null));
            monsterDB.Add(new Monster("공허충", 9, 2, 10, 10, 3, ItemManager.usefulShield, 3, 10, SkillManager.bite));
            monsterDB.Add(new Monster("대포미니언", 8, 5, 25, 20, 5, ItemManager.steelArmor, 5, 20, SkillManager.cannon));

            // 각 층마다 출현 가능한 몬스터 설정
            monsterList.Add(new List<Monster>() { monsterDB[0], monsterDB[1] });
            monsterList.Add(new List<Monster>() { monsterDB[1], monsterDB[2] });
            monsterList.Add(new List<Monster>() { monsterDB[0], monsterDB[1], monsterDB[2] });

            // 각 층마다 출현 가능한 몬스터의 최소/최대 수 설정
            monsterNumList.Add(new Pair(1, 2));
            monsterNumList.Add(new Pair(2, 3));
            monsterNumList.Add(new Pair(3, 3));
        }
    }

    struct Pair // 구조체
    {
        public int first;
        public int second;

        public Pair(int first, int second)
        {
            this.first = first;
            this.second = second;
        }
    }
}
