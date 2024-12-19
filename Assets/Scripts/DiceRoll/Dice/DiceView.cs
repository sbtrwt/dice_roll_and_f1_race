using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DiceRoll.Dice
{
    public class DiceView : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        public DiceController Controller;

        public void SetSprite(Sprite sprite)
        {
            spriteRenderer.sprite = sprite;
        }
        private void Update()
        {
            Controller?.ChangeSprite();
        }
    }
}