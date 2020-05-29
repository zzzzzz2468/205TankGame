﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    //declares variables
    private TankData data;
    private float lastShot = 3.0f;

    //finds scripts
    private void Start()
    {
        data = gameObject.GetComponent<TankData>();
    }

    //updates time
    void Update()
    {
        lastShot += Time.deltaTime;
    }

    //creates the shell, called from input script
    public void Shoot()
    {
        if (lastShot >= data.fireRate)
        {
            var shot = Instantiate(data.Shell, data.endOfBarrel.transform.position, transform.rotation, data.ShellHolder.transform);
            lastShot = 0;
            shot.GetComponent<Bullet>().Initilization(data);
        }
    }
}