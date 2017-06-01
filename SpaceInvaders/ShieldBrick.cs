using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class ShieldBrick : ShieldCategory
    {
        public ShieldBrick(GameObjectNames name, Index index, SpriteNames spriteName, float posX, float posY)
            : base(name, index, spriteName, ShieldCategory.Type.Brick)
        {
            this.x = posX;
            this.y = posY;
        }

        public override void Update()
        {

        }

        public override void Accept(ColVisitor other)
        {
            // deal with the collision reaction
            other.VisitShieldBrick(this);
        }

        public override void VisitMissileRoot(MissileRoot m)
        {
            // MissileRoot vs ShieldBrick
            // now go deeper on Missile root
            ColPair.Collide((GameObject)m.child, this);
        }

        public override void VisitMissile(Missile m)
        {
            // ShieldBrick vs Missile
            //Debug.WriteLine("collide: {0} with {1}", this, m);

            //Debug.WriteLine(" ---> Done");
            ColPair pColPair = ColPairManager.GetActiveColPair();
            pColPair.SetCollision(m, this);
            pColPair.NotifyListeners();
        }

        public override void VisitBombRoot(BombRoot m)
        {
            // MissileRoot vs ShieldBrick
            // now go deeper on Missile root
            ColPair.Collide((GameObject)m.child, this);
        }

        public override void VisitShieldRoot(ShieldRoot m)
        {
            // MissileRoot vs ShieldRoot
            ColPair.Collide(m, (GameObject)this.child);
        }

        public override void VisitCrossBomb(CrossBomb m)
        {
            // ShieldBrick vs Missile
            //Debug.WriteLine("collide: {0} with {1}", this, m);

            //Debug.WriteLine(" ---> Done");
            ColPair pColPair = ColPairManager.GetActiveColPair();
            pColPair.SetCollision(m, this);
            pColPair.NotifyListeners();
        }
    }
}
