using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace F1Timer.UI
{
    [CreateAssetMenu(fileName = "LightScriptableObject", menuName = "ScriptableObjects/LightScriptableObject")]

    public class LightSO : ScriptableObject
    {
        public List<LightData> Lights;
    }

    [Serializable]
    public struct LightData
    {
       public LightCount LightCount;
       public Sprite image;
    }
    public enum LightCount
    {   None,
        One,
        Two,
        Three,
        Four,
        Five,
        Six
    }
}
