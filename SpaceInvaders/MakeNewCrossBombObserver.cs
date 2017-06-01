using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class MakeNewCrossBombObserver : CollisionObserver
    {
        public MakeNewCrossBombObserver()
        {

        }

        public MakeNewCrossBombObserver(MakeNewCrossBombObserver s)
        {
            ///  this.pMissile = s.pMissile;
        }

        public override void Notify()
        {
            // Create a new one, and attach it to the root
            Debug.WriteLine("MakeNewCrossBombObserver: --> Make new CrossBomb and attach");

            //   Delay
            MakeNewCrossBombObserver pObserver = new MakeNewCrossBombObserver(this);
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

            // get the coord from the lowest alien in a particular column
            // go down the tree until hit the AlienGrid, then get random child of aliengrid, then get lowest child of that
            GameObject pGameObject = null;
            PCSNode pNode = pTree.getRoot();
            PCSTreeIterator pIterator = new PCSTreeIterator((GameObject)pNode);
            pGameObject = pIterator.First();
            bool foundIt = false;
            if (pGameObject != null)
            {
                while (pGameObject != null)
                {
                    if (pGameObject.getName().Equals(GameObjectNames.Grid))
                    {
                        foundIt = true;
                        break;
                    }
                    pGameObject = pIterator.Next();
                    
                }
                pGameObject = (GameObject)pGameObject.child;
            }

            Random r = new Random();
            int ColumnToDropFrom = r.Next(1, 11);
            Console.WriteLine("column = " + ColumnToDropFrom);

            //for (int i = 0; i < ColumnToDropFrom; i++)
            //{
            //    pGameObject = pIterator.Next();
            //}
            int j = 0;
            while ((j < ColumnToDropFrom) && (pGameObject.sibling != null))
            {
               // pGameObject = pIterator.Next();
                pGameObject = (GameObject)pGameObject.sibling;
                j++;
            }







            //bool foundIt = false;
            //// loop through this tree
            //while (pGameObject != null)
            //{
            //    // delta
            //    if (pGameObject.getName().Equals(GameObjectNames.Grid))
            //    {
            //        foundIt = true;
            //        break;
            //    }

            //    // Advance
            //    pGameObject = pIterator.Next();
            //}

            pNode = pGameObject.child;
           // pNode = pNode.child;
            pGameObject = (GameObject)pNode;
            float posX = pGameObject.x;
            float posY = pGameObject.y;
           
            
         
            
            // create CrossBomb
            CrossBomb pCrossBomb = new CrossBomb(GameObjectNames.CrossBomb, SpriteNames.CrossBombSprite, posX, posY);

            // Attach the sprite to the correct sprite batch
            SpriteBatchGroup pSBG_Aliens = SpriteBatchManager.Find(SpriteBatchGroup.Name.SBG_Aliens);
            pSBG_Aliens.Attach(pCrossBomb.pFlyweightSprite);

            // Attach the missile to the missile root
            //GameObject pMissileRoot = GameObjManager.Find(GameObjectNames.MissileRoot);
            //pTree.Insert(pNewMissile, pMissileRoot);

            GameObject pBombRoot = GameObjManager.Find(GameObjectNames.BombRoot);
            pTree.Insert(pCrossBomb, pBombRoot);

            // set up the PlayerShip to fire again
            
            //pPlayerShip.state = new ReadyToFireMode();
            //pPlayerShip.status = PlayerShipFiringStatus.ArmedAndReady;
            //pPlayerShip.pMissile = pNewMissile;

        }
    }
}
