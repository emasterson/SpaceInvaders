using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class MissileObserver : CollisionObserver
    {
        public MissileObserver()
        {

        }

        public override void Notify()
        {
           // GameObject rootNode = (GameObject)this.subject.pGameObj.getRoot();
           // FlyweightSprite myFlyweightSprite = this.subject.pGameObj.pFlyweightSprite;
           //GameObjManager.RemoveNode(rootNode);
           //SpriteBatchManager.DeleteSpriteBatchNode(myFlyweightSprite);

           GameObject pMissile = MissileCategory.GetMissile(this.subject.objA, this.subject.objB);
           pMissile.RemoveMe(); 


         //  GameObjManager.Remove(this.subject.pGameObj.getName());
            //missile has been deleted
            Debug.WriteLine(" delete missile {0}", this.subject.pGameObj);
           // Debug.Assert(false);
        }

        public override void execute()
        {
            
        }
    }
}
