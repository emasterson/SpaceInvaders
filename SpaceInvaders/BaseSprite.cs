using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    public abstract class BaseSprite : ManagerLink
    {

        protected BaseSprite()
            :base()
        {
            this.pSpriteBatchGroup = null;
        }
        public abstract void Draw();
        public abstract void Update();

        public SpriteBatchGroup pSpriteBatchGroup;

        
    }
}
