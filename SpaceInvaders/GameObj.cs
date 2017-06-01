using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    //class GameObj:ManagerLink
    class GameObj : BaseSprite
    {
        public  GameObj()
            : base()
        {

            this.x = 0;
            this.y = 0;
            this.sprite = null;
            this.name = GameObjNames.Not_Initialized;
            
            
        }

        public GameObj(GameObjNames _name,  int _x, int _y, Sprite _sprite) 
        {
            this.x = _x;
            this.y = _y;
            this.sprite = _sprite;
            this.name = _name;
           // this.flyweightSprite = new FlyweightSprite(FlyweightSpriteNames.FlyweightSprite1, x, y, sprite);
           // this.flyweightSprite = new FlyweightSprite(SpriteManager.find(_sprite.spriteName), x, y, sprite);
            this.pAzulSprite = new Azul.Sprite2D(_sprite.pImage.pTexture.texture,
                                                              _sprite.pImage.rect,
                                                              new Azul.Rect(_x, _y, _sprite.width, _sprite.height));
        }

        public void Set(GameObjNames _name, int _x, int _y, Sprite _sprite)
        {
            this.x = _x;
            this.y = _y;
            this.sprite = _sprite;
            
            this.name = _name;

            this.pAzulSprite = new Azul.Sprite2D(_sprite.pImage.pTexture.texture,
                                                              _sprite.pImage.rect,
                                                              new Azul.Rect(_x, _y, _sprite.width, _sprite.height));
        }

         public override Enum getName()
        {
            return name;
        }

         public override void Draw()
         {
             //this.sprite.x = this.x;
             //this.sprite.y = this.y;
             //sprite.Draw();
             this.pAzulSprite.Draw();


         }

         public override void Update()
         {
             // push the data from Sprite to Azul.Sprite2D
             Debug.Assert(pAzulSprite != null);
             this.pAzulSprite.x = x;
             this.pAzulSprite.y = sprite.y;
             this.pAzulSprite.sx = sprite.sx;
             this.pAzulSprite.sy = sprite.sy;
             this.pAzulSprite.angle = sprite.rot;

             //this.pAzulSprite.sx = 1.0f;
             //this.pAzulSprite.sy = 1.0f;
             // this.pAzulSprite.angle = this.rot;
             // this.pAzulSprite.setColor(this.pColor);
         }
        


        //-------------------data
        private int x;
        private int y;
        private Sprite sprite;
      //  public FlyweightSprite flyweightSprite;
       // public FlyweightSpriteNames flyweightSpriteName;
        private GameObjNames name;
        public Azul.Sprite2D pAzulSprite;
    }
}
