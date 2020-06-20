using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseMaker : MonoBehaviour
{
    //variables
    private float noiseRadius = 0.0f;
    public float closeEnough;

    //sets noise
    public float NoiseRadius
    {
        get { return noiseRadius; }
        set
        {
            noiseRadius = Mathf.Max(noiseRadius, value);
        }
    }

    //reduces sound over time
    void Update()
    {
        if(noiseRadius > 0)
        {
            noiseRadius *= 0.7f;
            if(noiseRadius <= closeEnough)
            {
                noiseRadius = 0;
            }
        }
    }

    //draws gizmos
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, noiseRadius);
    }
}
