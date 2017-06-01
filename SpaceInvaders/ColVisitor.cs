using System;
using System.Diagnostics;


namespace SpaceInvaders
{
    abstract class ColVisitor : PCSNode
    {
        public virtual void VisitAlienGrid(AlienGrid a)
        {
            Debug.WriteLine("Visit by AlienGrid not implemented");
            Debug.Assert(false);

        }

        public virtual void VisitAlienColumn(AlienColumn a)
        {
            Debug.WriteLine("Visit by AlienColumn not implemented");
            Debug.Assert(false);
        }

        public virtual void VisitAlienCrab(AlienCrab a)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by AlienCrab not implemented");
            Debug.Assert(false);
        }

        public virtual void VisitAlienSquid(AlienSquid a)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by AlienSquid not implemented");
            Debug.Assert(false);
        }

        public virtual void VisitAlienOctopus(AlienOctopus a)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by AlienOctopus not implemented");
            Debug.Assert(false);
        }

        public virtual void VisitBomb(Bomb b)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by Bomb not implemented");
            Debug.Assert(false);
        }

        public virtual void VisitMissile(Missile m)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by Missile not implemented");
            Debug.Assert(false);
        }

        public virtual void VisitMissileRoot(MissileRoot m)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by MissileRoot not implemented");
            Debug.Assert(false);
        }

        public virtual void VisitRootGameObject(RootGameObject r)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by RootGameObject not implemented");
            Debug.Assert(false);
        }

        public virtual void VisitShieldRoot(ShieldRoot s)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by ShieldRoot not implemented");
            Debug.Assert(false);
        }

        public virtual void VisitShieldColumn(ShieldColumn s)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by ShieldColumn not implemented");
            Debug.Assert(false);
        }

        public virtual void VisitShieldBrick(ShieldBrick s)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by ShieldBrick not implemented");
            Debug.Assert(false);
        }

        public virtual void VisitPlayerShip(PlayerShip p)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by PlayerShip not implemented");
            Debug.Assert(false);
        }

        public virtual void VisitPlayerShipRoot(PlayerShipRoot pr)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by PlayerShipRoot not implemented");
            Debug.Assert(false);
        }

        public virtual void VisitUFO_GoRight(UFO_GoRight fr)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by UFO_FromRight not implemented");
            Debug.Assert(false);
        }

        public virtual void VisitUFO_GoLeft(UFO_GoLeft l)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by UFO_FromLeft not implemented");
            Debug.Assert(false);
        }

        public virtual void VisitUFO_Root(UFO_Root r)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by UfO_Root not implemented");
            Debug.Assert(false);
        }

        public virtual void VisitBombRoot(BombRoot b)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by BombRoot not implemented");
            Debug.Assert(false);
        }

        public virtual void VisitCrossBomb(CrossBomb b)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by CrossBomb not implemented");
            Debug.Assert(false);
        }

        public virtual void VisitSquigglyBomb(SquigglyBomb b)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by SquigglyBomb not implemented");
            Debug.Assert(false);
        }

        public virtual void VisitWallRoot(WallRoot b)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by WallRoot not implemented");
            Debug.Assert(false);
        }

        public virtual void VisitCeiling(Ceiling b)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by Ceiling not implemented");
            Debug.Assert(false);
        }

        public virtual void VisitLeftWall(LeftWall b)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by LeftWall not implemented");
            Debug.Assert(false);
        }

        public virtual void VisitRightWall(RightWall b)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by RightWall not implemented");
            Debug.Assert(false);
        }

        public virtual void VisitFloor(Floor f)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by floor not implemented");
            Debug.Assert(false);
        }

        abstract public void Accept(ColVisitor other);
    }
}
