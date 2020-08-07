using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    //declares variables
    private TankData data;
    private float lastShot = 3.0f;

    //finds scripts
    private void Start()
    {
        data = GetComponent<TankData>();
    }

    //updates time
    void Update()
    {
        lastShot += Time.deltaTime;
    }

    //creates the shell, called from input script
    public void ShootBullet()
    {
        if (lastShot >= data.fireRate && data.ammo > 0)
        {
            AudioSource.PlayClipAtPoint(data.tankShoot, transform.position, 1.0f);

            var shot = Instantiate(data.Shell, data.endOfBarrel.transform.position, transform.rotation, GameManager.Instance.ShellHolder.transform);
            lastShot = 0;

            shot.GetComponent<Bullet>().attacker = gameObject;
            shot.GetComponent<Bullet>().attack = new Attack(data.damageDone);

            shot.GetComponent<Bullet>().Initilization(data);

            data.ammo--;
        }
    }
}
