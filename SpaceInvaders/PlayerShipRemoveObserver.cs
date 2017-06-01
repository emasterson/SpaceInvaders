using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class PlayerShipRemoveObserver : CollisionObserver
    {
        public PlayerShipRemoveObserver()
        {
            this.pPlayerShip = null;
        }

        public PlayerShipRemoveObserver(PlayerShipRemoveObserver m)
        {
            this.pPlayerShip = m.pPlayerShip;
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
            this.pPlayerShip = PlayerShipCategory.GetPlayerShip(this.subject.objA, this.subject.objB);

            
            Azul.Sound AlienExplosionSound;
            AlienExplosionSound = Azul.Audio.playSound("invaderkilled.wav", false, false, true);



            Debug.WriteLine("CrossBomb hits PlayerShip: --> delete missile {0}", pPlayerShip);

            //   Delay
            PlayerShipRemoveObserver pObserver = new PlayerShipRemoveObserver(this);
            DelayedObjectManager.Attach(pObserver);
        }

        public override void execute()
        {
            // Let the gameObject deal with this...
            pPlayerShip.RemoveMe();
            //PlayerShip pShip = (PlayerShip)GameObjManager.Find(GameObjectNames.PlayerShip);
            //pShip.status = PlayerShipFiringStatus.ArmedAndReady;
            //SpriteBatchManager pSpriteBatchManager = SpriteBatchManager.privInstance();
            //pSpriteBatchManager.F
            //GameObjManager pGameObjManager = GameObjManager.Find(GameObjectNames.PlayerLife2, Index.i0)
            //PlayerLife pPlayerLife = (PlayerLife)GameObjManager.Find(GameObjectNames.PlayerLife);
            //pPlayerLife.RemoveMe();
        }

        // data
        private GameObject pPlayerShip;
    }
}
