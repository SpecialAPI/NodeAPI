using System;
using System.Collections.Generic;
using System.Text;
using DiskCardGame;
using HarmonyLib;
using UnityEngine;

namespace NodeAPI.Patches
{
    [HarmonyPatch(typeof(SpecialNodeHandler), "StartSpecialNodeSequence")]
    public class SpecialNodeHandler_StartSpecialNodeSequence
    {
        [HarmonyPrefix]
        public static bool Prefix(SpecialNodeHandler __instance, SpecialNodeData nodeData)
        {
            if(nodeData is CustomSpecialNodeData && (nodeData as CustomSpecialNodeData).Node != null && (nodeData as CustomSpecialNodeData).Node.nodeSequenceHandlerType != null && 
                (nodeData as CustomSpecialNodeData).Node.nodeSequenceHandlerType.IsSubclassOf(typeof(CustomSpecialNodeSequencer)))
            {
                GameObject sequencer = new GameObject((nodeData as CustomSpecialNodeData).Node.name + " Custom Sequencer");
                CustomSpecialNodeSequencer nodeSequence = (CustomSpecialNodeSequencer)sequencer.AddComponent((nodeData as CustomSpecialNodeData).Node.nodeSequenceHandlerType);
                __instance.StartCoroutine(nodeSequence.Sequence());
                return false;
            }
            else if (nodeData is CustomSpecialNodeData && (nodeData as CustomSpecialNodeData).Node != null && ((nodeData as CustomSpecialNodeData).Node.nodeSequenceHandlerType == null ||
                !(nodeData as CustomSpecialNodeData).Node.nodeSequenceHandlerType.IsSubclassOf(typeof(CustomSpecialNodeSequencer))))
            {
                GameObject sequencer = new GameObject("MISSING_SEQUENCE Custom Sequencer");
                CustomSpecialNodeSequencer nodeSequence = sequencer.AddComponent<MissingSequenceSequencer>();
                __instance.StartCoroutine(nodeSequence.Sequence());
                return false;
            }
            else if(nodeData is CustomSpecialNodeData && (nodeData as CustomSpecialNodeData).Node == null)
            {
                GameObject sequencer = new GameObject("MISSING_NODE Custom Sequencer");
                CustomSpecialNodeSequencer nodeSequence = sequencer.AddComponent<MissingEventSequencer>();
                __instance.StartCoroutine(nodeSequence.Sequence());
                return false;
            }
            return true;
        }
    }
}
