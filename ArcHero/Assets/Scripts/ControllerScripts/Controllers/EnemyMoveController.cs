using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMoveController : Actor
{
    NavMeshAgent agent;
    [SerializeField]
    float distanceMove;
    [SerializeField]
    private float cooldownMoveTime;
    [SerializeField]
    private float currentcooldownMoveTime;
    [SerializeField]
    private float distanceReady;
    [SerializeField]
    private float distanceGo;
    [SerializeField]
    private Vector3 lastposition;
    

    public override void Start()
    {
        base.Start();
        distanceMove = data.distanceMove;
        cooldownMoveTime = data.cooldownMoveTime;
        currentcooldownMoveTime = cooldownMoveTime;
        lastposition = transform.position;
        agent = GetComponent<NavMeshAgent>();
        agent.speed = runSpeed;
        targets = Managers.Enemy.Players;
    }

    public override void Update()
    {
        if (isReady)
        {
            base.Update();
            currentcooldownMoveTime -= Time.deltaTime;
            Move();
            Debug.DrawLine(transform.position, target.position, Color.red, 2.0f);
            if (!isAlive)
            {
                Managers.Enemy.Enemies.Remove(gameObject.transform);
                Destroy(gameObject);
            }
        }
    }

    void FixedUpdate()
    {
        distanceGo = (transform.position - lastposition).magnitude;
        distanceReady += distanceGo;
        lastposition = transform.position;

    }
    public override void Move()
    {
        {
            if (isMoving)
            {
                if (distanceReady <= distanceMove)
                {
                    transform.LookAt(target);
                    agent.destination = target.position;
                    currentcooldownMoveTime = cooldownMoveTime;
                }
                else
                {
                    isMoving = false;
                    agent.destination = transform.position;
                    currentcooldownMoveTime = cooldownMoveTime;
                }

            }
            if (!isMoving)
            {
                if (currentcooldownMoveTime <= 0)
                {
                    isMoving = true;
                    currentcooldownMoveTime = 0;
                    distanceReady = 0;
                }
            }

        }



    }

}
