using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class PlayerShipRoot : PlayerShipCategory
    {
        public PlayerShipRoot(GameObjectNames name, SpriteNames spriteName, float posX = 0.0f, float posY = 0.0f)
            : base(name, Index.i0, spriteName, PlayerShipCategory.Type.PlayerShipRoot)
        {
            this.x = posX;
            this.y = posY;
        }

        public override void Process()
        {
            this.Update();
        }

        public override void Update()
        {
            this.baseUpdateBoundingBox();
        }

        public override void Accept(ColVisitor other)
        {
            other.VisitPlayerShipRoot(this);
        }

        public override void VisitBombRoot(BombRoot m)
        {
            // MissileRoot vs ShieldBrick
            // now go deeper on Missile root
           // ColPair.Collide((GameObject)m.child, this);
            ColPair.Collide(m, (GameObject)this.child);
        }

        public override void VisitCrossBomb(CrossBomb m)
        {
            // ShieldBrick vs Missile
            //Debug.WriteLine("collide: {0} with {1}", this, m);

            //Debug.WriteLine(" ---> Done");
            //ColPair pColPair = ColPairManager.GetActiveColPair();
            //pColPair.SetCollision(m, this);
            //pColPair.NotifyListeners();
        }
    }
}
