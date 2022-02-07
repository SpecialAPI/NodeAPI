using BepInEx;
using EasyFeedback.APIs;
using HarmonyLib;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace NodeAPI
{
    [BepInPlugin(GUID, NAME, VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        public const string GUID = "spapi.inscryption.nodeapi";
        public const string NAME = "NodeAPI";
        public const string VERSION = "1.0.0";
        public static List<Texture2D> MAP_EVENT_MISSING;

        public void Awake()
        {
            Harmony harm = new Harmony(GUID);
            harm.PatchAll();
            MAP_EVENT_MISSING = new List<Texture2D>
            {
                TextureLoader.GetTextureFromResource("NodeAPI/Resources/mapevent_missing.png")
            };
        }
    }
}
