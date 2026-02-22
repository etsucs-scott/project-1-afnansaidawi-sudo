namespace AdventureGame.Core
{
    public class Weapon : Item
    {
        public int AttackModifier { get; }

        public Weapon(string name, int attackModifier)
            : base(name, $"You picked up a {name}!")
        {
            AttackModifier = attackModifier;
        }
    }
}
