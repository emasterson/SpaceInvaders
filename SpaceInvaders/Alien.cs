using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    abstract class Alien : GameObject
    {

        public enum Type
        {
            Crab,
            Squid,
            Octopus,
            Hierarchy,
            Grid, 
            Column,
            Not_Initialized
        }

        protected Alien(GameObjectNames name, Index index, SpriteNames spriteName, Alien.Type alienType)
            : base(name, index, spriteName)
        {
            this.type = alienType;
        }

        

        // Data: ---------------

        // this is just a placeholder, who knows what data will be stored here
        protected Alien.Type type;
    }
}
