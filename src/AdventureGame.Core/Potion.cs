namespace AdventureGame.Core
{
    public class Potion : Item
    {
        /// <summary>
        /// Gets the amount of health restored by the potion.
        /// </summary>
        /// <value>
        /// An integer representing how many health points the potion restores when used.
        /// </value>
        public int HealAmount { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Potion"/> class with a specified name and healing amount.
        /// </summary>
        /// <param name="name">The name of the potion.</param>
        /// <param name="healAmount">The amount of health this potion restores when used.</param>
        public Potion(string name, int healAmount)
            : base(name, $"You used a {name} and gained health!")
        {
            HealAmount = healAmount;
        }
    }
}
