using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using DiskCardGame;

namespace NodeAPI
{
    public class NewNode
    {
        public static List<NewNode> nodes = new List<NewNode>();
        public Type nodeSequenceHandlerType;
        public GameObject nodeSequencerPrefab;
        public List<Texture2D> mapAnimationFrames;
        public MapNodeType type;
        public string name;
        public List<NodeData.SelectionCondition> generationPrerequisiteConditions;
        public List<NodeData.SelectionCondition> forceGenerationConditions;

        public NewNode(string name, MapNodeType type, List<Texture2D> mapAnimationFrames, GameObject nodeSequencerPrefab, List<NodeData.SelectionCondition> generationPrerequisites = null, List<NodeData.SelectionCondition> forceGenerationConditions = null)
        {
            this.name = name;
            this.type = type;
            this.mapAnimationFrames = new List<Texture2D>(mapAnimationFrames);
            generationPrerequisiteConditions = new List<NodeData.SelectionCondition>();
            if (generationPrerequisites != null)
            {
                generationPrerequisiteConditions = new List<NodeData.SelectionCondition>(generationPrerequisites);
            }
            this.forceGenerationConditions = new List<NodeData.SelectionCondition>();
            if (forceGenerationConditions != null)
            {
                this.forceGenerationConditions = new List<NodeData.SelectionCondition>(forceGenerationConditions);
            }
            this.nodeSequencerPrefab = nodeSequencerPrefab;
            nodes.Add(this);
        }

        public NewNode(string name, MapNodeType type, List<Texture2D> mapAnimationFrames, Type nodeSequenceHandlerType, List<NodeData.SelectionCondition> generationPrerequisites = null, List<NodeData.SelectionCondition> forceGenerationConditions = null)
        {
            this.name = name;
            this.type = type;
            this.mapAnimationFrames = new List<Texture2D>(mapAnimationFrames);
            generationPrerequisiteConditions = new List<NodeData.SelectionCondition>();
            if(generationPrerequisites != null)
            {
                generationPrerequisiteConditions = new List<NodeData.SelectionCondition>(generationPrerequisites);
            }
            this.forceGenerationConditions = new List<NodeData.SelectionCondition>();
            if (forceGenerationConditions != null)
            {
                this.forceGenerationConditions = new List<NodeData.SelectionCondition>(forceGenerationConditions);
            }
            this.nodeSequenceHandlerType = nodeSequenceHandlerType;
            nodes.Add(this);
        }

        public enum MapNodeType
        {
            NONE,
            CardBattle,
            SpecialCardBattle,
            CardChoice,
            SpecialCardChoice,
            Other
        }
    }
}
