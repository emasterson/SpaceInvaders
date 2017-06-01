using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class SpriteBatchManager : Manager
    {
        public static void Create(int reserveNum = 3, int reserveGrow = 1)
        {
            //Debug.WriteLine("SpriteBatchMan:Create()"+" reserve "+reserveNum+" grow "+reserveGrow );

            // make sure values are ressonable 
            Debug.Assert(reserveNum > 0);
            Debug.Assert(reserveGrow > 0);

            // initialize the singleton here
            Debug.Assert(instance == null);

            // Do the initialization
            if (instance == null)
            {
                instance = new SpriteBatchManager(reserveNum, reserveGrow);
            }
        }

        private SpriteBatchManager( int numReserve, int reserveGrow )
            : base(numReserve, reserveGrow)
        {
            //Debug.WriteLine("SpriteBatchMan()" );
            // do nothing
        }

        public static SpriteBatchGroup Find(SpriteBatchGroup.Name name, Index index = Index.i0)
        {
            //get the singleton
            SpriteBatchManager pSpriteBatchManager = SpriteBatchManager.privInstance();
            
            // call the base class function
            return (SpriteBatchGroup)pSpriteBatchManager.basefind(name, index);

        }

        public static void Destroy()
        {
            SpriteBatchManager.privInstance().baseDestroy();
        }

        public static SpriteBatchManager privInstance()
        {
            // Safety - this forces users to call create first
            Debug.Assert(instance != null);
            return instance;
        }

        public static SpriteBatchGroup Add(SpriteBatchGroup.Name spriteBatchName, bool drawEnable = true, int reserveNum = 3, int reserveGrow = 1)
        {
            return SpriteBatchManager.Add(spriteBatchName, Index.i0, drawEnable, reserveNum, reserveGrow);
        }

        public static SpriteBatchGroup Add(SpriteBatchGroup.Name spriteBatchGroupName, Index index, bool drawEnable = true,  int reserveNum = 3, int reserveGrow = 1)
        {
            //return SpriteBatchManager.Add(spriteBatchGroupName, Index.INDEX_0, reserveNum, reserveGrow );
            // Get the instance
            SpriteBatchManager pSpriteBatchManager = SpriteBatchManager.privInstance();

            // Go to Man, get a node from reserve, add to active, return it
            SpriteBatchGroup pSpriteBatchGroup = (SpriteBatchGroup)pSpriteBatchManager.baseAdd();

            // Initialize object
            //pSpriteBatchGroup.Set(spriteBatchGroupName, index, reserveNum, reserveGrow);
            pSpriteBatchGroup.Set(spriteBatchGroupName, index, drawEnable,  reserveNum, reserveGrow);

            return pSpriteBatchGroup;
        }

        //public static SpriteBatchGroup Add(SpriteBatchGroup.Name spriteBatchGroupName, Index index, int reserveNum = 3, int reserveGrow = 1)
        //{
        //    // Get the instance
        //    SpriteBatchManager pSpriteBatchManager = SpriteBatchManager.privInstance();

        //    // Go to Man, get a node from reserve, add to active, return it
        //    SpriteBatchGroup pSpriteBatchGroup = (SpriteBatchGroup)pSpriteBatchManager.baseAdd();

        //    // Initialize object
        //    pSpriteBatchGroup.Set(spriteBatchGroupName, index, reserveNum, reserveGrow);

        //    return pSpriteBatchGroup;
        //}

        // Must define for Abastract Man class
        protected override object privGetNewObj()
        {
            object pObj = new SpriteBatchGroup();
            return pObj;
        }

        public static void Draw()
        {
            // get the singleton
            SpriteBatchManager pSpriteBatchMan = SpriteBatchManager.privInstance();
            SpriteBatchGroup pSpriteBatchGroup = (SpriteBatchGroup)pSpriteBatchMan.active;
            SpriteBatchNode pSpriteBatchNode = null;

            while (pSpriteBatchGroup != null)
            {
                pSpriteBatchNode = (SpriteBatchNode)pSpriteBatchGroup.active;
              //  Debug.WriteLine("SpriteBatch--->: {0} {1}", pSpriteBatchGroup, pSpriteBatchGroup.name);
                while (pSpriteBatchNode != null && pSpriteBatchGroup.DrawEnable == true)
                {
                    //Debug.WriteLine("      SpriteBatch.Draw(): {0} {1}", pSpriteBatchNode.pBaseSprite.getName(), pSpriteBatchNode.pBaseSprite.getIndex());
                    pSpriteBatchNode.pBaseSprite.Update();
                    pSpriteBatchNode.pBaseSprite.Draw();

                    //pSpriteBatchNode.pSprite.Update();
                    //pSpriteBatchNode.pSprite.Draw();

                    pSpriteBatchNode = (SpriteBatchNode)pSpriteBatchNode.next;
                }

                pSpriteBatchGroup = (SpriteBatchGroup)pSpriteBatchGroup.next;
            }
        }

       // public static void DeleteSpriteBatchNode(GameObject gameObject)
         public static void DeleteSpriteBatchNode(FlyweightSprite inFlyweightSprite)
        {
            // get the singleton
            SpriteBatchManager pSpriteBatchMan = SpriteBatchManager.privInstance();
            SpriteBatchGroup pSpriteBatchGroup = (SpriteBatchGroup)pSpriteBatchMan.active;
            SpriteBatchNode pSpriteBatchNode = null;

            while (pSpriteBatchGroup != null)
            {
                pSpriteBatchNode = (SpriteBatchNode)pSpriteBatchGroup.active;
              

                while (pSpriteBatchNode != null)
                {

                    if ((pSpriteBatchNode.pBaseSprite.getIndex().Equals(inFlyweightSprite.getIndex())) && (pSpriteBatchNode.pBaseSprite.getName().Equals(inFlyweightSprite.getName())))
                    {
                        pSpriteBatchGroup.Detach(pSpriteBatchNode, pSpriteBatchGroup);
                    }
                   // pSpriteBatchNode.pBaseSprite.Update();
                   // pSpriteBatchNode.pBaseSprite.Draw();

                    //pSpriteBatchNode.pSprite.Update();
                    //pSpriteBatchNode.pSprite.Draw();

                    pSpriteBatchNode = (SpriteBatchNode)pSpriteBatchNode.next;
                }

                pSpriteBatchGroup = (SpriteBatchGroup)pSpriteBatchGroup.next;
            }
        }

        // Data: ----------------------------------------------
        private static SpriteBatchManager instance = null;
    }
}
