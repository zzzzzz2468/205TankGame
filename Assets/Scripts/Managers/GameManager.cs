using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    //declares variables
    public static GameManager gamemanager;
    public GameObject playerPref;
    public GameObject shellHolderPref;
    public GameObject cameraPref;

    private GameObject gamePlayer;
    private GameObject gameShellHolder;

    public int numOfEnemies;

    public List<PlayerSpawn> playerSpawnPoints;

    public List<PickupSpawner> pickupSpawners;

    public List<EnemySpawn> enemySpawners;

    public List<GameObject> enemyPrefs = new List<GameObject>();

    //initializes list
    protected override void Awake()
    {
        base.Awake();
        playerSpawnPoints = new List<PlayerSpawn>();
        pickupSpawners = new List<PickupSpawner>();
        enemySpawners = new List<EnemySpawn>();
    }

    private void Update()
    {
        if(!gamePlayer.activeInHierarchy)
            SpawnPlayer();
    }

    //Spawns the player, the camera and the shellholder at random location
    public void SpawnPlayer()
    {
        var spawn = playerSpawnPoints[Random.Range(0, playerSpawnPoints.Count)].transform.position;
        var player = Instantiate(playerPref, spawn, Quaternion.identity);
        var shellHolder = Instantiate(shellHolderPref, Vector3.zero, Quaternion.identity);
        var camera = Instantiate(cameraPref, spawn, Quaternion.identity);
        camera.GetComponent<CameraController>().target = player;
        player.GetComponent<TankData>().ShellHolder = shellHolder;

        gamePlayer = player;
        gameShellHolder = shellHolder;
    }

    public void SpawnEnemy()
    {
        var spawn = enemySpawners[Random.Range(0, enemySpawners.Count)].transform.position;
        var enemyTemp = enemyPrefs[Random.Range(0, enemyPrefs.Count)];

        var enemy = Instantiate(enemyTemp, spawn, Quaternion.identity);
        enemy.GetComponent<EnemyPersonality>().target = gamePlayer.transform;
        enemy.GetComponent<TankData>().ShellHolder = gameShellHolder;
    }
}