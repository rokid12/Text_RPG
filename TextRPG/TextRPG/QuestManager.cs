using TextRPG;

class QuestManager
{
    public static List<Quest> questList = new List<Quest>();
    private static List<Quest> acceptedQuests = new List<Quest>();
    public static void Show()
    {

        while (true)
        {
            Console.Clear();
            Console.WriteLine("\n안녕하세요. 모험가 길드입니다. ");
            Console.WriteLine("퀘스트를 완료하시면 경험치를 드립니다. \n");
            Console.WriteLine("1. 퀘스트 받기");
            Console.WriteLine("2. 받은 퀘스트 보기");
            Console.WriteLine("0. 나가기\n");
            Console.Write("행동하려면 번호를 입력하세요. >> ");

            string input = Console.ReadLine();

            if (input == "0")
                return;

            else if (input == "1")
                ReceiveQuestMenu();

            else if (input == "2")
                ShowAcceptedQuests();
        }
    }


    private static void ReceiveQuestMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("\n수령 가능한 퀘스트 목록:\n");

            for (int i = 0; i < questList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {questList[i].Title} - {questList[i].Description}");
            }

            Console.WriteLine("0. 돌아가기");
            Console.Write("\n퀘스트 번호 선택: ");
            string input = Console.ReadLine();

            if (input == "0")
                break;

            if (int.TryParse(input, out int questIndex) &&
                questIndex >= 1 && questIndex <= questList.Count)
            {
                Quest selectedQuest = questList[questIndex - 1];

                acceptedQuests.Add(selectedQuest);
                Console.WriteLine($"'{selectedQuest.Title}' 퀘스트를 수령했습니다!");
                questList.Remove(selectedQuest);

                /* // 퀘스트 목록 개선으로 중복수령 자체가 불가하므로 주석처리 
                아래 코드는 혹시모를 반복 퀘스트를 위해 남겨둠 (예정에 없다면 삭제)

                if (!acceptedQuests.Contains(selectedQuest))
                {
                    acceptedQuests.Add(selectedQuest);
                    Console.WriteLine($"'{selectedQuest.Title}' 퀘스트를 수령했습니다!");
                    questList.Remove(selectedQuest);
                }
                else
                {
                    Console.WriteLine("이미 수령한 퀘스트입니다.");
                }*/

                Console.WriteLine("아무 키나 누르면 계속...");
                Console.ReadKey();
            }
        }
    }
    private static void ShowAcceptedQuests()
    {
        Console.Clear();
        Console.WriteLine("\n수령한 퀘스트 목록:\n");

        if (acceptedQuests.Count == 0)
        {
            Console.WriteLine("\n수령한 퀘스트가 없습니다.\n");
        }
        else
        {
            for (int i = 0; i < acceptedQuests.Count; i++)
            {
                var q = acceptedQuests[i];
                string status = q.IsCompleted ? (q.IsRewardGiven ? "완료됨" : "보상 대기") : "진행 중";
                Console.WriteLine($"{i + 1}. {q.Title} - {q.CurrentKillCount}/{q.GoalKillCount} ({status})");
            }

            Console.Write("\n보상을 받을 퀘스트 번호를 입력하세요 (0: 뒤로가기): ");
            string rewardInput = Console.ReadLine();
            if (int.TryParse(rewardInput, out int rewardIndex) &&
                rewardIndex >= 1 && rewardIndex <= acceptedQuests.Count)
            {
                Quest quest = acceptedQuests[rewardIndex - 1];

                if (quest.IsCompleted && !quest.IsRewardGiven)
                {
                    GameManager.Instance.player.exp += quest.RewardExp;
                    GameManager.Instance.player.gold += quest.RewardGold;
                    GameManager.Instance.player.LevelUp();

                    quest.IsRewardGiven = true;

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"[보상 지급] EXP: {quest.RewardExp}, GOLD: {quest.RewardGold}");
                    Console.ResetColor();

                    acceptedQuests.Remove(quest);
                }
                
                else
                {
                    Console.WriteLine("아직 완료되지 않은 퀘스트입니다.");
                }
            }
        }

        Console.WriteLine("아무 키나 누르면 돌아갑니다.");
        Console.ReadKey();
    }

    public static void RegisterKill(string monsterName)
    {
        foreach (Quest quest in acceptedQuests)
        {
            if (!quest.IsCompleted && quest.TargetMonsterName == monsterName)
            {
                quest.AddKill();

                Console.WriteLine($"[퀘스트 진행] '{quest.Title}' {quest.CurrentKillCount}/{quest.GoalKillCount}");

                if (quest.IsCompleted)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"\n[퀘스트 완료] '{quest.Title}' - 퀘스트 완료!");
                    Console.WriteLine($"→ 보상은 퀘스트 메뉴에서 수령할 수 있습니다.\n");
                    Console.ResetColor();
                }
            }
        }
    }
}