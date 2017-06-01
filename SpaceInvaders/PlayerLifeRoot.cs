using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class PlayerLifeRoot : PlayerShipCategory
    {
        public PlayerLifeRoot(GameObjectNames name, SpriteNames spriteName, float posX = 0.0f, float posY = 0.0f)
            : base(name, Index.i0, spriteName, PlayerShipCategory.Type.PlayerShipRoot)
        {
            this.x = posX;
            this.y = posY;
        }

        public override void Process()
        {
           // this.Update();
        }

        public override void Update()
        {
           // this.baseUpdateBoundingBox();
        }

        public override void Accept(ColVisitor other)
        {
           // other.VisitPlayerShipRoot(this);
        }
    }
}
