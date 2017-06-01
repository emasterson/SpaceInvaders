using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ImageManager : Manager
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
                instance = new ImageManager(reserveNum, reserveGrow);
            }

        }

        private ImageManager( int numReserve, int reserveGrow )
            : base(numReserve, reserveGrow)
        {
            // do nothing
        }

        public static void Destroy()
        {
            // Get the instance
            ImageManager pImageMan = ImageManager.privInstance();

            pImageMan.baseDestroy();
        }

        public static void add(Image node)
        {
            //make sure it is not null
            Debug.Assert(node != null);
            // get the singleton
            //imageManager is instance pointer for this obj
            ImageManager imageManager = ImageManager.privInstance();

            // CALL THE BASE CLASS FUNCTION
            imageManager.baseAdd(node);


            
        }

        public static void Add(ImageNames imageName, TextureNames textureName, int x, int y, int width, int height)
        {
            // Get the instance
            ImageManager pImageMan = ImageManager.privInstance();

            // Go to Man, get a node from reserve, add to active, return it
            Image pImage = (Image)pImageMan.baseAdd();

            // Initialize object
            pImage.Set(imageName, textureName, x, y, width, height);
        }
        // static method 
        public static Image Find(ImageNames name, Index index = Index.i0)
        {
            // get the instance pointer
            ImageManager imageManager = ImageManager.privInstance();
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
            return (Image)imageManager.basefind(name, index);
        }

        public static void Remove(ImageNames _name, Index index = Index.i0)
        {
            // get the instance pointer
            ImageManager imageManager = ImageManager.privInstance();

            //call the base class function
            imageManager.baseRemove(_name, index);

            
        }

        public static void Remove(Image node)
        {
            // get the singleton
            ImageManager imageManager = ImageManager.privInstance();

            //call base class function
            imageManager.baseRemove(node);
        }

        private static ImageManager privInstance()
        {
            Debug.Assert(instance != null);
            //if (instance == null)
            //{
            //    instance = new ImageManager();
            //}
            return instance;
        }

        protected override object privGetNewObj()
        {
            object pObj = new Image();
            return pObj;
        }

        public static void PrintActive()
        {
            // get the singleton
            ImageManager pImageMan = ImageManager.privInstance();

            Debug.WriteLine("\nImageMan: (active list)");
            Image pImage = (Image)pImageMan.active;
            while (pImage != null)
            {
                pImage.Print("    ");
                pImage = (Image)pImage.next;
            }

        }

        public static void PrintStats()
        {
            // get the singleton
            ImageManager pImageMan = ImageManager.privInstance();

            pImageMan.basePrintStats();
        }

        //Data----------------
        private static ImageManager instance;

        // WE CAN REMOVE LOCAL DATA AND PUT INTO BASE CLASS MANAGER
        //private Image pHead;
        //private Image active;
        //private int numNodes;
    }
}
