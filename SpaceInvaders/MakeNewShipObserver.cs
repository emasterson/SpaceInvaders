using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class MakeNewShipObserver : CollisionObserver
    {
        public MakeNewShipObserver()
        {

        }

        public MakeNewShipObserver(MakeNewShipObserver s)
        {
            ///  this.pMissile = s.pMissile;
        }

        public override void Notify()
        {
            // Create a new one, and attach it to the root
            Debug.WriteLine("SpawnNewMissileObserver: --> Spawn new missile and attach");

            //   Delay
            MakeNewShipObserver pObserver = new MakeNewShipObserver(this);
            DelayedObjectManager.Attach(pObserver);

            // pTree.dumpTree();    
        }

        public override void execute()
        {
            // get the tree
            PCSTree pTree = GameObjManager.GetRootTree();

            // get the coordinates from the PlayerShip
            //PlayerShip pPlayerShip = (PlayerShip)GameObjManager.Find(GameObjectNames.PlayerShip);
            //float posX = pPlayerShip.x;
            //float posY = pPlayerShip.y;

            // Create missile
           
           // Missile pNewMissile = new Missile(GameObjectNames.Missile, SpriteNames.PlayerMissileSprite2, posX, posY);
            
            // create new ship
            PlayerShip pNewPlayerShip = new PlayerShip(GameObjectNames.PlayerShip, SpriteNames.PlayerShipSprite, 400, 100);

            // attach ship to correct spriteBatch
            SpriteBatchGroup pSBG_Aliens = SpriteBatchManager.Find(SpriteBatchGroup.Name.SBG_Aliens);
            pSBG_Aliens.Attach(pNewPlayerShip.pFlyweightSprite);
           // pTree.Insert(pPlayerShip, pPlayerShipRoot);

            // attach playerShip to PlayerShipRoot
            GameObject pPlayerShipRoot = GameObjManager.Find(GameObjectNames.PlayerShipRoot);
            pTree.Insert(pNewPlayerShip, pPlayerShipRoot);
            // Attach the sprite to the correct sprite batch
            //SpriteBatchGroup pSBG_Aliens = SpriteBatchManager.Find(SpriteBatchGroup.Name.SBG_Aliens);
            //pSBG_Aliens.Attach(pNewMissile.pFlyweightSprite);

            // Attach the missile to the missile root
            //GameObject pMissileRoot = GameObjManager.Find(GameObjectNames.MissileRoot);
            //pTree.Insert(pNewMissile, pMissileRoot);

            // set up the PlayerShip to fire again
            
            pNewPlayerShip.state = new ReadyToFireMode();
            pNewPlayerShip.status = PlayerShipFiringStatus.ArmedAndReady;
           // pNewPlayerShip.pMissile = pNewMissile;

        }
    }
}
