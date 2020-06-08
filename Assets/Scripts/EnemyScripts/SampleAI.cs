using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleAI : MonoBehaviour
{
    public Transform target;
    public float avoidTime = 2.0f;
    private float exitTime;

    private TankData data;
    private TankMotor motor;
    private Transform tf;

    public enum AvoidStage { NotAvoiding, RotateUntilCanMove, MoveForSeconds}
    public AvoidStage avoidStage;

    void Start()
    {
        data = GetComponent<TankData>();
        motor = GetComponent<TankMotor>();
        tf = GetComponent<Transform>();
    }

    void Update()
    {
        if(!(avoidStage == AvoidStage.NotAvoiding))
        {
            Avoid();
        }
        else
        {
            Chase();
        }
    }

    void Chase()
    {
        if(CanMove(data.moveSpeedForward))
        {
            if (motor.RotateTowards(target.position, data.rotateSpeed))
            {

            }
            else
            {
                motor.Move(data.moveSpeedForward);
            }
        }
        else
        {
            avoidStage = AvoidStage.RotateUntilCanMove;
        }
    }

    void Avoid()
    {
        if(avoidStage == AvoidStage.RotateUntilCanMove)
        {
            motor.Rotate(-data.rotateSpeed);

            if(CanMove(data.moveSpeedForward))
            {
                avoidStage = AvoidStage.MoveForSeconds;
                exitTime = avoidTime;
            }
        }
        else if(avoidStage == AvoidStage.MoveForSeconds)
        {
            if(CanMove(data.moveSpeedForward))
            {
                exitTime -= Time.deltaTime;
                motor.Move(data.moveSpeedForward);

                if(exitTime <= 0)
                {
                    avoidStage = AvoidStage.NotAvoiding;
                }
            }
            else
            {
                avoidStage = AvoidStage.RotateUntilCanMove;
            }
        }
    }

    public bool CanMove(float speed)
    {
        RaycastHit hit;

        if(Physics.Raycast(tf.position, tf.forward, out hit, speed))
        {
            if(!hit.collider.CompareTag("Player"))
            {
                return false;
            }
        }
        return true;
    }
}
