using TextRPG;

    namespace TextRPG
    {
        public class Character
        {
            public string Name { get; private set; }
            public int Level { get; private set; }
            public int MaxHp { get; private set; }
            public int Gold { get; private set; }

        private List<Items> inventory = new List<Items>();

        public Character(string name = "서란", int level = 1, int maxHp = 100, int gold = 1500)
        {
            Name = name;
            Level = level;
            MaxHp = maxHp;
            Gold = gold;

            inventory.Add(new Items.Weapon("롱소드", "기본 공격 무기", 10));
            inventory.Add(new Items.Shield("나무 방패", "튼튼한 나무 방패", 5));
            inventory.Add(new Items.Armor("가죽 갑옷", "얇지만 유연한 방어구", 3));
        }

        public List<Items> GetInventory()
        {
            return inventory;
        }

            public void ShowStatus()
            {
                Console.WriteLine($"\nLv. {Level:00}");
                Console.WriteLine($"{Name}");
                Console.WriteLine($"체력 : {MaxHp}");
                Console.WriteLine($"Gold : {Gold} G");

                Console.WriteLine("\n[장착중인 장비]");
                foreach (var item in inventory)
                {
                    if (item.isEquipped)
                    {
                        Console.Write($" - ");
                        item.ItemInformation();
                        Console.WriteLine();
                    }
                }
            }

            public void ShowInventory()
            {
                EquipManager equipManager = new EquipManager(this);

                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("[ 인벤토리 ]");

                    if (inventory.Count == 0)
                    {
                        Console.WriteLine("보유한 아이템이 없습니다.");
                        break;
                    }

                    for (int i = 0; i < inventory.Count; i++)
                    {
                        var item = inventory[i];
                        Console.Write($"{i + 1}. ");
                        item.ItemInformation();
                        Console.WriteLine(item.isEquipped ? " [장착 중]" : "");
                    }

                    Console.WriteLine("\n0. 나가기");
                    Console.Write("장착할 아이템 번호를 입력해주세요: ");
                    string input = Console.ReadLine() ?? "";

                    if (input == "0")
                        break;

                    if (int.TryParse(input, out int index) && index >= 1 && index <= inventory.Count)
                    {
                        equipManager.EquipItem(index - 1);
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다.");
                    }

                    Console.WriteLine("\n아무 키나 누르면 계속...");
                    Console.ReadKey();
                }
            }
        }
    }