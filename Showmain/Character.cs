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
            Console.WriteLine($"공격력 : {Attack}");
            Console.WriteLine($"방어력 : {Defense}");
            Console.WriteLine($"체력 : {MaxHp}");
            Console.WriteLine($"Gold : {Gold} G");
        }
    }
}
