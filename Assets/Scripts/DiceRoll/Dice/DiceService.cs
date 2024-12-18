using DiceRoll.Events;
using DiceRoll.Level;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace DiceRoll.Dice
{
    public class DiceService
    {
        private DiceSO diceSO;
        private DiceController diceController;
        private EventService eventService;
        public DiceService(DiceSO diceSO, Transform parent)
        {
            this.diceSO = diceSO;
            diceController = new DiceController(diceSO.DiceViewPrefab, parent);
        }
        public void Init(EventService eventService)
        {
            this.eventService = eventService;
            diceController.Init(diceSO.DiceFaces);
            SubscribeToEvents();
        }
        public void SubscribeToEvents() { eventService.OnLevelStart.AddListener(OnLevelStart); }
        public void UnsubscribeToEvents() { eventService.OnLevelStart.RemoveListener(OnLevelStart); }
        public void OnLevelStart(LevelType levelType)
        {
            Debug.Log("Dice Roll");
            diceController.StartDiceRoll();
        }
        public DiceFace GetCurrentDiceFace()
        {
            return diceController.GetCurrentDiceFace();
        }
        ~DiceService()
        {
            UnsubscribeToEvents();
        }
    }
}
