﻿//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class DLinkIterator : Iterator
    {
        public DLinkIterator(  )
            : base()
        {
            this.pStart = null;

            this.privInitialize();
        }

        public void Reset( DLink pHead )
        {
            this.pStart = pHead;

            this.privInitialize();
        }
        override public NodeBase Next()
        {
            DLink pLink = (DLink)this.pCurr;

            if (pLink != null)
            {
                pLink = pLink.pNext;
                this.pCurr = (NodeBase)pLink;
            }

            if (pLink == null)
            {
                bDone = true;
            }

            return (NodeBase)pLink;

        }
        override public bool IsDone()
        {
            return bDone;
        }

        override public NodeBase First()
        {
            this.privInitialize();

            return this.pFirst;
        }

        override public NodeBase Current()
        {
            return this.pCurr;
        }

        private void privInitialize( )
        {
            this.pFirst = this.pStart;
            this.pCurr = this.pStart;

            if (this.pStart == null)
            {
                this.bDone = true;
            }
            else
            {
                this.bDone = false;
            }
        }

        
        override public void Erase(ManBase pMan)
        {
            // need to have the manager update its stats, etc...
            Debug.Assert(pMan != null);

            // the one to be deleted
            NodeBase pTmp = this.Current();
            Debug.Assert(pTmp != null);

            // increment the iterator
            this.Next();
            // signal to skip Next() since it was incremented here
            this.bDeleteMe = true;

            // actual removal
            pMan.baseRemove(pTmp);
        }

        // ------------------------
        // Data:
        // ------------------------
        NodeBase pStart;
        NodeBase pFirst;
        NodeBase pCurr;
        bool bDeleteMe;
        bool bDone;
    }
}

// --- End of File ---

