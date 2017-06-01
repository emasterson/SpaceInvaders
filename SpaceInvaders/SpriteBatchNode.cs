using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class SpriteBatchNode : ContainerLink
    {

        public enum Name
        {

        }

        

        public void Set(BaseSprite spriteBase)
        {
            this.pBaseSprite = spriteBase;
            Debug.Assert(this.pBaseSprite != null);

            this.name = (SpriteBatchNode.Name)spriteBase.getName();
            this.index = (Index)spriteBase.getIndex();
        }

        //public void Set(SpriteNames gameSpriteName)
        public void Set(ImageNames imageName)
        {
            this.pBaseSprite = SpriteManager.find(imageName);
            Debug.Assert(this.pBaseSprite != null);

            this.name = (SpriteBatchNode.Name)imageName;
            // this.index = _index;
        }

        // tells which sprite this SpriteBatchNode should point to
        public void Set(SpriteNames spriteName)
        {
           // this.pBaseSprite = SpriteManager.find(spriteName);
            this.pBaseSprite = SpriteManager.find(spriteName);
           // Debug.Assert(this.pBaseSprite != null);
            Debug.Assert(this.pBaseSprite != null);

            this.name = (SpriteBatchNode.Name)spriteName;
            // this.index = _index;
        }

        // tells which sprite this SpriteBatchNode should point to
        public void Set(FlyweightSpriteNames flyweightName)
        {
            //this.pBaseSprite = SpriteManager.find(spriteName);
            FlyweightSprite fs;
           // fs = new FlyweightSprite(FlyweightSpriteNames.FlyweightSprite1, 400, 300, SpriteManager.find(SpriteNames.AlienSprite01));
           // this.pBaseSprite = fs;
            Debug.Assert(this.pBaseSprite != null);

            this.name = (SpriteBatchNode.Name)flyweightName;
            // this.index = _index;
        }

        

        override public Enum getName()
        {
            return this.name;
        }




        // Data: ----------------------------------------------
        public SpriteBatchNode.Name name;
        public Index index;
        
        public BaseSprite pBaseSprite;

    }
}
