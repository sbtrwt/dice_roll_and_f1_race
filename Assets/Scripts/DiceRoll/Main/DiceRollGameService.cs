using DiceRoll.Dice;
using DiceRoll.Events;
using DiceRoll.Level;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRollGameService : MonoBehaviour
{
    private EventService eventService;
    private PlayerService playerService;
    private DiceService diceService;
    private LevelService levelService;


    //Scriptable Data
    [SerializeField] private DiceSO diceSO;
    [SerializeField] private LevelSO levelSO;
    // Start is called before the first frame update
    private void Start()
    {
        InitializeServices();
        InjectDependencies();
    }

    private void InitializeServices()
    {
        eventService = new EventService();
        playerService = new PlayerService();
        diceService = new DiceService(diceSO);
        levelService = new LevelService(levelSO);
      
    }

    private void InjectDependencies()
    {
        
    }
}
