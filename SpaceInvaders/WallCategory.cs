using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract class WallCategory : GameObject
    {
        public enum Type
        {
            WallRoot,
            LeftWall,
            Ceiling,
            RightWall,
            Floor,
            Not_Initialized
        }

        protected WallCategory(GameObjectNames name, Index index, SpriteNames spriteName, WallCategory.Type WallType)
            : base(name, index, spriteName)
        {
            this.type = WallType;
        }

        static public GameObject GetUFO(GameObject objA, GameObject objB)
        {
            GameObject pWall;
            if (objA is WallCategory)
            {
                pWall = (GameObject)objA;
            }
            else
            {
                pWall = (GameObject)objB;
            }

            Debug.Assert(pWall is WallCategory);

            return pWall;
        }
        //Data -------------------
        protected WallCategory.Type type;
    }
}
