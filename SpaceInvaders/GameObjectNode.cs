using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class GameObjectNode : ManagerLink
    {

         public GameObjectNode()
            : base()
        {
            this.pGameObj = null;
        }

        public void Set(GameObject gameObject)
        {
            this.pGameObj = gameObject;
        }

        

        override public Enum getName()
        {
            return this.pGameObj.name;
        }

        override public Enum getIndex()
        {
            return this.pGameObj.index;
        }

        

        // Data: ------------------

        public GameObject pGameObj;
        
        // Note: Name is stored in GameObject
    }
}
