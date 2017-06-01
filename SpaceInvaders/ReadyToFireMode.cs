using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class ReadyToFireMode : ShipState
    {
        public override void HandleTheChangeState(PlayerShip playerShip)
        {
            if (playerShip.a == 1)
            {
                //once the missile is fired we want to change to Wait For Missile to Explode Mode
                playerShip.StateOfShip = new WaitingForMissileToExplodeMode();
                //playerShip.a = 0;
                
            }
        }
    }
}
