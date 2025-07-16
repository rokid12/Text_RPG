using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    public class Skill
    {
        public string skillName;
        public int MpCost;
        public int Damage;

        public Skill(string name, int mpCost, int damage)
        {
            skillName = name;
            MpCost = mpCost;
            Damage = damage;
        }

        public void UseSkill(Unit user, Unit target)
        {
            if(user.mp < MpCost)
            {
                Console.WriteLine($"{user.name}의 마나가 부족합니다.");
                return;
            }
            else
            {
                user.mp -= MpCost;
                Console.WriteLine($"{user.name}이(가) {skillName}을 사용했습니다.");

                target.TakeDamage(Damage);
            }
        }
    }
}
