using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class PCSTreeContraryIterator :  Iterator
    {

        public PCSTreeContraryIterator(GameObject rootNode)
        {
            Debug.Assert(rootNode != null);
            this.root = rootNode;
            this.currentNode = this.root;

            GameObject tmp = rootNode;
            // Initialize the reserve pointer
            GameObject pGameObj = this.First();

            if (pGameObj.child != null)
            {
                while (pGameObj != null)
                {
                    // fill the basis
                    tmp = pGameObj;

                   // Debug.WriteLine("--tmp: {0}", tmp);
                    // Advance
                    pGameObj = this.privSecretNext();

                    if (pGameObj != null)
                    {
                        pGameObj.reverse = tmp;
                    }
                }
            }
            else
            {   // if the root node does Not have children
                pGameObj.reverse = null;
            }

            this.root = tmp;
        }

        public override GameObject First()
        {
            this.currentNode = this.root;
            return this.currentNode;
        }

        public override GameObject Next()
        {

            this.currentNode = (GameObject)this.currentNode.reverse;

            return this.currentNode;
        }

        private GameObject privSecretNext()
        {
            this.currentNode = privGetNext(this.currentNode);

            return this.currentNode;
        }

        private GameObject privGetNext(GameObject node, bool UseChild = true)
        {
            GameObject tmp = null;

            if ((node.child != null) && UseChild)
            {
                tmp = (GameObject)node.child;
            }
            else if (node.sibling != null)
            {
                tmp = (GameObject)node.sibling;
            }
            else if (node.parent != this.root)
            {
                // recurse here
                tmp = this.privGetNext((GameObject)node.parent, false);
            }
            else
            {
                tmp = null;
            }
            return tmp;
        }

        public override bool IsDone()
        {
            return (this.currentNode == null);
        }

        public override GameObject CurrentItem()
        {
            return this.currentNode;
        }

        private GameObject root;
        private GameObject currentNode;
    }
}
