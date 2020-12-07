using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIStartController : MonoBehaviour
{
    
    public CanvasGroup StartPanel;       
    void Start()
    {
        StartPanel.alpha = 1;
        StartPanel.interactable = true;        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
       
   
}
