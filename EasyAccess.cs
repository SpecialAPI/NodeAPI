using DiskCardGame;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using System.Reflection;

namespace NodeAPI
{
    public static class EasyAccess
    {
        public static CardSingleChoicesSequencer CardChoice => SpecialNodeHandler.Instance.cardChoiceSequencer;
        public static CardMergeSequencer CardMerge => SpecialNodeHandler.Instance.cardMerger;
        public static DuplicateMergeSequencer DuplicateMerge => SpecialNodeHandler.Instance.duplicateMerger;
        public static CardRemoveSequencer CardRemove => SpecialNodeHandler.Instance.cardRemoveSequencer;
        public static CardStatBoostSequencer CardStatBoost => SpecialNodeHandler.Instance.cardStatBoostSequencer;
        public static GainConsumablesSequencer GainConsumable => SpecialNodeHandler.Instance.gainConsumablesSequencer;
        public static BuildTotemSequencer BuildTotem => SpecialNodeHandler.Instance.buildTotemSequencer;
        public static BuyPeltsSequencer BuyPelts => SpecialNodeHandler.Instance.buyPeltsSequencer;
        public static TradePeltsSequencer TradePelts => SpecialNodeHandler.Instance.tradePeltsSequencer;
        public static DeckTrialSequencer DeckTrial => SpecialNodeHandler.Instance.deckTrialSequencer;
        public static BoulderChoiceSequencer BoulderChoice => SpecialNodeHandler.Instance.boulderChoiceSequencer;
        public static ChooseEyeballSequencer EyeChoice => SpecialNodeHandler.Instance.chooseEyeballSequencer;
        public static RareCardChoicesSequencer RareCardChoice => SpecialNodeHandler.Instance.rareCardChoiceSequencer;
        public static VictoryFeastSequencer VictoryFeast => SpecialNodeHandler.Instance.victoryFeastSequencer;
        public static ManagedBehaviour CopyCard 
        {
            get
            {
                if (typeof(SpecialNodeHandler).GetField("copyCardSequencer", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance) != null)
                {
                    return typeof(SpecialNodeHandler).GetField("copyCardSequencer", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance).GetValue(SpecialNodeHandler.Instance) as ManagedBehaviour;
                }
                Debug.LogError("Something is trying to get CopyCard in the non-kaycees version of the game!");
                return null;
            }
        }
    }
}
