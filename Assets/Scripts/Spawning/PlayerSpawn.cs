using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    void Awake()
    {
        GameManager.Instance.playerSpawnPoints.Add(this.gameObject.GetComponent<PlayerSpawn>());
    }

    void OnDestroy()
    {
        GameManager.Instance.playerSpawnPoints.Remove(this.gameObject.GetComponent<PlayerSpawn>());
    }
}
