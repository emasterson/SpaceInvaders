using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{

    public enum TextureNames
    {
        AliensTexture,
        ShieldsTexture,
        AmmoTexture,
        Not_Initialized
    }
    public class Texture:ManagerLink
    {
        public  Texture()
            : base()
        {
            
           // this.rect = new Azul.Rect(0.0f, 0.0f, 0.0f, 0.0f);
            this.name = TextureNames.Not_Initialized;
            this.index = Index.i0;
        }

        public Texture(TextureNames inName)
            : base()
        {

            switch (inName)
            {
                case TextureNames.AliensTexture :
                    this.texture = new Azul.Texture("invaders-from-space.tga");
                    this.name = inName;
                    break;
                //case TextureNames.Birds :
                //    this.texture = new Azul.Texture("birds.tga");
                //    this.name = inName;
                //    break;

                //case TextureNames.Stitch :
                //    this.texture = new Azul.Texture("stitch.tga");
                //    this.name = inName;
                //    break;
                default :
                    this.texture = new Azul.Texture("invaders-from-space.tga");
                    this.name = inName;
                    break;

            }
            
            //this.birdsTexture = new Azul.Texture("birds.tga");
        }

        

        public void Set(TextureNames textureName, Index n,String fileName)
        {
            this.texture = new Azul.Texture(fileName);
            this.name = textureName;
            this.index = n;
        }

        public override Enum getName()
        {

            return this.name;

        }

        override public Enum getIndex()
        {
            return this.index;
        }

        //---------------------data line
       // public Azul.Rect rect;
        public TextureNames name;
        public Azul.Texture texture;
        public Index index;
        
    }
}
