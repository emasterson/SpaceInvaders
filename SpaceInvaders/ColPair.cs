using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ColPair : ManagerLink
    {
        public enum Name
        {
            Alien_Missile,
            Alien_Shield,
            NullObject,
            Missile_Shield,
            Missile_Ceiling,
            LeftWall_AlienGrid,
            RightWall_AlienGrid,
            CrossBomb_Shield,
            CrossBomb_Floor,
            UFO_RightWall,
            UFO_Missile,
            CrossBomb_PlayerShip,
            Not_Initialized
        }

        public ColPair()
            : base()
        {
            this.treeA = null;
            this.treeB = null;
            this.name = ColPair.Name.Not_Initialized;
            this.index = Index.i0;
            //this.subjectA = null;
            //this.subjectB = null;
            this.subject = null;
        }

        ~ColPair()
        {

        }

        public void Set(ColPair.Name pairName, Index n, GameObject treeRootA, GameObject treeRootB)
        {
            this.treeA = treeRootA;
            this.treeB = treeRootB;
            this.name = pairName;
            this.index = n;
            //this.subjectA = new CollisionSubject();
            //this.subjectB = new CollisionSubject();
            this.subject = new CollisionSubject();
        }

        public void Process()
        {
            Collide(this.treeA, this.treeB, true);
        }

        

        static public void Collide(GameObject pSafeTreeA, GameObject pSafeTreeB, bool flag = false)
        {

            // A vs B
            GameObject pNodeA = pSafeTreeA;
            GameObject pNodeB = pSafeTreeB;

            while (pNodeA != null && (pNodeA != pSafeTreeB))
            {
                // Restart compare
                pNodeB = pSafeTreeB;

                // added safety 
                while (pNodeB != null && (pNodeB != pSafeTreeA))
                {
                    // added safety no way that you compare against itself
                    Debug.Assert(pNodeA != pNodeB);
                    // who is being tested?
                   // Debug.WriteLine("collide:  {0}, {1}", pNodeA.getName(), pNodeB.getName());

                    // Get rectangles
                    CollisionRect rectA = pNodeA.pCollisionObject.pCollisionRect;
                    CollisionRect rectB = pNodeB.pCollisionObject.pCollisionRect;

                    // test them
                    if (CollisionRect.Intersect(rectA, rectB))
                    {
                       // Debug.WriteLine("collide:  {0}, {1}", pNodeA.getName(), pNodeB.getName());
                        // Boom - it works (Visitor in Action)
                        pNodeA.Accept(pNodeB);
                        return;
                    }
                    else if (flag == true)
                    {
                        // first time through collision tree, if no high level collision 
                        // tree is complete
                        return;
                    }

                    pNodeB = (GameObject)pNodeB.sibling;
                }
                pNodeA = (GameObject)pNodeA.sibling;
            }
        }

        //public void Attach_Sub_A(CollisionObserver observer)
        //{
        //    this.subjectA.AttachObserver(observer);
        //}

        //public void Attach_Sub_B(CollisionObserver observer)
        //{
        //    this.subjectB.AttachObserver(observer);
        //}

        public void AttachObserverToSubject(CollisionObserver observer)
        {
            this.subject.AttachObserver(observer);
        }

        public void SetCollision(GameObject objA, GameObject objB)
        {
           // GameObject pAlien = AlienCategory.GetAlien(objA, objB);
            this.subject.objA = objA;
            this.subject.objB = objB;
        }

        public void NotifyListeners()
        {
           // this.subjectA.CollisionSubTellObservers();
           // this.subjectB.CollisionSubTellObservers();
            this.subject.CollisionSubTellObservers();
        }
        

        override public Enum getName()
        {
            return this.name;
        }

        override public Enum getIndex()
        {
            return this.index;
        }

        // Data: ---------------
        public ColPair.Name name;
        public Index index;
        public GameObject treeA;
        public GameObject treeB;
        
        public CollisionSubject subject;
    }
}
