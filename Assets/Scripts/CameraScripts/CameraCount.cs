using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraCount : MonoBehaviour
{
    private Camera playerCamera;

    private void Awake()
    {
        playerCamera = GetComponent<Camera>();
        CameraSplitter.Instance.cameras.Add(playerCamera);
    }

    private void OnDestroy()
    {
        CameraSplitter.Instance.cameras.Remove(playerCamera);
    }
}