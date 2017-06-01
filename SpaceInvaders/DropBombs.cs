using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class DropBombs : Command
    {
        public DropBombs()
        {

        }

        public override void execute(float deltaTime)
        {
            // get the tree
            PCSTree pTree = GameObjManager.GetRootTree();

            CrossBomb pCrossBomb = new CrossBomb(GameObjectNames.CrossBomb, SpriteNames.CrossBombSprite, 200, 450);

            
           // UFO_FromRight pUFO_FromRight = new UFO_FromRight(GameObjectNames.UFO_FromRight, SpriteNames.UFO_Sprite, 150, 875);
            //pSBG_Aliens.Attach(pUFO_FromRight.pFlyweightSprite);
           // pTree.Insert(pUFO_FromRight, pUFO_Root);


            // Attach the sprite to the correct sprite batch
            SpriteBatchGroup pSBG_Aliens = SpriteBatchManager.Find(SpriteBatchGroup.Name.SBG_Aliens);
            //pSBG_Aliens.Attach(pUFO_FromRight.pFlyweightSprite);

            pSBG_Aliens.Attach(pCrossBomb.pFlyweightSprite);

            // Attach the UFO to the UfO root
            //GameObject pUFO_Root2 = GameObjManager.Find(GameObjectNames.UFO_Root);
            //pTree.Insert(pUFO_FromRight, pUFO_Root2);

            //Attach bomb to bombRoot
            GameObject pBombRoot = GameObjManager.Find(GameObjectNames.BombRoot);
            pTree.Insert(pCrossBomb, pBombRoot);
            
            //CrossBomb pCrossBomb = new CrossBomb(GameObjectNames.CrossBomb, SpriteNames.CrossBombSprite, 150, 875);
            //pSBG_Aliens.Attach(pCrossBomb.pFlyweightSprite);
            //GameObject pBombRoot = GameObjManager.Find(GameObjectNames.BombRoot);
            //pTree.Insert(pCrossBomb, pBombRoot);

            Random r = new Random();
            int newDelta = r.Next(1, 5);
            Console.WriteLine("newDelta = " + newDelta);
            TimerManager.Add(TimeEventNames.DropCrossBomb, this, newDelta);


        
        }
    }
}
