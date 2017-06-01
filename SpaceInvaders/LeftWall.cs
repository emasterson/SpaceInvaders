using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class LeftWall : WallCategory
    {
        public LeftWall( GameObjectNames name, SpriteNames spriteName, float posX, float posY)
            : base(name, Index.i0, spriteName, WallCategory.Type.LeftWall)
        {
            this.x = posX;
            this.y = posY;
            PushPosition();
        }

        public override void Update()
        {
           // this.x += 5.0f; 
        }

        public override void Accept(ColVisitor other)
        {
            // Important: at this point we have an Missile
            // Call the appropriate collision reaction
            other.VisitLeftWall(this);
        }

        public override void VisitAlienGrid(AlienGrid m)
        {
            // AlienCrab vs MissileRoot
            // Debug.WriteLine("collide: {0} with {1}", this, m);

            // AlienCrab vs Missile
           // ColPair.Collide((GameObject)m.child, this);
            ColPair.Collide((GameObject)m, this);

        }



        // Data: --------------------
    }
}
