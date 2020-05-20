using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer1Example : MonoBehaviour
{
    public float shotDelay = 3.0f;
    private float lastShot;

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= lastShot + shotDelay)
        {
            Debug.Log("Timer 3 completed");
            lastShot = Time.time;
        }
    }
}
