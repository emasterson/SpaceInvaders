using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class PCSTree
    {
        public enum Name
        {
            Root,
            Not_Initialized
        }

        // constructor
        public PCSTree()
        {
            this.root = null;
            this.maxNodeCount = 0;
            this.numNodes = 0;

            ////create the root
            //PCSNode pcsRoot = new PCSRootNode(PCSTree.Name.Root);
            //this.Insert(pcsRoot, null);
        }

        public PCSNode getRoot()
        {
            return this.root;
        }

        //insert
        public void Insert(PCSNode inNode, PCSNode pParent)
        {
            Debug.Assert(inNode != null);

            //insert to root
            if (null == pParent)
            {
                this.root = inNode;
                inNode.child = null;
                inNode.parent = null;
                inNode.sibling = null;

                this.privInfoAddNode();
            }
            else
            {
                //insert inside the tree
                if (pParent.child == null)
                {
                    // child is 0, just add child
                    pParent.child = inNode;

                    inNode.parent = pParent;
                    inNode.child = null;
                    inNode.sibling = null;

                    this.privInfoAddNode();
                }
                else
                {
                    // add as sibling

                    //get first child
                    PCSNode first = pParent.child;

                    inNode.parent = pParent;
                    inNode.child = null;
                    inNode.sibling = first;

                    pParent.child = inNode;

                    this.privInfoAddNode();
                }
            }
        }

        // remove
        public void Remove(PCSNode inNode)
        {
            Debug.Assert(inNode != null);

            if (inNode.child == null)
            {
                // last node
                if (inNode.sibling == null)
                {
                    // find the previous child
                    PCSNode pParent;
                    pParent = inNode.parent;

                    // special case root
                    if (pParent == null)
                    {
                        this.root = null;
                    }
                    else
                    {   // no children, no younger siblings
                        privRemoveNodeNoYoungerSiblings(inNode, pParent);
                    }
                }
                else
                {   // No children, but has other younger siblings
                    privRemoveNodeHasYoungerSiblings(inNode);
                }

                inNode.child = null;
                inNode.parent = null;
                inNode.sibling = null;
                this.privInfoRemoveNode();
                return;
            }
            else
            {
                // If we are here, recursively call
                PCSNode pTmp = inNode.child;
                Debug.Assert(pTmp != null);

                this.Remove(pTmp);
                this.Remove(inNode);
            }
        }

        private void privRemoveNodeNoYoungerSiblings(PCSNode inNode, PCSNode pParent)
        {
            Debug.Assert(pParent != null);

            PCSNode pTmp;
            // goto eldest child
            pTmp = pParent.child;
            Debug.Assert(pTmp != null);

            if (pTmp.sibling == null)
            {   // delete inNode so it's parent is 0
                // in child has no siblings
                pParent.child = null;
            }
            else
            {   // now iterate until child
                while (pTmp.sibling != inNode)
                {
                    pTmp = pTmp.sibling;
                }
                // this point we found the sibling
                PCSNode pPrev = pTmp;
                pPrev.sibling = null;
            }
        }

        private void privRemoveNodeHasYoungerSiblings(PCSNode inNode)
        {
            // I have a sibling to the right of me
            // find the previous child
            PCSNode pParent;
            pParent = inNode.parent;
            Debug.Assert(pParent != null);

            PCSNode pTmp;

            // goto eldest child
            pTmp = pParent.child;
            Debug.Assert(pTmp != null);

            if (pTmp == inNode)
            {   // we are deleting a eldest child with siblings
                pParent.child = pTmp.sibling;
            }
            else
            {   // now iterate until child
                while (pTmp.sibling != inNode)
                {
                    pTmp = pTmp.sibling;
                }

                // this point we found the sibling
                PCSNode pPrev = pTmp;
                pPrev.sibling = inNode.sibling;
            }
        }

        public void dumpTree()
        {
            Debug.WriteLine("");
            Debug.WriteLine("dumpTree () -------------------------------");
            this.privDumpTreeDepthFirst(this.root);
        }


        private void privDumpTreeDepthFirst(PCSNode pNode)
        {
            PCSNode pChild = null;

            // dump
            pNode.dumpNode();

            // iterate through all of the active children 
            if (pNode.child != null)
            {
                pChild = pNode.child;
                // make sure that allocation is not a child node 
                while (pChild != null)
                {
                    privDumpTreeDepthFirst(pChild);
                    // goto next sibling
                    pChild = pChild.sibling;
                }
            }
            else
            {
                // bye bye exit condition
            }
        }

        

        private void privInfoAddNode()
        {
            this.numNodes += 1;

            if (this.numNodes > this.maxNodeCount)
            {
                this.maxNodeCount += 1;
            }
        }

        private void privInfoRemoveNode()
        {
            numNodes -= 1;
        }

        class PCSRootNode : PCSNode
        {
            public PCSRootNode(PCSTree.Name treeName)
                : base()
            {
                this.name = treeName;
                this.index = Index.i0;
            }

            public override Enum getName()
            {
                return this.name;
            }

            public override Enum getIndex()
            {
                return this.index;
            }

            private PCSTree.Name name;
            private Index index;
        }

        //data --------------

        private PCSNode root;
        public int numNodes;
        public int maxNodeCount;
    }
}
