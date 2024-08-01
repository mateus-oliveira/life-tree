using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControllerMenu : MonoBehaviour
{
    public void StartTheGame()
    {
        SceneManager.LoadScene("Introduction");
    }

    public void ExitTheGame()
    {
        Application.Quit();
    }
}
