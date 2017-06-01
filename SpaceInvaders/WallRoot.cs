using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class WallRoot : WallCategory
    {

        public WallRoot(GameObjectNames name, SpriteNames spriteName, float posX = 0.0f, float posY = 0.0f)
            : base(name, Index.i0, spriteName, WallCategory.Type.WallRoot)
        {
            this.x = posX;
            this.y = posY;
        }

        public override void Process()
        {
            this.Update();
        }

        public override void Update()
        {
            this.baseUpdateBoundingBox();
        }

        public override void Accept(ColVisitor other)
        {
            other.VisitWallRoot(this);
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

        public override void VisitMissileRoot(MissileRoot m)
        {
            // AlienGrid vs MissileRoot
          //  Debug.WriteLine("collide: {0} with {1}", this, m);

            // MissileRoot vs Columns
            ColPair.Collide(m, (GameObject)this.child);
        }

        public override void VisitAlienGrid(AlienGrid m)
        {
            // AlienGrid vs MissileRoot
         //   Debug.WriteLine("collide: {0} with {1}", this, m);

            // MissileRoot vs Columns
            ColPair.Collide(m, (GameObject)this.child);
        }
    }
}
