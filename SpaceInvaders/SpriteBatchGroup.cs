using System;
using System.Diagnostics;

namespace SpaceInvaders
{
     public class SpriteBatchGroup : Container
    {
        public enum Name
        {
            SBG_Aliens,
            SBG_Sheilds,
            SBG_Background,
            SBG_Missiles,
            SBG_Explosions,
            SBG_Boxes,
            SBG_PlayerShip,
            SBG_Score,
            SBG_UFOs,
            SBG_PlayerLives,
            
            SBG_Not_Initialized
        }

        public SpriteBatchGroup(int reserveNum = 0, int reserveGrow = 0)
            : base(reserveNum, reserveGrow)
        {
            // Debug.WriteLine("SpriteBatchGroup()" + " reserve " + reserveNum + " grow " + reserveGrow);

            // make sure values are ressonable 
            Debug.Assert(reserveNum >= 0);
            Debug.Assert(reserveGrow >= 0);
        }

        public void Attach(BaseSprite pSpriteBase)
        {
            // Go to Man, get a node from reserve, add to active, return it
            SpriteBatchNode pSpriteBatchNode = (SpriteBatchNode)this.baseAdd();

            // Initialize SpriteBatchNode
            pSpriteBatchNode.Set(pSpriteBase);
            pSpriteBase.pSpriteBatchGroup = this;
           //FlyweightSprite myFlyweightSprite =(FlyweightSprite) pSpriteBase;
           //  myFlyweightSprite.name  =  pSpriteBase.getName();
           //  myFlyweightSprite.index = pSpriteBase.getIndex();
        }


        //public void Attach(GameSprite.Name gameSpriteName, Index _index = Index.INDEX_0)
         public void Attach(SpriteNames gameSpriteName)
        // public void Attach(ImageNames imageName)
        {
            // Go to Man, get a node from reserve, add to active, return it
            
            SpriteBatchNode pSpriteBatchNode = (SpriteBatchNode)this.baseAdd();

            // Initialize object
           // pSpriteBatchNode.Set(gameSpriteName, _index);
            pSpriteBatchNode.Set(gameSpriteName);
        }

         public void Attach(FlyweightSpriteNames flyweightName)
         // public void Attach(ImageNames imageName)
         {
             // Go to Man, get a node from reserve, add to active, return it

             SpriteBatchNode pSpriteBatchNode = (SpriteBatchNode)this.baseAdd();

             // Initialize object
            
             pSpriteBatchNode.Set(flyweightName);
            

         }

         public void Remove(BaseSprite inBaseSprite)
         {
             // search for the name on the active list
             SpriteBatchNode pSpriteBatchNode = (SpriteBatchNode)this.active;
             SpriteBatchNode pFoundSpriteBatchNode = null;
           //  Debug.WriteLine(" inBaseSprite = " + inBaseSprite);
             // traverse the list
             while (pSpriteBatchNode != null)
             {
                 if (pSpriteBatchNode.pBaseSprite == inBaseSprite)
                 {
                     // found the node
                     pFoundSpriteBatchNode = pSpriteBatchNode;
                     break;
                 }
                 pSpriteBatchNode = (SpriteBatchNode)pSpriteBatchNode.next;
             }
            // Debug.WriteLine("pSpriteBatchNode.pBaseSprite " + pSpriteBatchNode.pBaseSprite);
             // take the node off the active list, put on reserve list
             Debug.Assert(pFoundSpriteBatchNode != null);
             Debug.WriteLine("SpriteBAtch:Remove() {0} {1}\n",(GameObjectNames)pFoundSpriteBatchNode.name,pFoundSpriteBatchNode.index);
             this.baseRemove(pFoundSpriteBatchNode);

         }

         public void Detach(SpriteBatchNode pBaseSprite, SpriteBatchGroup pSpriteBatchGroup)
         {
             pSpriteBatchGroup.baseRemove(pBaseSprite);

         }

         



       // public void Set(SpriteBatchGroup.Name spriteBatchGroupName, Index _index, int _reserveNum, int _reserveGrow)
        public void Set(SpriteBatchGroup.Name spriteBatchGroupName,  Index _index, bool drawEnable,  int _reserveNum, int _reserveGrow)
        {
            this.name = spriteBatchGroupName;
            this.index = _index;
            this.DrawEnable = drawEnable;

            this.stats.reserveGrow = _reserveGrow;
            this.stats.reserveNum = _reserveNum;

            base.privFillPool(_reserveNum);
        }

        override public Enum getName()
        {
            return this.name;
        }

        override public Enum getIndex()
        {
            return this.index;
        }

        // Must define for Abastract Man class
        protected override object privGetNewObj()
        {
            object pObj = new SpriteBatchNode();
            return pObj;
        }

        // Data: ----------------------------------------------
        public SpriteBatchGroup.Name name;
        public Index index;
        public bool DrawEnable;
    }
}
