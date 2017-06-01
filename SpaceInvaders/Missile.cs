using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class Missile : MissileCategory
    {
        public Missile(GameObjectNames name, Index index, SpriteNames spriteName, float posX, float posY)
            : base(name, index, spriteName, MissileCategory.Type.Missile)
        {
            this.x = posX;
            this.y = posY;
        }

        public Missile(GameObjectNames name, SpriteNames spriteName, float posX, float posY)
            : base(name, Index.i0, spriteName, MissileCategory.Type.Missile)
        {
            this.x = posX;
            this.y = posY;
        }

        public void FireMissile()
        {
            status = PlayerShipFiringStatus.JustFired;
            
        }

        public void MoveMissile()
        {
            if (status == PlayerShipFiringStatus.JustFired)
            {
                this.y += 40.0f; 
            }
            
        }

        public override void Accept(ColVisitor other)
        {
            // Important: at this point we have an Missile
            // Call the appropriate collision reaction
            other.VisitMissile(this);
        }

        public override void Update()
        {
            if (this.status == PlayerShipFiringStatus.ArmedAndReady)
            {
                PlayerShip pPlayerShip = (PlayerShip)GameObjManager.Find(GameObjectNames.PlayerShip);
                this.x = pPlayerShip.x;
                this.y = pPlayerShip.y;
            }

            if(this.status == PlayerShipFiringStatus.JustFired)
            {
                this.y +=10.0f;
            }
        }

        //public void Process()
        //{
        //    if (status == PlayerShipFiringStatus.JustFired)
        //    {
        //        this.y += 20.0f;
        //    }

        //}

        //data---------------
        PlayerShipFiringStatus status = PlayerShipFiringStatus.ArmedAndReady;
        public bool hit;
        private PCSTree pTree;
        private SpriteBatchGroup pSpriteBatch;
        private PCSNode pParent;
    }
}
