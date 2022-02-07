using System;
using System.Collections.Generic;
using System.Text;
using DiskCardGame;
using HarmonyLib;

namespace NodeAPI.Patches
{
    [HarmonyPatch(typeof(MapGenerator), "ChooseSpecialNodeFromPossibilities")]
    public class MapGenerator_ChooseSpecialNodeFromPossibilities
    {
        [HarmonyPrefix]
        public static void Prefix(ref List<NodeData> possibilities)
        {
            NewNode.MapNodeType type = NewNode.MapNodeType.NONE;
            if (possibilities[0] is BuyPeltsNodeData && possibilities[1] is TradePeltsNodeData && possibilities[2] is DeckTrialNodeData && possibilities[3] is BoulderChoiceNodeData)
            {
                type = NewNode.MapNodeType.SpecialCardChoice;
            }
            else if(possibilities[0] is CardMergeNodeData && possibilities[1] is GainConsumablesNodeData && possibilities[2] is BuildTotemNodeData && possibilities[3] is DuplicateMergeNodeData && possibilities[4] is CardRemoveNodeData && possibilities[5] is
                CardStatBoostNodeData && possibilities[6] is CopyCardNodeData)
            {
                type = NewNode.MapNodeType.Other;
            }
            if(type != NewNode.MapNodeType.NONE)
            {
                List<NewNode> nodesOftype = NewNode.nodes.FindAll((x) => x.type == type);
                if(nodesOftype.Count > 0)
                {
                    possibilities.AddRange(nodesOftype.ConvertAll(delegate(NewNode nn) 
                    {
                        NodeData node = new CustomSpecialNodeData();
                        if(node is CustomSpecialNodeData)
                        {
                            (node as CustomSpecialNodeData).nodeName = nn.name;
                            (node as CustomSpecialNodeData).nodeIndex = NewNode.nodes.IndexOf(nn);
                        }
                        return node;
                    }));
                }
            }
        }
    }
}
