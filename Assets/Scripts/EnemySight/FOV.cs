using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOV : MonoBehaviour
{
    public float fieldOfView = 60.0f;

    public bool CanSee(GameObject target)
    {
        Transform targetTransform = target.transform;
        Vector3 targetPosition = targetTransform.position;
        Vector3 vectorToTarget = targetPosition - transform.position;

        float angleToTarget = Vector3.Angle(vectorToTarget, transform.forward);

        if ((angleToTarget <= fieldOfView))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, vectorToTarget, out hit, Mathf.Infinity))
            {
                if (hit.collider.gameObject == target)
                {
                    Debug.DrawRay(transform.position, vectorToTarget, Color.green);
                    return true;
                }
                else
                {
                    Debug.DrawRay(transform.position, vectorToTarget, Color.red);
                }
            }
        }
        return false;

    }

    /*
    //sets the radius of how far it can see and the angle that he can see at
    public float viewRadius;
    [Range(0, 360)]
    public float viewAngle;

    //layers his targets and obstacles are on
    public LayerMask targetMask;
    public LayerMask obstacleMask;

    //the targets the enemy can see
    public List<Transform> visibleTargets = new List<Transform>();

    //bool for if the player is being seen
    private bool canSeePlayer = false;

    //starts the search process
    private void Start()
    {
        StartCoroutine("FindTargetsWithDelay", 0.2f);
    }

    private void Update()
    {
        //changes the enemy to be unable to see the player
        if (visibleTargets.Count == 0 && canSeePlayer)
        {
            this.GetComponent<EnemyPersonality>().canSee(false);
        }
    }

    //finds targets
    IEnumerator FindTargetsWithDelay(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            FindVisibleTargets();
        }
    }

    //Finds targets that are in the area that the enemy can see
    void FindVisibleTargets()
    {
        visibleTargets.Clear();

        Collider[] targetsInViewRadius = Physics.OverlapSphere(new Vector3(transform.position.x, transform.position.y), viewRadius, targetMask);
        for (int i = 0; i < targetsInViewRadius.Length; i++)
        {
            Transform target = targetsInViewRadius[i].transform;
            Vector3 dirToTarget = (target.position - transform.position).normalized;
            if (Vector3.Angle(transform.right, dirToTarget) < viewAngle / 2)
            {
                float dstToTarget = Vector3.Distance(transform.position, target.position);
                if (!Physics.Raycast(transform.position, dirToTarget, dstToTarget, obstacleMask))
                {
                    visibleTargets.Add(target);
                    GetComponent<EnemyPersonality>().canSee(true);
                    canSeePlayer = true;
                }
            }
        }
    }

    //detects where the player is inside of the circle
    public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
        {
            angleInDegrees += transform.eulerAngles.z;
        }
        return new Vector3(-Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }*/
}
