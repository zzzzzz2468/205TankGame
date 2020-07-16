using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOV : MonoBehaviour
{
    public float fieldOfView = 60.0f;

    //detects if player is in the sight of the AI
    public bool CanSee(GameObject target)
    {
        Transform targetTransform = target.transform;
        Vector3 targetPosition = targetTransform.position;
        Vector3 vectorToTarget = targetPosition - transform.position;

        float angleToTarget = Vector3.Angle(vectorToTarget, transform.forward);

        if (angleToTarget >= fieldOfView)
            return false;

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
        return false;
    }
}