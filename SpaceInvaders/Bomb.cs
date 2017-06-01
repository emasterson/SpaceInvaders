using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class Bomb : GameObject
    {
        public Bomb(GameObjectNames name, Index index, SpriteNames spriteName, float posX, float posY)
            : base(name, index, spriteName)
        {
            this.x = posX;
            this.y = posY;
        }

        public override void Update()
        {
        }

        public override void Accept(ColVisitor other)
        {
            // Important: at this point we have an Missile
            // Call the appropriate collision reaction
            other.VisitBomb(this);
        }
    }
}
