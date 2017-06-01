using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class Floor : WallCategory
    {
        public Floor( GameObjectNames name, SpriteNames spriteName, float posX, float posY)
            : base(name, Index.i0, spriteName, WallCategory.Type.Ceiling)
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
            other.VisitFloor(this);
        }

        

        public override void VisitBombRoot(BombRoot m)
        {
            // MissileRoot vs ShieldBrick
            // now go deeper on Missile root
            ColPair.Collide((GameObject)m.child, this);
        }

        public override void VisitCrossBomb(CrossBomb m)
        {
            // ShieldBrick vs Missile
            //Debug.WriteLine("collide: {0} with {1}", this, m);

            //Debug.WriteLine(" ---> Done");
            ColPair pColPair = ColPairManager.GetActiveColPair();
            pColPair.SetCollision(m, this);
            pColPair.NotifyListeners();
        }

        // Data: --------------------
    }
}
