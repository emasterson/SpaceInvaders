using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract class Manager
    {

        //protected Manager()
        protected Manager(int _reserveNum, int _reserveGrow)
        {
            // set everything to default
            this.active = null;
            this.reserve = null;

            //stats
           
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

        //don't use so make private
        private Manager()
        {
            // force do not use
        }

        // PRIVATE NODE METHODS
        protected void privFillPool(int count)
        {
            // add to the count
            this.stats.totalNumNodes += count;
            this.stats.currNumReserveNodes += count;
            if (this.stats.totalNumNodes > this.stats.maxTotalNumNodes)
            {
                this.stats.maxTotalNumNodes = this.stats.totalNumNodes;
            }
            //allocate Objects
            for (int i = 0; i < count; i++)
            {
                // gets a new Image, or new Texture, or new Sprite object
                object pObj = privGetNewObj();
                //move it to the reserve list , puts the newly created object on reserve list
                privAddNode((ManagerLink)pObj, ref this.reserve);
            }
        }

        private ManagerLink privGetNodeFirstNode(ref ManagerLink head)
        {
            //protection
            Debug.Assert(head != null);

            //pop from the front
            ManagerLink node = head;

            // correct head, point head to next node on list
            head = node.next;

            // Take the first node off the list
            if (node.next != null)
            {
                node.next.prev = node.prev;
            }

            return node;

        }

        private ManagerLink privGetReserveObject()
        {
            if (this.reserve == null)
            {
                //fill pool with more nodes
                // now preload the timeEvents
                this.privFillPool(this.stats.reserveGrow);
            }

            //make sure we have nodes
            Debug.Assert(this.reserve != null);

            //detach 1 from the reserve pool
            ManagerLink pManagerLink = this.privGetNodeFirstNode(ref this.reserve);
            this.stats.currNumReserveNodes--;

            return pManagerLink;
        }

        //Adds node to a list, could be active, could be reserve, Manager owns the nodes, must do new / delete
        private void privAddNode(ManagerLink node, ref ManagerLink head)
        {
            //protection
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

        private void privRemoveNode(ManagerLink node, ref ManagerLink head)
        {
            // protection
            Debug.Assert(node != null);

            if (node.prev != null)
            {
                //middle or last node
                node.prev.next = node.next;

            }
            else
            {
                //first
                head = node.next;
            }

            if (node.next != null)
            {
                // middle node
                node.next.prev = node.prev;
            }
        }

        //--------------------------------------------------------]
        // protected base methods
        //-------------------------------------------------

        // Method used in the derived class:
        protected ManagerLink baseAdd()
        {
            // Get node from the reserve
            ManagerLink pNode = this.privGetReserveObject();

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

        protected void baseAdd(ManagerLink node)
        {
            //make sure it is not null
            Debug.Assert(node != null);
            // get the singleton
            //imageManager is instance pointer for this obj
           // ImageManager imageManager = ImageManager.privInstance();

            if (this.active == null)
            {
                //only node
                node.next = null;
                node.prev = null;
                this.active = node;

            }
            else
            {
                //add to front
                node.next = this.active;
                node.prev = null;
                this.active.prev = node;
                this.active = node;
            }
            this.stats.totalNumNodes++;
        }

        // Method used in the derived class:
        protected void baseDestroy()
        {
            // search for the name
            ManagerLink pNode;
            ManagerLink tmpNode;

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

        protected ManagerLink basefind(Enum name, Enum index)
        {
            // get the instance pointer
           // ImageManager imageManager = ImageManager.privInstance();
            // get the head
           // Image pImage = (Image)imageManager.active;
            ManagerLink node = this.active;
            // iterate thru looking for name
            while (node != null)
            {
                if (node.getName().Equals(name) && node.getIndex().Equals(index))
                {
                    break;
                }
                node = node.next;
            }
            return node;
        }

        
        protected void baseRemove(Enum name, Enum index)
        {
            // remove
            ManagerLink node = this.basefind(name, index);
            Debug.Assert(node != null);

            if (node.prev != null)
            {
                // middle or last node
                node.prev.next = node.next;
            }
            else
            {
                //first
                this.active = node.next;
            }

            if (node.next != null)
            {
                //middle node
                node.next.prev = node.prev;
            }
            this.stats.totalNumNodes--;
        }

        protected void baseRemove(ManagerLink node)
        {
           
            if (node.prev != null)
            {
                // middle or last node
                node.prev.next = node.next;
            }
            else
            {
                //first
                this.active = node.next;
            }

            if (node.next != null)
            {
                node.next.prev = node.prev;
            }
            this.stats.totalNumNodes--;
        }

        protected void baseRemove(GameObjectNode node)
        {

            if (node.prev != null)
            {
                // middle or last node
                node.prev.next = node.next;
            }
            else
            {
                //first
                this.active = node.next;
            }

            if (node.next != null)
            {
                node.next.prev = node.prev;
            }
            this.stats.totalNumNodes--;
        }

        

        // Base Contract - Manager class is dependent on Derive's getNewObject()
        abstract protected object privGetNewObj();

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
        

        //------------------------
        // Internal Structures
        //---------------------------------

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

        //----------------DATA
        //protected Image pHead;
        //protected Image active;
        //protected int numNodes;

        // change to ManagerLink
        protected ManagerLink pHead;
        public ManagerLink active;
       // protected ManagerLink reserve;
        public ManagerLink reserve;
       // protected int numNodes;

        protected Stats stats;
    }
}
