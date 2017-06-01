using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class AlienOctopus : AlienCategory
    {
        public AlienOctopus(GameObjectNames name, Index index, SpriteNames spriteName, float posX, float posY)
            : base(name, index, spriteName, AlienCategory.Type.Octopus)
        {
            this.x = posX;
            this.y = posY;
        }

        

        public override void Accept(ColVisitor other)
        {
            // Important: at this point we have an Alien
            // Call the appropriate collision reaction            
            other.VisitAlienOctopus(this);
        }

        public override void VisitMissileRoot(MissileRoot m)
        {
            // AlienOctopus vs MissileRoot
            Debug.WriteLine("collide: {0} with {1}", this, m);

            // AlienOctopus vs Missile
            ColPair.Collide((GameObject)m.child, this);

        }

        public override void VisitMissile(Missile m)
        {
            // AlienOctopus vs Missile
            Debug.WriteLine("collide: {0} with {1}", this, m);

            Debug.WriteLine(" ---> Done");

            m.hit = true;

            ColPair pColPair = ColPairManager.GetActiveColPair();
            pColPair.SetCollision(m, this);
            pColPair.NotifyListeners();

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
            ColPair.Collide(m, (GameObject)this.child);
            // ColPair.Collide(m, (GameObject)this);
        }

        public override void Update()
        {

        }

        
    }
    
}
