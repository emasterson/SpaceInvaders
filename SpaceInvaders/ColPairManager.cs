using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ColPairManager : Manager
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
                instance = new ColPairManager(reserveNum, reserveGrow);
            }

        }

        public static void Destroy()
        {
            // Get the instance
            ColPairManager pImageMan = ColPairManager.privInstance();

            pImageMan.baseDestroy();
        }

        private ColPairManager(int numReserve, int reserveGrow)
            : base(numReserve, reserveGrow)
        {
            // do nothing
        }

        private static ColPairManager privInstance()
        {
            // Safety - this forces users to call create first
            Debug.Assert(instance != null);

            return instance;
        }

        public static ColPair Add(ColPair.Name colpairName, GameObject treeRootA, GameObject treeRootB)
        {
            return ColPairManager.Add(colpairName, Index.i0, treeRootA, treeRootB);
        }

        public static ColPair Add(ColPair.Name colpairName, Index index, GameObject treeRootA, GameObject treeRootB)
        {
            // Get the instance
            ColPairManager pColPairMan = ColPairManager.privInstance();

            // Go to Man, get a node from reserve, add to active, return it
            ColPair pColPair = (ColPair)pColPairMan.baseAdd();

            // Initialize Image
            pColPair.Set(colpairName, index, treeRootA, treeRootB);

            return pColPair;
        }

        public static ColPair Find(ImageNames name, Index index = Index.i0)
        {
            // get the singleton
            ColPairManager pColPairManager = ColPairManager.privInstance();

            // call base class function
            return (ColPair)pColPairManager.basefind(name, index);
        }



        public static void Remove(ColPair.Name name, Index index = Index.i0)
        {
            // get the singleton
            ColPairManager pColPairMan = ColPairManager.privInstance();

            // call base class function
            pColPairMan.baseRemove(name, index);
        }

        public static void Process()
        {
            // get the singleton
            ColPairManager pColPairManager = ColPairManager.privInstance();

            ColPair pColPair = (ColPair)pColPairManager.active;

            while (pColPair != null)
            {
                // do the check for a single pair
                pColPairManager.activeColPair = pColPair;
                pColPair.Process();

                // advance to next
                pColPair = (ColPair)pColPair.next;
            }

        }

        static public ColPair GetActiveColPair()
        {
            // get singleton
            ColPairManager pColPairManager = ColPairManager.privInstance();

            return pColPairManager.activeColPair;
        }


        // Must define for Abastract Man class
        protected override object privGetNewObj()
        {
            object pObj = new ColPair();
            return pObj;
        }

        // Data: ----------------------------------------------
        private static ColPairManager instance = null;
        private ColPair activeColPair;
    }
}
