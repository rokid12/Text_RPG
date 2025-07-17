using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG;

namespace TextRPG
{
    public class Skill
    {
        public string skillName;
        public int mpCost;
        public int damage;

        public Skill(string name, int mpCost, int damage)
        {
            skillName = name;
            this.mpCost = mpCost;
            this.damage = damage;
        }

        public void UseSkill(Unit user, Unit target)
        {
            if(user.mp < mpCost)
            {
                Console.WriteLine($"{user.name}의 마나가 부족합니다.");
                return;
            }
            else
            {
                user.mp -= mpCost;
                Console.WriteLine($"{user.name}이(가) {skillName}을(를) 사용했습니다.");

                Random random = new Random();
                int skillDamage = damage;
                int critical = random.Next(0, 100);
                if (critical < 30)
                {
                    Console.WriteLine("치명타!!");
                    skillDamage = damage * 3 / 2;
                }

                target.TakeDamage(skillDamage, isSkill : true);
            }
        }
    }
}
