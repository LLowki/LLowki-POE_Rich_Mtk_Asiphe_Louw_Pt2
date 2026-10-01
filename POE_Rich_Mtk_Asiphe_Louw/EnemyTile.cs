using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POE_Rich_Mtk_Asiphe_Louw
{
    internal abstract class EnemyTile : CharacterTile
    {
        public EnemyTile(Position position, int hitPoints, int attackPower) : base(position, hitPoints, attackPower)
        {
        }

        public abstract bool GetMove(out Tile outMove);

        public abstract CharacterTile[] GetTargets();
    }
}
