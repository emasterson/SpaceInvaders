﻿using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class RightWall : WallCategory
    {
        public RightWall( GameObjectNames name, SpriteNames spriteName, float posX, float posY)
            : base(name, Index.i0, spriteName, WallCategory.Type.RightWall)
        {
            this.x = posX;
            this.y = posY;
            PushPosition();
        }

        public override void Update()
        {
           // this.x += 5.0f; 
        }

        public override void Accept(ColVisitor other)
        {
            // Important: at this point we have an Missile
            // Call the appropriate collision reaction
            other.VisitRightWall(this);
        }

        public override void VisitAlienGrid(AlienGrid m)
        {
            // AlienCrab vs MissileRoot
             Debug.WriteLine("collide: {0} with {1}", this, m);
             Debug.WriteLine("Done -----------> tell observer to send the aliens other way");
            // AlienCrab vs Missile
           // ColPair.Collide((GameObject)m.child, this);
           // ColPair.Collide((GameObject)m, this);

             //ColPair pColPair = ColPairManager.GetActiveColPair();
             //pColPair.SetCollision(m, this);
             //pColPair.NotifyListeners();

            

        }

        public override void VisitUFO_GoRight(UFO_GoRight m)
        {
            // AlienSquid vs Missile
            Debug.WriteLine("collide: {0} with {1}", this, m);

            Debug.WriteLine(" ---> Done");

           // m.hit = true;
            ColPair pColPair = ColPairManager.GetActiveColPair();
            pColPair.SetCollision(m, this);
            pColPair.NotifyListeners();
        }



        // Data: --------------------
    }
}
