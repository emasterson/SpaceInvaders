using System;
using System.Diagnostics;

namespace SpaceInvaders
{
     public abstract class Container : ManagerLink
    {
        //-----------------------------------------------------------------------------------------
        // Public constructor:  
        //-----------------------------------------------------------------------------------------

        // specialized constructor
        protected Container(int _reserveNum, int _reserveGrow)
        {
            //Debug.WriteLine("Container()" + " reserve " + _reserveNum + " grow " + _reserveGrow);

            // set everything to default
            this.active = null;
            this.reserve = null;

            // stats
            this.stats.currNumActiveNodes = 0;
            this.stats.maxNumActiveNodes = 0;
            this.stats.totalNumNodes = 0;
            this.stats.maxNumActiveNodes = 0;
            this.stats.currNumReserveNodes = 0;
            this.stats.reserveGrow = _reserveGrow;
            this.stats.reserveNum = _reserveNum;

            // now fill with new nodes
            this.privFillPool(_reserveNum);
        }

        //-----------------------------------------------------------------------------------------
        // Private:  
        //-----------------------------------------------------------------------------------------

        // Do Not use, so make it private
        private Container()
        {
            // force a do not use
        }

        //-----------------------------------------------------------------------------------------
        // Private nodes methods:  
        //-----------------------------------------------------------------------------------------

        protected void privFillPool(int count)
        {
            // add to the count
            this.stats.totalNumNodes += count;
            this.stats.currNumReserveNodes += count;
            if (this.stats.totalNumNodes > this.stats.maxTotalNumNodes)
            {
                this.stats.maxTotalNumNodes = this.stats.totalNumNodes;
            }
            // allocate Objects
            for (int i = 0; i < count; i++)
            {
                // create a new Object
                object pObj = privGetNewObj();
                // move it to InActive list
                privAddNode((ContainerLink)pObj, ref this.reserve);
            }
        }

        private ContainerLink privGetNodeFirstNode(ref ContainerLink head)
        {
            // Protection
            Debug.Assert(head != null);

            // Pop from front
            ContainerLink node = head;

            // Correct head
            head = node.next;

            // Take it off the list
            if (node.next != null)
            {
                node.next.prev = node.prev;
            }

            return node;
        }

        private ContainerLink privGetReserveObject()
        {
            if (this.reserve == null)
            {
                // fill pool with more nodes
                // OK now preload the timeEvents
                this.privFillPool(this.stats.reserveGrow);
            }
            // make sure we have nodes
            Debug.Assert(this.reserve != null);

            // Detach 1 from the reserve pool
            ContainerLink pContainerLink = this.privGetNodeFirstNode(ref this.reserve);

            this.stats.currNumReserveNodes--;

            return pContainerLink;
        }

        private void privAddNode(ContainerLink node, ref ContainerLink head)
        {
            // protection
            Debug.Assert(node != null);

            // add to front
            if (head == null)
            {
                head = node;
                node.next = null;
                node.prev = null;
            }
            else
            {
                node.next = head;
                head.prev = node;
                head = node;
            }
        }

        private void privRemoveNode(ContainerLink node, ref ContainerLink head)
        {
            // protection
            Debug.Assert(node != null);

            if (node.prev != null)
            {	// middle or last node
                node.prev.next = node.next;
            }
            else
            {  // first
                head = node.next;
            }

            if (node.next != null)
            {	// middle node
                node.next.prev = node.prev;
            }
        }

        //-----------------------------------------------------------------------------------------
        // Protected Base methods: 
        //-----------------------------------------------------------------------------------------

        // Method used in the derived class:
        protected ContainerLink baseAdd()
        {
            // Get node from the reserve
            ContainerLink pNode = this.privGetReserveObject();

            // make sure its valid
            Debug.Assert(pNode != null);

            // Add node to active
            privAddNode(pNode, ref this.active);

            // Update stats
            this.stats.currNumActiveNodes++;

            if (this.stats.currNumActiveNodes > this.stats.maxNumActiveNodes)
            {
                this.stats.maxNumActiveNodes = this.stats.currNumActiveNodes;
            }

            return pNode;
        }

