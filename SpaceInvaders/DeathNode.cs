using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class DeathNode : ManagerLink
    {
        enum Name
        {
            Not_initialized
        }

        public DeathNode()
            : base()
        {
            this.pObject = null;
            this.name = DeathNode.Name.Not_initialized;
            this.index = DeathNode.Name.Not_initialized;
        }

        public void Set(object pObj)
        {
            this.name = DeathNode.Name.Not_initialized;
            this.index = DeathNode.Name.Not_initialized;
            this.pObject = pObj;
        }

        override public Enum getName()
        {
            return this.name;
        }

        override public Enum getIndex()
        {
            return this.index;
        }

        public Enum name;
        public Enum index;
        public object pObject;
    }
}
