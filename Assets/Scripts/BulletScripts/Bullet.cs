using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private TankData _tankData;

    private Rigidbody _rigidBody;
    public Rigidbody RigidBody
    {
        get
        {
            if (_rigidBody == null) _rigidBody = GetComponent<Rigidbody>();
            return _rigidBody;
        }
    }

    void Update()
    {
        AddForce();
        //starts to destroy the bullet
        StartCoroutine(Destroy());
    }

    void AddForce()
    {
        RigidBody.AddForce(transform.forward * _tankData.shellForce, ForceMode.Impulse);
    }

    //destroys the bullet after shellLifeSpan
    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(_tankData.shellLifeSpan);
        Destroy(gameObject);
    }

    public void Initilization(TankData data)
    {
        _tankData = data;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyController>().UpdateHealth(_tankData.damageDone);
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
