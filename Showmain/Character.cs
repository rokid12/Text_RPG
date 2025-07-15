namespace GameCharacter
{
    public class Character
    {
        public string Name { get; private set; }
        public string Job { get; private set; }
        public int Level { get; private set; }
        public int Attack { get; private set; }
        public int Defense { get; private set; }
        public int MaxHp { get; private set; }
        public int Gold { get; private set; }

        private List<Item> inventory = new List<Item>
        {
            new Item("강철 검", "Attack", 5, "공격력 +5"),
            new Item("가죽 갑옷", "Defense", 3, "방어력 +3")
        };

        public List<Item> GetInventory()
        {
            return inventory;
        }

        public Character(string name = "Chad", string job = "전사", int level = 1, int attack = 10, int defense = 5, int maxHp = 100, int gold = 1500)
        {
            Name = name;
            Job = job;
            Level = level;
            Attack = attack;
            Defense = defense;
            MaxHp = maxHp;
            Gold = gold;
        }

        public void ShowStatus()
        {
            Console.WriteLine($"\nLv. {Level:00}");
            Console.WriteLine($"{Name} ( {Job} )");
            Console.WriteLine($"공격력 : {TotalAttack} (기본 {Attack})");
            Console.WriteLine($"방어력 : {TotalDefense} (기본 {Defense})");
            Console.WriteLine($"체력 : {MaxHp}");
            Console.WriteLine($"Gold : {Gold} G");

            Console.WriteLine("\n[장착 아이템]");
            foreach (var item in inventory.Where(i => i.IsEquipped))
            {
                Console.WriteLine($"- {item.Name} (+{item.Value} {item.Type})");
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
                    Console.WriteLine($"{i + 1}. {item.Name} ({item.Type}) +{item.Value} - {item.Description} {(item.IsEquipped ? "[장착 중]" : "")}");
                }

                Console.WriteLine("\n0. 나가기");
                Console.Write("장착할 아이템 번호를 입력해주세요.: ");
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

                Console.WriteLine("아무 키나 누르면 계속...");
                Console.ReadKey();
            }
        }

        public int TotalAttack
        {
            get
            {
                return Attack + inventory
                    .Where(item => item.IsEquipped && item.Type == "Attack")
                    .Sum(item => item.Value);
            }
        }

        public int TotalDefense
        {
            get
            {
                return Defense + inventory
                    .Where(item => item.IsEquipped && item.Type == "Defense")
                    .Sum(item => item.Value);
            }
        }
    }
}