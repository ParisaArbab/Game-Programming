//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class  OctopusA : AlienBase
    {
        public OctopusA(SpriteGame.Name spriteName, float posX, float posY)
        : base(GameObject.Name.OctopusA, spriteName, posX, posY)
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
