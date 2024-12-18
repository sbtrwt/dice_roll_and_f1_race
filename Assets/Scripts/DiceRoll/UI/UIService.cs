using DiceRoll.Dice;
using DiceRoll.Events;
using DiceRoll.Level;
using DiceRoll.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DiceRoll.UI
{
    public class UIService : MonoBehaviour
    {
        private EventService eventService;
        private DiceService diceService;

        [Header("Level Selection Panel")]
        [SerializeField] private GameObject levelSelectionPanel;
        [SerializeField] private List<LevelSelectionButton> levelSelectionButtons;


        [Header("Level Start Panel")]
        [SerializeField] private GameObject levelStartPanel;
        [SerializeField] private Button levelStartButton;

        [Header("Level Action Panel")]
        [SerializeField] private GameObject levelActionPanel;
        [SerializeField] private Button AddButton;
        [SerializeField] private Text scoreText;

        private int score;

        private LevelType currentLevelType;
        private void Start()
        {
            levelStartButton.onClick.AddListener(OnGameStart);
            AddButton.onClick.AddListener(OnAddClick);

        }

        private void OnAddClick()
        {
            Debug.Log("On add click");
            score += (int)diceService.GetCurrentDiceFace();
            scoreText.text = $"{score}";
        }

        public void Init(EventService eventService, DiceService diceService)
        {
            this.eventService = eventService;
            this.diceService = diceService;

            InitLevelSelectionButtons();
            SubscribeToEvents();

        }
        public void SubscribeToEvents() { eventService.OnLevelStart.AddListener(OnLevelStart); }
        public void UnsubscribeToEvents() { eventService.OnLevelStart.RemoveListener(OnLevelStart); }
        private void OnLevelStart(LevelType levelType)
        {
            Debug.Log("On level start :" + levelType);
            currentLevelType = levelType;
            levelSelectionPanel.SetActive(false); 
            levelStartPanel.SetActive(true);
        }

        private void OnGameStart()
        {
            levelStartPanel.SetActive(false);
            levelActionPanel.SetActive(true);
            eventService.OnGameStart.InvokeEvent(currentLevelType);
        }
        public void InitLevelSelectionButtons()
        {
            foreach (var levelButton in levelSelectionButtons)
            {
                levelButton.Init(eventService);
            }
        }

        ~UIService()
        {
            UnsubscribeToEvents();
        }
    }
}