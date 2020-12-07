using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIGameController : MonoBehaviour
{
    public CanvasGroup gamePanel;
    public CanvasGroup menuPanel;
    void Start()
    {
        gamePanel.interactable = true;
        gamePanel.alpha = 1;
        menuPanel.interactable = false;
        menuPanel.alpha = 0;
    }

    public void PauseMenu()
    {        
        gamePanel.interactable = false;
        gamePanel.alpha = 0;
        menuPanel.interactable = true;
        menuPanel.alpha = 1;
        Time.timeScale = 0;
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Restart()
    {
        var scNum = SceneManager.sceneCount;
        SceneManager.LoadScene(scNum);
        Time.timeScale = 1;
    }
    public void Back()
    {
        gamePanel.interactable = true;
        gamePanel.alpha = 1;
        menuPanel.interactable = false;
        menuPanel.alpha = 0;
        Time.timeScale = 1;
    }




}
