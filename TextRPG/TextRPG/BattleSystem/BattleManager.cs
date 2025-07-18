using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG.BattleSystem
{
    /// <summary>
    /// 배틀 매니저 사용방법
    /// BattleManager.Instance.StartBattle(싸움에 참여할 아군 리스트, 싸움에 참여할 적 리스트);
    /// 
    /// 이거 쓰면 바로 전투 시작함
    /// 현재 버전에서는 보상 따로 없고 
    /// </summary>
    internal class BattleManager
    {
        private static BattleManager _instance = null;

        public static BattleManager Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new BattleManager();
                }

                return _instance;
            }
        }

        // 실제 전투를 발생시키는 함수, 승리/패배를 bool값으로 반환함
        public bool StartBattle(List<Character> allies, List<Monster> enemies)
        {
            Battle battle = new Battle(allies, enemies);
            return battle.ExecuteBattle();
        }

        // 배틀이 제대로 되는 지 확인하기 위한 함수
        // 그냥 메인에서 Battle.Instance.DebugBattleSystem(); 복붙해서 쓰면 전투 기능 확인 가능함
        public void DebugBattleSystem()
        {
            List<Character> characters = new List<Character>();
            List<Monster> monsters = new List<Monster>();

            characters.Add(new Character("르탄", 10, 5, 100, 100, 1, 0, "전사", 1000));
            monsters.Add(new Monster("공허충", 2, 3, 20, 10, 1, ItemData.Instance.steelArmor, 5, 100, SkillManager.bite));
            monsters.Add(new Monster("공허충", 2, 3, 20, 10, 1, ItemData.Instance.steelArmor, 5, 100, SkillManager.bite));

            Battle battle = new Battle(characters, monsters);
            battle.ExecuteBattle();
        }
    }
}
