using DiskCardGame;
using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
