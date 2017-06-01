using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class CollisionSpriteNull : CollisionSpriteBox
    {
        private CollisionSpriteNull()
        {
            // prevent calling
        }

        public CollisionSpriteNull(GameObjectNames collisionSpriteName, Index _index = Index.i0)
            :base(collisionSpriteName, _index)
        {

        }

        public override void Update()
        {
            // do nothing
        }

        public override void Draw()
        {
            // do nothing - its a null sprite
        }

        // Data : -------------------------
        // no additional data


    }
    
    
    
}
