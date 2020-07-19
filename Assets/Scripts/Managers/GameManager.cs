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

    public int cameraHeight = 7;
    public int cameraDistance = 7;

    public List<PlayerSpawn> playerSpawnPoints;

    protected override void Awake()
    {
        base.Awake();
        playerSpawnPoints = new List<PlayerSpawn>();
    }

    public void SpawnPlayer()
    {
        var spawn = playerSpawnPoints[Random.Range(0, playerSpawnPoints.Count)].transform.position;
        Vector3 cameraSpawn = new Vector3(0, spawn.y + cameraHeight, spawn.z - cameraDistance);

        var player = Instantiate(playerPref, spawn, Quaternion.identity);
        var shellHolder = Instantiate(shellHolderPref, Vector3.zero, Quaternion.identity);
        var camera = Instantiate(cameraPref, cameraSpawn, Quaternion.identity);
        camera.GetComponent<CameraController>().target = player;
        player.GetComponent<TankData>().ShellHolder = shellHolder;
    }
}