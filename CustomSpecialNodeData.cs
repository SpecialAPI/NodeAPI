using DiskCardGame;
using System;
using System.Collections.Generic;
using System.Text;

namespace NodeAPI
{
    public class CustomSpecialNodeData : SpecialNodeData
    {
        public sealed override string PrefabPath => "Prefabs/Map/MapNodesPart1/MapNode_BuyPelts";
        public override List<SelectionCondition> GenerationPrerequisiteConditions => Node != null && Node.generationPrerequisiteConditions != null ? Node.generationPrerequisiteConditions : new List<SelectionCondition>();
        public override List<SelectionCondition> ForceGenerationConditions => Node != null && Node.forceGenerationConditions != null ? Node.forceGenerationConditions : new List<SelectionCondition>();

        public NewNode Node
        {
            get
            {
                if(NewNode.nodes.Exists((x) => x.name == nodeName && NewNode.nodes.IndexOf(x) == nodeIndex))
                {
                    return NewNode.nodes.Find((x) => x.name == nodeName && NewNode.nodes.IndexOf(x) == nodeIndex);
                }
                else if(NewNode.nodes.Exists((x) => x.name == nodeName))
                {
                    return NewNode.nodes.Find((x) => x.name == nodeName);
                }
                else if(NewNode.nodes.Count > nodeIndex)
                {
                    return NewNode.nodes[nodeIndex];
                }
                return null;
            }
        }

        public string nodeName;
        public int nodeIndex;
    }
}
