using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class SquigglyBomb : BombCategory
    {
        public SquigglyBomb( GameObjectNames name, SpriteNames spriteName, float posX, float posY)
            : base(name, Index.i0, spriteName, BombCategory.Type.SquigglyBomb)
        {
            this.x = posX;
            this.y = posY;
            PushPosition();
        }

        public override void Update()
        {
            
        }

        public override void Accept(ColVisitor other)
        {
            // Important: at this point we have an Missile
            // Call the appropriate collision reaction
            other.VisitSquigglyBomb(this);
        }
    }
}
