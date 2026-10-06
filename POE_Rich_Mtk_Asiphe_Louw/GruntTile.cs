using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POE_Rich_Mtk_Asiphe_Louw
{
    internal class GruntTile : EnemyTile
    {
        private static readonly Random random = new Random();

        public GruntTile(Position position) : base(position, 10, 1)
        {
        }

        public override char Display
        {
            get { return IsDead ? 'x' : '\u03EB'; }
        }

        public override bool GetMove(out Tile outMove)
        {
            List<Tile> emptyTiles = new List<Tile>();

            for (int i = 0; i < 4; i++)
            {
                if (Vision[i] is EmptyTile)
                {
                    emptyTiles.Add(Vision[i]);
                }
            }

            if (emptyTiles.Count == 0)
            {
                outMove = null;
                return false;
            }

            outMove = emptyTiles[random.Next(emptyTiles.Count)];
            return true;
        }

        public override CharacterTile[] GetTargets()
        {
            List<CharacterTile> targets = new List<CharacterTile>();

            for (int i = 0; i < 4; i++)
            {
                if (Vision[i] is CharacterTile target)
                {
                    targets.Add(target);
                }
            }

            return targets.ToArray();
        }
    }
}
