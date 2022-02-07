using System;
using System.Collections.Generic;
using System.Text;
using HarmonyLib;
using DiskCardGame;
using UnityEngine;

namespace NodeAPI.Patches
{
    [HarmonyPatch(typeof(MapDataReader), "SpawnAndPlaceElement")]
    public class MapDataReader_SpawnAndPlaceElement
    {
        [HarmonyPostfix]
        public static void Postfix(MapElementData data, GameObject __result)
        {
            if(data is CustomSpecialNodeData && (data as CustomSpecialNodeData).Node != null && NewNode.nodes.Contains((data as CustomSpecialNodeData).Node))
            {
                __result.GetComponentInChildren<AnimatingSprite>().SetTexture((data as CustomSpecialNodeData).Node.mapAnimationFrames[0]);
                __result.GetComponentInChildren<AnimatingSprite>().textureFrames = new List<Texture2D>((data as CustomSpecialNodeData).Node.mapAnimationFrames);
            }
            else if(data is CustomSpecialNodeData && ((data as CustomSpecialNodeData).Node == null || !NewNode.nodes.Contains((data as CustomSpecialNodeData).Node)))
            {
                __result.GetComponentInChildren<AnimatingSprite>().SetTexture(Plugin.MAP_EVENT_MISSING[0]);
                __result.GetComponentInChildren<AnimatingSprite>().textureFrames = new List<Texture2D>(Plugin.MAP_EVENT_MISSING);
            }
        }
    }
}
