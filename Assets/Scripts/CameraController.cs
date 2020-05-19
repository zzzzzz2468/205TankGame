using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //declaring the different variables needed
    public GameObject player;
    private Vector3 offset;

    //sets the position of the camera
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    //moves the camera with the player
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
