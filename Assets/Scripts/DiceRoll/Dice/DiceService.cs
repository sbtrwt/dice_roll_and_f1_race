using DiceRoll.Events;
using DiceRoll.Level;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

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
        public void SubscribeToEvents() 
        {
            eventService.OnLevelStart.AddListener(OnLevelStart);
            eventService.OnGameStart.AddListener(OnGamelStart);
        }
        public void UnsubscribeToEvents()
        {
            eventService.OnLevelStart.AddListener(OnLevelStart);
            eventService.OnGameStart.RemoveListener(OnGamelStart);
        }
        public void OnLevelStart(LevelType levelType)
        {
            Debug.Log("Suffle Dice Roll");
            //diceController.ShuffleDice();
        }
        public void OnGamelStart(LevelType levelType)
        {
            Debug.Log("Dice Roll");
            diceController.StartDiceRoll();
        }
        public DiceFace GetCurrentDiceFace()
        {
            return diceController.GetCurrentDiceFace();
        }
        public void SetDiceRollInterval(float interval)
        {
            diceController.SetRollInterval(interval);
        }
        public void SuffleDice()
        {
            diceController.ShuffleDice();
        }
        public void ShowDiceHint(Image[] diceImages)
        {
            int len = diceController.DiceFaceOrder.Length;
            Debug.Log(String.Join(",", diceController.DiceFaceOrder));
            for (int i = 0; i < len; i++)
            {
                diceImages[i].sprite = diceSO.DiceFaces[diceController.DiceFaceOrder[i]].DiceFaceSprite;
            }
        }
        ~DiceService()
        {
            UnsubscribeToEvents();
        }
    }
}
