using DiceRoll.Events;
using DiceRoll.Level;
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


        private EventService eventService;

        public int Score { get { return score; } }
        public int Target { get { return target; } }
        public int Lives { get { return currentLifeCount; } }
        public PlayerService()
        {

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
                eventService.OnGameOver.InvokeEvent(true);
            }
        }
        private void OnLevelStart(LevelType levelType)
        {
            Reset();
        }
        public void Init(EventService eventService)
        {
            this.eventService = eventService;
            SubscribeToEvents();
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

        private bool IsGameOver()
        {
            return currentLifeCount <= 0 || score >= target;
        }
        public void Reset()
        {
            score = 0;
            starCount = 0;
        }
        public void AddLife(int lifeValue)
        {
            currentLifeCount += lifeValue;
        }
    }
}