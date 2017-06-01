using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class UFO_GoRight : UFO_Category
    {
        public UFO_GoRight( GameObjectNames name, SpriteNames spriteName, float posX, float posY)
            : base(name, Index.i0, spriteName, UFO_Category.Type.UFO_FromRight)
        {
            this.x = posX;
            this.y = posY;
            PushPosition();
        }

        public override void Update()
        {
            this.x += 2.0f; 
        }

        public override void Accept(ColVisitor other)
        {
            // Important: at this point we have an Missile
            // Call the appropriate collision reaction
            other.VisitUFO_GoRight(this);
        }

        public override void VisitWallRoot(WallRoot m)
        {
            // AlienColumn vs MissileRoot
            //  Debug.WriteLine("collide: {0} with {1}", this, m);

            // MissileRoot vs Aliens
            ColPair.Collide(m, (GameObject)this.child);
        }

        public override void VisitRightWall(RightWall m)
        {
            // AlienGrid vs WallRoot
             Debug.WriteLine("collide: {0} with {1}", this, m);

            // MissileRoot vs Columns
           // ColPair.Collide(m, (GameObject)this.child);



            // ColPair.Collide(m, (GameObject)this);
            ColPair pColPair = ColPairManager.GetActiveColPair();
            pColPair.SetCollision(m, this);
            pColPair.NotifyListeners();
        }

        public override void VisitMissileRoot(MissileRoot m)
        {
            // AlienCrab vs MissileRoot
            // Debug.WriteLine("collide: {0} with {1}", this, m);

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
