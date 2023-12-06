
using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class GameObjectNull : GameObject
    {
        public GameObjectNull()
            : base(GameObject.Name.Null_Object, null)
        {

        }

        public override void Update()
        {
            // do nothing - its a null object
            Debug.WriteLine("NULL object");
        }
    }
}

// --- End of File ---
