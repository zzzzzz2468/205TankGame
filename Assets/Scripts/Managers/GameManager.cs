using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : Singleton<GameManager>
{
    [Header("Game Objects")]
    public static GameManager gamemanager;
    public GameObject playerPref;
    public GameObject shellHolderPref;
    public GameObject cameraPref;
    public TMP_InputField input;

    [Header("Map Seed")]
    public string seedType;
    public int seedNum;

    private GameObject gamePlayer;
    private GameObject gameShellHolder;

    [Header("Enemies")]
    public int numOfEnemies;

    private Transform _shellHolder;
    public Transform ShellHolder
    {
        get => _shellHolder != null ? _shellHolder : _shellHolder = new GameObject("ShellHolder").transform;
    }

    //References
    private GameObject _playerOne;
    private GameObject _playerTwo;

    public GameObject PlayerOne
    {
        get => _playerOne != null ? _playerOne : _playerOne = SpawnPlayer(InputManager.inputScheme.WASD);
    }
    public GameObject PlayerTwo
    {
        get => _playerTwo != null ? _playerTwo : _playerTwo = SpawnPlayer(InputManager.inputScheme.arrowKeys);
    }

    [Header("Lists")]
    //Lists for spawning players, enemies and pickups
    public List<PlayerSpawn> playerSpawnPoints = new List<PlayerSpawn>();
    public List<PickupSpawner> pickupSpawners = new List<PickupSpawner>();
    public List<EnemySpawn> enemySpawners = new List<EnemySpawn>();
    public List<GameObject> enemyPrefs = new List<GameObject>();

    //Score
    public List<ScoreData> scores = new List<ScoreData>();
    private const int MAXSCORESIZE = 3;

    [Header("Total Players")]
    public int numOfPlayers = 1;

    [Header("Lives")]
    public int lives = 3;

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

    public void TotalPlayers(int players)
    {
        numOfPlayers = players;
        lives *= numOfPlayers;
    }

    public void SeedType(string seed)
    {
        seedType = seed;

        if(seed.Contains("Seeded"))
            seedNum = int.Parse(input.text);
    }

    private void Update()
    {
        if (lives == 0)
            GameOver();
        Spawning();
    }

    private void GameOver()
    {
        

    }

    private void Spawning()
    {
        if (playerSpawnPoints.Count != 0 && lives > 0)
            PlayerSpawn();
        if (SceneManager.GetActiveScene().name == "Game")
            CameraSplitter.Instance.SetCameraPositions();
    }

    private void PlayerSpawn()
    {
        PlayerOne.transform.position = PlayerOne.transform.position;

        switch (numOfPlayers)
        {
            case 2:
                PlayerTwo.transform.position = PlayerTwo.transform.position;
                break;
            default:
                break;
        }
    }

    private void EnemySpawn()
    {
        for (int i = 0; i < numOfEnemies; i++)
            SpawnEnemy();
    }

    private GameObject SpawnPlayer(InputManager.inputScheme inputScheme)
    {
        int playerSpawn = Random.Range(0, playerSpawnPoints.Count);
        var spawn = playerSpawnPoints[playerSpawn].transform.position;
        playerSpawnPoints.RemoveAt(playerSpawn);

        var player = Instantiate(playerPref, spawn, Quaternion.identity);
        var camera = Instantiate(cameraPref, spawn, Quaternion.identity);

        camera.GetComponent<CameraController>().target = player;
        player.GetComponent<InputManager>().input = inputScheme;

        return player;
    }

    public GameObject SpawnEnemy()
    {
        int enemySpawn = Random.Range(0, enemySpawners.Count);
        var spawn = enemySpawners[enemySpawn].transform.position;
        enemySpawners.RemoveAt(enemySpawn);

        var enemyTemp = enemyPrefs[Random.Range(0, enemyPrefs.Count)];

        var enemy = Instantiate(enemyTemp, spawn, Quaternion.identity);
        enemy.GetComponent<EnemyPersonality>().target = gamePlayer.transform;

        return enemy;
    }
}