using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    // this is the concrete class. inherits from abstract ShipState
    class FrozenShip : ShipState
    {
        public override void HandleTheChangeState(PlayerShip playerShip)
        {
            // ship is frozen once the whole game loads then we want to unfreeze and put in ready to fire mode
            playerShip.StateOfShip = new ReadyToFireMode();
        }
    }
}
