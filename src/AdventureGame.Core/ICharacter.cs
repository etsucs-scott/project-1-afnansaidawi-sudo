using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureGame.Core
{
    internal interface ICharacter
    {
        /// <summary>
        /// Gets the current health points of the character.
        /// </summary>
        int Health { get; }

        /// <summary>
        /// Gets a value indicating whether the character is alive.
        /// </summary>
        bool IsAlive { get; }

        /// <summary>
        /// Calculates and returns the attack damage of the character.
        /// </summary>
        /// <returns>An integer representing the damage dealt by the character.</returns>
        int Attack();

        /// <summary>
        /// Reduces the character's health by the specified damage amount.
        /// </summary>
        /// <param name="damage">The amount of damage to apply to the character.</param>
        void TakeDamage(int damage);
    }
}
