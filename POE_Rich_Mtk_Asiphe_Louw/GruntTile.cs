using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POE_Rich_Mtk_Asiphe_Louw
{
    internal class GruntTile : EnemyTile
    {
        private bool canMove;
        private Tile[] empTile = new Tile[4];
        private CharacterTile[] identified = new CharacterTile[4];
        public GruntTile(Position position) : base(position, 10, 1)
        {

        }

        public override char Display
        {
            get { return IsDead ? 'x' : '\u03EB'; }
        }

        public override bool GetMove(out Tile outMove)
        {
            int surrounded = 0;
            int rolled = 0;
            outMove = null;

            for (int i = 0; i < 4; i++)
            {
                if (this.Vision[i] is EmptyTile)
                {
                    empTile[i] = this.Vision[i];
                }
                else if (this.Vision[i] is CharacterTile)
                {
                    surrounded++;
                    identified[i] = (CharacterTile)this.Vision[i];
                }
            }

            if (surrounded >= 4)
            {
                outMove = null;
                canMove = false;
            }
            else
            {
                Random roll = new Random();
                rolled = roll.Next(4);
                canMove = true;
                outMove = empTile[rolled];
            }

            return canMove;
        }

        public override CharacterTile[] GetTargets()
        {
            return identified;
        }
    }
}
