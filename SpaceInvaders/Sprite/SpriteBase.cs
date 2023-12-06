---------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract public class SpriteBase : DLink
    {
        abstract public void Render();
        abstract public void Update();
    }
}

// --- End of File ---
