using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : Actor
{
    public PlayerInput playerInput;   
    public CharacterController characterController;
    float tempDist;
    [SerializeField]   
    public override void Start()
    {
        base.Start();             
        playerInput = GetComponent<PlayerInput>();
        characterController = GetComponent<CharacterController>();
        targets = Managers.Enemy.Enemies;
    }

    public override void Update()
    {
        if (isReady)
        {
            base.Update();
            Move();
            if (!isAlive) Managers.Mission.Restart();
        }
    }

    public override void Move()
    {
        movement = Vector3.zero;
        movement.x= playerInput.LeftRight * runSpeed;
        movement.z = playerInput.ForwardBackward * runSpeed;
        if(Vector3.Angle(Vector3.forward,movement)>1f||Vector3.Angle(Vector3.forward, movement)==0)
        {
            Vector3 direct = Vector3.RotateTowards(transform.forward, movement, runSpeed, 0.0f);
            transform.rotation = Quaternion.LookRotation(direct);
        }
        movement = Vector3.ClampMagnitude(movement, runSpeed);
        movement *= Time.deltaTime;
        characterController.Move(movement);
        if (movement != Vector3.zero)
        {
            isMoving = true;
        }
        else isMoving = false;
    }  
  
 
}




   


