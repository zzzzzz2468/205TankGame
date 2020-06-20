using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hearing : MonoBehaviour
{
    //varaibles
    public float hearingDistance;
    private Color gizmoColor;

    //if enemy can hear player
    public bool CanHear(GameObject target)
    {
        NoiseMaker targetNoiseMaker = target.GetComponent<NoiseMaker>();

        if(targetNoiseMaker != null)
        {
            Vector3 vectorToTarget = target.transform.position - transform.position;
            if(hearingDistance + targetNoiseMaker.NoiseRadius > vectorToTarget.magnitude)
            {
                gizmoColor = Color.green;
                return true;
            }
        }
        gizmoColor = Color.red;
        return false;
    }

    //draws gizmos
    private void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;
        Gizmos.DrawWireSphere(transform.position, hearingDistance);
    }
}