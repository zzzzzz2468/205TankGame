using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    //declares variables
    public static GameManager gamemanager;
    public GameObject player;
    public GameObject bullet;

    public List<PlayerSpawn> playerSpawnPoints;

    protected override void Awake()
    {
        base.Awake();
        playerSpawnPoints = new List<PlayerSpawn>();
    }

    public void SpawnPlayer()
    {

    }
}
