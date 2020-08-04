using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Required scripts
[RequireComponent(typeof(TankData))]
public class Health : MonoBehaviour, IHealth
{
    //declares variable
    private TankData data;
    private float health;

    public GameObject playerCamera;

    //finds and sets data
    private void Start()
    {
        data = GetComponent<TankData>();
        health = data.maxHealth;
        data.curHealth = data.maxHealth;
    }

    private void Update()
    {
        health = data.curHealth;

        if(health <= 0)
        {
            Death();
        }

        if(gameObject.layer == 8)
            Debug.Log("Enemy Health is " + health);
        else if(gameObject.layer == 9)
            Debug.Log("Player Health is " + health);
    }

    void Death()
    {
        Destroy(this.gameObject);
        GameManager.Instance.lives -= 1;
        data.curHealth = data.maxHealth;
    }

    //allows bullet script to change health
    public void UpdateHealth(float newHealth)
    {
        health -= newHealth;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }
}
