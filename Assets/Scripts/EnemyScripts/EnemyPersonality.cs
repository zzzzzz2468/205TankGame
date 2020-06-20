using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TankData))]
[RequireComponent(typeof(TankMotor))]
[RequireComponent(typeof(Shoot))]
[RequireComponent(typeof(FOV))]
[RequireComponent(typeof(Hearing))]
public class EnemyPersonality : MonoBehaviour
{
    private TankData data;
    private TankMotor motor;
    private Transform tf;
    private Shoot shoot;
    private FOV fov;
    private Hearing hearing;

    [Header("Target")]
    public Transform target;

    public enum Personality
    {
        ScardyClause,
        Aggresive,
        Ranged,
        Hider,
        Tactician,
        Turret
    }
    public Personality personality;

    public enum EnemyMode
    {
        Flee,
        Chase,
        Idle,
        Patrol,
        Hide,
        Wait,
        Attack,
        Sneak,
        Search,
        Rotate
    }
    public EnemyMode enemyMode;

    //LoopType Enum
    public enum LoopType { Stop, Loop, PingPong };
    public LoopType loopType;

    [Header("Waypoints")]
    public Transform[] waypoints;
    public float closeDistance = 2.0f;
    public int curWaypoint = 0;

    //Other variables
    private bool isPatrolForward = true;

    void Start()
    {
        data = GetComponent<TankData>();
        motor = GetComponent<TankMotor>();
        tf = GetComponent<Transform>();
        shoot = GetComponent<Shoot>();
        fov = GetComponent<FOV>();
        hearing = GetComponent<Hearing>();
    }

    void Update()
    {
        Debug.Log(this + " See = " + fov.CanSee(target.gameObject));
        Debug.Log(this + " Hear = " + hearing.CanHear(target.gameObject));

        EnemyPersonalityStateMachine();
    }

    void EnemyPersonalityStateMachine()
    {
        switch (personality)
        {
            case Personality.ScardyClause:
                ScardyClause();
                break;
            case Personality.Aggresive:
                Aggresive();
                break;
            case Personality.Ranged:
                Ranged();
                break;
            case Personality.Hider:
                Hider();
                break;
            case Personality.Tactician:
                Tactician();
                break;
            case Personality.Turret:
                Turret();
                break;
            default:
                Debug.LogWarning("Not an available personality: EnemyPersonality");
                break;
        }
    }

    void EnemyModeStateMachine()
    {
        switch (enemyMode)
        {
            case EnemyMode.Chase:
                Chasing();
                break;
            case EnemyMode.Flee:
                Fleeing();
                break;
            case EnemyMode.Idle:
                Idle();
                break;
            case EnemyMode.Search:
                Search();
                break;
            case EnemyMode.Patrol:
                Patrol();
                break;
            case EnemyMode.Hide:
                Hide();
                break;
            case EnemyMode.Wait:
                Wait();
                break;
            case EnemyMode.Attack:
                motor.RotateTowards(target.position, data.rotateSpeed);
                shoot.ShootBullet();
                break;
            case EnemyMode.Sneak:
                Sneak();
                break;
            case EnemyMode.Rotate:
                motor.RotateTowards(target.position, data.rotateSpeed);
                break;
            default:
                Debug.LogWarning("Not an available mode: EnemyPersonality");
                break;
        }
    }

    //EnemyPersonalities
    private void ScardyClause()
    {
        //Hides/Shoots and hides
    }

    private void Aggresive()
    {
        //More close range
        float distance = Vector3.Distance(target.transform.position, transform.position);
        Debug.Log(distance);
        if (distance <= data.AggCloseDistance)
            enemyMode = EnemyMode.Attack;
        else if (fov.CanSee(target.gameObject) && hearing.CanHear(target.gameObject) && distance > data.AggCloseDistance)
            enemyMode = EnemyMode.Chase;
        else if (hearing.CanHear(target.gameObject))
            enemyMode = EnemyMode.Rotate;
        else if (!hearing.CanHear(target.gameObject))
            enemyMode = EnemyMode.Patrol;
        EnemyModeStateMachine();
    }

    private void Ranged()
    {
        //attacks from a far
    }

    private void Hider()
    {
        //tries to avoid the player / does not shoot
    }

    private void Tactician()
    {
        //tries to get behind the player
    }

    private void Turret()
    {
        //Stays still and fires
        if (fov.CanSee(target.gameObject) && hearing.CanHear(target.gameObject))
            enemyMode = EnemyMode.Attack;
        else if (hearing.CanHear(target.gameObject))
            enemyMode = EnemyMode.Rotate;
        else if (!hearing.CanHear(target.gameObject))
            enemyMode = EnemyMode.Idle;
        EnemyModeStateMachine();
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
        if (personality == Personality.Turret)
            return;
        enemyMode = EnemyMode.Patrol;
    }

    private void Search()
    {

    }

    private void Hide()
    {

    }

    private void Wait()
    {

    }

    private void Sneak()
    {

    }

    private void Patrol()
    {
        motor.RotateTowards(waypoints[curWaypoint].position, data.rotateSpeed);
        motor.Move(data.moveSpeedForward);

        if (Vector3.SqrMagnitude(waypoints[curWaypoint].position - tf.position) > (closeDistance * closeDistance))
            return;
        LoopTypeStateMachine();
    }

    void LoopTypeStateMachine()
    {
        switch (loopType)
        {
            case LoopType.Stop:
                if (curWaypoint < waypoints.Length - 1)
                    curWaypoint++;
                break;
            case LoopType.PingPong:
                if (isPatrolForward)
                    if (curWaypoint < waypoints.Length - 1)
                        curWaypoint++;
                    else
                    {
                        curWaypoint--;
                        isPatrolForward = curWaypoint <= 0;
                    }
                break;
            case LoopType.Loop:
                curWaypoint += curWaypoint < waypoints.Length - 1 ? 1 : 0;
                break;
            default:
                Debug.LogWarning("Not a loop type: EnemyController");
                break;
        }
    }
}