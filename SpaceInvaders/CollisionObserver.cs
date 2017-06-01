using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    abstract class CollisionObserver : CollisionLink
    {
        public abstract void Notify();
        abstract public void execute();

        public CollisionSubject subject;
    }


}
