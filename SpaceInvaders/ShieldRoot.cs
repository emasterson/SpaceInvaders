using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ShieldRoot : ShieldCategory
    {
        public ShieldRoot(GameObjectNames name, SpriteNames spriteName, float posX = 0.0f, float posY = 0.0f)
            : base(name, Index.i0, spriteName, ShieldCategory.Type.Root)
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

        public override void VisitMissileRoot(MissileRoot m)
        {
            // MissileRoot vs ShieldRoot
            ColPair.Collide(m, (GameObject)this.child);
        }

        public override void VisitBombRoot(BombRoot m)
        {
            // MissileRoot vs ShieldColumns
            ColPair.Collide(m, (GameObject)this.child);
        }

        public override void Accept(ColVisitor other)
        {
            // we have a shieldRoot
            // call the correct collision reaction
            other.VisitShieldRoot(this);
        }
    }
}
