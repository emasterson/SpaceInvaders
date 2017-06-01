using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace SpaceInvaders
{
    class SpriteManager:Manager
    {
        public static void Create(int reserveNum = 3, int reserveGrow = 1)
        {
            // make sure values are ressonable 
            Debug.Assert(reserveNum > 0);
            Debug.Assert(reserveGrow > 0);


            // initialize the singleton here
            Debug.Assert(instance == null);

            // Do the initialization
            if (instance == null)
            {
                instance = new SpriteManager(reserveNum, reserveGrow);
                instance.pNullSprite = new NullSprite(SpriteNames.NullObject);
            }

           // Sprite sprite = (Sprite)SpriteManager.privInstance().reserve;

        }

        private SpriteManager( int numReserve, int reserveGrow )
            : base(numReserve, reserveGrow)
        {
            // do nothing
        }

        public static void Destroy()
        {
            SpriteManager.privInstance().baseDestroy();
        }

        public static void add(Sprite node)
        {
            //make sure it is not null
            Debug.Assert(node != null);
            // get the singleton
            //SpriteManager is instance pointer for this obj
            SpriteManager spriteManager = SpriteManager.privInstance();

            // CALL THE BASE CLASS FUNCTION
            spriteManager.baseAdd(node);


            
        }

        public static void Add(SpriteNames spriteName, ImageNames imageName, int _x, int _y, int _width, int _height)
        {
            // Get the instance
            SpriteManager pGameSpriteMan = SpriteManager.privInstance();

            // Go to Man, get a node from reserve, add to active, return it
            Sprite pGameSprite = (Sprite)pGameSpriteMan.baseAdd();

            // Initialize object
            pGameSprite.Set(spriteName, imageName, _x, _y, _width, _height);
        }
        // static method 
        public static Sprite find(ImageNames name, Index index = Index.i0)
        {
            // get the instance pointer
            SpriteManager spriteManager = SpriteManager.privInstance();
            

            //call the base class function
            return (Sprite)spriteManager.basefind(name, index);
        }

        public static Sprite find(SpriteNames name, Index index = Index.i0)
        {
            // get the instance pointer
            SpriteManager spriteManager = SpriteManager.privInstance();


            //call the base class function
           // return (Sprite)spriteManager.basefind(name, index);

            // call base function
            Sprite pSprite = null;

            // special case for Null Objects
            if (name == SpriteNames.NullObject)
            {
                pSprite = (Sprite)spriteManager.pNullSprite;
            }
            else
            {
                pSprite = (Sprite)spriteManager.basefind(name, index);
            }

            return pSprite;
        }

        public static void Remove(ImageNames _name, Index index = Index.i0)
        {
            // get the instance pointer
            SpriteManager spriteManager = SpriteManager.privInstance();

            //call the base class function
            spriteManager.baseRemove(_name, index);

            
        }

        public static void Remove(Image node)
        {
            // get the singleton
            SpriteManager spriteManager = SpriteManager.privInstance();

            //call base class function
            spriteManager.baseRemove(node);
        }

        public static SpriteManager privInstance()
        {
            Debug.Assert(instance != null);
            //if (instance == null)
            //{
            //    instance = new SpriteManager();
            //}
            return instance;
        }

        protected override object privGetNewObj()
        {
            object pObj = new Sprite();
            return pObj;
        }

        public static void PrintStats()
        {
            // get the singleton
            SpriteManager pGameSpriteMan = SpriteManager.privInstance();
            pGameSpriteMan.basePrintStats();
        }

        //public static Sprite create()
        //{
        //    // get the singleton
        //    SpriteManager spriteManager = SpriteManager.privInstance();

        //    Debug.Assert(SpriteNames.AlienSprite00 != null);
        //    Debug.Assert(TextureManager.find(TextureNames.AliensTexture).texture != null);
        //    Debug.Assert(ImageManager.find(ImageNames.Crab_0) != null);




        //    Sprite s1, s2, s3;
        //     s1 = new Sprite(SpriteNames.AlienSprite00, TextureManager.find(TextureNames.AliensTexture).texture,ImageManager.find(ImageNames.Crab_0),  new Azul.Rect(50, 300, 43, 31));
        //     s2 = new Sprite(SpriteNames.AlienSprite00, TextureManager.find(TextureNames.AliensTexture).texture, ImageManager.find(ImageNames.Crab_0), new Azul.Rect(100, 300, 43, 31));
        //     s3 = new Sprite(SpriteNames.AlienSprite00, TextureManager.find(TextureNames.AliensTexture).texture, ImageManager.find(ImageNames.Crab_0), new Azul.Rect(150, 300, 43, 31));

        //     SpriteManager.add(s1);
        //     SpriteManager.add(s2);
        //     SpriteManager.add(s3);
        //     return s1;

        //}

        public static void Draw()
        {
            //get singleton
            SpriteManager pSpriteManager = SpriteManager.privInstance();
            Sprite pSprite = null;

            ManagerLink pNode = (Sprite)pSpriteManager.active;

            while (pNode != null)
            {
                pSprite = (Sprite)pNode;
                pSprite.Update();
                pSprite.Draw();

                pNode = pNode.next;
            }
        }

        //Data----------------
        private static SpriteManager instance = null;
        private NullSprite pNullSprite = null;
    }
}
