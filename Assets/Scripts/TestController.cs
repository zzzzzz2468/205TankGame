using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestController : MonoBehaviour
{
    public TankMotor motor;

    void Start()
    {
        
    }

    void Update()
    {
        motor.Move(5);
        motor.Rotate(90);
    }
}
