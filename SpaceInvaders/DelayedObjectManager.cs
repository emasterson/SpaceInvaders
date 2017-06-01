using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class DelayedObjectManager
    {
        static public void Attach(CollisionObserver observer)
        {
            Debug.Assert(observer != null);

            DelayedObjectManager pDelayManager = DelayedObjectManager.privInstance();

            // add to front
            if (pDelayManager.head == null)
            {
                pDelayManager.head = observer;
                observer.next = null;
                observer.prev = null;
            }
            else
            {
                observer.next = pDelayManager.head;
                pDelayManager.head.prev = observer;
                pDelayManager.head = observer;
            }
        }

        private void privDetach(CollisionObserver node, ref CollisionObserver head)
        {
            // protection
            Debug.Assert(node != null);

            if (node.prev != null)
            {	// middle or last node
                node.prev.next = node.next;
            }
            else
            {  // first
                head = (CollisionObserver)node.next;
            }

            if (node.next != null)
            {	// middle node
                node.next.prev = node.prev;
            }
        }

        static public void Process()
        {
            DelayedObjectManager pDelayMan = DelayedObjectManager.privInstance();

            CollisionObserver pNode = pDelayMan.head;

            while (pNode != null)
            {
                // Fire off listener
                pNode.execute();

                pNode = (CollisionObserver)pNode.next;
            }


            // remove
            pNode = pDelayMan.head;
            CollisionObserver pTmp = null;

            while (pNode != null)
            { 
                pTmp = pNode;
                pNode = (CollisionObserver)pNode.next;
                
                // remove
                pDelayMan.privDetach(pTmp, ref pDelayMan.head);
            }
        }

        private DelayedObjectManager()
        {
            this.head = null;
            
        }

        private static DelayedObjectManager privInstance()
        {
            // Do the initialization
            if (instance == null)
            {
                instance = new DelayedObjectManager();
            }

            // Safety - this forces users to call create first
            Debug.Assert(instance != null);

            return instance;
        }

        // Data: ------------------------
        private CollisionObserver head;
        private static DelayedObjectManager instance = null;
    }
}
