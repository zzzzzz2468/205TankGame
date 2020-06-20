using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //declares variable
    private TankData tankData;
    private Rigidbody _rigidBody;

    public Attack attack;
    public GameObject attacker;

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
        if (collision.gameObject.GetComponent<IAttackable>() != null)
        {
            IAttackable[] attackables = collision.gameObject.GetComponentsInChildren<IAttackable>();

            foreach(IAttackable attackable in attackables)
            {
                Destroy(gameObject);
                attackable.OnAttack(attacker, attack);
            }
        }
    }
}
