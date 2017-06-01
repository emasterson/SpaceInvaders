using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract class MissileCategory : GameObject
    {
        public enum Type
        {
            Missile,
            MissileRoot,
            Not_Initialized
        }

        protected MissileCategory(GameObjectNames name, Index index, SpriteNames spriteName, MissileCategory.Type missileType)
            : base(name, index, spriteName)
        {
            this.type = missileType;
        }

        static public GameObject GetMissile(GameObject objA, GameObject objB)
        {
            GameObject pMissile;
            if (objA is MissileCategory)
            {
                pMissile = (GameObject)objA;

            }
            else
            {
                pMissile = (GameObject)objB;
            }

            Debug.Assert(pMissile is MissileCategory);
            return pMissile;
        }



        //Data --------------
        protected MissileCategory.Type type;

    }
}
