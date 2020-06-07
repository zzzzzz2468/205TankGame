using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //declares variable
    private TankData tankData;
    private Rigidbody _rigidBody;

    //finds rigidbody
    public Rigidbody RigidBody
    {
        get
        {
            if (_rigidBody == null) _rigidBody = GetComponent<Rigidbody>();
            return _rigidBody;
        }
    }

    //starts to destroy and adds force to the shell on creation
    void Start()
    {
        AddForce();
        StartCoroutine(Destroy());
    }

    //adds force to the shell
    void AddForce()
    {
        RigidBody.AddForce(transform.forward * tankData.shellForce, ForceMode.Impulse);
    }

    //destroys the bullet after shellLifeSpan
    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(tankData.shellLifeSpan);
        Destroy(gameObject);
    }

    //gets data from tankdata
    public void Initilization(TankData data)
    {
        tankData = data;
    }

    //detects if collides with player, enemy or anything else, and does damage if needed then dies
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 8 || collision.gameObject.layer == 9)
        {
            collision.gameObject.GetComponent<Health>().UpdateHealth(tankData.damageDone);
            Destroy(gameObject);
            Debug.Log("Collision");
        }
        else
        {
            Destroy(gameObject);
            Debug.Log("Collision");
        }
    }
}
