using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class NullSprite : Sprite
    {
        private NullSprite()
        {
            //prevent calling
        }

        public NullSprite(SpriteNames spriteName, Index _index = Index.i0)
            : base(spriteName, _index)
        {

        }

        override public void Update()
        {
            // do nothing - its a nullSprite
        }

        override public void Draw()
        {
            // do nothing - its a nullSprite
        }

        // Data: ---------------
        //          no additional data
    }
}
