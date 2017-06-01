using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class CrossBombRemoveObserver : CollisionObserver
    {
        public CrossBombRemoveObserver()
        {
            this.pCrossBomb = null;
        }

        public CrossBombRemoveObserver(CrossBombRemoveObserver m)
        {
            this.pCrossBomb = m.pCrossBomb;
        }

        //public override void Notify()
        //{
        //    // Delete missile
        //    GameObject pMissile = MissileCategory.GetMissile(this.subject.objA, this.subject.objB);
        //    Debug.WriteLine("MissileRemoveObserver: --> delete missile {0}", pMissile);

        //    // Let the gameObject deal with this...
        //    pMissile.RemoveMe();  
        //}

        public override void Notify()
        {
            // Delete missile
            this.pCrossBomb = BombCategory.GetBomb(this.subject.objA, this.subject.objB);
            Debug.WriteLine("MissileRemoveObserver: --> delete missile {0}", pCrossBomb);

            //   Delay
            CrossBombRemoveObserver pObserver = new CrossBombRemoveObserver(this);
            DelayedObjectManager.Attach(pObserver);
        }

        public override void execute()
        {
            // Let the gameObject deal with this...
            pCrossBomb.RemoveMe();
            //PlayerShip pShip = (PlayerShip)GameObjManager.Find(GameObjectNames.PlayerShip);
            //pShip.status = PlayerShipFiringStatus.ArmedAndReady;
        }

        // data
        private GameObject pCrossBomb;
    }
}
