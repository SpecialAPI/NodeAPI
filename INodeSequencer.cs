using DiskCardGame;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace NodeAPI
{
    public interface INodeSequencer
    {
        IEnumerator DoCustomSequence();
        void Inherit();
    }
}
