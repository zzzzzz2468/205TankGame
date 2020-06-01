using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TankData))]
[RequireComponent(typeof(TankMotor))]
public class EnemyController : MonoBehaviour
{
    public Transform[] waypoints;
    public float closeDistance = 2.0f;
    public int curWaypoint = 0;

    private TankData data;
    private TankMotor motor;
    private Transform tf;

    private void Start()
    {
        data = GetComponent<TankData>();
        motor = GetComponent<TankMotor>();
        tf = GetComponent<Transform>();
    }

    private void Update()
    {
        if(motor.RotateTowards(waypoints[curWaypoint].position, data.rotateSpeed))
        {

        }
        else
        {
            motor.Move(data.moveSpeedForward);
        }

        if(Vector3.SqrMagnitude(waypoints[curWaypoint].position - tf.position) <= (closeDistance * closeDistance))
        {
            if (curWaypoint < waypoints.Length - 1)
                curWaypoint++;
        }
    }
}
