using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
[RequireComponent(typeof(MissionManager))]
public class Managers : MonoBehaviour
{
    
    public static MissionManager Mission { get; private set; }
    public static EnemyManager Enemy { get; private set; }
    private List<IGameManager> _starSequence;
    private float nextActionTime=4.0f;
    public Text score;
    private void Awake()
    {
        
        Mission = GetComponent<MissionManager>();
        Enemy = GetComponent<EnemyManager>();
        _starSequence = new List<IGameManager>();
        _starSequence.Add(Mission);
        _starSequence.Add(Enemy);
        StartCoroutine(StartupManagers());
        StartCoroutine(Ready());
    }
    private void Update()
    {
        if(nextActionTime>2)
        {
            nextActionTime -= 1.0f*Time.deltaTime;
            score.text = Convert.ToString((int)nextActionTime);
            Debug.Log(nextActionTime);
        }       
        StartCoroutine(LevelEnd());
    }

    public IEnumerator Ready()
    {

        yield return new WaitForSeconds(3.0f);
        foreach(var e in Enemy.Enemies)
        {
            e.GetComponent<Unit>().isReady = true;
        }
        foreach(var e in Enemy.Players)
        {
            e.GetComponent<Unit>().isReady = true;
        }
        Destroy(score);

    
    }

    public IEnumerator StartupManagers()
    {
        foreach (IGameManager manager in _starSequence)
        {
            manager.Startup();
        }
        yield return null;
        int numModules = _starSequence.Count;
        int numReady = 0;
        while (numReady < numModules)
        {
            int lastReady = numReady;
            numReady = 0;
            foreach (IGameManager manager in _starSequence)
            {
                if (manager.status == ManagerStatus.Started)
                {
                    numReady++;
                }
                if (numReady > lastReady)
                {
                    Debug.Log("Progress: " + numReady + "/" + numModules);
                }
                yield return null;
            }
            Debug.Log("All manager started up");
        }
        
       
    }

   


    public IEnumerator LevelEnd()
    {
       // if (Managers.Enemy.status== ManagerStatus.Started && Managers.Enemy.Enemies != null)
        
            if (Managers.Enemy.Enemies.Count == 0)
            {
                Managers.Mission.GoToNext();
                yield return new WaitForEndOfFrame();
            }
              
        

    }
   

}
