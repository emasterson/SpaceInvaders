using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class Image : ManagerLink
    {

        public Image()
            : base()
        {
            this.rect = new Azul.Rect(0.0f, 0.0f, 0.0f, 0.0f);
            this.name = ImageNames.Not_Initialized;
            this.pTexture = null;
            this.index = Index.i0;
        }

        public Image(ImageNames imageName, float x, float y, float width, float height) : base()
        {
            this.rect = new Azul.Rect(x, y, width, height);
            this.name = imageName;
            
        }

        ~Image()
        {
            this.Print("Image: destoying->");
            this.rect = null;
            this.pTexture = null;
        }

        public void Set(ImageNames imageName, TextureNames textureName, float x, float y, float width, float height)
        {
            this.name = imageName;
            //this.index = n;
            this.rect = new Azul.Rect(x, y, width, height);
            this.pTexture = TextureManager.Find(textureName);

        }

        public override Enum getName()
        {

            return this.name;

        }

        override public Enum getIndex()
        {
            return this.index;
        }

        public void Print(String extra = null)
        {
            Debug.WriteLine(extra + "Image:(" + this.name + ") x:" + this.rect.x + " y:" + this.rect.y + " w:" + this.rect.w + " h:" + this.rect.w);
        }

        //---------------------data line
        public Azul.Rect rect;
        public ImageNames name;
        public Texture pTexture;
        public Index index;

    }
}
