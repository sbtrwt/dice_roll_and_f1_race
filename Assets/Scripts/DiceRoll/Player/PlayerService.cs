using DiceRoll.Events;
using DiceRoll.Level;
using DiceRoll.Timer;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DiceRoll.Player
{
    public class PlayerService
    {
        private int score;
        private int starCount=0;
        private int target;
        private int lifeCount;
        private int currentLifeCount;
        private int[] scoreTime;

        private EventService eventService;
        private TimerService timerService;

        public int Score { get { return score; } }
        public int Target { get { return target; } }
        public int Lives { get { return currentLifeCount; } }
        public int Stars { get { return starCount; } }
        public PlayerService()
        {

        }
        public void Init(EventService eventService, TimerService timerService)
        {
            this.eventService = eventService;
            this.timerService = timerService;
            SubscribeToEvents();
        }
        public void SubscribeToEvents() { 
            eventService.OnLevelStart.AddListener(OnLevelStart);
            eventService.OnGameStart.AddListener(OnLevelStart);
            eventService.OnAddAction.AddListener(OnAddAction);
        }

        

        public void UnsubscribeToEvents() { 
            eventService.OnLevelStart.RemoveListener(OnLevelStart);
            eventService.OnGameStart.RemoveListener(OnLevelStart);

            eventService.OnAddAction.RemoveListener(OnAddAction);

        }
        private void OnAddAction(int faceCount)
        {
            AddScore(faceCount);
            AddLife(-1);
            if (IsGameOver())
            {
                if (score >= target)
                { CalculateStars(); }
                eventService.OnGameOver.InvokeEvent(true);
            }
        }
        private void OnLevelStart(LevelType levelType)
        {
            Reset();
        }
       
        public void AddScore(int addValue)
        {
            score += addValue;
        }
        public void SetTarget(int target)
        {
            this.target = target;
        }
        public void SetLifeCount(int lifeCount)
        {
            this.lifeCount = lifeCount;
            currentLifeCount = lifeCount;
        }
        public void SetScoreTime(int[] scoreTime)
        {
            this.scoreTime = scoreTime;
        }
        private bool IsGameOver()
        {
            return currentLifeCount <= 0 || score >= target;
        }
        public void Reset()
        {
            score = 0;
            starCount = 0;
        }
        public void CalculateStars() 
        {
            int length = scoreTime.Length;
            int count = 0;
            while (count < length)
            {
                if (timerService.TimeTaken > scoreTime[starCount])
                {
                    count++;
                }
                else
                {
                    break;
                }
            }
            starCount = length - count;
        }
        public void AddLife(int lifeValue)
        {
            currentLifeCount += lifeValue;
        }
    }
}