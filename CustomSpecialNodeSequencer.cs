using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using DiskCardGame;

namespace NodeAPI
{
    public class CustomSpecialNodeSequencer : ManagedBehaviour
    {
        public IEnumerator Sequence()
        {
            yield return DoCustomSequence();
            Singleton<ViewManager>.Instance.SwitchToView(View.MapDefault, false, false);
            Singleton<ViewManager>.Instance.Controller.LockState = ViewLockState.Unlocked;
            Singleton<GameFlowManager>.Instance.TransitionToGameState(GameState.Map, null);
            Destroy(gameObject);
            yield break;
        }

        public virtual IEnumerator DoCustomSequence()
        {
            yield break;
        }
    }
}
