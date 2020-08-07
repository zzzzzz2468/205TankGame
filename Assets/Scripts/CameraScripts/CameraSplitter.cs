using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSplitter : Singleton<CameraSplitter>
{
    //list of cameras
    public List<Camera> cameras;

    //sets the camera positions
    public void SetCameraPositions()
    {
        if (cameras.Count == 1)
            cameras[0].rect = new Rect(0, 0, 1, 1);
        else if(cameras.Count == 2)
        {
            cameras[0].rect = new Rect(0, 0, 1, 0.5f);
            cameras[1].rect = new Rect(0, 0.5f, 1, 0.5f);
        }
    }
}