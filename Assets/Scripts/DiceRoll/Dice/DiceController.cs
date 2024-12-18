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

        public int[] DiceFaceOrder { get { return diceFaceOrder; } }
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
                currentFaceIndex = (currentFaceIndex + 1) % diceFaces.Length;
                SetSprite(diceFaces[diceFaceOrder[currentFaceIndex]].DiceFaceSprite);

            }
        }

        public void ShuffleDice() 
        {
            Shuffle(diceFaceOrder); 
            //set first dice face
            SetSprite(diceFaces[diceFaceOrder[currentFaceIndex]].DiceFaceSprite);
            Debug.Log(String.Join(",", diceFaceOrder));
        }
        public void Shuffle<T>(T[] array)
        {
            System.Random random = new System.Random();
            for (int i = array.Length - 1; i > 0; i--)
            {
                // Generate a random index
                int j = random.Next(0, i + 1);

                // Swap elements at indices i and j
                T temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
        }
        public DiceFace GetCurrentDiceFace()
        {
            return diceFaces[diceFaceOrder[currentFaceIndex]].DiceFace;
        }
    }
}
