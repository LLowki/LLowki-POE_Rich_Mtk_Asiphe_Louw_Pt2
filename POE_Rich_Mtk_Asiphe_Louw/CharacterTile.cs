namespace POE_Rich_Mtk_Asiphe_Louw
{
    internal abstract class CharacterTile : Tile
    {
        private int hitPoints;
        private int maximumHitPoints;
        private int attackPower;
        private Tile[] vision;

        protected CharacterTile(Position position, int hitPoints, int attackPower) : base(position)
        {
            this.hitPoints = hitPoints;
            maximumHitPoints = hitPoints;
            this.attackPower = attackPower;
            vision = new Tile[4];
        }

        public int HitPoints
        {
            get { return hitPoints; }
        }

        public int MaximumHitPoints
        {
            get { return maximumHitPoints; }
        }

        public int AttackPower
        {
            get { return attackPower; }
        }

        public Tile[] Vision
        {
            get { return vision; }
        }

        public bool IsDead
        {
            get { return hitPoints <= 0; }
        }

        public void UpdateVision(Level level)
        {
            vision[0] = level.Tiles[X, Y - 1];
            vision[1] = level.Tiles[X + 1, Y];
            vision[2] = level.Tiles[X, Y + 1];
            vision[3] = level.Tiles[X - 1, Y];
        }

        public void TakeDamage(int damage)
        {
            hitPoints -= damage;

            if (hitPoints < 0)
            {
                hitPoints = 0;
            }
        }

        public void Heal(int amount)
        {
            hitPoints += amount;

            if (hitPoints > maximumHitPoints)
            {
                hitPoints = maximumHitPoints;
            }
        }

        public void Attack(CharacterTile target)
        {
            target.TakeDamage(attackPower);
        }
    }
}
