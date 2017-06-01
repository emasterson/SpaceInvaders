using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class AlienGrid : AlienCategory
    {
        public AlienGrid(GameObjectNames name, Index index, SpriteNames spriteName, float posX, float posY)
            : base(name, index, spriteName, AlienCategory.Type.Grid)
        {
            this.x = posX;
            this.y = posY;
            this.delta = 2.0f;
            this.total = 0.0f;
        }

        public override void Process()
        {
            // Note: no pushing of positions
            this.Update();
            // move the collection
           // this.privMoveBoxes();

            // update bounding boxes to the children underneath
            this.baseUpdateBoundingBox();

        }

        public override void Accept(ColVisitor other)
        {
            // Important: at this point we have an Alien
            // Call the appropriate collision reaction            
            other.VisitAlienGrid(this);
        }

        public override void VisitMissileRoot(MissileRoot m)
        {
            // AlienGrid vs MissileRoot
           // Debug.WriteLine("collide: {0} with {1}", this, m);

            // MissileRoot vs Columns
            ColPair.Collide(m, (GameObject)this.child);
        }

        public override void VisitWallRoot(WallRoot m)
        {
            // AlienGrid vs WallRoot
           // Debug.WriteLine("collide: {0} with {1}", this, m);

            // MissileRoot vs Columns
            //ColPair.Collide(m, (GameObject)this.child);
            ColPair.Collide((GameObject)m.child, (GameObject)this);
        }

        public override void VisitRightWall(RightWall m)
        {
            // AlienGrid vs WallRoot
          //  Debug.WriteLine("collide: {0} with {1}", this, m);
            Debug.WriteLine("done ->>>>>>>> tell observer that right wall and alien grid collide. send aliens other way");
            // MissileRoot vs Columns
           // ColPair.Collide(m, (GameObject)this.child);
           // ColPair.Collide(m, (GameObject)this);

            ColPair pColPair = ColPairManager.GetActiveColPair();
            pColPair.SetCollision(m, this);
            pColPair.NotifyListeners();
        }

        public override void VisitLeftWall(LeftWall m)
        {
            // AlienGrid vs WallRoot
            Debug.WriteLine("collide: {0} with {1}", this, m);
            Debug.WriteLine("done ->>>>>>>> tell observer that right wall and alien grid collide. send aliens other way");

            // MissileRoot vs Columns
            //ColPair.Collide(m, (GameObject)this.child);
            ColPair pColPair = ColPairManager.GetActiveColPair();
            pColPair.SetCollision(m, this);
            pColPair.NotifyListeners();
        }

        //public override void Update()
        //{
        //    // this.privMoveBoxes();
        //}

        public override void Update()
        {
            // move the collection
            //this.privMoveBoxes();

            // update bounding boxes to the children underneath
            this.baseUpdateBoundingBox();
        }

        public void privMoveBoxes()
        {
            PCSTreeIterator pNode = new PCSTreeIterator(this);




            
           // Debug.WriteLine("whichSound =" + whichSound);

            // Initialize
            GameObject pGameObj = pNode.First();
            
            while (pGameObj != null)
            {
                // delta
                pGameObj.x += this.delta;
               
                


                // Advance
                pGameObj = pNode.Next();
            }

            if (pDrop.Equals(AlienGrid.Drop.YesDrop))
            {
                // Initialize
                GameObject pGameObj2 = pNode.First();

                while (pGameObj2 != null)
                {
                    // delta
                    
                    pGameObj2.y -= 20;
                    // Debug.WriteLine(" in while of alien grid  delta = " + delta);



                    // Advance
                    pGameObj2 = pNode.Next();
                }

                
                pDrop = AlienGrid.Drop.NoDrop;
            }
            //Debug.WriteLine(" in while of alien grid  delta = " + delta);

            
        }

        public enum Direction
        {
            GoingRight,
            GoingLeft
        }

        public enum Drop
        {
            YesDrop,
            NoDrop
        }

        // Data: ---------------

        public float delta;
        private float total;
        public Direction pDirection = AlienGrid.Direction.GoingRight;
        public Drop pDrop = AlienGrid.Drop.NoDrop;
        int whichSound = 1;
    }
}
