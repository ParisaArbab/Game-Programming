//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class DLinkMan : ListBase
    {
        public DLinkMan()
            : base()
        {
            this.poIterator = new DLinkIterator();
            this.poHead = null;
        }


        public override void AddByPriority(NodeBase _pNode, float priority)
        {
            Debug.Assert(_pNode != null);
            DLink pNode = (DLink)_pNode;
            //bool isInserted = false;

            if (poHead == null)
            {
                poHead = pNode;
                pNode.pNext = null;
                pNode.pPrev = null;
                pNode.priority = priority;
            }
            else if (poHead.pNext == null)
            {
                if (priority < poHead.priority)
                {
                    pNode.pNext = poHead;
                    pNode.pPrev = null;
                    poHead.pPrev = pNode;
                    poHead.pNext = null;
                    poHead = pNode;
                    pNode.priority = priority;
                }
                else
                {
                    pNode.pNext = null;
                    pNode.pPrev = poHead;
                    poHead.pPrev = null;
                    poHead.pNext = pNode;
                    pNode.priority = priority;
                }

            }
            else
            {
                if (priority < poHead.priority)
                {
                    pNode.pNext = poHead;
                    pNode.pPrev = null;
                    poHead.pPrev = pNode;
                    poHead = pNode;
                    pNode.priority = priority;
                }
                else
                {
                    DLink it = poHead.pNext;
                    while (it != null)
                    {
                        if (priority < it.priority)
                        {
                            pNode.pNext = it;
                            pNode.pPrev = it.pPrev;
                            it.pPrev = pNode;
                            pNode.pPrev.pNext = pNode;
                            pNode.priority = priority;
                            // isInserted = true;
                            break;
                        }
                        else if (it.pNext == null)
                        {
                            pNode.pPrev = it;
                            pNode.priority = priority;
                            it.pNext = pNode;
                            pNode.pNext = null;
                            it = null;
                        }
                        else
                        {
                            it = it.pNext;
                        }
                    }
                    //        if (isInserted)
                    //        {
                    //            if (priority < it.priority)
                    //            {
                    //                pNode.pNext = it;
                    //                pNode.pPrev = it.pPrev;
                    //                it.pPrev = pNode;
                    //                pNode.pPrev.pNext = pNode;
                    //                pNode.pPrev.pPrev = poHead;

                    //                pNode.priority = priority;
                    //            }
                    //            else
                    //            {
                    //                pNode.pNext = null;
                    //                pNode.pPrev = it;
                    //                it.pNext = pNode;
                    //                it.pPrev.pPrev = poHead;
                    //                pNode.priority = priority;
                    //            }

                    //        } }
                    //}
                    Debug.Assert(poHead != null);
                }
            }
        }
                
        override public void AddToFront(NodeBase _pNode)
        {
            // add to front
            Debug.Assert(_pNode != null);

            DLink pNode = (DLink)_pNode;
            // add node
            if (poHead == null)
            {
                // push to the front
                poHead = pNode;
                pNode.pNext = null;
                pNode.pPrev = null;
            }
            else
            {
                // push to front
                pNode.pPrev = null;
                pNode.pNext = poHead;

                // update head
                poHead.pPrev = pNode;
                poHead = pNode;
            }

            // worst case, pHead was null initially, now we added a node so... this is true
            Debug.Assert(poHead != null);
        }

        public void AddToEnd(NodeBase _pNode)
        {
            // add to front
            Debug.Assert(_pNode != null);
            DLink pNode = (DLink)_pNode;

            // add node
            if (poHead == null)
            {
                // none on list... so add it
                poHead = pNode;
                pNode.pNext = null;
                pNode.pPrev = null;
            }
            else
            {
                // spin until end
                DLink pTmp = poHead;
                DLink pLast = pTmp;
                while (pTmp != null)
                {
                    pLast = pTmp;
                    pTmp = pTmp.pNext;
                }

                // push to front
                pLast.pNext = pNode;
                pNode.pPrev = pLast;
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
            DLink pNode = (DLink)_pNode;

            // four cases

            if (pNode.pPrev == null && pNode.pNext == null)
            {   // Only node
                poHead = null;
            }
            else if (pNode.pPrev == null && pNode.pNext != null)
            {   // First node
                poHead = pNode.pNext;
                pNode.pNext.pPrev = pNode.pPrev;
            }
            else if (pNode.pPrev != null && pNode.pNext == null)
            {   // Last node
                pNode.pPrev.pNext = pNode.pNext;
            }
            else // (pNode.pPrev != null && pNode.pNext != null)
            {   // Middle node
                pNode.pNext.pPrev = pNode.pPrev;
                pNode.pPrev.pNext = pNode.pNext;
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
            DLink pNode = poHead;

            // Update head (OK if it points to NULL)
            poHead = poHead.pNext;
            if (poHead != null)
            {
                poHead.pPrev = null;
                // do not change pEnd
            }
            //else
            //{
                // only one on the list
               // pHead == null;
           // }

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

        // ---------------------------------------
        // DO not add/modify variables
        // ---------------------------------------
        // Data:
        public DLink poHead;
        public DLinkIterator poIterator;
    }
}

// --- End of File ---
