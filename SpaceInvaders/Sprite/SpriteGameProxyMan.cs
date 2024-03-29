﻿using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class SpriteGameProxyMan : ManBase
    {
        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------
        private SpriteGameProxyMan(int reserveNum, int reserveGrow)
                : base(new DLinkMan(), new DLinkMan(), reserveNum, reserveGrow)   // <--- Kick the can (delegate)
        {
            // initialize derived data here
            SpriteGameProxyMan.psSpriteGameProxyCompare = new SpriteGameProxy();
        }

        //----------------------------------------------------------------------
        // Static Methods
        //----------------------------------------------------------------------
        public static void Create(int reserveNum = 8, int reserveGrow = 1)
        {
            // make sure values are ressonable 
            Debug.Assert(reserveNum >= 0);
            Debug.Assert(reserveGrow > 0);

            // initialize the singleton here
            Debug.Assert(psInstance == null);

            // Do the initialization
            if (psInstance == null)
            {
                psInstance = new SpriteGameProxyMan(reserveNum, reserveGrow);
            }
        }
        public static void Destroy(bool bPrintEnable = false)
        {
            SpriteGameProxyMan pMan = SpriteGameProxyMan.privGetInstance();
            Debug.Assert(pMan != null);

            // Do something clever here
            // track peak number of active nodes
            // print stats on destroy
            // invalidate the singleton
            if (bPrintEnable)
            {
                SpriteGameProxyMan.DumpStats();
            }
        }
        public static SpriteGameProxy Add(SpriteGame.Name name)
        {
            SpriteGameProxyMan pMan = SpriteGameProxyMan.privGetInstance();
            Debug.Assert(pMan != null);

            SpriteGameProxy pNode = (SpriteGameProxy)pMan.baseAdd();
            Debug.Assert(pNode != null);

            pNode.Set(name);

            return pNode;
        }
        public static void Remove(SpriteGameProxy pSprite)
        {
            SpriteGameProxyMan pMan = SpriteGameProxyMan.privGetInstance();
            Debug.Assert(pMan != null);

            Debug.Assert(pSprite != null);
            pMan.baseRemove(pSprite);
        }
        public static void Dump()
        {
            Debug.WriteLine("\n   ------ SpriteGameProxy Man: ------");

            SpriteGameProxyMan pMan = SpriteGameProxyMan.privGetInstance();
            Debug.Assert(pMan != null);

            pMan.baseDump();
        }
        public static void DumpStats()
        {
            Debug.WriteLine("\n   ------ SpriteGameProxy Man: ------");

            SpriteGameProxyMan pMan = SpriteGameProxyMan.privGetInstance();
            Debug.Assert(pMan != null);

            pMan.baseDumpStats();

            Debug.WriteLine("   ------------\n");
        }

        //----------------------------------------------------------------------
        // Override Abstract methods
        //----------------------------------------------------------------------
        override protected NodeBase derivedCreateNode()
        {
            NodeBase pNodeBase = new SpriteGameProxy();
            Debug.Assert(pNodeBase != null);

            return pNodeBase;
        }

        //------------------------------------
        // Private methods
        //------------------------------------
        private static SpriteGameProxyMan privGetInstance()
        {
            // Safety - this forces users to call Create() first before using class
            Debug.Assert(psInstance != null);

            return psInstance;
        }

        //------------------------------------
        // Data: unique data for this manager 
        //------------------------------------
        private static SpriteGameProxy psSpriteGameProxyCompare;
        private static SpriteGameProxyMan psInstance = null;

    }
}

// --- End of File ---
