using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract class UFO_Category : GameObject
    {
        public enum Type
        {
            UFO_FromRight,
            UFO_FromLeft,

            UFO_Root,
            Not_Initialized
        }

        protected UFO_Category(GameObjectNames name, Index index, SpriteNames spriteName, UFO_Category.Type UFO_CategoryType)
            : base(name, index, spriteName)
        {
            this.type = UFO_CategoryType;
        }

        static public GameObject GetUFO(GameObject objA, GameObject objB)
        {
            GameObject pUFO;
            if (objA is UFO_Category)
            {
                pUFO = (GameObject)objA;
            }
            else
            {
                pUFO = (GameObject)objB;
            }

            Debug.Assert(pUFO is UFO_Category);

            return pUFO;
        }


        protected UFO_Category.Type type;
    }
}
