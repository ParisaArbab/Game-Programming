using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract class AlienBase : GameObject
    {
        public enum Type
        {
            CrabA,
            
            SquidA,
            OctopusA,

            CrabB,

            SquidB,
            OctopusB
        }

        protected AlienBase(GameObject.Name gameName, SpriteGame.Name spriteName, float _x, float _y)
            : base(gameName,spriteName,_x,_y)
        {

        }
    }
}

// --- End of File ---
