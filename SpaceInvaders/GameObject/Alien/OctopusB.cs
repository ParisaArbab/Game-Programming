
using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class OctopusB : AlienBase
    {
        public OctopusB(SpriteGame.Name spriteName, float posX, float posY)
        : base(GameObject.Name.OctopusB, spriteName, posX, posY)
        {
        }

        public override void Update()
        {
            //this.y += 3.0f;
            //if (this.y > 600.0f)
            //{
            //    this.y = 0.0f;
            //}

            base.Update();
        }

        // Data: ---------------

    }
}

// --- End of File ---
