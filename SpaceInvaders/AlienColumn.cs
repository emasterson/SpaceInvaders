using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class AlienColumn : AlienCategory
    {

        public AlienColumn(GameObjectNames name, Index index, SpriteNames spriteName, float posX, float posY)
            : base(name, index, spriteName, AlienCategory.Type.Column)
        {
            this.x = posX;
            this.y = posY;

        }

        public override void Accept(ColVisitor other)
        {
            // Important: at this point we have an Alien
            // Call the appropriate collision reaction            
            other.VisitAlienColumn(this);
        }

        public override void VisitMissileRoot(MissileRoot m)
        {
            // AlienColumn vs MissileRoot
          //  Debug.WriteLine("collide: {0} with {1}", this, m);

            // MissileRoot vs Aliens
            ColPair.Collide(m, (GameObject)this.child);
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

        public override void Process()
        {
            // Note: no pushing of positions
            //this.Update();
            this.baseUpdateBoundingBox();
        }

        public override void Update()
        {

        }

        override public void RemoveMe()
        {
            //CollisionObject
            SpriteBatchGroup pSpriteBatch = this.pCollisionObject.pCollisionSprite.pSpriteBatchGroup;
            pSpriteBatch.Remove(this.pCollisionObject.pCollisionSprite);

            //Object tree
            PCSTree pTree = GameObjManager.GetRootTree();
            pTree.Remove(this);
            
            // pTree.dumpTree()
        }
    }
}
