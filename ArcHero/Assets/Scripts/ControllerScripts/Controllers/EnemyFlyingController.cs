using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlyingController : Actor
{
    [SerializeField]
    float distanceMove;
    [SerializeField]
    private float cooldownMoveTime;
    [SerializeField]
    private float currentcooldownMoveTime;
    [SerializeField]
    Transform dest;
    [SerializeField]
    private float distanceReady;
    [SerializeField]
    private float distanceGo;
    [SerializeField]
    private Vector3 lastposition;
    Vector3 dist;

    public override void Start()
    {
        base.Start();
        distanceMove = data.distanceMove;
        cooldownMoveTime = data.cooldownMoveTime;
        currentcooldownMoveTime = cooldownMoveTime;
        lastposition = transform.position;
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
                    dist = target.position;
                    dist.y = transform.position.y;
                    transform.LookAt(dist);
                    transform.position = Vector3.MoveTowards(transform.position, dist, runSpeed * Time.deltaTime);
                    Debug.DrawRay(transform.position, dist, Color.blue, 5.0f);
                    currentcooldownMoveTime = cooldownMoveTime;
                }
                else
                {                    
                    isMoving = false;
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
