using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void OpenDiceRoll()
    {
        SceneManager.LoadScene(1);
    }
    public void OpenF1Reflex()
    {
        SceneManager.LoadScene(2);
    }
    public void OpenMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
