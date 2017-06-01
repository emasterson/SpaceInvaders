using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    //this is the context class
    abstract class ShipState
    {
        public abstract void HandleTheChangeState(PlayerShip playerShip);

        
    }
}
