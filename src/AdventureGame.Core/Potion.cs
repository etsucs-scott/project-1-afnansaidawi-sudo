namespace AdventureGame.Core
{
    public class Potion : Item
    {
        public int HealAmount { get; }

        public Potion(string name, int healAmount)
            : base(name, $"You used a {name} and gained health!")
        {
            HealAmount = healAmount;
        }
    }
}
