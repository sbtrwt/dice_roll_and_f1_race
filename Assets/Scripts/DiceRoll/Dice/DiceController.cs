using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace DiceRoll.Dice
{
    public class DiceController
    {
        private DiceView diceView;
        private DiceFaceData[] diceFaces;
        private bool isDiceRoll = false;
        private float changeInterval = 0.6f;
        private int currentFaceIndex = 0;
        private float timer = 0f;
        private int[] diceFaceOrder = { 0, 1, 2, 3, 4, 5 };
        public DiceController(DiceView diceViewPrefab, Transform parent)
        {
            this.diceView = UnityEngine.Object.Instantiate(diceViewPrefab, parent);
            this.diceView.Controller = this;

        }
        public void Init(DiceFaceData[] diceFaces)
        {
            this.diceFaces = diceFaces;
        }
        public void SetSprite(Sprite sprite)
        {
            diceView.SetSprite(sprite);
        }
        public void StartDiceRoll() { isDiceRoll = true; }
        public void StopDiceRoll() { isDiceRoll = false; }

        public void SetRollInterval(float interval)
        {
            this.changeInterval = interval;
        }
        public void ChangeSprite()
        {
            if (!isDiceRoll) return;
            // Increment the timer
            timer += Time.deltaTime;

            // Check if enough time has passed
            if (timer >= changeInterval)
            {
                // Reset the timer
                timer = 0f;
                // Change to the next sprite
                SetSprite(diceFaces[diceFaceOrder[currentFaceIndex]].DiceFaceSprite);
                currentFaceIndex = (currentFaceIndex + 1) % diceFaces.Length;

            }
        }
        public DiceFace GetCurrentDiceFace()
        {
            return diceFaces[diceFaceOrder[currentFaceIndex]].DiceFace;
        }
    }
}
