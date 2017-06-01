using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class PCSTreeIterator : Iterator
    {
        public PCSTreeIterator(GameObject rootNode)
        {
            Debug.Assert(rootNode != null);
            this.root = rootNode;
            this.current = this.root;

        }

        public override GameObject First()
        {
            this.current = this.root;
            return this.current;
        }

        public override GameObject Next()
        {
            this.current = privGetNext(this.current);
            return this.current;
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
            return (this.current == null);
        }

        public override GameObject CurrentItem()
        {
            return this.current;
        }

        //data --------------------
        private GameObject root;
        private GameObject current;
    }
}
