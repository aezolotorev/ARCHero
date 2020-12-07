using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MissionManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status { get; private set; }
    
    public bool levelend;

    public void Startup()
    {
        levelend = false;
       
        status = ManagerStatus.Started;
    }
 
    
    public IEnumerator UpdataLebel()
    {
        levelend = false;
        yield return new WaitForSeconds(2.0f);
        
    }


    public void GoToNext()
    {
        if (levelend == true)
        {
            Debug.Log("Уровень Закончен");           
            StartCoroutine(UpdataLebel());
            Restart();
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

   
}
