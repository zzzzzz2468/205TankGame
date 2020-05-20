using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestController : MonoBehaviour
{
    public TankMotor motor;
    public TankData data;

    void Start()
    {
        
    }

    void Update()
    {
        motor.Move(data.moveSpeedForward,data.moveSpeedBack);
        motor.Rotate(data.rotateSpeed);
    }
}