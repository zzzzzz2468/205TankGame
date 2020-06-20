using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    //declares variables
    public static GameManager gamemanager;
    public GameObject player;
    public GameObject bullet;

    private void Awake()
    {
        gamemanager = this;
    }
}
