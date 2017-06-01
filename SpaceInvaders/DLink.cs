using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    abstract class DLink
    {
        protected DLink()
        {
            this.next = null;
            this.prev = null;
        }

        //Data:-----------------------
        public DLink next;
        public DLink prev;
    }
}
