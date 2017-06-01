using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract class PlayerShipCategory : GameObject
    {

        public enum Type
        {
            PlayerShip,
            PlayerShipRoot,
            Not_Initialized
        }

        protected PlayerShipCategory(GameObjectNames name, Index index, SpriteNames spriteName, PlayerShipCategory.Type PlayerShipCategoryType)
            : base(name, index, spriteName)
        {
            this.type = PlayerShipCategoryType;
        }

        static public GameObject GetPlayerShip(GameObject objA, GameObject objB)
        {
            GameObject pPlayerShip;
            if (objA is PlayerShipCategory)
            {
                pPlayerShip = (GameObject)objA;
            }
            else
            {
                pPlayerShip = (GameObject)objB;
            }

           // Debug.Assert(pPlayerShip is MissileCategory);
            Debug.Assert(pPlayerShip is PlayerShipCategory);

            return pPlayerShip;
        }


        protected PlayerShipCategory.Type type;

    }
}
