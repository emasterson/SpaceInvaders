using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace SpaceInvaders
{

    

    public class Sprite: BaseSprite
    {
        public  Sprite()
            : base()
        {
            
            this.rect = new Azul.Rect(0.0f, 0.0f, 0.0f, 0.0f);
            this.spriteName = SpriteNames.Not_Initialized;
            this.texture = new Azul.Texture("invaders-from-space.tga");
            this.pImage = null;
            this.pAzulSprite = null;

            this.pColor = null;

            this.x = 0.0f;
            this.y = 0.0f;
            this.rot = 0.0f;
            this.sx = 1.0f;
            this.sy = 1.0f; ;
        }

        ~Sprite()
        {
            this.Print("GameSprite: destoying->");            
            this.pAzulSprite = null;
            this.pImage = null;
            this.pColor = null;
        }

        public Sprite(SpriteNames spriteNameIn, Azul.Texture tc, Image im, Azul.Rect screenRect)
        {
            Debug.Assert(spriteNameIn != null);
            Debug.Assert(tc != null);
            Debug.Assert(im != null);
            Debug.Assert(screenRect != null);

            this.spriteName = spriteNameIn;
            this.texture = tc;
            this.pImage = im;

            this.pAzulSprite = new Azul.Sprite2D(tc, im.rect, screenRect);
            this.x = screenRect.x;
            this.y = screenRect.y;
            this.sx = 1.0f;
            this.sy = 1.0f;

            this.origHeight = 0.0f;
            this.origWidth = 0.0f;
            
        }

        protected Sprite(SpriteNames spriteName, Index n)
            : base()
        {
            this.spriteName = spriteName;
            this.index = n;

            this.pAzulSprite = null;
            this.pImage = null;
            this.pColor = null;

            this.x = 0.0f;
            this.y = 0.0f;
            this.rot = 0.0f;
            this.sx = 1.0f;
            this.sy = 1.0f; 
        }

        public void Set(SpriteNames spriteName, ImageNames imageName, float _x, float _y, float _width, float _height)
        {
            this.spriteName = spriteName;
           

            this.pImage = ImageManager.Find(imageName);
            this.pAzulSprite = new Azul.Sprite2D(pImage.pTexture.texture,
                                                  pImage.rect,
                                                  new Azul.Rect(_x, _y, _width, _height));
            // todo make refactor color
            this.pColor = new Azul.Color(1.0f, 1.0f, 1.0f);
            this.x = _x;
            this.y = _y;
            this.rot = 0.0f;
            this.sx = 1.0f;
            this.sy = 1.0f;
            this.width = _width;
            this.height = _height;
            this.origHeight = _height;
            this.origWidth = _width;

        }

        public void Print(String extra = null)
        {
            Debug.WriteLine(extra + "GameSprite:(" + this.spriteName + ") ");
        }

        public override  Enum getName()
        {

            return this.spriteName;

        }

        override public Enum getIndex()
        {
            return this.index;
        }

        public override void  Update()
        {
            // push the data from Sprite to Azul.Sprite2D
            this.pAzulSprite.x = this.x;
            this.pAzulSprite.y = this.y;
            this.pAzulSprite.sx = this.sx;
            this.pAzulSprite.sy = this.sy;

            
            this.pAzulSprite.angle = this.rot;
           // this.pAzulSprite.setColor(this.pColor);
            this.pAzulSprite.swapImage(this.pImage.rect);

            
        }

        public override void Draw()
        {
            this.pAzulSprite.Draw();
            //Console.WriteLine("in sprite Draw");
        }

        //---------------------data line
        public Azul.Rect rect;
        public SpriteNames spriteName;

       // public Texture texture;
        public Azul.Texture texture;
        public Image pImage;
        public Azul.Sprite2D pAzulSprite;
        public Azul.Color pColor;
        public Index index;

        public float x;
        public float y;
        public float rot;
        public float sx;
        public float sy;
        public float width;
        public float height;
        public float origWidth;
        public float origHeight;
    }
}
