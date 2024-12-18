using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace F1Timer.UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private LightView lightView;
        [SerializeField] private Button startButton;
        [SerializeField] private Button screenButton;
        [SerializeField] private GameObject gameOverPanel;
        [SerializeField] private GameObject[] finalStars;
        [SerializeField] private float[] reactionData;
        [SerializeField] private Text reationTimeText;


        private int countWrong;
        private void Start()
        {
            startButton.onClick.AddListener(OnStartButtonClick);
            screenButton.onClick.AddListener(OnScreenButtonClick);
        }

        private void OnStartButtonClick()
        {
            ShowStars(3, false);
            if (lightView.IsLightInProcess())
            {
                Debug.Log("Light in process...too early");
                countWrong++;
                if(countWrong == 2)
                {
                    Debug.Log("Game End");
                    startButton.gameObject.SetActive(false);
                    screenButton.gameObject.SetActive(true);
                    gameOverPanel.SetActive(true);
                    reationTimeText.text = "0.00";
                    lightView.OffStartLight();
                }
            }
            else
            {
                float reactionTime = Time.time - lightView.GetCompleteTime();
                Debug.Log($"reaction time : {reactionTime}");
                reationTimeText.text = reactionTime.ToString("0.000");
                ShowStars(CalculateStars(reactionTime), true);
                screenButton.gameObject.SetActive(true);
                gameOverPanel.SetActive(true);
                lightView.OffStartLight();
            }
        }
        private void OnScreenButtonClick()
        {
            screenButton.gameObject.SetActive(false);
            lightView.OnStartLight();
            countWrong = 0;
            gameOverPanel.SetActive(false);
            startButton.gameObject.SetActive(true);
        }
        private void ShowStars(int count, bool isShow)
        {
            for (int i = 0; i < count; i++)
            {
                finalStars[i].SetActive(isShow);
            }
        }
        private int CalculateStars(float reactionTime)
        {
            if (reactionData[0] >= reactionTime) { return countWrong==0?3:2; }
            else if (reactionData[1] >= reactionTime) { return 2; }
            else if (reactionData[2] >= reactionTime) { return 1; }
            else return 0;

        }
    }
}