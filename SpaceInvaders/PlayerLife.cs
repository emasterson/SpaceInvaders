using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class PlayerLife : PlayerShipCategory
    {
        public PlayerLife(GameObjectNames name, SpriteNames spriteName, float posX, float posY)
            : base(name, Index.i0, spriteName, PlayerShipCategory.Type.PlayerShip)
        {
            this.x = posX;
            this.y = posY;
            PushPosition();

            //// Do the initialization
            //if (instance == null)
            //{
            //    instance = new CollisionSpriteManager(reserveNum, reserveGrow);
            //    // instance.pNullSprite = new NullSprite(GameSprite.Name.NullObject);
            //}
        }

        
        public override void Update()
        {
            
        }

        

        public override void Accept(ColVisitor other)
        {
            // Important: at this point we have an Missile
            // Call the appropriate collision reaction
            
        }
    }
}
