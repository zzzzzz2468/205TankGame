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
            Death();
    }

    void Death()
    {
        Destroy(this.gameObject);

        if(GameManager.Instance.numOfPlayers == 1)
            GameManager.Instance.lives[0] -= 1;
        else if(GameManager.Instance.numOfPlayers == 2)
        {
            if (GameManager.Instance.players[0] == this.gameObject)
                GameManager.Instance.lives[0] -= 1;
            else if (GameManager.Instance.players[1] == this.gameObject)
                GameManager.Instance.lives[1] -= 1;
        }
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
