using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract class GameObject : ColVisitor
    {
        

        protected GameObject(GameObjectNames gameName, Index gameIndex, SpriteNames spriteName)
        {
            this.name = gameName;
            this.index = gameIndex;
            Sprite pSprite = SpriteManager.find(spriteName);
            Debug.Assert(pSprite != null);
           // Debug.Assert(this.pFlyweightSprite != null);
            this.pFlyweightSprite = new FlyweightSprite(pSprite, gameName, gameIndex);
            

            this.pCollisionObject = new CollisionObject(pSprite, gameName, gameIndex);
        }

        //public void Update()
        //{
        //    pFlyweightSprite.x = this.x;
        //    pFlyweightSprite.y = this.y;

        //    pCollisionObject.Update(this.x, this.y);
        //}

        abstract public void Update();

        public virtual void Process()
        {
            
            this.Update();
            this.PushPosition();

        }

        protected void PushPosition()
        {
            pFlyweightSprite.UpdatePos(this.x, this.y);
            pCollisionObject.UpdatePos(this.x, this.y);
        }

        virtual public void RemoveMe()
        {
            // Remove the SpriteBase from the SpriteBatch
            SpriteBatchGroup pSpriteBatchG = this.pFlyweightSprite.pSpriteBatchGroup;
            pSpriteBatchG.Remove(this.pFlyweightSprite);

            // collisionObject
            pSpriteBatchG = this.pCollisionObject.pCollisionSprite.pSpriteBatchGroup;
            pSpriteBatchG.Remove(this.pCollisionObject.pCollisionSprite);

            //Object tree
            PCSTree pTree = GameObjManager.GetRootTree();
            pTree.Remove(this);

           // pTree.dumpTree();
        }
        

        protected void baseUpdateBoundingBox()
        {
            // Calculated union of children

            // CollisionRect ColTotal = pColObj.pColRect

            // Zero the collision
            CollisionRect ColTotal = new CollisionRect();
            pCollisionObject.SetRect(ColTotal);

            // Go to first child
            PCSNode pNode = (PCSNode)this;
            pNode = pNode.child;

            if (pNode != null)
            {
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
        }

        public PCSNode getRoot()
        {
            PCSNode pNode = (PCSNode)this;
            Debug.Assert(pNode != null);
            while (pNode.parent != null)
            {
                pNode = pNode.parent;
            }
            return pNode;
        }

        public void SetCollisionColor(float red, float green, float blue)
        {
            Azul.Color pColor = new Azul.Color(red, green, blue);

            Debug.Assert(this.pCollisionObject != null);
            Debug.Assert(this.pCollisionObject.pCollisionSprite != null);

            // todo kick the can
            this.pCollisionObject.pCollisionSprite.pColor = pColor;
        }

        public void SetGameObjectNodePointer(GameObjectNode gNode)
        {
           // this.pGameObjectNode = gNode;
        }

        override public Enum getName()
        {
            return this.name;
        }

        override public Enum getIndex()
        {
            return this.index;
        }

        // Data: ---------------
        public GameObjectNames name;
        public Index index;

        public float x;
        public float y;
        public FlyweightSprite pFlyweightSprite;
        public CollisionObject pCollisionObject;
        //public GameObjectNode pGameObjectNode; // do  i need this?
    }
}
