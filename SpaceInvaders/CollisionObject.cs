using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class CollisionObject
    {

        //**********************
        // corrects the xy of the sprite from the center to the top left for its Collision Rectangle
        public CollisionObject(Sprite pSprite, GameObjectNames gameName, Index gameIndex)
        {
            this.pCollisionRect = new CollisionRect(pSprite.x, pSprite.y, pSprite.origWidth, pSprite.origHeight);

            //correct for center
            pCollisionRect.x -= pCollisionRect.width / 2;
            pCollisionRect.y += pCollisionRect.height / 2;


            //*******************This needs to change ! Why do we always call it Crab??????????????????????????????????

          //  this.pCollisionSprite = CollisionSpriteBoxManager.Add(CollisionSpriteBoxNames.Crab, new Azul.Color(1.0f, 1.0f, 0.0f), pCollisionRect);
            this.pCollisionSprite = CollisionSpriteBoxManager.Add(gameName, gameIndex, new Azul.Color(1.0f, 1.0f, 0.0f), pCollisionRect);
            SpriteBatchGroup pSBG_Boxes = SpriteBatchManager.Find(SpriteBatchGroup.Name.SBG_Boxes);
            Debug.Assert(pSBG_Boxes != null);
            pSBG_Boxes.Attach(this.pCollisionSprite);

        }

        //public void Update(float x, float y)
        //{
        //    this.pCollisionRect.x = x - pCollisionRect.width / 2;
        //    this.pCollisionRect.y = y + pCollisionRect.height / 2;

        //    this.pCollisionSprite.pRect.x = this.pCollisionRect.x;
        //    this.pCollisionSprite.pRect.y = this.pCollisionRect.y;
        //}

        public void UpdatePos(float x, float y)// this mattered when I changed plus and minus
        {
            this.pCollisionRect.x = x - pCollisionRect.width / 2;
            this.pCollisionRect.y = y + pCollisionRect.height / 2;

            this.pCollisionSprite.pRect.x = this.pCollisionRect.x;
            this.pCollisionSprite.pRect.y = this.pCollisionRect.y;
        }
        

        public void SetRect(CollisionRect rect)
        {
            // set the collision data
            this.pCollisionRect = rect;

            // update the sprite data;
            pCollisionSprite.SetRect(rect);

        }


        //Data -----------------
        public CollisionSpriteBox pCollisionSprite;
        public CollisionRect pCollisionRect;

    }
}
