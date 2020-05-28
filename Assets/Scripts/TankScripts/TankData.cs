using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankData : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeedForward = 5.0f;
    public float moveSpeedBack = 2.0f;
    public float rotateSpeed = 90.0f;

    [Header("Shells")]
    public float shellForce = 10.0f;
    public float damageDone = 25.0f;
    public float fireRate = 3.0f;
    public float shellLifeSpan = 5.0f;

    [Header("Health")]
    public float maxHealth = 200.0f;

    [Header("Score")]
    public int score = 0;
}