using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG.BattleSystem
{
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
