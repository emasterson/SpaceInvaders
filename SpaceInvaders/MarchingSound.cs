using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class MarchingSound : Command
    {

        class SoundLink
        {
            protected SoundLink()
            {
                this.next = null;
            }

            // Data: ---------------
            public SoundLink next;
        }

        //class SoundHolder : SoundLink
        //{
        //    public SoundHolder(Sound sound)
        //        : base()
        //    {
        //        this.pSound = sound;
        //    }

        //    // Data: ---------------
        //    public Sound pSound;
        //}

        
        
            public MarchingSound()
            {
                // initialized the sprite animation is attached to
                //this.pSprite = SpriteManager.find(spriteName);
               // Debug.Assert(this.pSprite != null);

                //initialize the sound
               
                
                // initialize references
               // this.pCurrImage = null;

                // list
               // this.pImageList = null;
            }

            private void privAddNode(SoundLink node, ref SoundLink head)
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

            //public void Attach(ImageNames imageName)
            //{
            //    // Get the image
            //    Image pImage = ImageManager.Find(imageName);
            //    Debug.Assert(pImage != null);

            //    // Create a new holder
            //    ImageHolder pImageHolder = new ImageHolder(pImage);

            //    // Attach it to the Animation Sprite ( Push to front )
            //    this.privAddNode(pImageHolder, ref this.pImageList);

            //    // Set the first one to this image
            //    this.pCurrImage = pImageHolder;
            //}

            public override void execute(float deltaTime)
            {
                //// advance to next image 
                //ImageHolder pImageHolder = (ImageHolder)this.pCurrImage.next;

                //// if at end of list, set to first
                //if (pImageHolder == null)
                //{
                //    pImageHolder = (ImageHolder)pImageList;
                //}

                //// squirrel away for next timer event
                //this.pCurrImage = pImageHolder;
                //// Console.WriteLine("this.pCurrImage " + this.pCurrImage.pImage.name);

                //// change image
                //this.pSprite.pImage = pImageHolder.pImage;
                newTime = .018f * pAlienRemove.AlienCount;

                //// Add itself back to timer
               // TimerManager.Add(TimeEventNames.MarchingSound, this, deltaTime);
                TimerManager.Add(TimeEventNames.MarchingSound, this, newTime);

                if (whichSound == 4)
                {
                    Azul.Sound AlienMarchingSoundD;
                    AlienMarchingSoundD = Azul.Audio.playSound("D.wav", false, false, true);
                    whichSound = 5;
                }
                if (whichSound == 3)
                {
                    Azul.Sound AlienMarchingSoundC;
                    AlienMarchingSoundC = Azul.Audio.playSound("C.wav", false, false, true);
                    whichSound = 4;
                }
                if (whichSound == 2)
                {
                    Azul.Sound AlienMarchingSoundB;
                    AlienMarchingSoundB = Azul.Audio.playSound("B.wav", false, false, true);
                    whichSound = 3;
                }
                if (whichSound == 1)
                {
                    Azul.Sound AlienMarchingSoundA;
                    AlienMarchingSoundA = Azul.Audio.playSound("A.wav", false, false, true);
                    whichSound = 2;
                }

                if (whichSound == 5)
                {
                    whichSound = 1;
                }
            }





            // Data: ---------------
            //public Image.Name name;
            //public Index index;

            private Sprite pSprite;
            private ImageHolder pCurrImage;
            private ImageLink pImageList;
            Azul.Sound A = Azul.Audio.playSound("A.wav", false, false, true);
            int whichSound = 1;
            public AlienRemoveObserver pAlienRemove;
            float newTime = 1.0f;
        }
    
}
