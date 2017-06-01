using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class RootGameObject :GameObject 
    {
        public RootGameObject(GameObjectNames name, Index index, SpriteNames spriteName, float posX, float posY)
            :base(name, index, spriteName)
        {
            this.x = posX;
            this.y = posY;

        }

        public override void Update()
        {

        }

        public override void Accept(ColVisitor other)
        {
            other.VisitRootGameObject(this);
        }
    }
}
