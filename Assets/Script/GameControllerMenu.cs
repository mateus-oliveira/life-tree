using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControllerMenu : MonoBehaviour
{
    [SerializeField]
    AudioSource m_AudioSource;
    void Start()
    {
        m_AudioSource.Play();
    }
    public void StartTheGame()
    {
        SceneManager.LoadScene("Introduction");
    }

    public void ExitTheGame()
    {
        Application.Quit();
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
