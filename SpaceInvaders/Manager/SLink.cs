﻿using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract public class SLink : NodeBase
{

        protected SLink()
            : base()
    {
            this.baseClear();
        }

        public void Clear()
        {
            this.baseClear();
        }

        protected void baseClear()
        {
            this.pNext = null;
        }

        protected void baseDump()
        {
            if (this.pNext == null)
            {
                Debug.WriteLine("      next: null");
            }
            else
            {
                NodeBase pTmp = (NodeBase)this.pNext;
                Debug.WriteLine("      next: {0} ({1})", pTmp.GetName(), pTmp.GetHashCode());
            }
        }

        // Data: -----------------------------
        public SLink pNext;
        public float priority;
        //public S

    }
}

// --- End of File ---