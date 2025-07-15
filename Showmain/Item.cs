namespace GameCharacter
{
    public class Item
    {
        public string Name { get; private set; }
        public string Type { get; private set; }
        public int Value { get; private set; }
        public string Description { get; private set; }
        public bool IsEquipped { get; set; }

        public Item(string name, string type, int value, string description)
        {
            Name = name;
            Type = type;
            Value = value;
            Description = description;
            IsEquipped = false;
        }
    }
}