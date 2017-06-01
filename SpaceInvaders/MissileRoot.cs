using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class MissileRoot : MissileCategory
    {
        public MissileRoot(GameObjectNames name, SpriteNames spriteName, float posX = 0.0f, float posY = 0.0f)
            : base(name, Index.i0,spriteName, MissileCategory.Type.MissileRoot)
        {
            this.x = posX;
            this.y = posY;
        }

        public override void Process()
        {
            this.baseUpdateBoundingBox();

        }

        public override void Accept(ColVisitor other)
        {
            // Important: at this point we have an Missileroot
            // Call the appropriate collision reaction
            other.VisitMissileRoot(this);
        }

        public override void Update()
        {

        }
    }
}
