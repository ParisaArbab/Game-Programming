﻿//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class SLinkMan : ListBase 
    {
        public SLinkMan()
        {
            this.poIterator = new SLinkIterator();
            this.poHead = null;
        }

        override public void AddToFront(NodeBase _pNode)
        {
            // add to front
            Debug.Assert(_pNode != null);

            SLink pNode = (SLink)_pNode;
            // add node
            if (poHead == null)
            {
                // push to the front
                poHead = pNode;
                pNode.pNext = null;
            }
            else
            {
                // push to front
                pNode.pNext = poHead;
                poHead = pNode;
            }

            // worst case, pHead was null initially, now we added a node so... this is true
            Debug.Assert(poHead != null);
        }
        public void AddToEnd(NodeBase _pNode)
        {
            // add to front
            Debug.Assert(_pNode != null);
            SLink pNode = (SLink)_pNode;

            // add node
            if (poHead == null)
            {
                // none on list... so add it
                poHead = pNode;
                pNode.pNext = null;
            }
            else
            {
                // Spin to the last
                SLink pTmp = poHead;
                SLink pLast = poHead;
                while (pTmp != null)
                {
                    pLast = pTmp;
                    pTmp = pTmp.pNext;
                }

                // push to front
                pLast.pNext = pNode;
                pNode.pNext = null;

            }

            // worst case, pHead was null initially, now we added a node so... this is true
            Debug.Assert(poHead != null);
        }
        override public void Remove(NodeBase _pNode)
        {
            // There should always be something on list
            Debug.Assert(poHead != null);
            Debug.Assert(_pNode != null);
            SLink pNode = (SLink)_pNode;

            // four cases

            if (pNode == poHead)
            {   // Only node or First Node
                poHead = pNode.pNext;
            }
            else
            {   // middle or last (minimum of 2 nodes)
                // find node before pNode
                SLink pTmp = poHead;
                SLink pPrev = poHead;
                while (pTmp != pNode)
                {
                    pPrev = pTmp;
                    pTmp = pTmp.pNext;
                }

                // prev is valid
                pPrev.pNext = pNode.pNext;
            }

            // remove any lingering links
            // HUGELY important - otherwise its crossed linked 
            pNode.Clear();
        }
        override public NodeBase RemoveFromFront()
        {
            // There should always be something on list
            Debug.Assert(poHead != null);

            // return node
            SLink pNode = poHead;

            // Update head (OK if it points to NULL)
            poHead = poHead.pNext;

            // remove any lingering links
            // HUGELY important - otherwise its crossed linked 
            pNode.Clear();

            return pNode;
        }
        override public Iterator GetIterator()
        {
            Debug.Assert(this.poIterator != null);
            this.poIterator.Reset(this.poHead);

            return this.poIterator;
        }

        public override void AddByPriority(NodeBase _pNode, float priority)
        {
            Debug.Assert(_pNode != null);
            SLink pNode = (SLink)_pNode;

            if (poHead == null || priority < poHead.priority)
            {
                pNode.pNext = poHead;
                poHead = pNode;
                pNode.priority = priority;
            }
            else
            {
                SLink it = poHead;
                while (it.pNext != null && it.pNext.priority <= priority)
                {
                    it = it.pNext;
                }
                pNode.pNext = it.pNext;
                it.pNext = pNode;
                pNode.priority = priority;
            }

            Debug.Assert(poHead != null);
        }


        // ---------------------------------------
        // DO not add/modify variables
        // ---------------------------------------
        // Data:
        public SLink poHead;
        public SLinkIterator poIterator;
    }
}

// --- End of File ---
