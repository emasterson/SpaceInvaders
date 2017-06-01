using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract class BombCategory :  GameObject
    {
        public enum Type
        {
            CrossBomb,
            SquigglyBomb,

            BombRoot,
            Not_Initialized
        }

        protected BombCategory(GameObjectNames name, Index index, SpriteNames spriteName, BombCategory.Type BombType)
            : base(name, index, spriteName)
        {
            this.type = BombType;
        }

        static public GameObject GetBomb(GameObject objA, GameObject objB)
        {
            GameObject pBomb;
            if (objA is BombCategory)
            {
                pBomb = (GameObject)objA;
            }
            else
            {
                pBomb = (GameObject)objB;
            }

            Debug.Assert(pBomb is BombCategory);

            return pBomb ;
        }


        protected BombCategory.Type type;
    }
}
