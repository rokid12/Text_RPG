using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    class Job
    {
        public int Atk { get; }
        public int Def { get; }
        public int MaxHp { get; }
        public int MaxMp { get; }
        public string JobName { get; }

        public Job(int atk, int def, int maxHp, int maxMp, string jobName)
        {
            Atk = atk;
            Def = def;
            MaxHp = maxHp;
            MaxMp = maxMp;
            JobName = jobName;
        }
    }

    class JobData
    {
        public static Dictionary<JobType, Job> Jobs = new Dictionary<JobType, Job>()
        {
            { JobType.Warrior, new Job(5, 5, 100, 60, "전사") },
            { JobType.Archer,  new Job(7, 4, 80, 80, "궁수") },
            { JobType.Mage,    new Job(10, 2, 60, 150, "마법사") }
        };
    }

    enum JobType { Warrior, Archer, Mage }

}
