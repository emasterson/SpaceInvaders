using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class BrickRemoveObserver : CollisionObserver
    {
        public BrickRemoveObserver()
        {
            this.pBrick = null;
        }

        public BrickRemoveObserver(BrickRemoveObserver a)
        {
            this.pBrick = a.pBrick;
        }

        public override void Notify()
        {
            pBrick = ShieldCategory.GetShield(this.subject.objA, this.subject.objB);
            Debug.WriteLine("ShieldRemoveObserver: --> delete brick {0}", pBrick);
            //delay
            BrickRemoveObserver pBrickObserver = new BrickRemoveObserver(this);
            DelayedObjectManager.Attach(pBrickObserver);
        }

        public override void execute()
        {
            // if deleting all the children
            // remove the column
            GameObject pParent = (GameObject)pBrick.parent;
            Debug.Assert(pParent != null);

            pBrick.RemoveMe();

            if (pParent.child == null)
            {
                // deleted last child in column so delete the column
                pParent.RemoveMe();
            }
        }



        //data=====================
        private GameObject pBrick;
    }
}
