using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal class DungeonData
    {
        public List<Monster> MonsterDB { get; private set; }
        public List<List<Monster>> MonsterList { get; private set; }
        public List<Pair> MonsterNumList { get; private set; }

        public int MaxFloor => MonsterList.Count;

        public DungeonData()
        {
            MonsterDB = new List<Monster>();
            MonsterList = new List<List<Monster>>();
            MonsterNumList = new List<Pair>();

            InitDungeonData();
        }

        private void InitDungeonData()
        {
            // 던전 출현 몬스터 설정
            MonsterDB.Add(new Monster("미니언", 5, 0, 15, 10, 2, ItemManager.oldSword, 2, 5, null));
            MonsterDB.Add(new Monster("공허충", 9, 2, 10, 10, 3, ItemManager.usefulShield, 3, 10, SkillManager.bite));
            MonsterDB.Add(new Monster("대포미니언", 8, 5, 25, 20, 5, ItemManager.steelArmor, 5, 20, SkillManager.cannon));

            // 층별 몬스터 구성
            MonsterList.Add(new List<Monster>() { MonsterDB[0], MonsterDB[1] });                   // 1층
            MonsterList.Add(new List<Monster>() { MonsterDB[1], MonsterDB[2] });                   // 2층
            MonsterList.Add(new List<Monster>() { MonsterDB[0], MonsterDB[1], MonsterDB[2] });     // 3층

            // 층별 몬스터 수 범위
            MonsterNumList.Add(new Pair(1, 2));
            MonsterNumList.Add(new Pair(2, 3));
            MonsterNumList.Add(new Pair(3, 3));
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
