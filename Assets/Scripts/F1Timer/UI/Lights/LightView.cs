using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace F1Timer.UI
{
    public class LightView : MonoBehaviour
    {
        [SerializeField] private Image image;
        [SerializeField] private LightSO lightSO;
        [SerializeField] private Vector2 smallLightIntervalRange;
        [SerializeField] private Vector2 bigLightIntervalRange;
        [SerializeField] private Sprite defaultSprite;

        private bool IsLightStart = false;
        private float timer = 0f;
        private float changeInterval = 0f;
        private int currentLightIndex = 0;
        private int MaxLightCount = 0;
        private float completeTime ;
        private void Awake()
        {
            IsLightStart = true;
            MaxLightCount = lightSO.Lights.Count;
        }
      

        public void ChangeSprite()
        {
            if (!IsLightStart) return;
            // Increment the timer
            timer += Time.deltaTime;

            // Check if enough time has passed
            if (timer >= changeInterval)
            {
                // Reset the timer
                timer = 0f;
                // Change to the next sprite
                image.sprite = lightSO.Lights[currentLightIndex].image;
               
                if (currentLightIndex + 1 == lightSO.Lights.Count) 
                { 
                    completeTime = Time.time;
                    IsLightStart = false; 
                }
                currentLightIndex = (currentLightIndex + 1) % lightSO.Lights.Count;

                if(currentLightIndex == lightSO.Lights.Count - 1)
                {
                    changeInterval = Random.Range(bigLightIntervalRange.x, bigLightIntervalRange.y);
                }
                else
                {
                    changeInterval = Random.Range(smallLightIntervalRange.x, smallLightIntervalRange.y);
                }
               
            }
        }
        
        public bool IsLightInProcess()
        {
            //Debug.Log($"currentLightIndex :{currentLightIndex} MaxLightCount :{MaxLightCount}");
            return IsLightStart;
        }
        public float GetCompleteTime()
        {
            return completeTime;
        }
        public void OnStartLight() 
        {
            IsLightStart = true;
            image.sprite = defaultSprite;
           
        }
        public void OffStartLight()
        {
            IsLightStart = false;
            image.sprite = defaultSprite;
            currentLightIndex = 0;
            changeInterval = 0f;
        }
        private void Update()
        {
            ChangeSprite();
        }
    }
}