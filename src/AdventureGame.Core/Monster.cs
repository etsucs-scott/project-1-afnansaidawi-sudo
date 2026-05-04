using System;

namespace AdventureGame.Core
{
    public class Monster : ICharacter
    {
        private const int BaseDamage = 10;
        private static Random _random = new Random();

        /// <summary>
        /// Gets the current health points of the player.
        /// </summary>
        /// <value>
        /// An integer representing the player's remaining health. 
        /// Health decreases when the player takes damage and increases when healing.
        /// </value>
        public int Health { get; private set; }
        public bool IsAlive => Health > 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="Monster"/> class.
        /// </summary>
        public Monster()
        {
            Health = _random.Next(30, 51);
        }

        /// <summary>
        /// Gets the attack damage of the monster.
        /// </summary>
        /// <returns>
        /// An integer representing the monster's base damage for an attack.
        /// </returns>
        public int Attack()
        {
            return BaseDamage;
        }

        /// <summary>
        /// Reduces the monster's health by the specified damage amount.
        /// </summary>
        /// <param name="damage">The amount of damage to apply to the monster.</param>
        public void TakeDamage(int damage)
        {
            Health -= damage;

            if (Health < 0)
                Health = 0;
        }
    }
}
