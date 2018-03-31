﻿

namespace _03BarracksFactory.Models.Units
{
    public class Horseman:Unit
    {
        public const int DefaultHealth = 50;
        public const int DefaultAttack = 10;

        public Horseman() : base(DefaultHealth,DefaultAttack)
        {
        }
    }
}
