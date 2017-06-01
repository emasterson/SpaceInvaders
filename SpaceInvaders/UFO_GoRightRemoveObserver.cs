using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class UFO_GoRightRemoveObserver : CollisionObserver
    {
        public UFO_GoRightRemoveObserver()
        {
            this.pUFO_FromRight = null;
        }

        public UFO_GoRightRemoveObserver(UFO_GoRightRemoveObserver m)
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

            if (this.subject.objB.name.Equals(GameObjectNames.UFO_GoRight))
            {
                Scoreboard pScoreboard = Scoreboard.privInstance();
                pScoreboard.p1Score += 100;
            }

            //if (this.subject.objB.name.Equals(GameObjectNames.Crab))
            //{
            //    Scoreboard pScoreboard = Scoreboard.privInstance();
            //    pScoreboard.p1Score += 20;
            //}

            //if (this.subject.objB.name.Equals(GameObjectNames.Squid))
            //{
            //    Scoreboard pScoreboard = Scoreboard.privInstance();
            //    pScoreboard.p1Score += 30;
            //}
            Azul.Sound AlienExplosionSound;
            AlienExplosionSound = Azul.Audio.playSound("invaderkilled.wav", false, false, true);



            Debug.WriteLine("UFO_HitsRightWallObserver: --> delete missile {0}", pUFO_FromRight);

            //   Delay
            UFO_GoRightRemoveObserver pObserver = new UFO_GoRightRemoveObserver(this);
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
