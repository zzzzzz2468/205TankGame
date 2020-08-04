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

    private Transform _shellHolder;
    public Transform ShellHolder
    {
        get => _shellHolder != null ? _shellHolder : _shellHolder = new GameObject("ShellHolder").transform;
    }

    //References
    private GameObject _playerOne;
    private GameObject _playerTwo;
    private GameObject _playerThree;
    private GameObject _playerFour;

    public GameObject PlayerOne
    {
        get => _playerOne != null ? _playerOne : _playerOne = SpawnPlayer();
    }
    public GameObject PlayerTwo
    {
        get => _playerTwo != null ? _playerTwo : _playerTwo = SpawnPlayer();
    }
    public GameObject PlayerThree
    {
        get => _playerThree != null ? _playerThree : _playerThree = SpawnPlayer();
    }
    public GameObject PlayerFour
    {
        get => _playerFour != null ? _playerFour : _playerFour = SpawnPlayer();
    }

    //Lists for spawning players, enemies and pickups
    public List<PlayerSpawn> playerSpawnPoints = new List<PlayerSpawn>();
    public List<PickupSpawner> pickupSpawners = new List<PickupSpawner>();
    public List<EnemySpawn> enemySpawners = new List<EnemySpawn>();
    public List<GameObject> enemyPrefs = new List<GameObject>();

    //Score
    public List<ScoreData> scores = new List<ScoreData>();
    private const int MAXSCORESIZE = 3;

    //TotalPlayers
    public int totPlayers = 1;

    //Sorts the scores
    protected override void Awake()
    {
        base.Awake();
        if(scores.Count >= 1)
            CleanScores();
    }

    void CleanScores()
    {
        scores.Sort();
        scores.Reverse();
        scores = scores.GetRange(index: 0, count: MAXSCORESIZE);
    }

    private void Start()
    {
        PlayerOne.transform.position = new Vector3(0, 0, 0);
    }

    private void Update()
    {
        EnemySpawn();
    }

    private void EnemySpawn()
    {
        for (int i = 0; i < numOfEnemies; i++)
            SpawnEnemy();
    }

    private GameObject SpawnPlayer()
    {
        int playerSpawn = Random.Range(0, playerSpawnPoints.Count);
        var spawn = playerSpawnPoints[playerSpawn].transform.position;
        playerSpawnPoints.RemoveAt(playerSpawn);

        var player = Instantiate(playerPref, spawn, Quaternion.identity);
        var camera = Instantiate(cameraPref, spawn, Quaternion.identity);

        camera.GetComponent<CameraController>().target = player;

        return player;
    }

    public GameObject SpawnEnemy()
    {
        int enemySpawn = Random.Range(0, playerSpawnPoints.Count);
        var spawn = enemySpawners[enemySpawn].transform.position;
        enemySpawners.RemoveAt(enemySpawn);

        var enemyTemp = enemyPrefs[Random.Range(0, enemyPrefs.Count)];

        var enemy = Instantiate(enemyTemp, spawn, Quaternion.identity);
        enemy.GetComponent<EnemyPersonality>().target = gamePlayer.transform;

        return enemy;
    }
}