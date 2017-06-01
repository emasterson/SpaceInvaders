using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class ShieldColumn : ShieldCategory
    {
        public ShieldColumn(GameObjectNames name, Index index, SpriteNames spriteName, float posX, float posY)
            : base(name, index, spriteName, ShieldCategory.Type.Column)
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
            // we have a shieldColumn
            // call the correct collision reaction
            other.VisitShieldColumn(this);
        }

        public override void VisitMissileRoot(MissileRoot m)
        {
            // MissileRoot vs ShieldColumns
            ColPair.Collide(m, (GameObject)this.child);
        }

        public override void VisitBombRoot(BombRoot m)
        {
            // MissileRoot vs ShieldColumns
            ColPair.Collide(m, (GameObject)this.child);
        }

        public override void VisitShieldRoot(ShieldRoot m)
        {
            // MissileRoot vs ShieldRoot
            ColPair.Collide(m, (GameObject)this.child);
        }

        public override void RemoveMe()
        {
            // collision object
            SpriteBatchGroup pSpriteBatchGroup = this.pCollisionObject.pCollisionSprite.pSpriteBatchGroup;
            pSpriteBatchGroup.Remove(this.pCollisionObject.pCollisionSprite);

            //object tree
            PCSTree pTree = GameObjManager.GetRootTree();
            pTree.Remove(this);

            // pTree.dumpTree();
        }
    }
}
