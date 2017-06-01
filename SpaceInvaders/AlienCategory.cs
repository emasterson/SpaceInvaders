using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract class AlienCategory : GameObject
    {
        public enum Type
        {
            Crab,
            Squid,
            Octopus,
            Grid,
            Column,
            Hierarchy,
            Not_Initialized
        }

        protected AlienCategory(GameObjectNames name, Index index, SpriteNames spriteName, AlienCategory.Type alienType)
            :base(name, index, spriteName)
        {
            this.type = alienType;
        }

        

        static public GameObject GetAlien(GameObject objA, GameObject objB)
        {
            GameObject pAlien;
            if (objA is AlienCategory)
            {
                pAlien = (GameObject)objA;
            }
            else
            {
                pAlien = (GameObject)objB;
            }

            Debug.Assert(pAlien is AlienCategory);

            return pAlien;
        }

        //data-------------------
        protected AlienCategory.Type type;
    }
}
