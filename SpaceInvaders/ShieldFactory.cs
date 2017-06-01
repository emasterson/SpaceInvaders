using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ShieldFactory
    {
        public ShieldFactory(SpriteBatchGroup.Name spriteBatchGroupName, PCSTree tree)
        {
            this.pSpriteBatchGroup = SpriteBatchManager.Find(spriteBatchGroupName);
            Debug.Assert(this.pSpriteBatchGroup != null);

            this.pTree = tree;
        }

        public void setParent(PCSNode parentNode)
        {
            this.pParent = parentNode;
            Debug.Assert(this.pParent != null);
        }

        ~ShieldFactory()
        {
            Debug.WriteLine("~ShieldFactory():");
            this.pSpriteBatchGroup = null;
        }

        public ShieldCategory Create(ShieldCategory.Type type, GameObjectNames gameName, Index index, float posX = 0.0f, float posY = 0.0f)
        {
            ShieldCategory pShield = null;

            switch (type)
            {
                case ShieldCategory.Type.Brick:
                    pShield = new ShieldBrick(gameName, index, SpriteNames.Brick, posX, posY);
                    this.pSpriteBatchGroup.Attach(pShield.pFlyweightSprite);
                    break;

                case ShieldCategory.Type.LeftTop1:
                    pShield = new ShieldBrick(gameName, index, SpriteNames.Brick_LeftTop1, posX, posY);
                    this.pSpriteBatchGroup.Attach(pShield.pFlyweightSprite);
                    break;

                case ShieldCategory.Type.LeftTop0:
                    pShield = new ShieldBrick(gameName, index, SpriteNames.Brick_LeftTop0, posX, posY);
                    this.pSpriteBatchGroup.Attach(pShield.pFlyweightSprite);
                    break;

                case ShieldCategory.Type.LeftBottom:
                    pShield = new ShieldBrick(gameName, index, SpriteNames.Brick_LeftBottom, posX, posY);
                    this.pSpriteBatchGroup.Attach(pShield.pFlyweightSprite);
                    break;


                case ShieldCategory.Type.RightTop1:
                    pShield = new ShieldBrick(gameName, index, SpriteNames.Brick_RightTop1, posX, posY);
                    this.pSpriteBatchGroup.Attach(pShield.pFlyweightSprite);
                    break;

                case ShieldCategory.Type.RightTop0:
                    pShield = new ShieldBrick(gameName, index, SpriteNames.Brick_RightTop0, posX, posY);
                    this.pSpriteBatchGroup.Attach(pShield.pFlyweightSprite);
                    break;

                case ShieldCategory.Type.RightBottom:
                    pShield = new ShieldBrick(gameName, index, SpriteNames.Brick_RightBottom, posX, posY);
                    this.pSpriteBatchGroup.Attach(pShield.pFlyweightSprite);
                    break;

                case ShieldCategory.Type.Root:
                    pShield = new ShieldRoot(gameName, SpriteNames.NullObject, posX, posY);
                    pShield.SetCollisionColor(0.0f, 0.0f, 1.0f);
                    GameObjManager.Attach(pShield);
                    break;



                case ShieldCategory.Type.Column:
                    pShield = new ShieldColumn(gameName, index, SpriteNames.NullObject, posX, posY);
                    pShield.SetCollisionColor(1.0f, 0.0f, 0.0f);
                    break;

                default:
                    Debug.Assert(false);
                    break;

            }

            this.pTree.Insert(pShield, this.pParent);

            return pShield;
        }



        // Data: ---------------------
        private PCSTree pTree;
        private SpriteBatchGroup pSpriteBatchGroup;
        private PCSNode pParent;
    }


}
