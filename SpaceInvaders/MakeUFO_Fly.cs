using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class MakeUFO_Fly : Command
    {

        public MakeUFO_Fly()
        {
            
        }

        public override void execute(float deltaTime)
        {
            // get the tree
            PCSTree pTree = GameObjManager.GetRootTree();

            

            // Create UFO

            
            UFO_GoRight pUFO_FromRight2 = new UFO_GoRight(GameObjectNames.UFO_GoRight, SpriteNames.UFO_Sprite, 150, 875);
            //pSBG_Aliens.Attach(pUFO_FromRight.pFlyweightSprite);
           // pTree.Insert(pUFO_FromRight, pUFO_Root);


            // Attach the sprite to the correct sprite batch
            SpriteBatchGroup pSBG_UFO1 = SpriteBatchManager.Find(SpriteBatchGroup.Name.SBG_UFOs);
            pSBG_UFO1.Attach(pUFO_FromRight2.pFlyweightSprite);

            // Attach the UFO to the UfO root
            GameObject pUFO_Root2 = GameObjManager.Find(GameObjectNames.UFO_Root);
            pTree.Insert(pUFO_FromRight2, pUFO_Root2);

            //put the bomb in the UFO
            
            //CrossBomb pCrossBomb = new CrossBomb(GameObjectNames.CrossBomb, SpriteNames.CrossBombSprite, 150, 875);
            //pSBG_Aliens.Attach(pCrossBomb.pFlyweightSprite);
            //GameObject pBombRoot = GameObjManager.Find(GameObjectNames.BombRoot);
            //pTree.Insert(pCrossBomb, pBombRoot);
            
            Random r = new Random();
            int newDelta = r.Next(10, 20);
            Console.WriteLine("newDelta = " + newDelta);
           // TimerManager.Add(TimeEventNames.UFO_Flight_Time, this, newDelta);


        }
    }
}
