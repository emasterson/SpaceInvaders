using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    public abstract class ContainerLink
    {
        protected ContainerLink()
        {
            this.baseInitialize();
        }

        protected void baseInitialize()
        {
            this.next = null;
            this.prev = null;
        }

        abstract public Enum getName();
       // abstract public Enum getIndex();

        // Data: -----------------------------
        public ContainerLink next;
        public ContainerLink prev;
    }
}
