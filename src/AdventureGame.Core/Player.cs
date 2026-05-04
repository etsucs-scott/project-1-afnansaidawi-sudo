using System;
using System.Collections.Generic;

namespace AdventureGame.Core
{
    public class Player : ICharacter
    {
        private const int BaseDamage = 10;
        private const int MaxHealth = 150;

        /// <summary>
        /// Gets the current health points of the player.
        /// </summary>
        /// <value>
        /// An integer representing the player's remaining health. 
        /// The value decreases when taking damage and may increase when using healing items.
        /// </value>
        public int Health { get; private set; }
        public bool IsAlive => Health > 0;

        public List<Weapon> Inventory { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Player"/> class.
        /// </summary>
        /// <remarks>
        /// Sets the player's <see cref="Health"/> to 100 and initializes an empty
        /// <see cref="Inventory"/> of weapons.
        /// </remarks>
        public Player()
        {
            Health = 100;
            Inventory = new List<Weapon>();
        }

        /// <summary>
        /// Calculates the player's total attack damage for a turn.
        /// </summary>
        /// <returns>
        /// An integer representing the total damage dealt by the player, 
        /// which is the sum of the <see cref="BaseDamage"/> and the highest 
        /// <see cref="Weapon.AttackModifier"/> among the player's inventory.
        /// </returns>
        public int Attack()
        {
            int bestModifier = 0;

            foreach (var weapon in Inventory)
            {
                if (weapon.AttackModifier > bestModifier)
                    bestModifier = weapon.AttackModifier;
            }

            return BaseDamage + bestModifier;
        }

        /// <summary>
        /// Reduces the player's health by the specified damage amount.
        /// </summary>
        /// <param name="damage">The amount of damage to apply to the player.</param>
        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health < 0)
                Health = 0;
        }

        /// <summary>
        /// Increases the player's health by the specified amount.
        /// </summary>
        /// <param name="amount">The amount of health to restore.</param>
        public void Heal(int amount)
        {
            Health += amount;
            if (Health > MaxHealth)
                Health = MaxHealth;
        }
    }
}
