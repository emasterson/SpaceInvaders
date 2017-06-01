using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class CollisionSubject
    {
        public void AttachObserver(CollisionObserver observer)
        {
            Debug.Assert(observer != null);

            observer.subject = this;

            // add to front of list
            if (pCollisionObserver == null)
            {
                pCollisionObserver = observer;
                observer.next = null;
                observer.prev = null;
            }
            else
            {
                
                observer.next = pCollisionObserver;
                pCollisionObserver.prev = observer;
                pCollisionObserver = observer;
            }
        }

        public void CollisionSubTellObservers()
        {
            CollisionObserver pNode = this.pCollisionObserver;

            while (pNode != null)
            {
                // Fire off listener
                pNode.Notify();

                pNode = (CollisionObserver)pNode.next;
            }

        }

        public void Detach()
        {
        }

        // Data: ------------------------
        private CollisionObserver pCollisionObserver;
        public GameObject pGameObj;
        public GameObject objA;
        public GameObject objB;

    }
}
