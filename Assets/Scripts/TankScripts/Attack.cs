using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private TankData data;

    private float lastShot = 3.0f;

    private void Start()
    {
        data = gameObject.GetComponent<TankData>();
    }

    void Update()
    {
        lastShot += Time.deltaTime;
        Shoot();
        Debug.Log(lastShot);
    }

    void Shoot()
    {
        if (lastShot >= data.fireRate && Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log("Shot");
            lastShot = 0;
        }
    }
}