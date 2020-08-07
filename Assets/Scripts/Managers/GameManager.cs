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
    public TMP_InputField teamName;
    public GameObject UI;

    [Header("Map Seed")]
    public string seedType;
    public int seedNum;

    private GameObject gamePlayer;
    private GameObject gameShellHolder;

    [Header("Enemies")]
    public int numOfEnemies;

    //creates the shellholder if called
    private Transform _shellHolder;
    public Transform ShellHolder
    {
        get => _shellHolder != null ? _shellHolder : _shellHolder = new GameObject("ShellHolder").transform;
    }

    //References
    private GameObject _playerOne;
    private GameObject _playerTwo;

    //creates the players if called
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

    [Header("Score")]
    public List<ScoreData> highScores = new List<ScoreData>();
    public List<ScoreData> currentGame = new List<ScoreData>();
    private const int MAXSCORESIZE = 3;
    public string txtTeamName;

    [Header("Players")]
    public int numOfPlayers = 1;
    public int numOfLiving = 1;
    public int playerDeath = 2;
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

    //cleans the scores up
    void CleanScores()
    {
        highScores.Sort();
        highScores.Reverse();
        highScores = highScores.GetRange(index: 0, count: MAXSCORESIZE);
    }

    //gets total players and sets the variables up, called via button
    public void TotalPlayers(int play)
    {
        numOfPlayers = play;
        numOfLiving = play;
        txtTeamName = teamName.text;
    }

    //decides the seed type and checks if seeded, also called via button
    public void SeedType(string seed)
    {
        seedType = seed;

        if (seed.Contains("Seeded") && input.text.Length != 0)
            seedNum = int.Parse(input.text);
        else if (seed.Contains("Seeded") && input.text.Length == 0)
            seedNum = 0;
    }

    //spawns players and checks lives
    private void Update()
    {
        if (playerSpawnPoints.Count != 0)
        {
            CheckLives();
            PlayerSpawn();
            CameraSplitter.Instance.SetCameraPositions();
        }
    }

    //checks if a player dies or when the game is over
    private void CheckLives()
    {
        if (lives.Count == 0)
            lives.Add(playerLives);

        if (numOfPlayers == 2 && lives.Count == 1)
            lives.Add(playerLives);

        if (lives.Contains(0) && numOfPlayers == 2)
        {
            CameraSplitter.Instance.SetCameraPositions();
            numOfLiving = 1;
        }

        if ((lives.Contains(0) && numOfPlayers == 1) || (lives[0] == 0 && lives[1] == 0 && numOfPlayers == 2))
            GameOver();

    }

    //changes the scene to the gameover scene
    private void GameOver()
    {
        numOfLiving = 0;
        MainMenu.Instance.ChangeScene(2);
    }

    //spawns the players into the scene, also adds them into a list
    private void PlayerSpawn()
    {
        if (lives[0] != 0)
        {
            PlayerOne.transform.position = PlayerOne.transform.position;
            if (players.Count == 0)
            {
                players.Add(PlayerOne);
            }
            else
            {
                players[0] = PlayerOne;
            }
        }

        if (numOfPlayers == 1)
            return;

        if(lives[1] != 0)
        {
            PlayerTwo.transform.position = PlayerTwo.transform.position;
            if (players.Count == 1)
            {
                players.Add(PlayerTwo);
            }
            else
            {
                players[1] = PlayerTwo;
            }
        }
    }

    //what actually spawns the player into the game. Sets the needed variables to their proper value
    //creates a new camera if none, or uses the old camera and changes target if it exists
    //also spawns the user interface, but only does it once per player
    private GameObject SpawnPlayer(InputManager.inputScheme inputScheme)
    {
        int playerSpawn = Random.Range(0, playerSpawnPoints.Count);
        var spawn = playerSpawnPoints[playerSpawn].transform.position;
        playerSpawnPoints.RemoveAt(playerSpawn);

        var player = Instantiate(playerPref, spawn, Quaternion.identity);
        player.GetComponent<InputManager>().input = inputScheme;

        if (CameraSplitter.Instance.cameras.Count != 2)
        {
            var camera = Instantiate(cameraPref, spawn, Quaternion.identity);
            camera.GetComponent<CameraController>().target = player;
            var userInterface = Instantiate(UI, spawn, Quaternion.identity);
            userInterface.GetComponent<Canvas>().worldCamera = camera.GetComponent<Camera>();
            userInterface.GetComponent<Canvas>().planeDistance = 1;
        }
        else
        {
            switch (inputScheme)
            {
                case InputManager.inputScheme.WASD:
                    CameraSplitter.Instance.cameras[0].gameObject.GetComponent<CameraController>().target = player;
                    break;
                case InputManager.inputScheme.arrowKeys:
                    CameraSplitter.Instance.cameras[1].gameObject.GetComponent<CameraController>().target = player;
                    break;
                default:
                    break;
            }
        }

        return player;
    }

    //spawns the enemy into the world
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