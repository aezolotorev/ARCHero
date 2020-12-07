using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float ForwardBackward { get; private set; }

    public float LeftRight { get; private set; }

    public int Jump { get; private set; }

    public bool Attack{ get; private set; }
      

    public void Update()
    {
        ForwardBackward = Input.GetAxis("Vertical");
        LeftRight = Input.GetAxis("Horizontal");
        Attack = Input.GetMouseButtonDown(0);               
    }
}
