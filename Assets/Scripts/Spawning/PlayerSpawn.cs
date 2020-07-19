using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    //Adds spawnpoints to list
    void Awake()
    {
        GameManager.Instance.playerSpawnPoints.Add(this.gameObject.GetComponent<PlayerSpawn>());
    }

    //removes spawnpoints from list
    void OnDestroy()
    {
        GameManager.Instance.playerSpawnPoints.Remove(this.gameObject.GetComponent<PlayerSpawn>());
    }
}
