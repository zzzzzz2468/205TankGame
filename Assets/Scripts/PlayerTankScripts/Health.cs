using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Required scripts
[RequireComponent(typeof(TankData))]
public class Health : MonoBehaviour
{
    //declares variable
    private TankData data;
    private float health;

    //finds and sets data
    private void Start()
    {
        data = gameObject.GetComponent<TankData>();
        health = data.maxHealth;
    }

    private void Update()
    {
        //destroys if zero health
        if (health <= 0)
        {
            Destroy(gameObject);
        }

        //logs the health remaining
        if(gameObject.layer == 8)
        {
            Debug.Log("Enemy Health is " + health);
        }
        else if(gameObject.layer == 9)
        {
            Debug.Log("Player Health is " + health);
        }

    }

    //allows bullet script to change health
    public void UpdateHealth(float newHealth)
    {
        health -= newHealth;
    }
}
