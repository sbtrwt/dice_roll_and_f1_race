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

        [Header("Level Selection Panel")]
        [SerializeField] private GameObject levelSelectionPanel;
        [SerializeField] private List<LevelSelectionButton> levelSelectionButtons;


        [Header("Level Start Panel")]
        [SerializeField] private GameObject levelStartPanel;
        [SerializeField] private Button levelStartButton;

        [Header("Level Action Panel")]
        [SerializeField] private GameObject levelActionPanel;
        [SerializeField] private Button AddButton;

        private void Start()
        {
            levelStartButton.onClick.AddListener(OnLevelStart);
        }
        public void Init(EventService eventService)
        {
            this.eventService = eventService;
            InitLevelSelectionButtons();
            SubscribeToEvents();

        }
        public void SubscribeToEvents() { eventService.OnLevelStart.AddListener(OnLevelStart); }
        public void UnsubscribeToEvents() { eventService.OnLevelStart.RemoveListener(OnLevelStart); }
        private void OnLevelStart(LevelType levelType)
        {
            Debug.Log("On level start :" + levelType);
            levelSelectionPanel.SetActive(false); 
            levelStartPanel.SetActive(true);
        }

        private void OnLevelStart()
        {
            levelStartPanel.SetActive(false);
            levelActionPanel.SetActive(true);
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