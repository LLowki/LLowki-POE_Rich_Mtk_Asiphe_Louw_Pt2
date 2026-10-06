namespace POE_Rich_Mtk_Asiphe_Louw
{
    internal abstract class PickupTile : Tile
    {
        protected PickupTile(Position position) : base(position)
        {
        }

        public abstract void ApplyEffect(CharacterTile target);
    }
}
