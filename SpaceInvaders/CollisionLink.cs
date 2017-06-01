using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    abstract class CollisionLink
    {
        protected CollisionLink()
        {
            this.next = null;
            this.prev = null;
        }

        //Data --------------------
        public CollisionLink next;
        public CollisionLink prev;
    }
}
