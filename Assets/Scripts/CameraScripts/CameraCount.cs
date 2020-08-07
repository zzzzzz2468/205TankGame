using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraCount : MonoBehaviour
{
    private Camera playerCamera;

    //Counts the cameras in a list
    private void Awake()
    {
        playerCamera = GetComponent<Camera>();
        CameraSplitter.Instance.cameras.Add(playerCamera);
    }

    //removes the camera if destroyed
    private void OnDestroy()
    {
        CameraSplitter.Instance.cameras.Remove(playerCamera);
    }
}