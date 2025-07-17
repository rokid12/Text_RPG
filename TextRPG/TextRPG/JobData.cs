using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    class JobData
    {
        public static Job Warrior = new Job(5, 5, 100, 60, "전사");
        public static Job Archor = new Job(7, 4, 80, 80, "궁수");
        public static Job Mage = new Job(10, 2, 60, 150, "마법사");
    }

    struct Job
    {
        public int _atk;
        public int _def;
        public int _maxHp;
        public int _maxMp;
        public string _jobName;

        public Job(int atk, int def, int maxHp, int maxMp, string jobName)
        {
            _atk = atk;
            _def = def;
            _maxHp = maxHp;
            _maxMp = maxMp;
            _jobName = jobName;
        }
    }
}
