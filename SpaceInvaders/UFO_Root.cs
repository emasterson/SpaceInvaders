using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class UFO_Root : UFO_Category
    {
        public UFO_Root(GameObjectNames name, SpriteNames spriteName, float posX = 0.0f, float posY = 0.0f)
            : base(name, Index.i0, spriteName, UFO_Category.Type.UFO_Root)
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
            other.VisitUFO_Root(this);
        }

        public override void VisitWallRoot(WallRoot m)
        {
            // AlienGrid vs WallRoot
             Debug.WriteLine("collide: {0} with {1}", this, m);

            // MissileRoot vs Columns
            //ColPair.Collide(m, (GameObject)this.child);
            ColPair.Collide((GameObject)m.child, (GameObject)this);
        }

        public override void VisitRightWall(RightWall m)
        {
            // AlienGrid vs WallRoot
            //  Debug.WriteLine("collide: {0} with {1}", this, m);
            Debug.WriteLine("done ->>>>>>>> tell observer that right wall and UFO collide");
            // MissileRoot vs Columns
             ColPair.Collide(m, (GameObject)this.child);
            // ColPair.Collide(m, (GameObject)this);

            //ColPair pColPair = ColPairManager.GetActiveColPair();
            //pColPair.SetCollision(m, this);
            //pColPair.NotifyListeners();
        }

        public override void VisitMissileRoot(MissileRoot m)
        {
            // AlienGrid vs MissileRoot
            // Debug.WriteLine("collide: {0} with {1}", this, m);

            // MissileRoot vs Columns
            ColPair.Collide(m, (GameObject)this.child);
        }
    }
}
