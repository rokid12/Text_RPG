using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    public static class SkillManager
    {
        public static Skill bite = new Skill("물기", 10, 15);
        public static Skill cannon = new Skill("대포발사", 20, 40);
        //public static Skill raisethorn = new Skill("가시 돋히기", 5, 20);
        //public static Skill javelin = new Skill("투창", 10, 30);
        //public static Skill counterattack = new Skill("반격", 15, 50);
    }
}
