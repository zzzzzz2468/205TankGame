using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    public List<ScoreData> highScores = new List<ScoreData>();
    private const int MAXSCORESIZE = 3;

    [Header("Players")]
    public int numOfPlayers = 1;
    public List<GameObject> players = new List<GameObject>();

    [Header("Lives")]
    public int playerLives = 3;
    public List<int> lives = new List<int>();

    //Sorts the scores
    protected override void Awake()
    {
        base.Awake();
        if(highScores.Count > 1)
            CleanScores();
    }

    void CleanScores()
    {
        highScores.Sort();
        highScores.Reverse();
        highScores = highScores.GetRange(index: 0, count: MAXSCORESIZE);
    }

    public void TotalPlayers(int play)
    {
        numOfPlayers = play;
    }

    public void SeedType(string seed)
    {
        seedType = seed;

        if (seed.Contains("Seeded") && input.text.Length != 0)
            seedNum = int.Parse(input.text);
        else if (seed.Contains("Seeded") && input.text.Length == 0)
            seedNum = 0;
    }

    private void Update()
    {
        if (playerSpawnPoints.Count != 0)
        {
            CheckLives();
            PlayerSpawn();
            CameraSplitter.Instance.SetCameraPositions();
        }
    }

    private void CheckLives()
    {
        if (lives.Count == 0)
            lives.Add(playerLives);

        if (numOfPlayers == 2 && lives.Count == 1)
            lives.Add(playerLives);

        if (lives.Contains(0) && numOfPlayers == 2)
            CameraSplitter.Instance.SetCameraPositions();

        if ((lives.Contains(0) && numOfPlayers == 1) || (lives[0] == 0 && lives[1] == 0 && numOfPlayers == 2))
            GameOver();

    }

    private void GameOver()
    {
        Debug.Log("Game");
    }

    private void PlayerSpawn()
    {
        if(lives[0] != 0)
        {
            PlayerOne.transform.position = PlayerOne.transform.position;
            if (players.Count == 0)
                players.Add(PlayerOne);
            else
                players[0] = PlayerOne;
        }

        if (numOfPlayers == 1)
            return;

        if(lives[1] != 0)
        {
            PlayerTwo.transform.position = PlayerTwo.transform.position;
            if (players.Count == 1)
                players.Add(PlayerTwo);
            else
                players[1] = PlayerTwo;
        }
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

        return enemy;
    }
}