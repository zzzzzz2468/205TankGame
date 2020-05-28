using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private TankData data;

    private void Start()
    {
        data = gameObject.GetComponent<TankData>();
    }

    void Update()
    {

    }

    //destroys the bullet after bulletLifeSpan
    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(data.shellLifeSpan);
        Destroy(gameObject);
    }
}
