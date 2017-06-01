using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class AlienObserver : CollisionObserver
    {
        public AlienObserver()
        {

        }

        public override void Notify()
        {

           // GameObject Node = (GameObject)this.subject.pGameObj;

           //FlyweightSprite myFlyweightSprite = this.subject.pGameObj.pFlyweightSprite;


           // GameObjManager.RemoveNode(Node);

           // SpriteBatchManager.DeleteSpriteBatchNode(myFlyweightSprite);
            //missile has been deleted
            Debug.WriteLine(" delete alien {0}", this.subject.pGameObj);
           // Debug.Assert(false);
        }

        public override void execute()
        {
            
        }
    }
}
