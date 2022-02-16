using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using DiskCardGame;

namespace NodeAPI
{
    public class NewNode<T> : NewNode where T : INodeSequencer
    {
        public NewNode(string name, MapNodeType type, List<Texture2D> mapAnimationFrames, List<NodeData.SelectionCondition> generationPrerequisites = null, List<NodeData.SelectionCondition> forceGenerationConditions = null) : base(name, type, 
            mapAnimationFrames, typeof(T), generationPrerequisites, forceGenerationConditions)
        {
        }
    }
}
