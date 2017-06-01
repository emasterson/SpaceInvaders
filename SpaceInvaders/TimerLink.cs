using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    public abstract class TimerLink
    {
        protected TimerLink()
        {
            this.next = null;
            this.prev = null;
            this.timeStamp = 0;
        }

        abstract public Enum getName();
  

        // Data -------------------
        public TimerLink next;
        public TimerLink prev;
        public int timeStamp;

    }
}
