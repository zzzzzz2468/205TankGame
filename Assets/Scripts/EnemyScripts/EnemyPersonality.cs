using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TankData))]
[RequireComponent(typeof(TankMotor))]
[RequireComponent(typeof(EnemyMovement))]
public class EnemyPersonality : MonoBehaviour
{
    private TankData data;
    private TankMotor motor;
    private Transform tf;
    private EnemyMovement movement;

    public Transform target;

    public enum Personality { ScardyClause, Aggresive, Ranged, Hider, Tactician }
    public Personality personality;

    public enum EnemyMode { Flee, Chase, Idle, Patrol }
    public EnemyMode enemyMode;

    void Start()
    {
        data = GetComponent<TankData>();
        motor = GetComponent<TankMotor>();
        tf = GetComponent<Transform>();
        movement = GetComponent<EnemyMovement>();
    }

    void Update()
    {
        if (enemyMode == EnemyMode.Chase)
        {
            //Chasing();
        }
        if (enemyMode == EnemyMode.Flee)
        {
            //Fleeing();
        }
    }

    //EnemyPersonalities
    private void ScardyClause()
    {

    }

    private void Aggresive()
    {

    }

    private void Ranged()
    {

    }

    private void Hider()
    {

    }

    private void Tactician()
    {

    }


    //EnemyModes
    private void Chasing()
    {
        motor.RotateTowards(target.position, data.rotateSpeed);
        motor.Move(data.moveSpeedForward);
    }

    private void Fleeing()
    {
        Vector3 vectorToTarget = target.position - tf.position;
        Vector3 vectorAwayTarget = -vectorToTarget;

        vectorAwayTarget.Normalize();
        Vector3 fleePosition = vectorAwayTarget + tf.position;
        motor.RotateTowards(fleePosition, data.rotateSpeed);
        motor.Move(data.moveSpeedForward);
    }

    private void Idle()
    {

    }

    private void Patrol()
    {

    }
}