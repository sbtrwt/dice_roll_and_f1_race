using DiceRoll.Dice;
using DiceRoll.Events;
using DiceRoll.Player;
using DiceRoll.Timer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceRoll.Level
{
   public class LevelService
    {
        private LevelSO levelSO;
        private LevelType currentLevel;
        private LevelData currentLevelData;

        private EventService eventService;
        private DiceService diceService;
        private TimerService timerService;
        private PlayerService playerService;
        public LevelService(LevelSO levelSO)
        {
            this.levelSO = levelSO;
        }
        public void Init(EventService eventService, DiceService diceService, TimerService timerService, PlayerService playerService) 
        {
            this.eventService = eventService;
            this.diceService = diceService;
            this.timerService = timerService;
            this.playerService = playerService;

            SubscribeToEvents();
        }
        public void SubscribeToEvents() { 
            eventService.OnLevelStart.AddListener(OnLevelStart);
            eventService.OnGameStart.AddListener(OnLevelStart);

        }
        public void UnsubscribeToEvents() {
            eventService.OnLevelStart.RemoveListener(OnLevelStart);
            eventService.OnGameStart.RemoveListener(OnLevelStart);
        }
    
    public void OnLevelStart(LevelType levelType) 
        {
            this.currentLevel = levelType;
            SetCurrentLevelData();
            LoadLevel();
        }

        public void LoadLevel() 
        {
            //Load Player service
            LoadPlayer();
            LoadDice();

            eventService.OnLevelLoaded.InvokeEvent(true);
        }
        private void LoadPlayer() 
        {
            playerService.Reset();
            playerService.SetLifeCount(currentLevelData.LifeCount);
            playerService.SetTarget(UnityEngine.Random.Range(currentLevelData.MinTargetScore, currentLevelData.MaxTargetScore));
            playerService.SetScoreTime(currentLevelData.ScoreTime);
        }
        private void LoadDice() 
        {
            diceService.SetDiceRollInterval(currentLevelData.DiceRollInterval);
        }
        private void SetCurrentLevelData()
        {
            currentLevelData = levelSO.Levels.Find(x => x.LevelType == currentLevel);
        }

      
        ~LevelService(){ UnsubscribeToEvents(); }
    }
}
