using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class WaitingForMissileToExplodeMode : ShipState
    {
        public override void HandleTheChangeState(PlayerShip playerShip)
        {
            if (playerShip.a == 0)
            {
                //once missile explodes want to put back into ready to fire mode
                playerShip.StateOfShip = new ReadyToFireMode();
               // playerShip.a = 1;
            }
        }
    }
}
