using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class CollisionSpriteBoxManager : Manager
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
                instance = new CollisionSpriteBoxManager(reserveNum, reserveGrow);
                // instance.pNullSprite = new NullSprite(GameSprite.Name.NullObject);
            }
        }

        public static void Destroy()
        {
            CollisionSpriteBoxManager.privInstance().baseDestroy();
        }

         private CollisionSpriteBoxManager(int numReserve, int reserveGrow)
            : base(numReserve, reserveGrow)
        {
            // do nothing
        }

         public static CollisionSpriteBox Add(GameObjectNames collisionSpriteName, Azul.Color color, CollisionRect rect)
         {
             return CollisionSpriteBoxManager.Add(collisionSpriteName, Index.i0, color, rect);
         }

         public static CollisionSpriteBox Add(GameObjectNames collisionSpriteName, Index index, Azul.Color color, CollisionRect rect)
         {
             // Get the instance
             CollisionSpriteBoxManager pCollisionSpriteMan = CollisionSpriteBoxManager.privInstance();

             // Go to Man, get a node from reserve, add to active, return it
             CollisionSpriteBox pCollisionSprite = (CollisionSpriteBox)pCollisionSpriteMan.baseAdd();

             // Initialize CollisionSprite
             //// correct for center
             //rect.x -= rect.width / 2;
             //rect.y -= rect.height / 2;
             pCollisionSprite.Set(collisionSpriteName, index, color, rect);

             return pCollisionSprite;
         }

         public static void Add(GameObjectNames collisionSpriteName, Azul.Color color, int x, int y, int width, int height)
         {
             CollisionSpriteBoxManager.Add(collisionSpriteName, Index.i0, color, x, y, width, height);

         }

         public static void Add(GameObjectNames collisionSpriteName, Index index, Azul.Color color, int x, int y, int width, int height)
         {
             //get the instance
             CollisionSpriteBoxManager pCollisionSpriteManager = CollisionSpriteBoxManager.privInstance();

             //go to Manager, get a node from reserve, add to active, return it
             CollisionSpriteBox pCollisionSprite = (CollisionSpriteBox)pCollisionSpriteManager.baseAdd();

             //Initialize CollisionSprite
             // correct for center
             x -= width / 2;
             y -= height / 2;
             pCollisionSprite.Set(collisionSpriteName, index, color, x, y, width, height);

         }

         private static CollisionSpriteBoxManager privInstance()
         {
             //Safety = this forces users to call create first
             Debug.Assert(instance != null);
             return instance;

         }

         // Must define for Abastract Manager class
         protected override object privGetNewObj()
         {
             object pObj = new CollisionSpriteBox();
             return pObj;
         }

         public static CollisionSpriteBox Find(CollisionSpriteBoxNames name, Index index = Index.i0)
         {
             //get the singleton
             CollisionSpriteBoxManager pCollisionSpriteManager = CollisionSpriteBoxManager.privInstance();

             //call the base class function
             CollisionSpriteBox pCollisionSprite = null;

             //special case for Null Object
             //if (name == CollisionSpriteBoxNames.NullObject)
             //{
             //    pCollisionSprite = (CollisionSpriteBox)pCollisionSpriteManager.pCollisionSpriteNull;

             //}
             //else
             //{
             //    pCollisionSprite = (CollisionSpriteBox)pCollisionSpriteManager.basefind(name, index);

             //}
             pCollisionSprite = (CollisionSpriteBox)pCollisionSpriteManager.basefind(name, index);
             return pCollisionSprite;
         }



        



       //Data -------------------
        private static CollisionSpriteBoxManager instance = null;
        private CollisionSpriteNull pCollisionSpriteNull = null;
    }
}
