
using System;
using UnityEngine;

namespace DiceRoll.Dice
{
    [CreateAssetMenu(fileName = "DiceScriptableObject", menuName = "ScriptableObjects/DiceScriptableObject")]
    public class DiceSO : ScriptableObject
    {
        public DiceFaceData[] DiceFaces;
    } 

    [Serializable]
    public struct DiceFaceData 
    {
        public DiceFace DiceFace;
        public Sprite DiceFaceSprite;
    }
}
