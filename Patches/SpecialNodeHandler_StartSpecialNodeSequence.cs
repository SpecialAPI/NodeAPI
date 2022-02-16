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
            if (nodeData is CustomSpecialNodeData && (nodeData as CustomSpecialNodeData).Node != null && (nodeData as CustomSpecialNodeData).Node.nodeSequencerPrefab != null && 
                (nodeData as CustomSpecialNodeData).Node.nodeSequencerPrefab.GetComponent<INodeSequencer>() != null)
            {
                GameObject sequencer = UnityEngine.Object.Instantiate((nodeData as CustomSpecialNodeData).Node.nodeSequencerPrefab);
                INodeSequencer nodeSequence = sequencer.GetComponent<INodeSequencer>();
                nodeSequence.StartSequence(__instance);
                return false;
            }
            else if(nodeData is CustomSpecialNodeData && (nodeData as CustomSpecialNodeData).Node != null && NodeTools.SequencerTypeValid((nodeData as CustomSpecialNodeData).Node.nodeSequenceHandlerType))
            {
                GameObject sequencer = new GameObject((nodeData as CustomSpecialNodeData).Node.name + " Custom Sequencer");
                INodeSequencer nodeSequence = (INodeSequencer)sequencer.AddComponent((nodeData as CustomSpecialNodeData).Node.nodeSequenceHandlerType);
                nodeSequence.StartSequence(__instance);
                return false;
            }
            else if (nodeData is CustomSpecialNodeData && (nodeData as CustomSpecialNodeData).Node != null && ((nodeData as CustomSpecialNodeData).Node.nodeSequenceHandlerType == null ||
                !(nodeData as CustomSpecialNodeData).Node.nodeSequenceHandlerType.IsSubclassOf(typeof(CustomSpecialNodeSequencer))))
            {
                GameObject sequencer = new GameObject("MISSING_SEQUENCE Custom Sequencer");
                INodeSequencer nodeSequence = sequencer.AddComponent<MissingSequenceSequencer>();
                nodeSequence.StartSequence(__instance);
                return false;
            }
            else if(nodeData is CustomSpecialNodeData && (nodeData as CustomSpecialNodeData).Node == null)
            {
                GameObject sequencer = new GameObject("MISSING_NODE Custom Sequencer");
                INodeSequencer nodeSequence = sequencer.AddComponent<MissingEventSequencer>();
                nodeSequence.StartSequence(__instance);
                return false;
            }
            return true;
        }
    }
}
