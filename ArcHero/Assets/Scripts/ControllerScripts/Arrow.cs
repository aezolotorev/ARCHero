using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float liveTime;
    [SerializeField]
    private float destroytime;
    public BaseArrowData data;
    [SerializeField]
    private int damagevalue;
    
    void Start()
    {
        speed = data.speed;
        liveTime = data.liveTime;        
        Invoke("RemoveArrow", liveTime);        
    }

    void RemoveArrow()
    {
        Destroy(gameObject);
    }
    void Update()
    {
        transform.Translate(Vector3.forward*speed*Time.deltaTime);
    }
        
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag != "Arrow"&& other.transform.tag != "Gate")
        {
            Debug.Log("Hit" + other.transform.name);
            var hitcol = other.GetComponentInParent<Unit>();
            hitcol.Hurt(damagevalue);
            Debug.Log("take damege" + other.transform.name);
            Destroy(gameObject);
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag != "Arrow")
        {
            Debug.Log("Destroy arrow");
            Destroy(gameObject);
        }    
    }

    public Transform Shoot(int damage, Vector3 arrowSpawn, Quaternion rotation)
    {
        var arrowready = Instantiate(gameObject, arrowSpawn, rotation);        
        arrowready.transform.parent = null;
        damagevalue = damage;
        return arrowready.transform;
        
    }

}
