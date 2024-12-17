using System;
using System.Collections.Generic;

using UnityEngine;

namespace DiceRoll.Level
{
    [CreateAssetMenu(fileName = "LevelScriptableObject", menuName = "ScriptableObjects/LevelScriptableObject")]
    public class LevelSO : ScriptableObject
    {
        public List<LevelData> Levels; 
    }

    [Serializable]
    public struct LevelData
    {
        public LevelType LevelType;
        public float DiceRollInterval;
        public int TargetScore;
        public int[] ScoreTime;
    }

    public enum LevelType
    {
        Easy,
        Medium,
        Hard
    }
}
