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
    }

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