        // Method used in the derived class:
        protected ContainerLink baseFind(Enum name, Enum index)
        {
            // search for the name
            ContainerLink node = this.active;

            while (node != null)
            {
                //if (node.getName().Equals(name) && node.getIndex().Equals(index))
                if (node.getName().Equals(name))
                {
                    // found it
                    break;
                }
                node = node.next;
            }

            return node;
        }

        // Method used in the derived class:
        protected void baseRemove(Enum name, Enum index)
        {
            // find the node by name
            ContainerLink pNode = this.baseFind(name, index);

            // make sure its not a null 
            Debug.Assert(pNode != null);

            // remove from active
            privRemoveNode(pNode, ref this.active);

            // add to reserve
            privAddNode(pNode, ref this.reserve);

            this.stats.currNumActiveNodes--;
            this.stats.currNumReserveNodes++;

        }

        // Method used in the derived class:
        protected void baseRemove(ContainerLink node)
        {
            // find the node by name
           // ContainerLink pNode = this.baseFind(name, index);

            // make sure its not a null 
            Debug.Assert(node != null);

            // remove from active
            privRemoveNode(node, ref this.active);

            // add to reserve
            privAddNode(node, ref this.reserve);

            this.stats.currNumActiveNodes--;
            this.stats.currNumReserveNodes++;

        }

        // Base Contract - Man class is dependent on Derive's getNewObject()
        abstract protected object privGetNewObj();

        // Method used in the derived class:
        protected void baseDestroy()
        {
            // search for the name
            ContainerLink pNode;
            ContainerLink tmpNode;

            // Active List
            pNode = this.active;
            while (pNode != null)
            {
                // walking through the list
                tmpNode = pNode;
                pNode = pNode.next;

                // node to cleanup
                this.privRemoveNode(tmpNode, ref this.active);
                tmpNode = null;
                this.stats.currNumActiveNodes--;
                this.stats.totalNumNodes--;
            }

            // Reserve List
            pNode = this.reserve;
            while (pNode != null)
            {
                // walking through the list
                tmpNode = pNode;
                pNode = pNode.next;

                // node to cleanup
                this.privRemoveNode(tmpNode, ref this.reserve);
                tmpNode = null;
                this.stats.currNumReserveNodes--;
                this.stats.totalNumNodes--;
            }


        }

        // print stats
        protected void basePrintStats()
        {
            Debug.WriteLine("Stats:");
            Debug.WriteLine("     currNumActiveNodes: " + this.stats.currNumActiveNodes);
            Debug.WriteLine("    currNumReserveNodes: " + this.stats.currNumReserveNodes);
            Debug.WriteLine("          totalNumNodes: " + this.stats.totalNumNodes);
            Debug.WriteLine("      maxNumActiveNodes: " + this.stats.maxNumActiveNodes);
            Debug.WriteLine("            reserveGrow: " + this.stats.reserveGrow);
            Debug.WriteLine("             reserveNum: " + this.stats.reserveNum);
            Debug.WriteLine("       MaxTotalNumNodes: " + this.stats.maxTotalNumNodes);

            if (this.stats.maxTotalNumNodes > this.stats.reserveNum)
            {
                Debug.WriteLine("--> Change reserve:" + this.stats.maxTotalNumNodes + " instead of :" + this.stats.reserveNum);
            }
        }

        //-----------------------------------------------------------------------------------------
        // Internal Stuctures:
        //-----------------------------------------------------------------------------------------

        protected struct Stats
        {
            public int currNumActiveNodes;
            public int currNumReserveNodes;
            public int totalNumNodes;
            public int maxTotalNumNodes;
            public int maxNumActiveNodes;
            public int reserveGrow;
            public int reserveNum;
        }

        //-----------------------------------------------------------------------------------------
        // Data:
        //-----------------------------------------------------------------------------------------

        public ContainerLink active;
        protected ContainerLink reserve;

        protected Stats stats;
    }
}
