using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class UFO_HitsRightWallObserver : CollisionObserver
    {

        public UFO_HitsRightWallObserver()
        {
            this.pUFO_FromRight = null;
        }

        public UFO_HitsRightWallObserver(UFO_HitsRightWallObserver m)
        {
            this.pUFO_FromRight = m.pUFO_FromRight;
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
            this.pUFO_FromRight = UFO_Category.GetUFO(this.subject.objA, this.subject.objB);
            Debug.WriteLine("UFO_HitsRightWallObserver: --> delete missile {0}", pUFO_FromRight);

            //   Delay
            UFO_HitsRightWallObserver pObserver = new UFO_HitsRightWallObserver(this);
            DelayedObjectManager.Attach(pObserver);
        }

        public override void execute()
        {
            // Let the gameObject deal with this...
            pUFO_FromRight.RemoveMe();
            //PlayerShip pShip = (PlayerShip)GameObjManager.Find(GameObjectNames.PlayerShip);
            //pShip.status = PlayerShipFiringStatus.ArmedAndReady;
        }

        // data
        private GameObject pUFO_FromRight;
    }
}
