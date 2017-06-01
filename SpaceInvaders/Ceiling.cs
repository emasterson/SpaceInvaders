using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class Ceiling : WallCategory
    {
        public Ceiling( GameObjectNames name, SpriteNames spriteName, float posX, float posY)
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
            other.VisitCeiling(this);
        }

        public override void VisitMissileRoot(MissileRoot m)
        {
            // AlienCrab vs MissileRoot
             Debug.WriteLine("collide: {0} with {1} +++++++++++++++++++++++++++++++++++++++++++++++++++++\n", this, m);

            // AlienCrab vs Missile
            ColPair.Collide((GameObject)m.child, this);

        }

        public override void VisitMissile(Missile m)
        {
            // AlienCrab vs Missile
            Debug.WriteLine("collide: {0} with {1}", this, m);

            Debug.WriteLine(" ---> Done");

            m.hit = true;

            ColPair pColPair = ColPairManager.GetActiveColPair();
            pColPair.SetCollision(m, this);
            pColPair.NotifyListeners();

        }

        // Data: --------------------
    }
}
