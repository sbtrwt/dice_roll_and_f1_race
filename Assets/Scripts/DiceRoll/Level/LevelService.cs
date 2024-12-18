using DiceRoll.Dice;
using DiceRoll.Events;
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

        private EventService eventService;
        private DiceService diceService;
        private TimerService timerService;
        public LevelService(LevelSO levelSO)
        {
            this.levelSO = levelSO;
        }
        public void Init(EventService eventService, DiceService diceService, TimerService timerService) 
        {
            this.eventService = eventService;
            this.diceService = diceService;
            this.timerService = timerService;

            SubscribeToEvents();
        }
        public void SubscribeToEvents() { eventService.OnLevelStart.AddListener(OnLevelStart); }
        public void UnsubscribeToEvents() { eventService.OnLevelStart.RemoveListener(OnLevelStart); }
        public void OnLevelStart(LevelType levelType) 
        {
            this.currentLevel = levelType;
        }

        public void LoadLevel() 
        {
        }

        ~LevelService(){ UnsubscribeToEvents(); }
    }
}
