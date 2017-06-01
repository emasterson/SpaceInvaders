using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class MissileRemoveObserver : CollisionObserver
    {
        public MissileRemoveObserver()
        {
            this.pMissile = null;
        }

        public MissileRemoveObserver(MissileRemoveObserver m)
        {
            this.pMissile = m.pMissile;
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
            this.pMissile = MissileCategory.GetMissile(this.subject.objA, this.subject.objB);
            Debug.WriteLine("MissileRemoveObserver: --> delete missile {0}", pMissile);

            //   Delay
             MissileRemoveObserver pObserver = new MissileRemoveObserver(this);
            DelayedObjectManager.Attach(pObserver);
        }

        public override void execute()
        {
            // Let the gameObject deal with this...
            pMissile.RemoveMe();
            PlayerShip pShip = (PlayerShip)GameObjManager.Find(GameObjectNames.PlayerShip);
            pShip.status = PlayerShipFiringStatus.ArmedAndReady;
        }

        // data
        private GameObject pMissile;
    }
}
