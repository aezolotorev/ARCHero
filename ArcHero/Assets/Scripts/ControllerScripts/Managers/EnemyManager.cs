using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status { get; private set; }
    public GameObject PlayerPrefab;
    private List<IGameManager> _starSequence;
    public List<Transform> nodes;
    public int countOffEnemy;
    public List<GameObject> PrefabEnemy;
    public List<Transform> Enemies = new List<Transform>();
    public List<Transform> Players = new List<Transform>();

    public void Startup()
    {
        PreStartGame();
        status = ManagerStatus.Started;
    }
    public void PreStartGame()
    {
        for (int i = 1; i < countOffEnemy; i++)
        {
            var x = Random.RandomRange(nodes[0].position.x, nodes[1].position.x);
            var z = Random.RandomRange(nodes[0].position.z, nodes[1].position.z);

            var numberinlistofenemy = Random.RandomRange(0, PrefabEnemy.Count);
            var y = PrefabEnemy[numberinlistofenemy].transform.position.y;
            GameObject enemy = Instantiate(PrefabEnemy[numberinlistofenemy], new Vector3(x, y, z), Quaternion.identity);
            Enemies.Add(enemy.transform);
        }
       Players.Add(Instantiate(PlayerPrefab, new Vector3(nodes[2].position.x, nodes[2].position.y, nodes[2].position.z), Quaternion.identity).transform);
        
    }  

}
