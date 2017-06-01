using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class CollisionSpriteManager : Manager
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
                instance = new CollisionSpriteManager(reserveNum, reserveGrow);
                // instance.pNullSprite = new NullSprite(GameSprite.Name.NullObject);
            }
        }

        public static void Destroy()
        {
            CollisionSpriteManager.privInstance().baseDestroy();
        }

         private CollisionSpriteManager(int numReserve, int reserveGrow)
            : base(numReserve, reserveGrow)
        {
            // do nothing
        }

         public static CollisionSprite Add(CollisionSpriteNames collisionSpriteName, Azul.Color color, CollisionRect rect)
         {
             return CollisionSpriteManager.Add(collisionSpriteName, Index.i0, color, rect);
         }

         public static CollisionSprite Add(CollisionSpriteNames collisionSpriteName, Index index, Azul.Color color, CollisionRect rect)
         {
             // Get the instance
             CollisionSpriteManager pCollisionSpriteMan = CollisionSpriteManager.privInstance();

             // Go to Man, get a node from reserve, add to active, return it
             CollisionSprite pCollisionSprite = (CollisionSprite)pCollisionSpriteMan.baseAdd();

             // Initialize CollisionSprite
             //// correct for center
             //rect.x -= rect.width / 2;
             //rect.y -= rect.height / 2;
             pCollisionSprite.Set(collisionSpriteName, index, color, rect);

             return pCollisionSprite;
         }

         public static void Add(CollisionSpriteNames collisionSpriteName, Azul.Color color, int x, int y, int width, int height)
         {
             CollisionSpriteManager.Add(collisionSpriteName, Index.i0, color, x, y, width, height);

         }

         public static void Add(CollisionSpriteNames collisionSpriteName, Index index, Azul.Color color, int x, int y, int width, int height)
         {
             //get the instance
             CollisionSpriteManager pCollisionSpriteManager = CollisionSpriteManager.privInstance();

             //go to Manager, get a node from reserve, add to active, return it
             CollisionSprite pCollisionSprite = (CollisionSprite)pCollisionSpriteManager.baseAdd();

             //Initialize CollisionSprite
             // correct for center
             x -= width / 2;
             y -= height / 2;
             pCollisionSprite.Set(collisionSpriteName, index, color, x, y, width, height);

         }

         private static CollisionSpriteManager privInstance()
         {
             //Safety = this forces users to call create first
             Debug.Assert(instance != null);
             return instance;

         }

         // Must define for Abastract Manager class
         protected override object privGetNewObj()
         {
             object pObj = new CollisionSprite();
             return pObj;
         }

         public static CollisionSprite Find(CollisionSpriteNames name, Index index = Index.i0)
         {
             //get the singleton
             CollisionSpriteManager pCollisionSpriteManager = CollisionSpriteManager.privInstance();

             //call the base class function
             CollisionSprite pCollisionSprite = null;

             //special case for Null Object
             if (name == CollisionSpriteNames.NullObject)
             {
                 pCollisionSprite = (CollisionSprite)pCollisionSpriteManager.pCollisionSpriteNull;

             }
             else
             {
                 pCollisionSprite = (CollisionSprite)pCollisionSpriteManager.basefind(name, index);

             }
             return pCollisionSprite;
         }



        



       //Data -------------------
        private static CollisionSpriteManager instance = null;
        private CollisionSpriteNull pCollisionSpriteNull = null;
    }
}
