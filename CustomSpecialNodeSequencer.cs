using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using DiskCardGame;

namespace NodeAPI
{
    public abstract class CustomSpecialNodeSequencer : ManagedBehaviour, INodeSequencer
    {
        public virtual void Inherit() { }

        public abstract IEnumerator DoCustomSequence();
    }
}
