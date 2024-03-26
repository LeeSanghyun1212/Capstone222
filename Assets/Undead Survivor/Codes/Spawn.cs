using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public Transform[] spawnPoint;

    float timer_LU, timer_LD, timer_RU, timer_RD;

    void Awake()
    {
        spawnPoint = GetComponentsInChildren<Transform>();
        
        
    }
    // Update is called once per frame
    void Update()
    {
        timer_LU += Time.deltaTime;
        timer_LD += Time.deltaTime;
        timer_RU += Time.deltaTime;
        timer_RD += Time.deltaTime;
        if (timer_LU > 1f)
        {
            SpawnPosition_LU();
            timer_LU = 0;
        }
        else if (timer_LD > 1.4f)
        {
            SpawnPosition_LD();
            timer_LD = 0;
        }
        else if (timer_RU > 1.7f)
        {
            SpawnPosition_RU();
            timer_RU = 0;
        }
        else if (timer_RD > 1.9f)
        {
            SpawnPosition_RD();
            timer_RD = 0;
        }
    }
    void SpawnPosition_RU()
    {
        GameObject enemy = GameManager.Instance.pool.Get(0);
        enemy.transform.position = spawnPoint[1].position;        
    }
    void SpawnPosition_LU()
    {        
        GameObject enemy2 = GameManager.Instance.pool.Get(1);
        enemy2.transform.position = spawnPoint[4].position;       
    }
    void SpawnPosition_LD()
    {
        GameObject enemy3 = GameManager.Instance.pool.Get(2);
        enemy3.transform.position = spawnPoint[3].position;
    }
    void SpawnPosition_RD()
    {
        GameObject enemy4 = GameManager.Instance.pool.Get(3);
        enemy4.transform.position = spawnPoint[2].position;
    }
}
