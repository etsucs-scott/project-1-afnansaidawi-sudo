using System;

namespace AdventureGame.Core
{
    public class Monster : ICharacter
    {
        private const int BaseDamage = 10;
        private static Random _random = new Random();

        public int Health { get; private set; }
        public bool IsAlive => Health > 0;

        public Monster()
        {
            Health = _random.Next(30, 51);
        }

        public int Attack()
        {
            return BaseDamage;
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;

            if (Health < 0)
                Health = 0;
        }
    }
}
