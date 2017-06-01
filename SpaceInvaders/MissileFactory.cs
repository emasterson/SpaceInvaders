using System;
using System.Diagnostics;


namespace SpaceInvaders
{
    class MissileFactory
    {
        public MissileFactory(SpriteBatchGroup.Name spriteBatchName, PCSTree tree)
        {
            this.pSpriteBatch = SpriteBatchManager.Find(spriteBatchName);
            Debug.Assert(this.pSpriteBatch != null);

            this.pTree = tree;

        }

        public void setParent(PCSNode parentNode)
        {
            this.pParent = parentNode;
           // Debug.Assert(this.pParent != null); now setting parent to null in Game.cs
        }

        ~MissileFactory()
        {
            Debug.WriteLine("~MissileFactory(): ");
            this.pSpriteBatch = null;
        }

        public Missile Create( GameObjectNames gameName, Index index, float posX = 0.0f, float posY = 0.0f)
            
        {
            //if (gameName == GameObjectNames.Missile)
            {
                Missile pMissile = null;
                pMissile = new Missile(gameName, index, SpriteNames.PlayerMissileSprite, posX, posY);

                // add it to the GameObjectManager
                //GameObjManager.Attach(pMissile);

                this.pTree.Insert(pMissile, this.pParent);

                // attach to Group
                this.pSpriteBatch.Attach(pMissile.pFlyweightSprite);

                return pMissile;
            }
            //else
            //{
            //    MissileRoot pMissileRoot = new MissileRoot(GameObjectNames.MissileRoot, SpriteNames.NullObject);

            //    // add it to the GameObjectManager
            //    GameObjManager.Attach(pMissileRoot);

            //    this.pTree.Insert(pMissileRoot, this.pParent);

            //    // attach to Group
            //    this.pSpriteBatch.Attach(pMissileRoot.pFlyweightSprite);
            //    Missile myMissile = new Missile(GameObjectNames.Not_Initialized, SpriteNames.PlayerMissileSprite, 300, 400);
            //   // return pMissileRoot;
            //    return myMissile;
            //}
            

            
        }

        public MissileRoot Create2(GameObjectNames gameName, Index index, float posX = 0.0f, float posY = 0.0f)
        {
            
            {
                MissileRoot pMissileRoot = new MissileRoot(GameObjectNames.MissileRoot, SpriteNames.NullObject);

                // add it to the GameObjectManager
                GameObjManager.Attach(pMissileRoot);

                this.pTree.Insert(pMissileRoot, this.pParent);

                // attach to Group
                this.pSpriteBatch.Attach(pMissileRoot.pFlyweightSprite);
               // Missile myMissile = new Missile(GameObjectNames.Not_Initialized, SpriteNames.PlayerMissileSprite, 300, 400);
                 return pMissileRoot;
               // return myMissile;
            }



        }

       // Data: ---------------------
        private PCSTree pTree;
        private SpriteBatchGroup pSpriteBatch;
        private PCSNode pParent;
    }
}
