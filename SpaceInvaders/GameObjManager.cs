using System;

using System.Diagnostics;

namespace SpaceInvaders
{
    class GameObjManager: Manager
    {
        

        public static void Create(int reserveNum = 3, int reserveGrow = 1)
        {
            // make sure values are ressonable 
            Debug.Assert(reserveNum > 0);
            Debug.Assert(reserveGrow > 0);


            // initialize the singleton here
            Debug.Assert(instance == null);

            // Do the initialization
            if (instance == null)
            {
                instance = new GameObjManager(reserveNum, reserveGrow);
            }

        }

        private GameObjManager( int numReserve, int reserveGrow )
            : base(numReserve, reserveGrow)
        {
            this.pRoot = null;
        }

        public static void Destroy()
        {
            // Get the instance
            GameObjManager pGameObjectMan = GameObjManager.privInstance();

            pGameObjectMan.baseDestroy();
        }

       

        public static void Attach(GameObject gameObject)
        {
            // Get the instance
            GameObjManager pGameObjectMan = GameObjManager.privInstance();

            // Go to Man, get a node from reserve, add to active, return it
            GameObjectNode pMyGameObjectNode = (GameObjectNode)pGameObjectMan.baseAdd();

            // Initialize Image
            pMyGameObjectNode.Set(gameObject);
           // gameObject.pGameObjectNode = pMyGameObjectNode;
        }

       

        
        

        public static GameObject Find(GameObjectNames name, Index index = Index.i0)
        {
            // get the singleton
            GameObjManager pGameObjectMan = GameObjManager.privInstance();

            bool foundIt = false;
            GameObject pGameObj = null;

            GameObjectNode pRoot = (GameObjectNode)pGameObjectMan.active;


            while ((pRoot != null) && (foundIt == false))
            {
                // OK at this point, I have a Root tree,
                // need to walk the tree completely before moving to next tree
                PCSTreeIterator pIterator = new PCSTreeIterator(pRoot.pGameObj);

                // Initialize
                pGameObj = pIterator.First();

                // loop through this tree
                while (pGameObj != null)
                {
                    // delta
                    if (pGameObj.getName().Equals(name) && pGameObj.getIndex().Equals(index))
                    {
                        foundIt = true;
                        break;
                    }

                    // Advance
                    pGameObj = pIterator.Next();
                }

                // Goto Next tree
                pRoot = (GameObjectNode)pRoot.next;
            }

            return pGameObj;
        }

       // public static void Remove(GameObjNames _name, Index index = Index.i0)
        public static void Remove(Enum _name, Index index = Index.i0)
        {
            // get the instance pointer
            GameObjManager gameObjManager = GameObjManager.privInstance();

            //call the base class function
            gameObjManager.baseRemove(_name, index);

            
        }

        public static void SetRootTree(PCSTree pTree)
        {
            GameObjManager pGameObjectManager = GameObjManager.privInstance();
            pGameObjectManager.pRoot = pTree;
        }

        public static PCSTree GetRootTree()
        {
            GameObjManager pGameObjectManager = GameObjManager.privInstance();
            return pGameObjectManager.pRoot;
        }

        

        private static GameObjManager privInstance()
        {
            Debug.Assert(instance != null);
            //if (instance == null)
            //{
            //    instance = new GameObjManager();
            //}
            return instance;
        }

        protected override object privGetNewObj()
        {
            object pObj = new GameObjectNode();
            return pObj;
        }

        public static void Update()
        {
            //get the singleton
            GameObjManager pGameObjManager = GameObjManager.privInstance();

            GameObjectNode pRoot = (GameObjectNode)pGameObjManager.active;

            while (pRoot != null)
            {
                // OK at this point, I have a Root tree,
                // need to walk the tree completely before moving to next tree
               // PCSTreeIterator pIterator = new PCSTreeIterator(pRoot.pGameObj);
                PCSTreeContraryIterator pIterator = new PCSTreeContraryIterator(pRoot.pGameObj);

                // Initialize
                GameObject pGameObj = pIterator.First();

                while (pGameObj != null)
                {
                    // delta
                    pGameObj.Process();

                    // Advance
                    pGameObj = pIterator.Next();
                }

                // Goto Next tree
                pRoot = (GameObjectNode)pRoot.next;
            }

            //GameObjectNode pNode = (GameObjectNode)pGameObjManager.active;

            //while (pNode != null)
            //{
            //    // update the node
            //    pNode.pGameObj.Update();
            //    pNode.pGameObj.Process();

            //    pNode = (GameObjectNode)pNode.next;
            //}
        }

        //Data----------------
        private static GameObjManager instance = null;
        public PCSTree pRoot;
    }
}
