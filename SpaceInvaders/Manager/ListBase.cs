
using System;

namespace SpaceInvaders
{
    public abstract class ListBase
    {
        abstract public void AddToFront(NodeBase pNode);
        abstract public void Remove(NodeBase pNode);
        abstract public NodeBase RemoveFromFront();
        abstract public Iterator GetIterator();
        abstract public void AddByPriority(NodeBase pNode, float priority);
    }
}

// --- End of File ---
