using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    public float runSpeed;
    public float speedAttack;
    public int damage;
    public int hp;
    public int maxhp;
    public bool isAlive;
    public bool isReady;
    public enum TypeUnit
    {
        None, FlyingEnemy, MovingEnemy, Player,
    }
    public void Hurt(int damagevalue)
    {
        if (hp > 0)
        {
            hp -= damagevalue;
            Debug.Log("Take damage" + damagevalue);
        }
        if (hp < 0)
        {
            hp = 0;
            isAlive = false;
            //Managers.Enemy.Enemies.Remove(gameObject.transform);
            //Destroy(gameObject);
            Debug.Log("Die" + gameObject.name + "Количество врагов " + Managers.Enemy.Enemies.Count);
        }


    }


}

