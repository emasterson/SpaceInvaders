using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class PlayerShipFactory
    {
        public PlayerShipFactory(SpriteBatchGroup.Name spriteBatchName, PCSTree tree)
        {
            this.pSpriteBatch = SpriteBatchManager.Find(spriteBatchName);
            Debug.Assert(this.pSpriteBatch != null);

            this.pTree = tree;

        }

        public void setParent(PCSNode parentNode)
        {
            this.pParent = parentNode;
            //Debug.Assert(this.pParent != null);
        }

        ~PlayerShipFactory()
        {
            Debug.WriteLine("~PlayerShipFactory(): ");
            this.pSpriteBatch = null;
        }

        public PlayerShip Create( GameObjectNames gameName, Index index, float posX = 0.0f, float posY = 0.0f)
        {
            PlayerShip pPlayerShip = null;
           // pPlayerShip = new PlayerShip(gameName, index, SpriteNames.PlayerShipSprite, posX, posY, new ReadyToFireMode());
            
            //switch (type)
            //{
            //    case Alien.Type.Crab:
            //        pAlien = new AlienCrab(gameName, index, SpriteNames.AlienSpriteCrab01, posX, posY);
            //        break;

            //    case Alien.Type.Squid:
            //        pAlien = new AlienSquid(gameName, index, SpriteNames.AlienSpriteSquid01, posX, posY);
            //        break;

            //    case Alien.Type.Octopus:
            //        pAlien = new AlienOctopus(gameName, index, SpriteNames.AlienSpriteOctopus01, posX, posY);
            //        break;

            //    case Alien.Type.Hierarchy:
            //        pAlien = new AlienHierarchy(gameName, index, SpriteNames.NullObject, posX, posY);
            //        pAlien.pCollisionObject.pCollisionSprite.pColor = new Azul.Color(0.5f, 0.5f, 1.0f);

            //        break;

            //    default:
            //        Debug.Assert(false);
            //        break;
            //}
            // add it to the GameObjectManager
            GameObjManager.Attach(pPlayerShip);

            this.pTree.Insert(pPlayerShip, this.pParent);

            // attach to Group
            this.pSpriteBatch.Attach(pPlayerShip.pFlyweightSprite);

            return pPlayerShip;
        }

       // Data: ---------------------
        private PCSTree pTree;
        private SpriteBatchGroup pSpriteBatch;
        private PCSNode pParent;
    }
}
