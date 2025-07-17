using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal class GameManager
    {
        private static GameManager _instance;
        public static GameManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new GameManager();
                return _instance;
            }
        }

        public Character player;
        private Dungeon dungeon;

        private GameManager()
        {
            player = new Character("rtan", 5, 5, 100, 100, 1, 0, "전사", 1000);
            dungeon = new Dungeon(player);
        }

        public Dungeon GetDungeon() => dungeon;
    }
}
