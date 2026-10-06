namespace POE_Rich_Mtk_Asiphe_Louw
{
    internal class HealthPickupTile : PickupTile
    {
        private const int HEAL_AMOUNT = 10;

        public HealthPickupTile(Position position) : base(position)
        {
        }

        public override char Display
        {
            get { return '+'; }
        }

        public override void ApplyEffect(CharacterTile target)
        {
            target.Heal(HEAL_AMOUNT);
        }
    }
}
