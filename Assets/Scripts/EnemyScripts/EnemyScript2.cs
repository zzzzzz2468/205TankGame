using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TankData))]
[RequireComponent(typeof(TankMotor))]
public class EnemyScript2 : MonoBehaviour
{
    private TankData data;
    private TankMotor motor;
    private Transform tf;

    public Transform target;
    public enum EnemyMode { Flee, Chase, Idle, Patrol }
    public EnemyMode enemyMode;
    void Start()
    {
        data = GetComponent<TankData>();
        motor = GetComponent<TankMotor>();
        tf = GetComponent<Transform>();
    }

    void Update()
    {
        if(enemyMode == EnemyMode.Chase)
        {
            motor.RotateTowards(target.position, data.rotateSpeed);
            motor.Move(data.moveSpeedForward);
        }
        if(enemyMode == EnemyMode.Flee)
        {
            Vector3 vectorToTarget = target.position - tf.position;
            Vector3 vectorAwayTarget = -vectorToTarget;

            vectorAwayTarget.Normalize();
            Vector3 fleePosition = vectorAwayTarget + tf.position;
            motor.RotateTowards(fleePosition, data.rotateSpeed);
            motor.Move(data.moveSpeedForward);
        }
    }

    private void Chasing()
    {

    }

    private void Fleeing()
    {

    }

    private void Idle()
    {

    }

    private void Patrol()
    {

    }
}
