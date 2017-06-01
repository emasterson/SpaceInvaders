using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    
     class FlyweightSprite : BaseSprite
    {
        public FlyweightSprite()
        {

        }

       public FlyweightSprite( Sprite pSprite, GameObjectNames gameName, Index gameIndex )
            : base()
        {
            Debug.Assert(pSprite != null);
            this.name = gameName;
            this.index = gameIndex;
            this.pSprite = pSprite;

        }

       //public FlyweightSprite(SpriteNames spriteName, Index spriteIndex = Index.i0)
       //    : base()
       //{
       //    this.name = SpriteNames.Not_Initialized;
       //    this.index = Index.i0;
       //    this.pSprite = SpriteManager.find(spriteName, spriteIndex);
       //    Debug.Assert(this.pSprite != null);
       //}



        public override void Draw()
        {
            //this.sprite.x = this.x;
            //this.sprite.y = this.y;
            //sprite.Draw();
           // this.pAzulSprite.Draw();

            this.pSprite.Update();
            this.pSprite.Draw();


        }

        public override void Update()
        {
            //// push the data from Sprite to Azul.Sprite2D
            //Debug.Assert(pAzulSprite != null);
            //this.pAzulSprite.x = x;
            //this.pAzulSprite.y = pSprite.y;
            //this.pAzulSprite.sx = pSprite.sx;
            //this.pAzulSprite.sy = pSprite.sy;
            //this.pAzulSprite.angle = pSprite.rot;

            // push the data from FlyweightSprite to GameSprite
            this.pSprite.x = this.x;
            this.pSprite.y = this.y;

            
        }

        public void UpdatePos(float xPos, float yPos)
        {
            this.x = xPos;
            this.y = yPos;
        }

        public override Enum getName()
        {
            return name;
        }

        override public Enum getIndex()
        {
            return this.index;
        }

        //data---------------
        public float x;
        public float y;
        public Sprite pSprite;
        public GameObjectNames name;
        public Index index;
        // pSpriteBatchGroup is in BaseSprite
    }
}
