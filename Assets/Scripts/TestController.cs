﻿using System.Collections;
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
        motor.Move(5,2);
        motor.Rotate(90);
    }
}