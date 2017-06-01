using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class DeathManager : Manager
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
                instance = new DeathManager(reserveNum, reserveGrow);
            }

        }

        public static void Destroy()
        {
            // Get the instance
            DeathManager pDeathMan = DeathManager.privInstance();

            pDeathMan.baseDestroy();
        }

        protected override object privGetNewObj()
        {
            DeathNode pDeathNode = new DeathNode();
            return pDeathNode;
        }

        private static DeathManager privInstance()
        {
            // Safety - this forces users to call create first
            Debug.Assert(instance != null);
            return instance;
        }

        public static void Attach( object pObj )
        {
            // Get the instance
            DeathManager pDeathMan = DeathManager.privInstance();

            // Go to Man, get a node from reserve, add to active, return it
            DeathNode pDeathNode = (DeathNode)pDeathMan.baseAdd();

            // Initialize DeathNode
            pDeathNode.Set( pObj );
        }


        private DeathManager( int numReserve, int reserveGrow )
            : base(numReserve, reserveGrow)
        {
            // do nothing
        }


        // Data: ----------------------------------------------
        private static DeathManager instance = null;
    }
}
