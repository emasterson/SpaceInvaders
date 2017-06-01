using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class PlayerLifeRemoveObserver : CollisionObserver
    {
        public PlayerLifeRemoveObserver()
        {
            this.pPlayerLife = null;
        }

        public PlayerLifeRemoveObserver(PlayerLifeRemoveObserver m)
        {
            this.pPlayerLife = m.pPlayerLife;
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
            this.pPlayerLife = PlayerShipCategory.GetPlayerShip(this.subject.objA, this.subject.objB);

            
            if (lifeCount == 3)
            {
                this.PlayerLifeToErase = (PlayerLife)GameObjManager.Find(GameObjectNames.PlayerLife2);
                PlayerLifeToErase.RemoveMe();
            }
            if (lifeCount == 2)
            {
                this.PlayerLifeToErase = (PlayerLife)GameObjManager.Find(GameObjectNames.PlayerLife);
                PlayerLifeToErase.RemoveMe();
            }

            Azul.Sound AlienExplosionSound;
            AlienExplosionSound = Azul.Audio.playSound("invaderkilled.wav", false, false, true);

            Scoreboard pScoreboard = Scoreboard.privInstance();
            pScoreboard.playerLivesCount -= 1;
            this.lifeCount -= 1;

            Debug.WriteLine("CrossBomb hits PlayerShip: --> delete missile {0}", pPlayerLife);

            //   Delay
            PlayerLifeRemoveObserver pObserver = new PlayerLifeRemoveObserver(this);
            DelayedObjectManager.Attach(pObserver);
        }

        public override void execute()
        {
            // Let the gameObject deal with this...
          //  this.PlayerLifeToErase.RemoveMe();
            //PlayerShip pShip = (PlayerShip)GameObjManager.Find(GameObjectNames.PlayerShip);
            //pShip.status = PlayerShipFiringStatus.ArmedAndReady;
            //SpriteBatchManager pSpriteBatchManager = SpriteBatchManager.privInstance();
            //pSpriteBatchManager.F
            //GameObjManager pGameObjManager = GameObjManager.Find(GameObjectNames.PlayerLife2, Index.i0)
            //PlayerLife pPlayerLife = (PlayerLife)GameObjManager.Find(GameObjectNames.PlayerLife);
            //pPlayerLife.RemoveMe();
        }

        // data
        private GameObject pPlayerLife;
        private GameObject PlayerLifeToErase;
        private int lifeCount = 3;
    }
}
