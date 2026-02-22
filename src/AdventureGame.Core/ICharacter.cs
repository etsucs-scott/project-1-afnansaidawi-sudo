using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureGame.Core
{
    internal interface ICharacter
    {
        int Health { get; }
        bool IsAlive { get; }

        int Attack();
        void TakeDamage(int damage);
    }
}
