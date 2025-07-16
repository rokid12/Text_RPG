using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TextRPG;

public class Quest
{
    public string Title { get; set; }
    public string Description { get; set; }
    public int GoalKillCount { get; set; }
    public int CurrentKillCount { get; set; }
    public int RewardExp { get; set; }
    public int RewardGold { get; set; }
    public bool IsCompleted => CurrentKillCount >= GoalKillCount;

    public bool IsRewardGiven { get; set; } = false;

    public void AddKill()
    {
        if (!IsCompleted)
            CurrentKillCount++;
    }

    public static void Initialize()
    {
        if (QuestManager.questList.Count == 0) // 중복 방지
        {
            QuestManager.questList.Add
                (

                    new Quest
                    {
                        Title = "공허충 1마리 처치",
                        Description = "공허충을 1마리 사냥하면 보상이 주어집니다.",
                        GoalKillCount = 1,
                        RewardExp = 30,
                        RewardGold = 100
                    }
                );

            QuestManager.questList.Add
                (

                    new Quest
                    {
                        Title = "미니언 1마리 처치",
                        Description = "미니언을 1마리 사냥하면 보상이 주어집니다.",
                        GoalKillCount = 1,
                        RewardExp = 30,
                        RewardGold = 100
                    }
                );

        }
    }
}

