using DiceRoll.Events;
using DiceRoll.Level;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DiceRoll.Timer
{
    public class TimerService : MonoBehaviour
    {
        
        public Text timerText;
        //[SerializeField] private float maxTime = 60f;
        [SerializeField] private float timeTaken = 0f;
        [SerializeField] private bool timerIsRunning = false;
        [SerializeField] private bool timerStart = false;
  

        private EventService eventService; 
        public float TimeTaken { get; private set; }
        void Start()
        {
            //timeRemaining = maxTime;
        }
        public void Init(EventService eventService)
        {
            this.eventService = eventService;
            SubscribeToEvents();
        }
        public void SubscribeToEvents() 
        { 
            eventService.OnGameStart.AddListener(OnGameStart);
            eventService.OnGameOver.AddListener(OnGameOver);
        }
        public void UnsubscribeToEvents() 
        { 
            eventService?.OnGameStart.RemoveListener(OnGameStart);
            eventService?.OnGameOver.RemoveListener(OnGameOver);

        }
        private void OnGameStart(LevelType levelType)
        {
            timeTaken = 0;
            timerStart = true;
            EnableTimerCount(true);
            //eventService.OnTimerStart.InvokeEvent();
            //Debug.Log("Game start in timer");
        }
        private void OnGameOver(bool isGameOver)
        {
            timerStart = false;
            EnableTimerCount(false);
            Debug.Log("Timer Stop");
        }
        void Update()
        {
            if (!timerStart)
            {
                return;
            }

            if (timerIsRunning)
            {
                //if (timeTaken > 1)
                //{
                    timeTaken += Time.deltaTime;
                    DisplayTime(timeTaken);
                    TimeTaken = timeTaken;
                //}
                //else
                //{
                //    timeTaken = 0;
                //    timerIsRunning = false;
                //    //eventService.OnTimerStop.InvokeEvent();
                //}
            }
        }

        private void DisplayTime(float timeToDisplay)
        {
            //float minutes = Mathf.FloorToInt(timeToDisplay / 60);
            //float seconds = Mathf.FloorToInt(timeToDisplay % 60);
            //timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            timerText.text = timeToDisplay.ToString("0.00");
            
        }
        public void EnableTimerCount(bool isEnable)
        {
            timerIsRunning = isEnable;
        }

        private void OnTimerPause()
        {
            timerStart = false;
            EnableTimerCount(false);
        }
        private void OnTimerResume()
        {
            timerStart = true;
            EnableTimerCount(true);
        }
       
        private void OnDisable()
        {
            UnsubscribeToEvents();
        }
    }
}