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

    public enum LoopType{ Stop, Loop, PingPong };
    public LoopType loopType;

    public enum Personality{ ScardyClause, Aggresive, Ranged, Hider, Tactician}
    public Personality personality;

    private TankData data;
    private TankMotor motor;
    private Transform tf;

    private bool isPatrolForward = true;

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
            switch (loopType)
            {
                case LoopType.Stop:
                    LoopStop();
                    break;
                case LoopType.PingPong:
                    LoopPingPong();
                    break;
                case LoopType.Loop:
                    LoopLoop();
                    break;
                default:
                    Debug.LogWarning("No loop type; EnemyController");
                    break;
            }
        }
    }

    private void LoopStop()
    {
        if (curWaypoint < waypoints.Length - 1)
            curWaypoint++;
    }

    private void LoopPingPong()
    {
        if (isPatrolForward && curWaypoint < waypoints.Length - 1)
            curWaypoint++;
        else if(!isPatrolForward && curWaypoint > 0)
            curWaypoint--;
        else if (!isPatrolForward && curWaypoint <= 0)
        {
            isPatrolForward = false;
            curWaypoint--;
        }
    }

    private void LoopLoop()
    {
        if (curWaypoint < waypoints.Length - 1)
            curWaypoint++;
        else
            curWaypoint = 0;
    }
}
