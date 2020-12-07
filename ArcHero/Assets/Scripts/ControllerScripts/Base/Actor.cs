using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Actor : Unit
{
    protected Vector3 movement;
    public bool isHaveTarget;
    public bool isMoving;
    public Transform target;
    public List<Transform> targets;
    public BaseData data;
    public Arrow arrowprefab;
    public Transform arrowSpawn;
    public float shootTime;
    [SerializeField]
    private float currentTime;

    public virtual void Start()
    {
        isReady = false;
        shootTime = data.shoottime;
        runSpeed = data.runSpeed;
        speedAttack = data.speedAttack;
        damage = data.damage;
        hp = data.maxHeath;
        currentTime = shootTime;
        isAlive = true;

    }
    public virtual void Update()
    {
        SearchTarget(targets);
        RotoateToTarget(target);
        Attack(isHaveTarget);
        currentTime -= Time.deltaTime * speedAttack;
    }

    public abstract void Move();
    public virtual Transform SearchTarget(List<Transform> targets)
    {
        float tempDist = float.MaxValue;
        foreach (var t in targets)
        {
            if (t != null && Vector3.Distance(transform.position, t.position) < tempDist)
            {
                tempDist = Vector3.Distance(transform.position, t.position);
                target = t;

            }

        }
        return target;
    }
    public virtual void RotoateToTarget(Transform target)
    {
        if (!isMoving)
        {
            if (target != null)
            {
                Quaternion direct = Quaternion.LookRotation(target.position - transform.position);
                direct.x = 0; direct.z = 0;
                transform.rotation = direct;
                Debug.DrawLine(transform.position, target.position);
                isHaveTarget = true;

            }
            if (target == null)
            {
                Debug.Log("нет целей");
                isHaveTarget = false;

            }
        }
    }
    public virtual void Attack(bool isHaveTarget)
    {
        if (isHaveTarget && !isMoving)
        {

            if (currentTime <= 0)
            {
                Debug.Log("Стреляем");

                var targetForShoot = target;

                if (targetForShoot != null)
                {
                    arrowprefab.Shoot(damage, arrowSpawn.transform.position, Quaternion.LookRotation(target.position - transform.position));
                }
                if (targetForShoot == null)
                {

                    arrowprefab.Shoot(damage, arrowSpawn.transform.position, Quaternion.identity);

                }
                arrowprefab.name = "Arrow" + this.gameObject.name;


                currentTime = shootTime;
            }
        }

        else return;
    }





}
