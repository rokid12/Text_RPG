using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    public class Unit
    {
        public string Name;
        public int Atk;
        public int Def;
        public int HP;
        public int Level;
        public int Mp;


        public class Character : Unit
        {
            public float Exp;
            public string Job;
            public string Inventory;
            public int Gold;

            Items <Inventory>
        }

        public class Monster : Unit
        {
            public string DropItem;
            public int DropExp;
            public int DropGold;
        }
    }
}