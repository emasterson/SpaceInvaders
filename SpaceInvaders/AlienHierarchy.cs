using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class AlienHierarchy : AlienCategory
    {
        public AlienHierarchy(GameObjectNames name, Index index, SpriteNames spriteName, float posX, float posY)
            : base(name, index, spriteName, AlienCategory.Type.Hierarchy)
        {
            this.x = posX;
            this.y = posY;
            this.delta = 10.0f;
            this.total = 0.0f;
        }

        public void MoveGrid()
        {
            this.total += this.delta;

            if (this.total > 350.0f || this.total < 0.0f)
            {
                this.delta *= -1.0f;
                this.privDropTreeDepthFirst(this);
                
            }

            // update all members of the grid
            this.privMoveTreeDepthFirst(this);
            
        }

        public override void Process()
        {
            this.UpdateUnion();
        }

        public override void Accept(ColVisitor other)
        {
            // Important: at this point we have an Alien
            // Call the appropriate collision reaction            
            //other.VisitAlienColumn(this);
        }

        public void UpdateUnion()
        {
            // Calculated union of children
            CollisionRect ColTotal = pCollisionObject.pCollisionRect;

            // Go to first child
            PCSNode pNode = (PCSNode)this;
            pNode = pNode.child;

            // Set ColTotal to first child
            GameObject pGameObj = (GameObject)pNode;
            ColTotal = pGameObj.pCollisionObject.pCollisionRect;

            // loop through sliblings
            while (pNode != null)
            {
                pGameObj = (GameObject)pNode;
                ColTotal = CollisionRect.Union(ColTotal, pGameObj.pCollisionObject.pCollisionRect);

                // go to next sibling
                pNode = pNode.sibling;
            }

            // set the collision object
            pCollisionObject.SetRect(ColTotal);

        }

        private void privMoveTreeDepthFirst(GameObject pNode)
        {
            PCSNode pChild = null;

            // dump
            pNode.x += this.delta;

            if (pNode.name.Equals(GameObjectNames.Crab))
            {
                pNode.x += 5.0f;
            }
           

            //iterate through all the active children
            if (pNode.child != null)
            {
                pChild = pNode.child;
                //make sure that allocation is not a child node
                while (pChild != null)
                {
                    privMoveTreeDepthFirst((GameObject)pChild);
                    //goto next sibling
                    pChild = pChild.sibling;
                }
            }
            else
            {
                // bye bye exit condition
            }
        }

        private void privDropTreeDepthFirst(GameObject pNode)
        {
            PCSNode pChild = null;

            // dump
            pNode.y -= 50.0f;

            //iterate through all the active children
            if (pNode.child != null)
            {
                pChild = pNode.child;
                //make sure that allocation is not a child node
                while (pChild != null)
                {
                    privDropTreeDepthFirst((GameObject)pChild);
                    //goto next sibling
                    pChild = pChild.sibling;
                }
            }
            else
            {
                // bye bye exit condition
            }
        }

        public override void Update()
        {

        }

        public override Enum getName()
        {

            return this.spriteName;

        }

        override public Enum getIndex()
        {
            return this.index;
        }

        // Data: ---------------

        private float delta;
        private float total;
        private SpriteNames spriteName;
    }
}
