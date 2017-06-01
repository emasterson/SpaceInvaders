using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace SpaceInvaders
{
    class TextureManager: Manager
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
                instance = new TextureManager(reserveNum, reserveGrow);
            }
        }
        private TextureManager(int numReserve, int reserveGrow)
            : base(numReserve, reserveGrow)
        {
            // do nothing
        }

        public static void Destroy()
        {   // call base
            TextureManager.privInstance().baseDestroy();
        }

        //private TextureManager() : base()
        //{
        //    //moved to Manager because we moved the data to manager
        //    //this.numNodes = 0;
        //    //this.pHead = null;
        //}

       

        //public static void Add(TextureNames textureName, String filename)
        //{
        //    //make sure it is not null
        //    Debug.Assert(node != null);
        //    // get the singleton
        //    //imageManager is instance pointer for this obj
        //    TextureManager textureManager = TextureManager.privInstance();

        //    // CALL THE BASE CLASS FUNCTION
        //    textureManager.baseAdd(node);


           
        //}

        public static void Add(TextureNames textureName, String fileName)
        {
            TextureManager.privInstance().Add(textureName, Index.i0, fileName);
        }

        public void Add(TextureNames textureName, Index index, String filename)
        {
            //make sure it is not null
           // Debug.Assert(node != null);
            // get the singleton
            //imageManager is instance pointer for this obj
            TextureManager textureManager = TextureManager.privInstance();

            // Go to Man, get a node from reserve, add to active, return it
            Texture pTexture = (Texture)textureManager.baseAdd();

            pTexture.Set(textureName, index, filename);

            // CALL THE BASE CLASS FUNCTION
           // textureManager.baseAdd(node);



        }
        // static method 
        public static Texture Find(TextureNames name, Index index = Index.i0)
        {
            // get the instance pointer
            TextureManager textureManager = TextureManager.privInstance();
            //// get the head
            //Image pImage = (Image)imageManager.active;

            //// iterate thru looking for name
            //while (pImage != null)
            //{
            //    if (name == pImage.name)
            //    {
            //        break;
            //    }
            //    pImage = (Image)pImage.next;
            //}
            //return pImage;

            //call the base class function
            return (Texture)textureManager.basefind(name, index);
        }

        public static void Remove(ImageNames _name, Index index = Index.i0)
        {
            // get the instance pointer
            TextureManager textureManager = TextureManager.privInstance();

            //call the base class function
            textureManager.baseRemove(_name, index);

            
        }

        public static void Remove(TextureNames name, Index index = Index.i0)
        {   // Call base class
            TextureManager.privInstance().baseRemove(name, index);
        }

        public static void Remove(Image node)
        {
            // get the singleton
            TextureManager textureManager = TextureManager.privInstance();

            //call base class function
            textureManager.baseRemove(node);
        }

        private static TextureManager privInstance()
        {
            // need to call create() first
            Debug.Assert(instance != null);
            //if (instance == null)
            //{
            //    instance = new TextureManager();
            //}
            return instance;
        }

        protected override object privGetNewObj()
        {
            object pObj = new Texture();
            return pObj;
        }

        //Data----------------
        private static TextureManager instance = null;
    }
}
