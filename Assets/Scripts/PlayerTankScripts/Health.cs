using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TankData))]
public class Health : MonoBehaviour
{
    private TankData data;
    private float health;

    private void Start()
    {
        data = gameObject.GetComponent<TankData>();
        health = data.maxHealth;
    }

    private void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }

        if(gameObject.layer == 8)
        {
            Debug.Log("Enemy Health is " + health);
        }
        else
        {
            Debug.Log("Player Health is " + health);
        }

    }

    public void UpdateHealth(float newHealth)
    {
        health -= newHealth;
    }
}
