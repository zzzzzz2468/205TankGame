using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    //Adds spawnpoints to list
    void Awake()
    {
        GameManager.Instance.enemySpawners.Add(this.gameObject.GetComponent<EnemySpawn>());
    }

    //removes spawnpoints from list
    void OnDestroy()
    {
        GameManager.Instance.enemySpawners.Remove(this.gameObject.GetComponent<EnemySpawn>());
    }
}
