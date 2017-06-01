using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class SpawnNewMissileObserver :  CollisionObserver
    {
        public SpawnNewMissileObserver()
        {

        }

        public SpawnNewMissileObserver(SpawnNewMissileObserver s)
        {
            ///  this.pMissile = s.pMissile;
        }

        public override void Notify()
        {
            // Create a new one, and attach it to the root
            Debug.WriteLine("SpawnNewMissileObserver: --> Spawn new missile and attach");

            //   Delay
            SpawnNewMissileObserver pObserver = new SpawnNewMissileObserver(this);
            DelayedObjectManager.Attach(pObserver);

            // pTree.dumpTree();    
        }

        public override void execute()
        {
            // get the tree
            PCSTree pTree = GameObjManager.GetRootTree();

            // get the coordinates from the PlayerShip
            PlayerShip pPlayerShip = (PlayerShip)GameObjManager.Find(GameObjectNames.PlayerShip);
            float posX = pPlayerShip.x;
            float posY = pPlayerShip.y;

            // Create missile
           
            Missile pNewMissile = new Missile(GameObjectNames.Missile, SpriteNames.PlayerMissileSprite2, posX, posY);
            

            // Attach the sprite to the correct sprite batch
            SpriteBatchGroup pSBG_Aliens = SpriteBatchManager.Find(SpriteBatchGroup.Name.SBG_Aliens);
            pSBG_Aliens.Attach(pNewMissile.pFlyweightSprite);

            // Attach the missile to the missile root
            GameObject pMissileRoot = GameObjManager.Find(GameObjectNames.MissileRoot);
            pTree.Insert(pNewMissile, pMissileRoot);

            // set up the PlayerShip to fire again
            
            pPlayerShip.state = new ReadyToFireMode();
            pPlayerShip.status = PlayerShipFiringStatus.ArmedAndReady;
            pPlayerShip.pMissile = pNewMissile;

        }

        //public override void Notify()
        //{
        //    //create new observer, attach it to root
        //    Debug.WriteLine("SpawnNewMissileObserver: --> Spawn new missile and attach");

        //    // get the tree
        //    PCSTree pTree = GameObjManager.GetRootTree();

        //    // Create missile
        //    Missile pMissile = new Missile(GameObjectNames.Missile, SpriteNames.PlayerMissileSprite, 300, 100);

        //    //Attach the Sprite to the correct Sprite batch
        //    SpriteBatchGroup pSBG_Aliens = SpriteBatchManager.Find(SpriteBatchGroup.Name.SBG_Aliens);
        //    pSBG_Aliens.Attach(pMissile.pFlyweightSprite);

        //    //attach the missile to the missile root
        //    GameObject pMissileRoot = GameObjManager.Find(GameObjectNames.MissileRoot);
        //    pTree.Insert(pMissile, pMissileRoot);

        //    pTree.dumpTree();
            
        //}
    }
}
