using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class MoveGridOppositeDirection : CollisionObserver
    {
        public MoveGridOppositeDirection()
        {
            
        }

        public MoveGridOppositeDirection(MoveGridOppositeDirection m)
        {
            //this.pMissile = m.pMissile;
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
            // move the grid in opposite direction
            this.pGrid = (AlienGrid)AlienCategory.GetAlien(this.subject.objA, this.subject.objB);

            //// Delete missile
            //this.pMissile = MissileCategory.GetMissile(this.subject.objA, this.subject.objB);
            Debug.WriteLine("MoveGridOppsiteDirection: --> change delta {0}", pGrid);

            //   Delay
            MoveGridOppositeDirection pObserver = new MoveGridOppositeDirection(this);
            DelayedObjectManager.Attach(pObserver);
        }

        public override void execute()
        {
            //// Let the gameObject deal with this...
            //pMissile.RemoveMe();
            //PlayerShip pShip = (PlayerShip)GameObjManager.Find(GameObjectNames.PlayerShip);
            //pShip.status = PlayerShipFiringStatus.ArmedAndReady;
            
        }

        // data
        private AlienGrid pGrid;
    }
}
