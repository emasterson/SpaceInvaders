using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class AlienRemoveObserver : CollisionObserver
    {
        public AlienRemoveObserver()
        {
            this.pAlien = null;
        }

        public AlienRemoveObserver(AlienRemoveObserver a)
        {
            this.pAlien = a.pAlien;
        }

        public override void Notify()
         {
            // Delete Alien
            pAlien = AlienCategory.GetAlien(this.subject.objA, this.subject.objB);

            if(this.subject.objB.name.Equals(GameObjectNames.Octopus))
            {
                Scoreboard pScoreboard = Scoreboard.privInstance();
                pScoreboard.p1Score += 10;
            }

            if (this.subject.objB.name.Equals(GameObjectNames.Crab))
            {
                Scoreboard pScoreboard = Scoreboard.privInstance();
                pScoreboard.p1Score += 20;
            }

            if (this.subject.objB.name.Equals(GameObjectNames.Squid))
            {
                Scoreboard pScoreboard = Scoreboard.privInstance();
                pScoreboard.p1Score += 30;
            }
            Azul.Sound AlienExplosionSound;
            AlienExplosionSound = Azul.Audio.playSound("invaderkilled.wav", false, false, true);
            Debug.WriteLine("AlienRemoveObserver: --> delete alien {0}", pAlien);

            //   Delay
            AlienRemoveObserver pObserver = new AlienRemoveObserver(this);
            DelayedObjectManager.Attach(pObserver);
            
            AlienCount -= 1.0f;
        }
        //public override void Notify()
        //{
        //    // Delete Alien
        //    GameObject pAlien = AlienCategory.GetAlien(this.subject.objA, this.subject.objB);
        //    Debug.WriteLine("AlienRemoveObserver: --> delete alien {0}", pAlien);

        //    // Let the gameObject deal with this...
        //    pAlien.RemoveMe();
        //}

        public override void execute()
        {
            // if deleting all children
            //     Kill the column
            GameObject pParent = (GameObject)pAlien.parent;
            Debug.Assert(pParent != null);

            // Let the gameObject deal with this...
             pAlien.RemoveMe();

            if (pParent.child == null)
            {
                // We just delete the last child
                // So delete the column
                pParent.RemoveMe();
            }
        }

        public double retAC()
        {
            return AlienCount;
        }

        private GameObject pAlien;
        public float AlienCount = 55.0f;
        private AnimateSprite pAS;
    }
}
