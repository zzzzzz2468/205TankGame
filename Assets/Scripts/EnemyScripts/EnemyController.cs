using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TankData))]
public class EnemyController : MonoBehaviour
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
        if(health <= 0)
        {
            Destroy(gameObject);
        }

        Debug.Log(health);
    }

    public void UpdateHealth(float newHealth)
    {
        health -= newHealth;
    }
}
