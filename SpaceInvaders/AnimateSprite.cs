using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    // These classes allow us to have linked lists of images
    // why are they inside?
    class ImageLink
    {
        protected ImageLink()
        {
            this.next = null;
        }

        // Data: ---------------
        public ImageLink next;
    }

    class ImageHolder : ImageLink
    {
        public ImageHolder(Image image)
            : base()
        {
            this.pImage = image;
        }

        // Data: ---------------
        public Image pImage;
    }

    class AnimateSprite : Command
    {
        public AnimateSprite(SpriteNames spriteName)
        {
            // initialized the sprite animation is attached to
            this.pSprite = SpriteManager.find(spriteName);
            Debug.Assert(this.pSprite != null);

            // initialize references
            this.pCurrImage = null;

            // list
            this.pImageList = null;
        }

        private void privAddNode(ImageLink node, ref ImageLink head)
        {
            // protection
            Debug.Assert(node != null);

            // add to front
            if (head == null)
            {
                head = node;
                node.next = null;
            }
            else
            {
                node.next = head;
                head = node;
            }
        }

        public void Attach(ImageNames imageName)
        {
            // Get the image
            Image pImage = ImageManager.Find(imageName);
            Debug.Assert(pImage != null);

            // Create a new holder
            ImageHolder pImageHolder = new ImageHolder(pImage);

            // Attach it to the Animation Sprite ( Push to front )
            this.privAddNode(pImageHolder, ref this.pImageList);

            // Set the first one to this image
            this.pCurrImage = pImageHolder;
        }

        public override void execute(float deltaTime)
        {
            // advance to next image 
            ImageHolder pImageHolder = (ImageHolder)this.pCurrImage.next;

            // if at end of list, set to first
            if (pImageHolder == null)
            {
                pImageHolder = (ImageHolder)pImageList;
            }

            // squirrel away for next timer event
            this.pCurrImage = pImageHolder;
           // Console.WriteLine("this.pCurrImage " + this.pCurrImage.pImage.name);

            // change image
            this.pSprite.pImage = pImageHolder.pImage;

           // GameObject pGameObj = GameObjManager.Find(GameObjectNames.
            float newTime = 1.0f;
              newTime  = .018f * pAlienRemove.AlienCount;
            // Add itself back to timer

            TimerManager.Add(TimeEventNames.SpriteAnimation, this, newTime);

        }





        // Data: ---------------
        //public Image.Name name;
        //public Index index;

        private Sprite pSprite;
        private ImageLink pImageList;
        private ImageHolder pCurrImage;
        private AnimateSprite pAnimateSprite;
        public AlienRemoveObserver pAlienRemove;
    }

    
}
