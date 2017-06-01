using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract class PCSNode // i tried this at 7:10pm
    {
        // Constructors: ---------------------------
        public PCSNode()
        {
            this.parent = null;
            this.child = null;
            this.sibling = null;
            this.reverse = null;
        }

        public PCSNode(PCSNode pNode)
        {
            this.parent = pNode.parent;
            this.child = pNode.child;
            this.sibling = pNode.sibling;
            this.reverse = null;
        }

        public PCSNode(PCSNode pParent, PCSNode pChild, PCSNode pSibling)
        {
            this.parent = pParent;
            this.child = pChild;
            this.sibling = pSibling;
            this.reverse = null;
        }

        // methods

        abstract public Enum getName();
        abstract public Enum getIndex();

        //methods dump
        public void dumpNode()
        {
            Debug.WriteLine("");

            Debug.WriteLine("    name: {0} {1}", this.getName(), this.getIndex());
            if (this.parent != null)
            {
                Debug.WriteLine("  parent: {0} {1}", this.parent.getName(), this.parent.getIndex());
            }
            else
            {
                Debug.WriteLine("  parent: ------");
            }
            if (this.child != null)
            {
                Debug.WriteLine("   child: {0} {1}", this.child.getName(), this.child.getIndex());
            }
            else
            {
                Debug.WriteLine("   child: ------");
            }
            if (this.sibling != null)
            {
                Debug.WriteLine(" sibling: {0} {1}", this.sibling.getName(), this.sibling.getIndex());
            }
            else
            {
                Debug.WriteLine(" sibling: ------");
            }
            
        }

        // data ----------------------
        public PCSNode parent;
        public PCSNode child;
        public PCSNode sibling;
        public PCSNode reverse;
    }
}
