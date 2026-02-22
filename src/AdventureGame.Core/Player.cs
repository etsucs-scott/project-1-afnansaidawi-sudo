using System;
using System.Collections.Generic;

namespace AdventureGame.Core
{
    public class Player : ICharacter
    {
        private const int BaseDamage = 10;
        private const int MaxHealth = 150;

        public int Health { get; private set; }
        public bool IsAlive => Health > 0;

        public List<Weapon> Inventory { get; }

        public Player()
        {
            Health = 100;
            Inventory = new List<Weapon>();
        }

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

        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health < 0)
                Health = 0;
        }

        public void Heal(int amount)
        {
            Health += amount;
            if (Health > MaxHealth)
                Health = MaxHealth;
        }
    }
}
