using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    public abstract class ManagerLink 
    {
        protected ManagerLink()
        {
            this.next = null;
            this.prev = null;
        }

        abstract public Enum getName();
        abstract public Enum getIndex();
  

        // Data -------------------
        public ManagerLink next;
        public ManagerLink prev;
    }
}
