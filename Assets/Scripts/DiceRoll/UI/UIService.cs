using DiceRoll.Dice;
using DiceRoll.Events;
using DiceRoll.Level;
using DiceRoll.Player;
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
        private PlayerService playerService;

        [Header("Level Selection Panel")]
        [SerializeField] private GameObject levelSelectionPanel;
        [SerializeField] private List<LevelSelectionButton> levelSelectionButtons;


        [Header("Level Start Panel")]
        [SerializeField] private GameObject levelStartPanel;
        [SerializeField] private Button levelStartButton;

        [Header("Level Action Panel")]
        [SerializeField] private GameObject levelActionPanel;
        [SerializeField] private Button addButton;
        [SerializeField] private Text scoreText;
        [SerializeField] private Text targetText;
        [SerializeField] private Text livesText;

        [Header("Game Over Panel")]
        [SerializeField] private GameObject gameOverPanel;
        [SerializeField] private Button menuButton;
        [SerializeField] private Button retryButton;

        private int score;

        private LevelType currentLevelType;
        private void Start()
        {
            levelStartButton.onClick.AddListener(OnGameStart);
            addButton.onClick.AddListener(OnAddClick);
            menuButton.onClick.AddListener(OnLevelMenuButtonClick);
            retryButton.onClick.AddListener(OnGameStart);

        }
        public void Init(EventService eventService, DiceService diceService, PlayerService playerService)
        {
            this.eventService = eventService;
            this.diceService = diceService;
            this.playerService = playerService;

            InitLevelSelectionButtons();
            SubscribeToEvents();

        }
        public void SubscribeToEvents()
        {
            eventService.OnLevelStart.AddListener(OnLevelStart);
            eventService.OnLevelLoaded.AddListener(OnLevelLoaded);
            eventService.OnGameOver.AddListener(OnGameOver);
        }
        public void UnsubscribeToEvents()
        {
            eventService.OnLevelStart.RemoveListener(OnLevelStart);
            eventService.OnLevelLoaded.RemoveListener(OnLevelLoaded);
            eventService.OnGameOver.RemoveListener(OnGameOver);

        }

        private void OnGameOver(bool isGamover)
        {
            if (isGamover)
            {
                levelActionPanel.SetActive(false);
                gameOverPanel.SetActive(true);
            }
        }

        private void OnAddClick()
        {
            Debug.Log("On add click");
            int currentFaceCount = (int)diceService.GetCurrentDiceFace();
            eventService.OnAddAction.InvokeEvent(currentFaceCount);
            //score += (int)diceService.GetCurrentDiceFace();
            //playerService.AddScore(currentFaceCount);
            scoreText.text = $"{playerService.Score}";
            targetText.text = playerService.Target.ToString();
            //playerService.AddLife(-1);
            livesText.text = playerService.Lives.ToString();
        }




        private void OnLevelLoaded(bool isLoaded)
        {
            targetText.text = playerService.Target.ToString();
            livesText.text = playerService.Lives.ToString();
            scoreText.text = playerService.Score.ToString();
        }


        private void OnLevelStart(LevelType levelType)
        {
            Debug.Log("On level start :" + levelType);
            currentLevelType = levelType;
            levelSelectionPanel.SetActive(false);
            levelStartPanel.SetActive(true);
        }

        private void OnGameStart()
        {
            gameOverPanel.SetActive(false);
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
        private void OnLevelMenuButtonClick()
        {
            gameOverPanel.SetActive(false);
            levelSelectionPanel.SetActive(true);
        }
        ~UIService()
        {
            UnsubscribeToEvents();
        }
    }
}