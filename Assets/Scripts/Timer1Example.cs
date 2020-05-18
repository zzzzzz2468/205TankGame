using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer1Example : MonoBehaviour
{
    public float timerDelay = 3.0f;
    private float timeUntilNextEvent = 0.0f;

    public float timerDelay3 = 3.0f;
    private float lastEventTime;

    // Start is called before the first frame update
    void Start()
    {
        lastEventTime = Time.time - timerDelay;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeUntilNextEvent > 0)
        {
            timeUntilNextEvent -= Time.deltaTime;
        }
        else
        {
            Debug.Log("Timer1 has ended");
            timeUntilNextEvent = timerDelay;
        }

        if (Time.time >= lastEventTime + timerDelay3)
        {
            Debug.Log("Timer 3 completed");
            lastEventTime = Time.time;
        }
    }
}
