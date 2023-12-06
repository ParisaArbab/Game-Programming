﻿using System.Diagnostics;

namespace SpaceInvaders
{
    public class SpriteGameProxy : SpriteBase
    {
        //------------------------------------
        // Enum
        //------------------------------------
        public enum Name
        {
            Proxy,

            Uninitialized
        }

        //------------------------------------
        // Constructors
        //------------------------------------

        // Create a single sprite and all dynamic objects ONCE and ONLY ONCE (OOO- tm)
        public SpriteGameProxy()
        : base()   // <--- Delegate (kick the can)
        {
            this.privClear();
        }


        //------------------------------------
        // Methods
        //------------------------------------

        public void Set(SpriteGame.Name _name)
        {
            this.name = SpriteGameProxy.Name.Proxy;

            this.x = 0.0f;
            this.y = 0.0f;

            this.pSprite = SpriteGameMan.Find(_name);
            Debug.Assert(this.pSprite != null);
        }
        private void privPushToReal()
        {
            // push the data from proxy to Real GameSprite
            Debug.Assert(this.pSprite != null);

            this.pSprite.x = this.x;
            this.pSprite.y = this.y;
        }
        private void privClear()
        {
            this.name = SpriteGameProxy.Name.Uninitialized;

            this.x = 0.0f;
            this.y = 0.0f;

            this.pSprite = null;
        }


        //------------------------------------
        // Override
        //------------------------------------

        public override void Render()
        {
            // move the values over to Real GameSprite
            this.privPushToReal();

            // update and draw real sprite 
            // Seems redundant - Real Sprite might be stale
            this.pSprite.Update();
            this.pSprite.Render();
        }
        
        public override void Update()
        {
            // push the data from proxy to Real GameSprite
            this.privPushToReal();
            this.pSprite.Update();
        }
        public override System.Enum GetName()
        {
            return this.name;
        }
        override public void Wash()
        {
            this.baseClear();
            this.privClear();
        }
        override public void Dump()
        {
            // we are using HASH code as its unique identifier 
            Debug.WriteLine("   {0} ({1})", this.name, this.GetHashCode());

            // Data:
            if (pSprite != null)
            {
                Debug.WriteLine("       Sprite:{0} ({1})", this.pSprite.GetName(), this.pSprite.GetHashCode());
            }
            else
            {
                Debug.WriteLine("       Sprite: null");
            }
            Debug.WriteLine("        (x,y): {0},{1}", this.x, this.y);

            // Let the base print its contribution
            this.baseDump();
        }

        //------------------------------------
        // Data
        //------------------------------------
        public Name name;
        public float x;
        public float y;
        public SpriteGame pSprite;
    }
}

// --- End of File ---

