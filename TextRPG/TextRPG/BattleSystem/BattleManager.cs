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

        public void StartBattle(List<Character> allies, List<Monster> enemies)
        {
            Battle battle = new Battle(allies, enemies);
            battle.ExecuteBattle();
        }
    }
}
