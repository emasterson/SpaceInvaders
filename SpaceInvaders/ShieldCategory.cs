using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract class ShieldCategory : GameObject
    {
        public enum Type
        {
            Root,
            Column,
            Brick,
            LeftTop0,
            LeftTop1,
            LeftBottom,
            RightTop0,
            RightTop1,
            RightBottom,
            Not_Initialized
        }

        protected ShieldCategory(GameObjectNames name, Index index, SpriteNames spriteName, ShieldCategory.Type shieldType)
            : base(name, index, spriteName)
        {
            this.type = shieldType;
        }

        static public GameObject GetShield(GameObject objA, GameObject objB)
        {
            GameObject pShield;
            if (objA is ShieldCategory)
            {
                pShield = (GameObject)objA;
            }
            else
            {
                pShield = (GameObject)objB;
            }

            Debug.Assert(pShield is ShieldCategory);

            return pShield;

        }

        protected ShieldCategory.Type type;
    }
}
