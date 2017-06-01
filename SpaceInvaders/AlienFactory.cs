using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class AlienFactory
    {
        public AlienFactory(SpriteBatchGroup.Name spriteBatchName, PCSTree tree)
        {
            this.pSpriteBatch = SpriteBatchManager.Find(spriteBatchName);
            Debug.Assert(this.pSpriteBatch != null);

            this.pTree = tree;

        }

        public void setParent(PCSNode parentNode)
        {
            this.pParent = parentNode;
           // Debug.Assert(this.pParent != null);// will i need to get rid of this?
        }

        ~AlienFactory()
        {
            Debug.WriteLine("~AlienFactory(): ");
            this.pSpriteBatch = null;
        }

        public AlienCategory Create(AlienCategory.Type type, GameObjectNames gameName, Index index, float posX = 0.0f, float posY = 0.0f)
        {
            AlienCategory pAlien = null;

            switch (type)
            {
                case AlienCategory.Type.Crab:
                    pAlien = new AlienCrab(gameName, index, SpriteNames.AlienSpriteCrab01, posX, posY);
                    this.pSpriteBatch.Attach(pAlien.pFlyweightSprite);
                    Debug.WriteLine("Crab attach to {0}", pSpriteBatch.name);
                    break;

                case AlienCategory.Type.Squid:
                    pAlien = new AlienSquid(gameName, index, SpriteNames.AlienSpriteSquid01, posX, posY);
                    this.pSpriteBatch.Attach(pAlien.pFlyweightSprite);
                    Debug.WriteLine("Squid attach to {0}", pSpriteBatch.name);
                    break;

                case AlienCategory.Type.Octopus:
                    pAlien = new AlienOctopus(gameName, index, SpriteNames.AlienSpriteOctopus01, posX, posY);
                    this.pSpriteBatch.Attach(pAlien.pFlyweightSprite);
                    Debug.WriteLine("Octopus attach to {0}", pSpriteBatch.name);
                    break;

                //case AlienCategory.Type.Hierarchy:
                //    pAlien = new AlienHierarchy(gameName, index, SpriteNames.NullObject, posX, posY);
                //    pAlien.pCollisionObject.pCollisionSprite.pColor = new Azul.Color(0.5f, 0.5f, 1.0f);

                //    break;

                case AlienCategory.Type.Grid:
                    pAlien = new AlienGrid(gameName, index, SpriteNames.NullObject, posX, posY);
                    pAlien.pCollisionObject.pCollisionSprite.pColor = new Azul.Color(0.0f, 0.0f, 1.0f);
                    Debug.WriteLine("Grid attach to {0}", pSpriteBatch.name);
                    GameObjManager.Attach(pAlien);
                    break;

                case AlienCategory.Type.Column:
                    pAlien = new AlienColumn(gameName, index, SpriteNames.NullObject, posX, posY);
                    pAlien.pCollisionObject.pCollisionSprite.pColor = new Azul.Color(1.0f, 0.0f, 0.0f);
                    Debug.WriteLine("Column attach to {0}", pSpriteBatch.name);
                    break;


                default:
                    Debug.Assert(false);
                    break;
            }
            // add it to the GameObjectManager
            //GameObjManager.Attach(pAlien);

            this.pTree.Insert(pAlien, this.pParent);

            // attach to Group
           // this.pSpriteBatch.Attach(pAlien.pFlyweightSprite);

            return pAlien;
        }

       // Data: ---------------------
        private PCSTree pTree;
        private SpriteBatchGroup pSpriteBatch;
        private PCSNode pParent;

    }
}
