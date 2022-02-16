using DiskCardGame;
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using UnityEngine;
using System.Linq;

namespace NodeAPI
{
    public static class NodeTools
    {
        public static Type GetTypeForNodeType(NewNode.MapNodeType type)
        {
            switch (type)
            {
                case NewNode.MapNodeType.SpecialCardBattle:
                case NewNode.MapNodeType.CardBattle:
                    return typeof(CardBattleNodeData);
                case NewNode.MapNodeType.CardChoice:
                case NewNode.MapNodeType.SpecialCardChoice:
                case NewNode.MapNodeType.Other:
                    return typeof(SpecialNodeData);
            }
            return typeof(NodeData);
        }

        public static void StartSequence(this INodeSequencer self, SpecialNodeHandler instance = null)
        {
            self.Inherit();
            (instance ?? SpecialNodeHandler.Instance).StartCoroutine(self.Sequence());
        }

        public static IEnumerator Sequence(this INodeSequencer self)
        {
            yield return self.DoCustomSequence();
            Singleton<ViewManager>.Instance.SwitchToView(View.MapDefault, false, false);
            Singleton<ViewManager>.Instance.Controller.LockState = ViewLockState.Unlocked;
            Singleton<GameFlowManager>.Instance.TransitionToGameState(GameState.Map, null);
            if(self is Component)
            {
                UnityEngine.Object.Destroy((self as Component).gameObject);
            }
            yield break;
        }

        public static bool SequencerTypeValid(Type type)
        {
            return type != null && type.IsSubclassOf(typeof(Component)) && type.GetInterfaces() != null && type.GetInterfaces().Contains(typeof(INodeSequencer));
        }
    }
}
