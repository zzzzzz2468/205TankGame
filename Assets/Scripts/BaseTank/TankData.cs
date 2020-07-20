using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankData : MonoBehaviour
{
    //declares and stores variables
    [Header("Movement")]
    public float moveSpeedForward = 5.0f;
    public float moveSpeedBack = 2.0f;
    public float rotateSpeed = 90.0f;

    [Header("Shells")]
    public float shellForce = 10.0f;
    public float damageDone = 25.0f;
    public float fireRate = 3.0f;
    public float shellLifeSpan = 5.0f;
    public int ammo = 5;
    public int maxAmmo = 5;

    [Header("Fuel")]
    public float curFuel = 100.0f;
    public float maxFuel = 100.0f;
    public float fuelLoss = 0.1f;

    [Header("Health")]
    public float maxHealth = 200.0f;
    public float curHealth;

    [Header("Score")]
    public int score = 0;

    [Header("Models")]
    public GameObject Shell;
    public GameObject ShellHolder;
    public GameObject endOfBarrel;

    [Header("Aggressive AI")]
    public float AggCloseDistance = 10.0f;

    private TankData _tankData;

    //Sends data to other scripts
    public void Initilization(TankData data)
    {
        _tankData = data;
    }
}