


namespace _03BarracksFactory.Models.Units
{
    public class Gunner : Unit
    {
        public const int DefaultHealth = 20;
        public const int DefaultAttack = 20;

        public Gunner() : base(DefaultHealth, DefaultAttack)
        {
        }
    }
}
