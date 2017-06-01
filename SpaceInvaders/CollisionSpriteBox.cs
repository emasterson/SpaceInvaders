using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class CollisionSpriteBox : BaseSprite
    {
        public CollisionSpriteBox()
            :base()
        {
            this.name = GameObjectNames.Not_Initialized;
            this.index = Index.i0;
            this.lineWidth = 1.0f;

            this.pAzulLine = null;
            this.pRect = null;
            this.pColor = null;
        }

        public CollisionSpriteBox(GameObjectNames _name, Index _n)
            : base()
        {
            this.name = _name;
            this.index = _n;
            this.lineWidth = 1.0f;

            this.pAzulLine = null;
            this.pRect = null;
            this.pColor = null;
        }

        public override Enum getName()
        {
            return this.name;
        }

        public override Enum getIndex()
        {
            return this.index;
        }

        public override void Update()
        {
            // push the data from Sprite to Azul.Line
            Debug.Assert(this.pAzulLine != null);
            Debug.Assert(this.pColor != null);
            pAzulLine.setColor(this.pColor);

            
        }

        public override void Draw()
        {
            Debug.Assert(this.pAzulLine != null);
            Debug.Assert(this.pRect != null);

            //Draw top line
            this.pAzulLine.Draw(this.pRect.x, this.pRect.y, (this.pRect.x + this.pRect.w), this.pRect.y);

            // draw left line
            this.pAzulLine.Draw(this.pRect.x, this.pRect.y, this.pRect.x, (this.pRect.y - this.pRect.h));

            // draw right line
            this.pAzulLine.Draw((this.pRect.x + this.pRect.w), this.pRect.y, (this.pRect.x + this.pRect.w), (this.pRect.y - this.pRect.h));

            // draw bottom line
            this.pAzulLine.Draw(this.pRect.x, (this.pRect.y - this.pRect.h), (this.pRect.x + this.pRect.w), (this.pRect.y - this.pRect.h));

        }

        //override public void Draw()
        //{
        //    Debug.Assert(this.pAzulLine != null);
        //    Debug.Assert(this.pRect != null);

        //    // Draw top line
        //    this.pAzulLine.Draw(this.pRect.x, this.pRect.y, (this.pRect.x + this.pRect.w), this.pRect.y);

        //    // Draw left line
        //    this.pAzulLine.Draw(this.pRect.x, this.pRect.y, this.pRect.x, (this.pRect.y - this.pRect.h));

        //    // Draw right line
        //    this.pAzulLine.Draw((this.pRect.x + this.pRect.w), this.pRect.y, (this.pRect.x + this.pRect.w), (this.pRect.y - this.pRect.h));

        //    // Draw bottom line
        //    this.pAzulLine.Draw(this.pRect.x, (this.pRect.y - this.pRect.h), (this.pRect.x + this.pRect.w), (this.pRect.y - this.pRect.h));

        //}

        public void SetRect(CollisionRect ColRect)
        {
            this.pRect.x = ColRect.x;
            this.pRect.y = ColRect.y;
            this.pRect.w = ColRect.width;
            this.pRect.h = ColRect.height;
        }

        public void Set(GameObjectNames collisionSpriteName, Index _index, Azul.Color color, int x, int y, int width, int height)
        {
            this.name = collisionSpriteName;
            this.index = _index;
            this.lineWidth = 2.0f;

            this.pRect = new Azul.Rect(x, y, width, height);
            Debug.Assert(this.pRect != null);

            Debug.Assert(color != null);
            this.pColor = color;

            this.pAzulLine = new Azul.Line(this.lineWidth, this.pColor, x, y, x + width, y + height);
            Debug.Assert(this.pAzulLine != null);

        }

        public void Set(GameObjectNames collisionSpriteName, Index _index, Azul.Color color, CollisionRect rect)
        {
            this.name = collisionSpriteName;
            this.index = _index;
            this.lineWidth = 2.0f;

            this.pRect = new Azul.Rect(rect.x, rect.y, rect.width, rect.height);
            Debug.Assert(this.pRect != null);

            Debug.Assert(color != null);
            this.pColor = color;

            this.pAzulLine = new Azul.Line(this.lineWidth, this.pColor, rect.x, rect.y, rect.x + rect.width, rect.y + rect.height);
            Debug.Assert(this.pAzulLine != null);
        }


        // Data------------------------------------
        public GameObjectNames name;
        public Index index;
        public Azul.Line pAzulLine;
        public float lineWidth;
        public Azul.Rect pRect;
        public Azul.Color pColor;

    }
}
