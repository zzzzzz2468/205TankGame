using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //declares variables
    public GameObject target;
    public float damping = 1;
    public float vertOff = 5;
    public float backOff = 5;

    //sets camera position
    private void Start()
    {
        //offset = target.transform.position - transform.position;
    }

    //changes the camera position as player moves, moves with dampining
    private void LateUpdate()
    {
        float currentAngle = transform.eulerAngles.y;
        float desiredAngle = target.transform.eulerAngles.y;
        float angle = Mathf.LerpAngle(currentAngle, desiredAngle, Time.deltaTime * damping);

        //Quaternion rotation = Quaternion.Euler(0, angle, 0);
        transform.position = target.transform.position - (target.transform.forward * backOff) + (Vector3.up * vertOff);

        transform.LookAt(target.transform);
    }
}
