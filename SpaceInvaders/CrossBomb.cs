using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class CrossBomb : BombCategory
    {
        public CrossBomb( GameObjectNames name, SpriteNames spriteName, float posX, float posY)
            : base(name, Index.i0, spriteName, BombCategory.Type.CrossBomb)
        {
            this.x = posX;
            this.y = posY;
            PushPosition();
        }

        public override void Update()
        {
          //  UFO_FromRight pUFO_FromRight = (UFO_FromRight)GameObjManager.Find(GameObjectNames.UFO_FromRight);
            //this.x = pUFO_FromRight.x;
            //this.y = pUFO_FromRight.y;
            this.y -= 5.0f;
            
        }

        public override void Accept(ColVisitor other)
        {
            // Important: at this point we have an Missile
            // Call the appropriate collision reaction
            other.VisitCrossBomb(this);
        }

        public override void VisitPlayerShip(PlayerShip m)
        {
            // AlienOctopus vs Missile
            Debug.WriteLine("collide: {0} with {1}", this, m);

            Debug.WriteLine(" ---> Done");

           // m.hit = true;

            ColPair pColPair = ColPairManager.GetActiveColPair();
            pColPair.SetCollision(m, this);
            pColPair.NotifyListeners();

        }
    }
}
