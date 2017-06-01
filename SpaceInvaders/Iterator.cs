using System;


namespace SpaceInvaders
{
    abstract class Iterator
    {
        public abstract GameObject First();
        public abstract GameObject Next();
        public abstract bool IsDone();
        public abstract GameObject CurrentItem();
    }
}
