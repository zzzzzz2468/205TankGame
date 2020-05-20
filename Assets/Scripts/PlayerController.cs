using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private TankData data;
    private TankMotor motor;

    void Start()
    {
        data = GetComponent<TankData>();
        motor = GetComponent<TankMotor>();
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            motor.Move(data.moveSpeedForward);
        }
        if (Input.GetKey(KeyCode.D))
        {
            motor.Rotate(data.rotateSpeed);
        }
    }
}