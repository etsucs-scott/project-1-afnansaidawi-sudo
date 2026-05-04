namespace AdventureGame.Core
{
    public class Weapon : Item
    {
        /// <summary>
        /// Gets the attack bonus provided by the weapon.
        /// </summary>
        /// <value>
        /// An integer representing how much the weapon increases the player's base damage when equipped.
        /// </value>
        public int AttackModifier { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Weapon"/> class with a specified name and attack modifier.
        /// </summary>
        /// <param name="name">The name of the weapon.</param>
        /// <param name="attackModifier">The attack bonus this weapon provides.</param>
        public Weapon(string name, int attackModifier)
            : base(name, $"You picked up a {name}!")
        {
            AttackModifier = attackModifier;
        }
    }
}
